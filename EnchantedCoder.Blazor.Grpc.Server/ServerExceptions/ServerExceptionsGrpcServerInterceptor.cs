﻿using System.Security;
using EnchantedCoder.AspNetCore.ExceptionMonitoring.Services;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Configuration;

namespace EnchantedCoder.Blazor.Grpc.Server.ServerExceptions;

// DI SINGLETON !!
public class ServerExceptionsGrpcServerInterceptor : ServerExceptionsInterceptorBase
{
	private readonly ILogger<ServerExceptionsGrpcServerInterceptor> logger;
	private readonly IExceptionMonitoringService exceptionMonitoringService;

	public ServerExceptionsGrpcServerInterceptor(ILogger<ServerExceptionsGrpcServerInterceptor> logger, IExceptionMonitoringService exceptionMonitoringService)
	{
		this.logger = logger;
		this.exceptionMonitoringService = exceptionMonitoringService;
	}

	protected override bool OnException(Exception exception, out Status status)
	{
		if (exception is RpcException)
		{
			status = default;
			return false;
		}

		if (exception is OperationFailedException)
		{
			// see ServerExceptionsGrpcClientInterceptor - gets propagated to EcMessenger + client-side OperationFailedException
			status = new Status(StatusCode.FailedPrecondition, exception.Message);

			logger.LogInformation(exception, exception.Message); // e.g. for ApplicationInsights (where Warning and higher levels get tracked by default)
		}
		else if (exception.GetType().Name == "ObjectNotFoundException") // e.g. EnchantedCoder.Data.Patterns.Exceptions.ObjectNotFoundException
		{
			status = new Status(StatusCode.NotFound, exception.Message);
			logger.LogInformation(exception, exception.Message);
		}
		else if ((exception is OperationCanceledException)
			|| ((exception.GetType().Name == "SqlException") && exception.Message.Contains("Operation cancelled by user."))) // e.g. System.Data.SqlClient.SqlException
		{
			status = new Status(StatusCode.Cancelled, exception.Message);
			logger.LogInformation(exception, exception.Message);
		}
		else
		{
			status = new Status(exception switch
			{
				NotImplementedException => StatusCode.Unimplemented,
				SecurityException => StatusCode.PermissionDenied,
				ArgumentOutOfRangeException => StatusCode.OutOfRange,
				ArgumentException or ArgumentNullException => StatusCode.InvalidArgument,
				TimeoutException => StatusCode.DeadlineExceeded,
				_ => StatusCode.Unknown,
			}, exception.ToString());

			logger.LogError(exception, exception.Message); // passes exception to ApplicationInsights tracking (by default, only Warning and higher levels get tracked)
			exceptionMonitoringService.HandleException(exception); // passes exception to SmtpExceptionMonitoring (errors@EnchantedCoder.cz)
		}
		return true;
	}
}
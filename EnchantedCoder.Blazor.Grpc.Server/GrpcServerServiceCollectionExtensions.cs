using System.Reflection;
using Grpc.AspNetCore.Server;
using EnchantedCoder.Blazor.Grpc.Core;
using EnchantedCoder.Blazor.Grpc.Server.GlobalizationLocalization;
using EnchantedCoder.Blazor.Grpc.Server.ServerExceptions;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc.Server;
using ProtoBuf.Meta;

namespace EnchantedCoder.Blazor.Grpc.Server;

public static class GrpcServerServiceCollectionExtensions
{
	public static void AddGrpcServerInfrastructure(
		this IServiceCollection services,
		Assembly assemblyToScanForDataContracts,
		Action<GrpcServiceOptions> configureOptions = null)
	{
		services.AddSingleton<GlobalizationLocalizationGrpcServerInterceptor>();
		services.AddSingleton<ServerExceptionsGrpcServerInterceptor>();
		services.AddSingleton(BinderConfiguration.Create(marshallerFactories: new[] { ProtoBufMarshallerFactory.Create(RuntimeTypeModel.Create().RegisterApplicationContracts(assemblyToScanForDataContracts)) }, binder: new ServiceBinderWithServiceResolutionFromServiceCollection(services)));

		services.AddCodeFirstGrpc(options =>
		{
			options.Interceptors.Add<GlobalizationLocalizationGrpcServerInterceptor>();
			options.Interceptors.Add<ServerExceptionsGrpcServerInterceptor>();
			options.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;

			configureOptions?.Invoke(options);
		});
	}
}

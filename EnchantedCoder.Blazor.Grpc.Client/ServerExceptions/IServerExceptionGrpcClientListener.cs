using Grpc.Core;

namespace EnchantedCoder.Blazor.Grpc.Client.ServerExceptions;

public interface IServerExceptionGrpcClientListener
{
	Task ProcessExceptionAsync(RpcException e);
}
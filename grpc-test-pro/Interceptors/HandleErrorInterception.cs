using grpc.test.pro.Exceptions;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace grpc.test.pro.Interceptors
{
    public class HandleErrorInterception:Interceptor
    {
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            try
            {
                return base.AsyncUnaryCall(request, context, continuation);
            }catch (NotFoundException ex)
            {
                throw new RpcException(status: new Status(StatusCode.NotFound,ex.Message.ToString()));
            }catch (Exception ex)
            {
                throw new RpcException(status: new Status(StatusCode.Internal, ex.Message.ToString()));
            }
        }
    }
}

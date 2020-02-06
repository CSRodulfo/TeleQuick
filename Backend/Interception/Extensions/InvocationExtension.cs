using Castle.DynamicProxy;
using Interception.MethodInterception;

namespace Interception.Extensions
{
    public static class InvocationExtension
    {
        public static IInvocation Intercept(this IInvocation invocation, IInterceptor interceptor)
        {
            return new InterceptedInvocation(invocation, interceptor);
        }
    }
}

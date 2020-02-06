using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Interception.MethodInterception;

namespace Interception.Extensions
{
    public static class RegistrationExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> EnableInterfaceMethodInterceptors<TLimit, TActivatorData, TSingleRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration)
        {
            return registration
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(typeof(MethodInterceptorCaller));
        }
    }
}

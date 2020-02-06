using Castle.DynamicProxy;
using Interception.Extensions;
using System;
using System.Linq;

namespace Interception.MethodInterception
{
    public class MethodInterceptorCaller : IInterceptor
    {
        public MethodInterceptorCaller(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        private IServiceProvider ServiceProvider { get; }
        public void Intercept(IInvocation invocation)
        {
            var attributes = invocation.Method.CustomAttributes.Where(x => x.AttributeType.GetInterfaces().Contains(typeof(IInterceptor)));

            foreach (var attribute in attributes.Reverse())
            {
                var interceptor = this.ServiceProvider.GetService(attribute.AttributeType) as IInterceptor;
                invocation = invocation.Intercept(interceptor);
            }

            invocation.Proceed();
        }
    }
}

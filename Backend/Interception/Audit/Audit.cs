using Castle.DynamicProxy;
using System;

namespace Interception.Audit
{
    public class Audit : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before Intercepted");
            invocation.Proceed();
            Console.WriteLine("After Intercepted");
        }
    }
}

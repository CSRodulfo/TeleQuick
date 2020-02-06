using Castle.DynamicProxy;
using System;

namespace Interception.Logging
{
    public class Logging : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before Intercepted");
            invocation.Proceed();
            Console.WriteLine("After Intercepted");
        }
    }
}

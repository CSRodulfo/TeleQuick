using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace Interception.MethodInterception
{
    public class InterceptedInvocation : IInvocation
    {
        public InterceptedInvocation(IInvocation invocation, IInterceptor interceptor)
        {
            this.Invocation = invocation;
            this.Interceptor = interceptor;
        }

        private IInvocation Invocation { get; }

        private IInterceptor Interceptor { get; }
        public object[] Arguments => this.Invocation.Arguments;

        public Type[] GenericArguments => this.Invocation.GenericArguments;

        public object InvocationTarget => this.Invocation.InvocationTarget;

        public MethodInfo Method => this.Invocation.Method;

        public MethodInfo MethodInvocationTarget => this.Invocation.MethodInvocationTarget;

        public object Proxy => this.Invocation.Proxy;

        public object ReturnValue
        {
            get => this.Invocation.ReturnValue;
            set => this.Invocation.ReturnValue = value;
        }

        public Type TargetType => this.Invocation.TargetType;

        public object GetArgumentValue(int index) => this.Invocation.GetArgumentValue(index);

        public MethodInfo GetConcreteMethod() => this.Invocation.GetConcreteMethod();

        public MethodInfo GetConcreteMethodInvocationTarget() => this.Invocation.GetConcreteMethodInvocationTarget();

        public void Proceed() => this.Interceptor.Intercept(this.Invocation);

        public void SetArgumentValue(int index, object value) => this.Invocation.SetArgumentValue(index, value);

        public IInvocationProceedInfo CaptureProceedInfo()
        {
            throw new NotImplementedException();
        }
    }
}

using Castle.DynamicProxy;
using Interception.MethodInterception;
using IServices.BranchOffices;
using System;
using System.Linq;
using System.Reflection;

namespace Bootstrapper.Modules
{
    using Autofac;
    public class InterceptorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            this.RegisterInterceptors(builder);
        }

        private void RegisterInterceptors(ContainerBuilder builder)
        {
            builder
                .RegisterType<MethodInterceptorCaller>()
                .InstancePerLifetimeScope();

            var interceptorTypes = this.GetCustomInterceptorTypes();

            builder
                .RegisterTypes(interceptorTypes)
                .InstancePerLifetimeScope();
        }

        private Type[] GetCustomInterceptorTypes()
        {
            return
                typeof(IBranchOfficeService)
                .Assembly
                .GetReferencedAssemblies()
                .SelectMany(s => Assembly.Load(s).GetTypes())
                .Where(p => typeof(IInterceptor).IsAssignableFrom(p) && typeof(Attribute).IsAssignableFrom(p) && !p.IsAbstract)
                .ToArray();
        }
    }
}

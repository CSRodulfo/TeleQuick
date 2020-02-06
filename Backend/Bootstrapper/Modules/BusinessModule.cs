using Autofac;
using Business.BranchOffices;
using Business.MedicalInsurances;
using System.Reflection;

namespace Bootstrapper.Modules
{
    internal class BusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new Assembly[]
            {
                typeof(BranchOffice).Assembly,
                typeof(MedicalInsurance).Assembly,
            };

            builder
                .RegisterAssemblyTypes(assemblies)
                .InstancePerLifetimeScope();
        }
    }
}
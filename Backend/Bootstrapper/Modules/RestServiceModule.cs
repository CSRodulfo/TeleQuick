using Autofac;
using Business.IRestServices;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using DataAccess.RestServices;

namespace Bootstrapper.Modules
{
    internal class RestServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomHttpClient>();
            builder.RegisterType<HttpRequestBuilder>();

            builder
                .RegisterType<BranchOfficeRestService>()
                .As<IBranchOfficeRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<MedicalInsuranceRestService>()
                .As<IMedicalInsuranceRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<MedicineRestService>()
                .As<IMedicineRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ImageRestService>()
                .As<IImageRestService>()
                .InstancePerLifetimeScope();

            builder
               .RegisterType<StockUnifiedRestService>()
               .As<IStockUnifiedRestService>()
               .InstancePerLifetimeScope();

            builder
                .RegisterType<ServiceRestService>()
                .As<IServiceRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ReservationRestService>()
                .As<IReservationRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<OfferRestService>()
                .As<IOfferRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserRestService>()
                .As<IUserRestService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ParametersRestService>()
                .As<IParametersRestService>()
                .InstancePerLifetimeScope();
        }
    }
}
using Autofac;
using Interception.Extensions;
using IServices.BranchOffices;
using IServices.MedicalInsurances;
using IServices.Medicines;
using IServices.Offers;
using IServices.Parameters;
using IServices.StockUnifieds;
using IServices.User;
using Services.BranchOffices;
using Services.Images;
using Services.MedicalInsurances;
using Services.Medicines;
using Services.Offers;
using Services.Parameters;
using Services.StockUnifieds;
using Services.User;

namespace Bootstrapper.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BranchOfficeService>()
                .As<IBranchOfficeService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<MedicalInsuranceService>()
                .As<IMedicalInsuranceService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<MedicineService>()
                .As<IMedicineService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<ImageService>()
                .As<IImageService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<StockUnifiedService>()
                .As<IStockUnifiedService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<ServiceService>()
                .As<IServiceService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<ReservationService>()
                .As<IReservationService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<OfferService>()
                .As<IOfferService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();

            builder.RegisterType<ParametersService>()
                .As<IParametersService>()
                .InstancePerLifetimeScope()
                .EnableInterfaceMethodInterceptors();
        }
    }
}

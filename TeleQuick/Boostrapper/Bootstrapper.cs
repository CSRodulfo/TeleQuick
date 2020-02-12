using DataAcces.Core;
using DataAccess;
using IDataAccess;
using IDataAccess.Core;
using IService.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Business;

namespace Boostrapper
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }
        public IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Business Services
            //services.AddScoped<IEmailSender, EmailSender>();

            // Repositories
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IVehicleService, VehicleService>();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            return services;
        }
    }
}

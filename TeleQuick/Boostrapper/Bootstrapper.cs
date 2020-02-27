using DataAcces.Business;
using DataAcces.Core;
using DataAccess;
using IDataAccess;
using IDataAccess.Business;
using IDataAccess.Core;
using IDataAccess.Repositories;
using IService.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Business;
using TeleQuick.Core.Autopista;
using TeleQuick.Core.IAutopista;

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
            services.AddTransient<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IAccountSessionService, AccountSessionService>();
            services.AddScoped<IConnectionAU, ConnectionAU>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IAccountSessionRepository, AccountSessionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            
            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            return services;
        }
    }
}

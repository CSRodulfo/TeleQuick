using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.TeleQuick.Business;
using System.Collections.ObjectModel;
using TeleQuick.Core.Autopista;
using TeleQuick.Core.IAutopista;
using TeleQuick.DataAcces;
using TeleQuick.DataAcces.Business;
using TeleQuick.DataAcces.Core;
using TeleQuick.IDataAccess;
using TeleQuick.IDataAccess.Business;
using TeleQuick.IDataAccess.Core;
using TeleQuick.IService;
using TeleQuick.Service;

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
            // TeleQuick.Business Services
            //services.AddScoped<IEmailSender, EmailSender>();

            // Repositories
            services.AddTransient<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IAccountManagerService, AccountManagerService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IAccountSessionService, AccountSessionService>();
            services.AddScoped<IConnectionAU, ConnectionAU>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IAccountSessionRepository, AccountSessionRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ObservableCollection<string>>();


            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            return services;
        }
    }
}

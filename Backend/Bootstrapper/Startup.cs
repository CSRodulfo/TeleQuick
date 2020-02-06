using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bootstrapper.Modules;
using Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using System;

namespace Bootstrapper
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
            services.AddOptions();
            services.Configure<Common.Configuration.ConfigurationRoot>(c => c.Startup(this.configuration));
            services.AddScoped<ConfigurationManager>();

            return services;
        }

        public ContainerBuilder ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<BusinessModule>();
            containerBuilder.RegisterModule<InterceptorModule>();
            containerBuilder.RegisterModule<RestServiceModule>();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<SecurityModule>();

            return containerBuilder;
        }

        public IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            this.ConfigureServices(services);
            var containerBuilder = new ContainerBuilder();
            this.ConfigureContainer(containerBuilder);
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        public void ConfigureSerilog()
        {
            var outputFormat = string.IsNullOrWhiteSpace(this.configuration["LogConfiguration:outputFormat"])
                ? "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                : this.configuration["LogConfiguration:outputFormat"];

            var logsFileName = string.IsNullOrWhiteSpace(this.configuration["LogConfiguration:fileName"])
                ? "logfile.log"
                : this.configuration["LogConfiguration:fileName"];

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .WriteTo.File(logsFileName, rollingInterval: RollingInterval.Day, outputTemplate: outputFormat)
                .CreateLogger();
        }
    }
}
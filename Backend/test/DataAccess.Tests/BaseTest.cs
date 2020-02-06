using Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataAccess.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
            // Configuration = CreateConfiguration();
            // ServiceProvider = CreateServiceProvider();
            // DataInitializer.Initialize(ServiceProvider);
        }

        protected IServiceProvider ServiceProvider { get; }
        private IConfigurationRoot Configuration { get; }

        private IConfigurationRoot CreateConfiguration()
        {
            var configurationFactory = new ConfigurationFactory();

            return configurationFactory.Create();
        }

        private IServiceProvider CreateServiceProvider()
        {
            var boostrapperStartup = new Bootstrapper.Startup(this.Configuration);

            return boostrapperStartup.CreateServiceProvider(new ServiceCollection());
        }
    }
}

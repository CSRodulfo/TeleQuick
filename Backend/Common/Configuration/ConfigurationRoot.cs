using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public class ConfigurationRoot
    {
        public IConfiguration Configuration { get; private set; }

        public AppConfiguration AppConfiguration { get; private set; }

        public void Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.AppConfiguration = new AppConfiguration(configuration.GetSection("AppConfiguration"));
        }
    }
}

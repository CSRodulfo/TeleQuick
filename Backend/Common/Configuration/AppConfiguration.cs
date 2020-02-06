using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public class AppConfiguration
    {
        private readonly IConfigurationSection configuration;

        public AppConfiguration(IConfigurationSection appConfigurationSection)
        {
            this.configuration = appConfigurationSection;
        }

        public AppConfiguration(IConfiguration globalConfiguration)
        {
            this.configuration = globalConfiguration.GetSection(this.GetType().Name);
        }

        public string Enviroment => this.configuration["Enviroment"];

        public string MicroServicesApiUrl => this.configuration["MicroServicesApiUrl"];

        public string StockUnificadoApiUrl => this.configuration["StockUnificadoApiUrl"];
    }
}

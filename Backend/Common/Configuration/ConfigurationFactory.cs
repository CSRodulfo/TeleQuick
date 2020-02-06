using System.IO;
using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public class ConfigurationFactory
    {
        public IConfigurationRoot Create()
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .Build();

            return configuration;
        }
    }
}

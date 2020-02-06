using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Common.Configuration
{
    public class ConfigurationManager
    {
        private readonly IOptions<ConfigurationRoot> options;

        public ConfigurationManager(
            IOptions<ConfigurationRoot> options)
        {
            this.options = options;
        }

        public IConfiguration Configuration => this.options.Value.Configuration;

        public AppConfiguration AppConfiguration => this.options.Value.AppConfiguration;
    }
}

using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public class AppOptions
    {
        public string MicroServicesApiUrl { get; set; }
        public string StockUnificadoApiUrl { get; set; }
        public string ReservasApiUrl { get; set; }
        public string FcdmApi { get; set; }
    }
}

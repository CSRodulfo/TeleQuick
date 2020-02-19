using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.AutopistaAUSA;
using TeleQuick.AutopistaAUSOL;
using TeleQuick.Core.Autopista.Model;
using TeleQuick.IAutopista;

namespace TeleQuick.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        IConnectionAU _connection; 
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConnectionAU connection)
        {
            _logger = logger;
            _connection = connection;
        }

        [HttpGet("GetAUSA")]
        public async Task<List<HeaderResponse>> Get()
        {
            var AUSALogin = await _connection.LoginWebPage(new AutopistaAUSA.Login());

            IScrapy scrapy = new ScrapySixon(_connection, AUSALogin);

            return await scrapy.Process();
        }

        [HttpGet("GetAUSOL")]
        public async Task<List<HeaderResponse>> GetAUSOL()
        {
            var AUSOLLogin = await _connection.LoginWebPage(new AutopistaAUSOL.Login());

            IScrapy scrapy = new ScrapyB(_connection, AUSOLLogin);

            return await scrapy.Process(); 
        }
    }
}

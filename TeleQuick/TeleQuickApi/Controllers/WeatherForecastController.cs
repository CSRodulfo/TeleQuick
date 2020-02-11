using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.AutopistaAUSA;
using TeleQuick.Core.AutopistaModel;
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

        IConnection _connection; 
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        [HttpGet("GetAUSA")]
        public async Task<List<HeaderResponse>> Get()
        {

            var b = await _connection.LoginWebPage(new AutopistaAUSA.Login());
            //_connection.

            //var data = AUSA.Process();

            return null;
        }

        [HttpGet("GetAUSOL")]
        public async Task<List<HeaderResponse>> GetAUSOL()
        {
            var a = await _connection.LoginWebPage(new AutopistaAUSOL.Login());

            Scrapy scrapy = new Scrapy(_connection, a);

            return  null;
        }
    }
}

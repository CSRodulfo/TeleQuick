using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Autopista;

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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAUSA")]
        public async Task<List<HeaderResponse>> Get()
        {
            IAutopista.IHighwayProcessable AUSA = new AutopistaAUSA.Login();
            await AUSA.ConnectLogin();

            var data = AUSA.Process();

            return await data;
        }

        [HttpGet("GetAUSOL")]
        public async Task<List<HeaderResponse>> GetAUSOL()
        {
            IAutopista.IHighwayProcessable AUSOL = new AutopistaAUSOL.Login();
            await AUSOL.ConnectLogin();

            var data = AUSOL.Process();

            return await data;
        }
    }
}

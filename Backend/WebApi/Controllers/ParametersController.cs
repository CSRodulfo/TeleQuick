using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : Controller
    {

        private readonly IParametersService parametersService;

        public ParametersController(IParametersService parametersService)
        {
            this.parametersService = parametersService;
        }

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var data = await this.parametersService.GetProvinces();
            return this.Ok(data);
        }

        [HttpGet("OptIns")]
        public async Task<IActionResult> GetOptIns()
        {
            var data = await this.parametersService.GetOptines();
            return this.Ok(data);
        }
    }
}
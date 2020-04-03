using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Charts;
using TeleQuick.IService;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger _logger;

        public HomeController(IMapper mapper, IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
            _logger = logger;
        }


        // GET: api/values
        [HttpGet("ChartDataConcessionary")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<ChartConcessionaries>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ChartDataConcessionary()
        {
            IEnumerable<ChartConcessionaries> invoices = await _invoiceService.GetChartDataByConcessionary();
            return Ok(invoices);
        }

        [HttpGet("ChartDataVehicle")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<ChartVehicle>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ChartDataVehicle()
        {
            IEnumerable<ChartVehicle> invoices = await _invoiceService.GetChartDataByVehicle();
            return Ok(invoices);
        }

        [HttpGet("ChartDataYear")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<ChartData>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ChartDataYear()
        {
            IEnumerable<ChartData> invoices = await _invoiceService.GetChartDataByMonth();
            return Ok(invoices);
        }
    }
}
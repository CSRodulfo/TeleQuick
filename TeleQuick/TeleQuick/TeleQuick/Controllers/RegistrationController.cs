using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IService;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class RegistrationController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger _logger;

        public RegistrationController(IMapper mapper, IInvoiceService invoiceService, ILogger<VehicleController> logger)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
            _logger = logger;
        }

        [HttpGet("Invoice")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceViewModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            IEnumerable<InvoiceDetail> invoices = await _invoiceService.GetAllDetails(pageNumber, pageSize);

            return Ok(_mapper.Map<IEnumerable<InvoiceDetailViewModel>>(invoices));
        }

    }
}
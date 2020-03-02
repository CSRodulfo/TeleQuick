using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.IService;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class InvoiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;
        private readonly ILogger _logger;

        public InvoiceController(IMapper mapper, IInvoiceService invoiceService, ILogger<InvoiceController> logger)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
            _logger = logger;
        }


        [HttpGet("Invoice/{id}")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        //[ProducesResponseType(200, Type = typeof(InvoiceViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            InvoiceHeader invoice = await _invoiceService.GetById(id);

            if (invoice == null)
                return NotFound();

            return Ok(_mapper.Map<InvoiceViewModel>(invoice));
        }

        // GET: api/values
        [HttpGet("Invoice")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InvoiceViewModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<InvoiceHeader> invoices = await _invoiceService.Get();
            return Ok(_mapper.Map<IEnumerable<InvoiceViewModel>>(invoices));
        }
    }
}
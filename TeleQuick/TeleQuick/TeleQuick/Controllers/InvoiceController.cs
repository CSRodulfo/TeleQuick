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
        private readonly IAccountSessionService _accountSessionService;
        private readonly ILogger _logger;

        public InvoiceController(IMapper mapper, IAccountSessionService accountSessionService, ILogger<AccountSessionController> logger)
        {
            _mapper = mapper;
            _accountSessionService = accountSessionService;
            _logger = logger;
        }


        [HttpGet("AccountSession/{id}")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(AccountSessionViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            AccountSession account = await _accountSessionService.GetById(id);

            if (account == null)
                return NotFound();

            return Ok(_mapper.Map<AccountSessionViewModel>(account));
        }

        // GET: api/values
        [HttpGet("AccountSession")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AccountSessionViewModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AccountSession> accounts = await _accountSessionService.Get();
            return Ok(_mapper.Map<IEnumerable<AccountSessionViewModel>>(accounts));
        }
    }
}
using AutoMapper;
using TeleQuick.Business.Models;
using IdentityServer4.AccessTokenValidation;
using IService.TeleQuick.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.Helpers;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class AccountSessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountSessionService _accountSessionService;
        private readonly ILogger _logger;

        public AccountSessionController(IMapper mapper, IAccountSessionService accountSessionService, ILogger<AccountSessionController> logger)
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

        // POST api/values
        [HttpPost("AccountSession")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateAccountSession([FromBody] AccountSessionViewModel accountSession)
        {
            return BadRequest(ModelState);
            if (ModelState.IsValid)
            {
                AccountSession account = _mapper.Map<AccountSession>(accountSession);
                //newVehicle.TAGs.Add(new TagRfid() { TAGNumber = vehicle.TAGNumber });

                return Ok(await _accountSessionService.Create(account));
            }

            return BadRequest(ModelState);
        }


        [HttpPut("AccountSession/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAccountSession(int id, [FromBody] AccountSessionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AccountSession account = await _accountSessionService.GetById(id);

                _mapper.Map(vm, account);

                return Ok(await _accountSessionService.Update(account));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("AccountSession/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAccountSession(string id)
        {
            return Ok();
        }

        [HttpPut("ValidateConection")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ValidateConectionAccountSession([FromBody] AccountSessionViewModel vm)
        {
            try
            {
                AccountSession account = await _accountSessionService.GetById(vm.Id);
                _mapper.Map(vm, account);

                var rtn = await _accountSessionService.ValidateConnection(account);

                return Ok(rtn);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SEND_EMAIL, ex, "An error occurred whilst sending email");
                return Ok(false);
            }

        }
    }
}
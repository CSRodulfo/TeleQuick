using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using IService.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSessionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountSessionService _AccountSession;
        private readonly ILogger _logger;

        public AccountSessionController(IMapper mapper, IAccountSessionService AccountSession, ILogger<AccountSessionController> logger)
        {
            _mapper = mapper;
            _AccountSession = AccountSession;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet("AccountSession")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<AccountSessionViewModel>))]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _AccountSession.Get();
            return Ok(_mapper.Map<IEnumerable<AccountSessionViewModel>>(allCustomers));
        }

        // POST api/values
        [HttpPost("AccountSession")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(201, Type = typeof(UserViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> CreateAccountSession([FromBody] AccountSessionViewModel accountSession)
        {
            return Ok();
        }


        [HttpPut("AccountSession/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAccountSession(string id, [FromBody] AccountSessionViewModel role)
        {
            return Ok();
        }

        [HttpDelete("AccountSession/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(RoleViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAccountSession(string id)
        {
            return Ok();
        }
    }
}
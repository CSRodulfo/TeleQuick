using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.Business.Models;
using TeleQuick.Helpers;
using TeleQuick.IService;
using TeleQuick.SignalR;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    public class ProcessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountSessionService _accountSessionService;
        private readonly ILogger _logger;
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private ObservableCollection<string> _summary;

        public ProcessController(IMapper mapper, IAccountSessionService accountSessionService,
            ILogger<AccountSessionController> logger, IHubContext<NotifyHub, ITypedHubClient> hubContext,
            ObservableCollection<string> summary)
        {
            _mapper = mapper;
            _accountSessionService = accountSessionService;
            _logger = logger;
            _hubContext = hubContext;
            _summary = summary;
        }

        [HttpGet("Process")]    
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ProcessAccountSession()
        {
            try
            {
                //_summary.
                _summary.CollectionChanged += async (o, e) =>
                {
                    var array = (IList<string>)o;
                    await _hubContext.Clients.All.BroadcastMessage(array.Last().ToString(), "");
                };

                var rtn = await _accountSessionService.Process();

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SEND_EMAIL, ex, "An error occurred whilst sending email");
                return Ok(false);
            }
        }
    }
}
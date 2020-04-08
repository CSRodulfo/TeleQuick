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
using TeleQuick.Business;
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
        private NotifyHub _hubContext;
        private ObservableCollection<Message> _summary;

        public ProcessController(IMapper mapper, IAccountSessionService accountSessionService,
            ILogger<AccountSessionController> logger, NotifyHub hubContext, ObservableCollection<Message> summary)
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
                _summary.CollectionChanged += async (o, e) =>
                {
                    var userId = Utilities.GetUserId(this.User);
                    var array = (IEnumerable<Message>)o;
                    try
                    {
                        await _hubContext.SendMessageUser(userId, array.Last());
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(LoggingEvents.HUB, ex, "Se produjo un error en adjuntar el mensaje");
                        //await _hubContext.SendMessageUser(userId, new Message("Error", ex.Message));
                    }
                };

                var rtn = await _accountSessionService.Process();

                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.HUB, ex, "Se produjo un error en procesar");
                return Ok(false);
            }
        }

    }
}
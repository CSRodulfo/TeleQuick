using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using IService.TeleQuick.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using TeleQuick.Business.Models;
using TeleQuick.Helpers;
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

        public ProcessController(IMapper mapper, IAccountSessionService accountSessionService, 
            ILogger<AccountSessionController> logger, IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _mapper = mapper;
            _accountSessionService = accountSessionService;
            _logger = logger;
            _hubContext = hubContext;
        }


        [HttpGet]
        public string Post()
        {
            string retMessage;

            try
            {

                ObservableCollection<string> list = new ObservableCollection<string>();
                list.CollectionChanged += this.listChanged;

                for (int i = 0; i < 20; i++)
                {

                    list.Add("pepe");
                }
                retMessage = "Successdsadasdas";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }

        private void listChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            _hubContext.Clients.All.BroadcastMessage("dasdsada", "dasdasds");
            System.Threading.Thread.Sleep(5000);
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
                AccountSession account = await _accountSessionService.GetById(3);

                var rtn = await _accountSessionService.Process(account);

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
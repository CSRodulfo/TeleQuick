using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IService.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using TeleQuick.SignalR;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                for (int i = 0; i < 100; i++)
                {
                    _hubContext.Clients.All.BroadcastMessage("dasdsada", "dasdasds");
                    System.Threading.Thread.Sleep(5000);
                }
                retMessage = "Successdsadasdas";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }
}
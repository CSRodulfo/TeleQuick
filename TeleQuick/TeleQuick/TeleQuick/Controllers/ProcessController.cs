using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IService.TeleQuick.Business;
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
    }
}
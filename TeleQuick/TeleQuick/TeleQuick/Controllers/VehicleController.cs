using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IDataAccess;
using IService.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicle;
        private readonly ILogger _logger;

        public VehicleController(IMapper mapper, IVehicleService vehicle, ILogger<VehicleController> logger)
        {
            _mapper = mapper;
            _vehicle = vehicle;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _vehicle.Get();
            //return Ok(_mapper.Map<IEnumerable<CustomerViewModel>>(allCustomers));
            return Ok(allCustomers);
        }

    }
}
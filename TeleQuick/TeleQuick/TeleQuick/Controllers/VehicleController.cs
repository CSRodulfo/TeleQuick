﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IDataAccess;
using IService.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeleQuick.ViewModels;

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
        [HttpGet("Vehicle")]
        //[Authorize(Authorization.Policies.ViewAllUsersPolicy)]
       // [ProducesResponseType(200, Type = typeof(List<RoleViewModel>))]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _vehicle.Get();
            return Ok(_mapper.Map<IEnumerable<VehicleViewModel>>(allCustomers));
        }

        // POST api/values
        [HttpPost("Vehicle")]
        //[Authorize(Authorization.Policies.ViewAllUsersPolicy)]
      //  [ProducesResponseType(201, Type = typeof(UserViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleViewModel vehicle)
        {
            return Ok();
        }


        [HttpPut("Vehicle/{id}")]
        //[Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateVehicle(string id, [FromBody] VehicleViewModel role)
        {
            return Ok();
        }

        [HttpDelete("Vehicle/{id}")]
        //[Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(RoleViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            return Ok();
        }
    }
}
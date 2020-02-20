using AutoMapper;
using Business.Models;
using IdentityServer4.AccessTokenValidation;
using IService.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
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

        [HttpGet("Vehicle/{id}")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(VehicleViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            Vehicle vehicle = await _vehicle.GetById(id);

            if (vehicle == null)
                return NotFound();

            return Ok(_mapper.Map<VehicleViewModel>(vehicle));
        }

        // GET: api/values
        [HttpGet("Vehicle")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(200, Type = typeof(List<VehicleViewModel>))]
        public async Task<IActionResult> Get()
        {
            var allCustomers = await _vehicle.GetAll();
            return Ok(_mapper.Map<IEnumerable<VehicleViewModel>>(allCustomers));
        }

        // POST api/values
        [HttpPost("Vehicle")]
        [Authorize(Authorization.Policies.ViewAllUsersPolicy)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle newVehicle = _mapper.Map<Vehicle>(vehicle);
                newVehicle.TAGs.Add(new TagRfid() { TAGNumber = vehicle.TAGNumber });

                return Ok( await _vehicle.Create(newVehicle));
            }

            return BadRequest(ModelState);
        }


        [HttpPut("Vehicle/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = await _vehicle.GetById(id);

                _mapper.Map(vm, vehicle);
                vehicle.TAGs.First().TAGNumber = vm.TAGNumber;

//v               var comparer = new AccommodationImageModelComparer();

//                var newItems = compareList.Where(l => l.Id == 0).ToList();
//                var toBeDeleted = masterList.Except(compareList, comparer).ToList();
//                var toBeUpdated = masterList.Intersect(compareList, comparer).ToList();

                return Ok(await _vehicle.Update(vehicle));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Vehicle/{id}")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(200, Type = typeof(RoleViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            return Ok();
        }
    }
}
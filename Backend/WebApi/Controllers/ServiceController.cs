using Business.BranchOffices;
using Business.Common;
using IServices.BranchOffices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetAll()
        {
            return await this.serviceService.GetAll();
        }
    }
}

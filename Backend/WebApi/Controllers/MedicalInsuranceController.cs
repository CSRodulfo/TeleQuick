using Business.MedicalInsurances;
using IServices.MedicalInsurances;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicalInsuranceController : Controller
    {
        private readonly IMedicalInsuranceService medicalInsuranceService;

        public MedicalInsuranceController(IMedicalInsuranceService medicalInsuranceService)
        {
            this.medicalInsuranceService = medicalInsuranceService;
        }

        // GET: api/MedicalInsurance
        //[HttpGet]
        //public async Task<IEnumerable<MedicalInsurance>> Get()
        //{
        //    try
        //    {
        //        var result = this.medicalInsuranceService.GetAll();
        //        return await result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

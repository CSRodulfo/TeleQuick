// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using AutoMapper;
using IService.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TeleQuick.Helpers;
using TeleQuick.ViewModels;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customer;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;


        public CustomerController(IMapper mapper, ICustomerService customer, ILogger<CustomerController> logger)//, IEmailSender emailSender)
        {
            _mapper = mapper;
            _customer = customer;
            _logger = logger;
           // _emailSender = emailSender;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allCustomers = _customer.Get();
            return Ok(_mapper.Map<IEnumerable<CustomerViewModel>>(allCustomers));
        }



        [HttpGet("throw")]
        public IEnumerable<CustomerViewModel> Throw()
        {
            throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
        }



        //[HttpGet("email")]
        //public async Task<string> Email()
        //{
        //    string recepientName = "QickApp Tester"; //         <===== Put the recepient's name here
        //    string recepientEmail = "test@ebenmonney.com"; //   <===== Put the recepient's email here

        //    string message = EmailTemplates.GetTestEmail(recepientName, DateTime.UtcNow);

        //    (bool success, string errorMsg) = await _emailSender.SendEmailAsync(recepientName, recepientEmail, "Test Email from TeleQuick", message);

        //    if (success)
        //        return "Success";

        //    return "Error: " + errorMsg;
        //}



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }







        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeleQuick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController : ControllerBase
    {
        //private readonly IConnection _mapper;


        //public BaseDataController(IConnection mapper)
        //{
        //    _mapper = mapper;
        //}
        // GET: api/BaseData
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BaseData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BaseData
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BaseData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

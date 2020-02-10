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
        public async Task<IActionResult> Get()
        {
            List<Test> list = new List<Test>();
            list.Add(new Test() { Name = "Create visual studio extension", Description = "Create a visual studio VSIX extension package that wi" });
            list.Add(new Test() { Name = "Do a quick how-to writeup", Description = "Lola" });
            list.Add(new Test() { Name = "Create aspnet-core/Angular8 tutorials based on this project", Description = "Create tutorials (blog/video/youtube) " });

            return Ok(list);
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

public class Test
{
    public string Name { get; set; }

    public string Description { get; set; }

}

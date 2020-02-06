using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IServices.Medicines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var image = await this.imageService.Get(id);
            return this.File(image, "image/jpeg");
        }
    }
}
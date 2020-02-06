using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            string lastBuildDate = Common.Extensions.AssemblyExtensions.GetAssemblyDate();

            return this.View();
        }
    }
}
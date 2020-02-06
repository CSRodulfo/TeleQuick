using System.Threading.Tasks;
using Business.User;
using IServices.User;
using Microsoft.AspNetCore.Mvc;
 

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewUser([FromBody]NewUserRequest newUserRequest)
        {
            await this.userService.RegisterNewUser(newUserRequest);
            return this.Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            string userToken = this.Request?.Headers["usertToken"];

            var data = await this.userService.GetUserInfo(userToken);
            return this.Ok(data);
        }

        [HttpPost("UpdateOptInes")]
        public async Task<IActionResult> UpdateOptines([FromBody] UpdateUserOptInsRequest updateUserOptInsRequest)
        {
            string userToken = this.Request?.Headers["usertToken"];

            await this.userService.UpdateOptInes(updateUserOptInsRequest,userToken);
            return this.Ok();
        }

        [HttpPost("reset-pwd")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest email)
        {
            await this.userService.ResetPassword(email);
            return this.Ok();
        }

    }
}
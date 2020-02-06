using Business.IRestServices;
using Business.User;
using IServices.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRestService userRestService;

        public UserService(IUserRestService userRestService)
        {
            this.userRestService = userRestService;
        }

        public async Task<UserInfoResponse> GetUserInfo(string userToken)
        {
            return await this.userRestService.GetUserInfo(userToken);
        }

        public async Task RegisterNewUser (NewUserRequest newUserRequest)
        {
            await this.userRestService.RegisterNewUser(newUserRequest);
        }

        public async Task UpdateOptInes(UpdateUserOptInsRequest updateUserOptInsRequest, string userToken)
        {
            await this.userRestService.UpdateOptInes(updateUserOptInsRequest, userToken);
        }

        public async Task ResetPassword(ResetPasswordRequest email)
        {
            await this.userRestService.ResetPassword(email);
        }
    }
}

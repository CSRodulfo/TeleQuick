using Business.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRestServices
{
    public interface IUserRestService
    {
        Task RegisterNewUser(NewUserRequest newUserRequest);
        Task<UserInfoResponse> GetUserInfo(string userToken);
        Task UpdateOptInes(UpdateUserOptInsRequest updateUserOptInsRequest, string userToken);
        Task ResetPassword(ResetPasswordRequest email);
    }
}

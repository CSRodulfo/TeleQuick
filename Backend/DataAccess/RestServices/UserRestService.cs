using Business.IRestServices;
using Business.User;
using Common.Configuration;
using DataAccess.BuildersRest;
using DataAccess.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RestServices
{
    public class UserRestService : BaseRestService, IUserRestService
    {
        private readonly IConfiguration _configuration;
        private readonly string userApi;
        public UserRestService(IOptions<AppOptions> options, HttpRequestBuilder httpRequestBuilder, CustomHttpClient client, IConfiguration configuration) : base(httpRequestBuilder, client)
        {
            this._configuration = configuration;
            this.userApi = $"{options.Value.FcdmApi}user";
        }

        public async Task<UserInfoResponse> GetUserInfo(string userToken)
        {

            var request = this.httpRequestBuilder.Initialize($"{this.userApi}")
             .SetMethod(HttpMethod.Get)
             .Build();

            return await this.client.DoCall<UserInfoResponse>(request, userToken);
        }

        public async Task RegisterNewUser(NewUserRequest newUserRequest)
        {
            newUserRequest.RegisteredFrom = this._configuration["FcdmAppKey"];

            var request = this.httpRequestBuilder.Initialize($"{this.userApi}/full-register")
               .SetBody(newUserRequest)
               .SetMethod(HttpMethod.Post)
               .Build();

            await this.client.DoCall(request);
        }

        public async Task UpdateOptInes(UpdateUserOptInsRequest updateUserOptInsRequest, string userToken)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.userApi}/Optins")
               .SetBody(updateUserOptInsRequest)
               .SetMethod(HttpMethod.Post)
               .Build();

            await this.client.DoCall(request, userToken);
        }

        public async Task ResetPassword(ResetPasswordRequest model)
        {
            var request = this.httpRequestBuilder.Initialize($"{this.userApi}/reset-pwd")
               .SetBody(model)
               .SetMethod(HttpMethod.Post)
               .Build();

            await this.client.DoCallFcdmResetToken(request);
        }
    }
}

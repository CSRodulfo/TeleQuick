namespace WebAPI.Security
{
    // public class CustomAuthorizeAttribute : AuthorizationFilterAttribute
    //{

    //    public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    //    {
    //        var headers = actionContext.Request.Headers;
    //        try
    //        {
    //            LoginUser login = new LoginUser();
    //            login.User = headers.GetValues("User").FirstOrDefault();
    //            login.Token = headers.GetValues("Token").FirstOrDefault();
    //            login.Application = headers.GetValues("App").FirstOrDefault();
    //            login.Serial = headers.GetValues("Serial").FirstOrDefault();
    //            login.Uuid = headers.GetValues("Uuid").FirstOrDefault();

    //            ILoginService loginService = new LoginService();

    //            //GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IApiUserService));

    //            var result = await loginService.ValidateUser(login);
    //            AuthTokenResponse data = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthTokenResponse>(result);

    //            if (data.errType == ServiceEntities.Common.ErrorTypeEnum.NO_ERR)
    //            {
    //                await base.OnAuthorizationAsync(actionContext, cancellationToken);
    //            }
    //            else
    //            {
    //                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, data);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Error al conectar");
    //        }
    //    }

    //    private void PutUnauthorizedResult(HttpActionContext actionContext, AuthTokenResponse msg)
    //    {
    //        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
    //        {
    //            //  Content = msg
    //        };
    //    }
    // }
}
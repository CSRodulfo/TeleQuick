using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace WebAPI.CustomSecurity
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "Farmacity";
        public string Scheme => DefaultScheme;
    }
}
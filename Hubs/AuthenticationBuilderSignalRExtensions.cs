using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ClimateMeter.Web.Hubs
{
    public static class AuthenticationBuilderSignalRExtensions
    {
        private static readonly string _defaultJwtTokenQueryStringParameter = "JWT_TOKEN";
        private static readonly string _defaultJwtAuthenticationSchemeName = JwtBearerDefaults.AuthenticationScheme;

        public static AuthenticationBuilder AddJwtBearerWithSignalR(
            this AuthenticationBuilder builder,
            string queryStringParameter,
            string authenticationSchemeName)
        {
            throw new NotImplementedException();
        }
    }
}
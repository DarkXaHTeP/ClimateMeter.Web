using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClimateMeter.Web.Hubs
{
    public static class AuthenticationBuilderSignalRExtensions
    {
        private static readonly string _defaultJwtTokenQueryStringParameter = "JWT_TOKEN";
        private static readonly string _defaultJwtAuthenticationSchemeName = JwtBearerDefaults.AuthenticationScheme;
        
        public static AuthenticationBuilder AddSignalRJwtParsing(this AuthenticationBuilder builder)
        {
            return AddSignalRJwtParsingCore(builder, _defaultJwtTokenQueryStringParameter, _defaultJwtAuthenticationSchemeName);
        }
        
        public static AuthenticationBuilder AddSignalRJwtParsing(this AuthenticationBuilder builder, Action<SignalRJwtParsingOptions> configure)
        {
            var provider = builder.Services.BuildServiceProvider();

            var authOptions = provider.GetService<IOptions<AuthenticationOptions>>();
            foreach (var schemeMapKey in authOptions.Value.SchemeMap.Keys)
            {
                Console.WriteLine("Scheme: " + schemeMapKey);
            }
            
            var configureNamedOptions = (ConfigureNamedOptions<JwtBearerOptions>) provider
                .GetService<IConfigureOptions<JwtBearerOptions>>();
            
            Console.WriteLine(configureNamedOptions.Name);

            var options = new SignalRJwtParsingOptions();
            configure(options);

            var queryStringParameter = String.IsNullOrEmpty(options.TokenQueryStringParameter)
                ? _defaultJwtTokenQueryStringParameter
                : options.TokenQueryStringParameter;

            var authSchemeName = String.IsNullOrEmpty(options.JwtAuthenticationSchemeName)
                ? _defaultJwtAuthenticationSchemeName
                : options.JwtAuthenticationSchemeName;
            
            return AddSignalRJwtParsingCore(
                builder,
                queryStringParameter,
                authSchemeName);
        }

        private static AuthenticationBuilder AddSignalRJwtParsingCore(
            AuthenticationBuilder builder,
            string queryStringParameter,
            string authenticationSchemeName)
        {
            throw new NotImplementedException();
        }
    }
}
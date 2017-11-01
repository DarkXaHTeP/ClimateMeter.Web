using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace ClimateMeter.Web.Hubs
{
    public static class AuthenticationBuilderSignalRExtensions
    {
        private static readonly string _defaultJwtTokenQueryStringParameter = "JWT_TOKEN";

        public static AuthenticationBuilder AddJwtBearerWithSignalR(this AuthenticationBuilder builder)
        {
            return builder;
        }

        public static AuthenticationBuilder AddJwtBearerWithSignalR(
            this AuthenticationBuilder builder,
            Action<JwtBearerOptions> configureOptions)
            =>
                builder.AddJwtBearer(AddSignalRTokenRetrieval(configureOptions));

        public static AuthenticationBuilder AddJwtBearerWithSignalR(
            this AuthenticationBuilder builder,
            string authenticationScheme,
            Action<JwtBearerOptions> configureOptions)
            =>
                builder.AddJwtBearer(authenticationScheme, AddSignalRTokenRetrieval(configureOptions));

        public static AuthenticationBuilder AddJwtBearerWithSignalR(this AuthenticationBuilder builder,
            string authenticationScheme, string displayName, Action<JwtBearerOptions> configureOptions)
            =>
                builder.AddJwtBearer(authenticationScheme, displayName, AddSignalRTokenRetrieval(configureOptions));
        
        private static Action<JwtBearerOptions> AddSignalRTokenRetrieval(Action<JwtBearerOptions> configureOptions)
        {
            return options =>
            {
                configureOptions(options);

                if (options.Events == null)
                {
                    options.Events = new JwtBearerEvents();
                }

                
            };
        }
    }
}
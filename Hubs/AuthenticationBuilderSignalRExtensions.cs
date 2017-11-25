using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace ClimateMeter.Web.Hubs
{
    public static class AuthenticationBuilderSignalRExtensions
    {
        private const string DefaultJwtTokenQueryStringParameter = "JWT_TOKEN";

        public static AuthenticationBuilder AddJwtBearerWithSignalR(this AuthenticationBuilder builder)
        {
            return builder.AddJwtBearer(AddSignalRTokenRetrieval(null));
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
            string authenticationScheme, string displayName, string jwtTokenQueryStringParameter, Action<JwtBearerOptions> configureOptions)
            =>
                builder.AddJwtBearer(authenticationScheme, displayName, AddSignalRTokenRetrieval(configureOptions, jwtTokenQueryStringParameter));
        
        private static Action<JwtBearerOptions> AddSignalRTokenRetrieval(Action<JwtBearerOptions> configureOptions, string jwtTokenParameter = DefaultJwtTokenQueryStringParameter)
        {
            return options =>
            {
                configureOptions?.Invoke(options);

                if (options.Events == null)
                {
                    options.Events = new JwtBearerEvents();
                }

                var originalOnMessageReceived = options.Events.OnMessageReceived;
                
                options.Events.OnMessageReceived = async context =>
                {                    
                    if (originalOnMessageReceived != null)
                    {
                        await originalOnMessageReceived(context);
                    }
                    
                    if (context.Token == null &&
                        !context.HttpContext.Request.Headers.ContainsKey("Authorization") &&
                        context.Request.Query.TryGetValue(jwtTokenParameter, out var token))
                    {
                        context.Token = token;
                    }
                };

            };
        }
    }
}

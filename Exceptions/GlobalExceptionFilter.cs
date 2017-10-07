using System;
using System.Net;
using ClimateMeter.Web.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace ClimateMeter.Web.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GlobalExceptionFilter>();
        }

        public void OnException(ExceptionContext context)
        {   
            Exception err = context.Exception;
            
            _logger.LogError(err, "Unhandled Exception happened");
            
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            
            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";

            context.ExceptionHandled = true;
            
            var settings = JsonSerializerSettingsProvider.CreateSettings();
            var json = JsonConvert.SerializeObject(new { err.Message }, settings);
            
            response.WriteAsync(json);
        }
    }
}

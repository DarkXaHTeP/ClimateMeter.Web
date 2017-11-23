using System.IO;
using DarkXaHTeP.Extensions.Configuration.Consul;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClimateMeter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .AddJsonFile("appsettings.json", true, true)
                        .AddConsul("ClimateMeter.Web")
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging
                        .AddConfiguration(hostingContext.Configuration.GetSection("Logging"))
                        .AddConsole();
                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .ConfigureServices(services =>
                {
                    services.AddTransient<IConfigureOptions<KestrelServerOptions>, KestrelServerOptionsSetup>();
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}

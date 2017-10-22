using ClimateMeter.Web.DAL;
using ClimateMeter.Web.Hubs;
using ClimateMeter.Web.Middleware;
using ClimateMeter.Web.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClimateMeter.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("ClimateMeter.DB");

            services.AddDbContext<ClimateMeterContext>(options => options.UseSqlServer(connectionString));
            services.AddSignalR();
            services.AddMvc()
                    .AddJsonOptions(options => JsonSerializerSettingsProvider.SetSettings(options.SerializerSettings));
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseDeveloperExceptionPage()
                .EnsureMigrationsApplied<ClimateMeterContext>()
                .UseStaticFiles()
                .UseSignalR(routes => routes.MapHub<ClimateHub>("socket/device"))
                .UseMvc(routes => routes.MapRoute("catchAll", "{*url}", new { controller = "Home", action = "Index" }));
        }
    }
}

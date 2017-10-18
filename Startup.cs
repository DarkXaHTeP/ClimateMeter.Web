using ClimateMeter.Web.DAL;
using ClimateMeter.Web.Exceptions;
using ClimateMeter.Web.Middleware;
using ClimateMeter.Web.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
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
            
            services
                .AddDbContext<ClimateMeterContext>(options => options.UseSqlServer(connectionString))
                .AddMvc(options => options.Filters.Add<GlobalExceptionFilter>())
                .AddJsonOptions(options => JsonSerializerSettingsProvider.SetSettings(options.SerializerSettings));
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .EnsureMigrationsApplied<ClimateMeterContext>()
                .UseDeveloperExceptionPage()
                .UseStaticFiles()
                .UseMvc(routes => routes.MapRoute("catchAll", "{*url}", new { controller = "Home", action = "Index" }));
        }
    }
}

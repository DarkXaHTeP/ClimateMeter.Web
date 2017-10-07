using ClimateMeter.Web.Exceptions;
using ClimateMeter.Web.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ClimateMeter.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options => options.Filters.Add<GlobalExceptionFilter>())
                .AddJsonOptions(options =>
                {
                    JsonSerializerSettingsProvider.SetSettings(options.SerializerSettings);
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}

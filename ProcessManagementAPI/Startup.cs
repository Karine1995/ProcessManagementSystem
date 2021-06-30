using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagementAPI.Configurations;
using ProcessManagementAPI.Middlewares;
using Serilog;

namespace ProcessManagementAPI
{
    /// <summary>
    /// Application startup
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configure application services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureDI(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureAuthorization();
            services.ConfigureApiVersioning();
            services.ConfigureFluentValidation();
            services.ConfigureSwagger();
            services.ConfigureFilters();
        }

        /// <summary>
        /// Configure HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseMiddleware<SetResponseContentType>();

            app.UseSerilogRequestLogging();

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<UnauthorizedResponseHandleMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireAuthorization();
            });
        }
    }
}

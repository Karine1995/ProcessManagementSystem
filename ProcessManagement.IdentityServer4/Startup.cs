using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.IdentityServer4.Configurations;
using ProcessManagement.IdentityServer4.Middlewares;
using Serilog;
using static IdentityServer4.IdentityServerConstants;

namespace ProcessManagement.IdentityServer4
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureIdentity(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureAuthorization();
            services.ConfigureFilters();
            services.ConfigureFluentValidation();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseMiddleware<SetResponseContentType>();

            app.UseSerilogRequestLogging();

            InitializeDbConfiguration.InitializeDatabase(app).GetAwaiter().GetResult();

            app.UseRouting();

            app.UseMiddleware<UnauthorizedResponseHandleMiddleware>();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireAuthorization(LocalApi.PolicyName);
            });
        }
    }
}

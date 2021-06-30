using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagementAPI.Infrastructure;

namespace ProcessManagementAPI.Configurations
{
    internal static class DIConfiguration
    {
        public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            ProcessManagement.BLL.DIConfiguration.ConfigureDI(services, configuration);

            services.AddScoped<ServiceFactory>();
        }
    }
}

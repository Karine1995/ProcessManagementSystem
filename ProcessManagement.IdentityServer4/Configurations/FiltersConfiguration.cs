using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.IdentityServer4.Filters;

namespace ProcessManagement.IdentityServer4.Configurations
{
    internal static class FiltersConfiguration
    {
        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.Filters.Add(new ModelValidationFilter());
            });
        }
    }
}

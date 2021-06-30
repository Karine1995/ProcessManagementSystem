using Microsoft.Extensions.DependencyInjection;
using ProcessManagementAPI.ActionFilters;

namespace ProcessManagementAPI.Configurations
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

using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProcessManagement.IdentityServer4.Configurations
{
    internal static class FluentValidationConfiguration
    {
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}

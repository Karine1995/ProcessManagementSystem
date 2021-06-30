using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.Common.Constants;
using System.Reflection;

namespace ProcessManagementAPI.Configurations
{
    internal static class FluentValidationConfiguration
    {
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.Load(Constants.ValidatorAssembly));
            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProcessManagement.Common.Constants;
using System;

namespace ProcessManagementAPI.Configurations
{
    internal static class AuthConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authority = configuration.GetSection(Constants.URLSection).GetValue<string>(Constants.Authority);

            services.AddAuthentication(Constants.Bearer)
                .AddJwtBearer(Constants.Bearer, options =>
                {
                    options.Authority = authority;

                    options.Audience = Constants.ProcessManagementDemo;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization();
        }
    }
}

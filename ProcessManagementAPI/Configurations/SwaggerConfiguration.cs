using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProcessManagement.Common.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProcessManagementAPI.Configurations
{
    internal static partial class SwaggerConfiguration
    {
        public static void UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProcessManagement.Demo.API v1");
            });
        }
        /// <summary>
        /// Public extension method on IServiceCollection for swagger
        /// </summary>
        /// <param name="services">IServiceCollection type parameter</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ProcessManagement.Demo.API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // This call remove version from parameter, without it we will have version as parameter 
                // for all endpoints in swagger UI
                options.OperationFilter<RemoveVersionFromParameter>();

                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v}" == docName);
                });

                options.AddSecurityDefinition(Constants.Bearer, new OpenApiSecurityScheme()
                {
                    Description = "Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Constants.Bearer
                            },
                            Scheme = Constants.Bearer,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}

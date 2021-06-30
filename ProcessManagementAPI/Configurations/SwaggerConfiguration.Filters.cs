using Microsoft.OpenApi.Models;
using ProcessManagement.Common.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace ProcessManagementAPI.Configurations
{
    internal class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == Constants.Version);
            operation.Parameters.Remove(versionParameter);

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "accept-language",
                In = ParameterLocation.Header,
                Required = true
            });
        }
    }

    internal class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            OpenApiPaths openApiPaths = new();

            foreach (var path in swaggerDoc.Paths)
                openApiPaths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);

            swaggerDoc.Paths = openApiPaths;
        }
    }
}

using Microsoft.AspNetCore.Http;
using ProcessManagementAPI.Infrastructure;
using System;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Middlewares
{
    /// <summary>
    /// Middleware for changing response content type to application/json
    /// </summary>
    public class SetResponseContentType : ApplicationMiddleware
    {
        /// <summary>
        /// </summary>
        /// <param name="next"></param>
        public SetResponseContentType(RequestDelegate next)
            : base(next)
        {
        }

        /// <summary>
        /// Invoke middleware
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;

            await Next(httpContext);
        }
    }
}

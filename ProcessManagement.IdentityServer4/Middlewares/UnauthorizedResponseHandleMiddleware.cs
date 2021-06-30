using Microsoft.AspNetCore.Http;
using ProcessManagement.IdentityServer4.Common.Extensions;
using ProcessManagement.IdentityServer4.Common.Models;
using ProcessManagement.IdentityServer4.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagement.IdentityServer4.Middlewares
{
    /// <summary>
    /// Unauthorized and forbidden requests handling middleware
    /// Allways set this middleware on the top of UseAuthentication and UseAuthorization middlewares
    /// </summary>
    public class UnauthorizedResponseHandleMiddleware : ApplicationMiddleware
    {
        /// <summary>
        /// </summary>
        /// <param name="next"></param>
        public UnauthorizedResponseHandleMiddleware(RequestDelegate next) : base(next)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task InvokeAsync(HttpContext httpContext)
        {
            await Next(httpContext);

            if (!IsAuthorized(httpContext.Response, out ResponseModel<string> response))
                await httpContext.Response.WriteResponseAsync(response, httpContext.Response.StatusCode);
        }

        private static bool IsAuthorized(HttpResponse httpResponse, out ResponseModel<string> response)
        {
            response = null;

            if (httpResponse.StatusCode == StatusCodes.Status401Unauthorized)
            {
                response = new ResponseModel<string>()
                {
                    Message = "Authorization has been denied for this request"
                };

                return false;
            }

            if (httpResponse.StatusCode == StatusCodes.Status403Forbidden)
            {
                response = new ResponseModel<string>()
                {
                    Message = "Permission denied"
                };

                return false;
            }

            return true;
        }
    }

}

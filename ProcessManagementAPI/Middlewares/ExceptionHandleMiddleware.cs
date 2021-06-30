using Microsoft.AspNetCore.Http;
using ProcessManagement.Common.Extensions;
using ProcessManagement.Common.Models;
using ProcessManagement.ViewModels.Infrastructure;
using ProcessManagementAPI.Infrastructure;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Middlewares
{
    /// <summary>
    /// IMPORTANT!!! Allways set this middleware on the top of middleware pipeline
    /// Application exception handling middleware
    /// </summary>
    public class ExceptionHandleMiddleware : ApplicationMiddleware
    {
        /// <summary>
        /// </summary>
        /// <param name="next"></param>
        public ExceptionHandleMiddleware(RequestDelegate next) : base(next)
        {
        }

        /// <summary>
        /// Invoke middleware
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
            }
            catch (Exception ex)
            {
                var response = BindErrorResponse(ex, out int statusCode);
                await httpContext.Response.WriteResponseAsync(response, statusCode);
            }
        }

        private static ResponseModel<object> BindErrorResponse(Exception exception, out int statusCode)
        {
            if (exception is FaultException<ErrorModel> faultException)
            {
                statusCode = faultException.Detail.StatusCode;

                return new()
                {
                    Message = faultException.Detail.Message,
                    Errors = faultException.Detail.Errors
                };
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;

                return new()
                {
                    Message = "Something went wrong",
                };
            }
        }
    }
}

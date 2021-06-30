using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Infrastructure
{
    /// <summary>
    /// Application base abstract middleware
    /// </summary>
    public abstract class ApplicationMiddleware
    {
        /// <summary>
        /// </summary>
        protected readonly RequestDelegate Next;

        /// <summary>
        /// Required constructor with RequestDelegate
        /// </summary>
        /// <param name="next"></param>
        public ApplicationMiddleware(RequestDelegate next) => Next = next;

        /// <summary>
        /// Write your middleware logic
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public abstract Task InvokeAsync(HttpContext httpContext);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProcessManagement.IdentityServer4.Common.Extensions;
using ProcessManagement.IdentityServer4.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProcessManagement.IdentityServer4.Filters
{
    /// <summary>
    /// Model Validation action filter for take all requested action context 
    /// </summary>
    internal class ModelValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.</param>
        /// <param name="next">The Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate. Invoked to execute the next action filter or the action itself.</param>
        /// <returns>A System.Threading.Tasks.Task that on completion indicates the filter has executed.</returns>       
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ModelStateDictionary modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var errorResponse = ErrorResponse(context.ModelState);
                await context.HttpContext.Response.WriteResponseAsync(errorResponse, StatusCodes.Status400BadRequest);
                return;
            }

            await next();
        }

        private static ResponseModel<object> ErrorResponse(ModelStateDictionary modelState)
        {
            Dictionary<string, string[]> errors = modelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(k => k.Key, v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray());

            return new ResponseModel<object>()
            {
                Message = HttpStatusCode.BadRequest.ToString(),
                Errors = errors
            };
        }
    }

}

using Microsoft.AspNetCore.Mvc.Filters;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Enumerations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProcessManagement.Common.Extensions;
using Microsoft.AspNetCore.Http;
using ProcessManagement.ViewModels.Infrastructure;

namespace ProcessManagementAPI.ActionFilters
{
    /// <summary>
    /// 
    /// </summary>
    public class RequiredUserTypeAttribute : ActionFilterAttribute
    {
        private readonly UserTypes[] _userTypes;

        /// <summary>
        /// </summary>
        /// <param name="userTypes"></param>
        public RequiredUserTypeAttribute(params UserTypes[] userTypes) => _userTypes = userTypes;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var username = context.HttpContext.User.Claims.FirstOrDefault(u => u.Type == Claims.Username).Value;
            var userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (!await userService.IsInTypeAsync(_userTypes, username))
            {
                var response = new ResponseModel<object> { Message = "You don't have permission" };
                await context.HttpContext.Response.WriteResponseAsync(response, StatusCodes.Status400BadRequest);
                return;
            }

            await next();
        }
    }
}

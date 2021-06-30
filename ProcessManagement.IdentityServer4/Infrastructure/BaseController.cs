using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProcessManagement.IdentityServer4.Common.Models;
using ProcessManagement.IdentityServer4.Common.Extensions;

namespace ProcessManagement.IdentityServer4.Infrastructure
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Base success response
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public override ResponseModel<object> Ok() => new();

        /// <summary>
        /// Success response with result
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [NonAction]
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
            => base.Ok(new ResponseModel<object>() { Data = value });

        /// <summary>
        /// Success response with message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public OkObjectResult Ok(string message)
            => base.Ok(new ResponseModel<object>() { Message = message });

        /// <summary>
        /// Bad request response with message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        public BadRequestObjectResult BadRequest(string message)
            => new(new ResponseModel<object>() { Message = message });

        /// <summary>
        /// Handle identity response
        /// </summary>
        /// <param name="identityResult"></param>
        /// <returns></returns>
        public ObjectResult IdentityResponse(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                ResponseModel<object> response = new()
                {
                    Errors = identityResult.Errors.ToDictionary()
                };

                ObjectResult result = new(response)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };

                return result;
            }

            return Ok(identityResult);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProcessManagement.ViewModels.Infrastructure;

namespace ProcessManagementAPI.Infrastructure
{
    /// <summary>
    /// Base controller for all controllers in application
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// ServiceFactory instance for get BLL services
        /// </summary>
        protected readonly ServiceFactory ServiceFactory;

        /// <summary>
        /// All controllers must be use service factory
        /// </summary>
        public BaseController(ServiceFactory serviceFactory) => ServiceFactory = serviceFactory;

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
    }
}

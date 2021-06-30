using ProcessManagement.Common.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace ProcessManagement.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static void ThrowFaultException(
            string message,
            int statuCode,
            Dictionary<string, string[]> errors = null)
            => throw new FaultException<ErrorModel>(new ErrorModel()
            {
                Message = message,
                StatusCode = statuCode,
                Errors = errors
            });
    }
}

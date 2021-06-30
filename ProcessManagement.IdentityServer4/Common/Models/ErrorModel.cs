using System.Collections.Generic;

namespace ProcessManagement.IdentityServer4.Common.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }

        public int StatusCode { get; set; }
    }
}

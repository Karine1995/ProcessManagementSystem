using System.Collections.Generic;

namespace ProcessManagement.Common.Models._3rdPartyResponses
{
    public class IdentityResponse<TData>
    {
        public string Message { get; set; }

        public TData Data { get; set; }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}

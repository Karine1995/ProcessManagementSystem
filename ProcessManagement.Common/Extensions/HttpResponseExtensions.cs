using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ProcessManagement.Common.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task WriteResponseAsync<T>(this HttpResponse httpResponse, T response, int statusCode)
        {
            string responseJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            httpResponse.StatusCode = statusCode;
            await httpResponse.WriteAsync(responseJson);
        }
    }
}

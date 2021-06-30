using Newtonsoft.Json;
using ProcessManagement.Common.Models;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessManagement.Common.Helpers
{
    public class HttpHelper
    {
        public static async Task<IRestResponse<TResponse>> PostAsync<TResponse>(RequestInfo requestInfo)
        {
            IRestClient client = requestInfo.Client;
            IRestRequest request = requestInfo.Request;

            var cancellationTokenSource = new CancellationTokenSource();

            request.AddJsonBody(requestInfo.Body);

            IRestResponse<TResponse> responseMessage = await client.ExecuteAsync<TResponse>(request, cancellationTokenSource.Token);

            if (!responseMessage.IsSuccessful)
                responseMessage.Data = JsonConvert.DeserializeObject<TResponse>(responseMessage.Content);

            return responseMessage;
        }
    }
}

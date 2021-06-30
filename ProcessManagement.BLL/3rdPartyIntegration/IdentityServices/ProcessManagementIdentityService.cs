using ProcessManagement.Common.Helpers;
using ProcessManagement.Common.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using ProcessManagement.Common.Constants;
using Microsoft.Extensions.Configuration;
using IdentityModel.Client;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.Common.Models._3rdPartyResponses;

namespace ProcessManagement.BLL._3rdPartyIntegration
{
    public class ProcessManagementIdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly DiscoveryDocumentResponse _discoveryDocument;
        private readonly Dictionary<string, string> _headers;
        private readonly string _baseAddress;

        public ProcessManagementIdentityService(IConfiguration configuration)
        {
            _configuration = configuration;
            _discoveryDocument = GetDiscoveryDocumentAsync().GetAwaiter().GetResult();
            _baseAddress = configuration.GetSection(Constants.ProcessManagementIdentity).GetValue<string>(Constants.IdentityBaseAddress);
            _headers = FillHeaders().GetAwaiter().GetResult();
        }

        public async Task<int> RegisterUser(CreateUserInput createUserInput)
        {
            Dictionary<string, object> body = new()
            {
                { "Username", createUserInput.Username },
                { "Email", createUserInput.Email },
                { "Password", createUserInput.Password }
            };

            RequestInfo requestInfo = new(_baseAddress, "Account/Register", Method.POST, body, _headers);

            IRestResponse<IdentityResponse<int?>> identityResponse =
                await HttpHelper.PostAsync<IdentityResponse<int?>>(requestInfo);

            if (identityResponse.StatusCode != HttpStatusCode.OK)
                ExceptionHelper.ThrowFaultException(
                    identityResponse.Data?.Message,
                    (int)identityResponse.StatusCode,
                    identityResponse.Data?.Errors);

            return identityResponse.Data.Data ?? 0;
        }

        #region private methods
        private async Task<Dictionary<string, string>> FillHeaders()
        {
            var tokenResponse = await ClientCredentialsTokenAsync();

            return new Dictionary<string, string>()
            {
                { Constants.Authorization, $"Bearer {tokenResponse.AccessToken}" },
            };
        }

        private async Task<TokenResponse> ClientCredentialsTokenAsync()
        {
            HttpClient client = new();

            var processManagementIdentitySection = _configuration.GetSection(Constants.ProcessManagementIdentity);

            var clientId = processManagementIdentitySection.GetValue<string>(Constants.ClientId);
            var clientSecret = processManagementIdentitySection.GetValue<string>(Constants.ClientSecret);
            var scope = processManagementIdentitySection.GetValue<string>(Constants.Scope);

            return await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = _discoveryDocument.TokenEndpoint,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Scope = scope
                });
        }

        private async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync()
        {
            HttpClient client = new();

            var authority = _configuration.GetSection(Constants.URLSection)
                .GetValue<string>(Constants.Authority);

            return await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = authority
            });
        }
        #endregion
    }
}

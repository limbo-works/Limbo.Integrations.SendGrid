using System;
using Limbo.Integrations.SendGrid.Http;
using Limbo.Integrations.SendGrid.Options.ApiKeys;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>API Keys</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/api-keys</cref>
    /// </see>
    public class SendGridApiKeysRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public SendGridHttpClient Client { get; }

        #endregion

        #region Constructors

        internal SendGridApiKeysRawEndpoint(SendGridHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the API key with the specified <paramref name="apiKeyId"/>.
        /// </summary>
        /// <param name="apiKeyId">The ID of the API key.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-an-existing-api-key</cref>
        /// </see>
        public IHttpResponse GetApiKey(string apiKeyId) {
            if (string.IsNullOrWhiteSpace(apiKeyId)) throw new ArgumentNullException(nameof(apiKeyId));
            return Client.Get($"/v3/api_keys/{apiKeyId}");
        }
        
        /// <summary>
        /// Returns a list of API keys belonging to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
        /// </see>
        public IHttpResponse GetApiKeys() {
            return GetApiKeys(new SendGridGetApiKeyListOptions());
        }
        
        /// <summary>
        /// Returns a list of API keys belonging to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
        /// </see>
        public IHttpResponse GetApiKeys(SendGridGetApiKeyListOptions options) {
            return Client.GetResponse(options);
        }

        #endregion

    }

}
using Limbo.Integrations.SendGrid.Options.ApiKeys;
using Limbo.Integrations.SendGrid.Responses.ApiKeys;

namespace Limbo.Integrations.SendGrid.Endpoints {

    /// <summary>
    /// Implementation of the <strong>API Keys</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/api-keys</cref>
    /// </see>
    public class SendGridApiKeysEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public SendGridHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SendGridApiKeysRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal SendGridApiKeysEndpoint(SendGridHttpService service) {
            Service = service;
            Raw = service.Client.ApiKeys;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the API key with the specified <paramref name="apiKeyId"/>.
        /// </summary>
        /// <param name="apiKeyId">The ID of the API key.</param>
        /// <returns>An instance of <see cref="SendGridApiKeyResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-an-existing-api-key</cref>
        /// </see>
        public SendGridApiKeyResponse GetApiKey(string apiKeyId) {
            return new(Raw.GetApiKey(apiKeyId));
        }

        /// <summary>
        /// Returns a list of API keys belonging to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridApiKeyListResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
        /// </see>
        public SendGridApiKeyListResponse GetApiKeys() {
            return new(Raw.GetApiKeys());
        }
        
        /// <summary>
        /// Returns a list of API keys belonging to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SendGridApiKeyListResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
        /// </see>
        public SendGridApiKeyListResponse GetApiKeys(SendGridGetApiKeyListOptions options) {
            return new(Raw.GetApiKeys(options));
        }

        #endregion

    }

}
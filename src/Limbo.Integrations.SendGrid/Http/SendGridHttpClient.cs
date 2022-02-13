using Limbo.Integrations.SendGrid.Endpoints;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;

namespace Limbo.Integrations.SendGrid.Http {

    /// <summary>
    /// Class for handling the HTTP communication with the SendGrid API.
    /// </summary>
    public class SendGridHttpClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the API token to be used for authentication with the SendGrid API.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Access Management</strong> endpoint.
        /// </summary>
        public SendGridAccessSettingsRawEndpoint AccessSettings { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>API Keys</strong> endpoint.
        /// </summary>
        public SendGridApiKeysRawEndpoint ApiKeys { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public SendGridUsersRawEndpoint Users { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SendGridHttpClient() {
            AccessSettings = new SendGridAccessSettingsRawEndpoint(this);
            ApiKeys = new SendGridApiKeysRawEndpoint(this);
            Users = new SendGridUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The API key to be used.</param>
        public SendGridHttpClient(string apiKey) : this() {
            ApiKey = apiKey;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Prepend the scheme and domain to the URL if not already specified
            if (request.Url.StartsWith("/")) request.Url = $"https://api.sendgrid.com{request.Url}";

            // Add the API key via the "Authorization" header (if specified)
            if (!string.IsNullOrWhiteSpace(ApiKey)) request.Authorization = $"Bearer {ApiKey}";

        }

        #endregion

    }

}
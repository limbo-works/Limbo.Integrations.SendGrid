using System;
using Limbo.Integrations.SendGrid.Endpoints;
using Limbo.Integrations.SendGrid.Http;

namespace Limbo.Integrations.SendGrid {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the SendGrid API.
    /// </summary>
    public class SendGridHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        public SendGridHttpClient Client { get; set; }

        /// <summary>
        /// Gets a reference to the <strong>Access Management</strong> endpoint.
        /// </summary>
        public SendGridAccessSettingsEndpoint AccessSettings { get; }

        /// <summary>
        /// Gets a reference to the <strong>API Keys</strong> endpoint.
        /// </summary>
        public SendGridApiKeysEndpoint ApiKeys { get; }

        /// <summary>
        /// Gets a reference to the <strong>Users</strong> endpoint.
        /// </summary>
        public SendGridUsersEndpoint Users { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options
        /// </summary>
        public SendGridHttpService(SendGridHttpClient client) {
            Client = client;
            AccessSettings = new SendGridAccessSettingsEndpoint(this);
            ApiKeys = new SendGridApiKeysEndpoint(this);
            Users = new SendGridUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="SendGridHttpService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="SendGridHttpService"/>.</returns>
        public static SendGridHttpService CreateFromClient(SendGridHttpClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new SendGridHttpService(client);
        }
        /// <summary>
        /// Returns a new instance of <see cref="SendGridHttpService"/> based on the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The API key to be used.</param>
        /// <returns>A new instance of <see cref="SendGridHttpService"/>.</returns>
        public static SendGridHttpService CreateFromApiKey(string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));
            return new SendGridHttpService(new SendGridHttpClient {
                ApiKey = apiKey
            });
        }

        #endregion

    }

}
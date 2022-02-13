using System;
using Limbo.Integrations.SendGrid.Http;
using Limbo.Integrations.SendGrid.Options.AccessSettings;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>Access Settings</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management</cref>
    /// </see>
    public class SendGridAccessSettingsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public SendGridHttpClient Client { get; }

        #endregion

        #region Constructors

        internal SendGridAccessSettingsRawEndpoint(SendGridHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the whitelist rule with the specified <paramref name="ruleId"/>.
        /// </summary>
        /// <param name="ruleId">The ID of the allowed IP address that you want to retrieve.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-specific-allowed-ip</cref>
        /// </see>
        public IHttpResponse GetWhitelistRule(string ruleId) {
            if (string.IsNullOrWhiteSpace(ruleId)) throw new ArgumentNullException(nameof(ruleId));
            return Client.Get($"/v3/access_settings/whitelist/{ruleId}");
        }

        /// <summary>
        /// Returns a list of currently allowed IPs.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-list-of-currently-allowed-ips</cref>
        /// </see>
        public IHttpResponse GetWhitelist() {
            return Client.Get("/v3/access_settings/whitelist");
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public IHttpResponse GetRecentAccessAttempts() {
            return GetRecentAccessAttempts(new SendGridGetAccessAttemptListOptions());
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <param name="limit">The maximum amount of access attempts to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public IHttpResponse GetRecentAccessAttempts(int limit) {
            return GetRecentAccessAttempts(new SendGridGetAccessAttemptListOptions(limit));
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public IHttpResponse GetRecentAccessAttempts(SendGridGetAccessAttemptListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}
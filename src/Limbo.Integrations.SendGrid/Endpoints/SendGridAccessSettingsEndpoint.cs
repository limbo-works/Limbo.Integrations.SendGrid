using Limbo.Integrations.SendGrid.Options.AccessSettings;
using Limbo.Integrations.SendGrid.Responses.AccessSettings;

namespace Limbo.Integrations.SendGrid.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Access Settings</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management</cref>
    /// </see>
    public class SendGridAccessSettingsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public SendGridHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SendGridAccessSettingsRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal SendGridAccessSettingsEndpoint(SendGridHttpService service) {
            Service = service;
            Raw = service.Client.AccessSettings;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns information about the whitelist rule with the specified <paramref name="ruleId"/>.
        /// </summary>
        /// <param name="ruleId">The ID of the allowed IP address that you want to retrieve.</param>
        /// <returns>An instance of <see cref="SendGridWhitelistRuleResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-specific-allowed-ip</cref>
        /// </see>
        public SendGridWhitelistRuleResponse GetWhitelistRule(string ruleId) {
            return new(Raw.GetWhitelistRule(ruleId));
        }

        /// <summary>
        /// Returns a list of currently allowed IPs.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridWhitelistResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-list-of-currently-allowed-ips</cref>
        /// </see>
        public SendGridWhitelistResponse GetWhitelist() {
            return new(Raw.GetWhitelist());
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridAccessAttemptListResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public SendGridAccessAttemptListResponse GetRecentAccessAttempts() {
            return new(Raw.GetRecentAccessAttempts());
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <param name="limit">The maximum amount of access attempts to be returned.</param>
        /// <returns>An instance of <see cref="SendGridAccessAttemptListResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public SendGridAccessAttemptListResponse GetRecentAccessAttempts(int limit) {
            return new(Raw.GetRecentAccessAttempts(limit));
        }

        /// <summary>
        /// Returns a list of recent access attempts.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SendGridAccessAttemptListResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
        /// </see>
        public SendGridAccessAttemptListResponse GetRecentAccessAttempts(SendGridGetAccessAttemptListOptions options) {
            return new(Raw.GetRecentAccessAttempts(options));
        }

        #endregion

    }

}
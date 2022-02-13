using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Limbo.Integrations.SendGrid.Options.AccessSettings {

    /// <summary>
    /// Options for getting a list of API Keys.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
    /// </see>
    public class SendGridGetAccessAttemptListOptions : IHttpRequestOptions {

        #region Member methods

        /// <summary>
        /// Gets or sets the maximum amount if access attempts to be returned. Default is <c>null</c>.
        /// </summary>
        public int? Limit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public SendGridGetAccessAttemptListOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="limit"/>.
        /// </summary>
        /// <param name="limit">The maximum amount of access attempts to be returned.</param>
        public SendGridGetAccessAttemptListOptions(int limit) {
            Limit = limit;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (Limit != null) query.Add("limit", Limit);

            return HttpRequest.Get("/v3/access_settings/activity", query);

        }

        #endregion

    }

}
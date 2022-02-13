using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Limbo.Integrations.SendGrid.Options.ApiKeys {

    /// <summary>
    /// Options for getting a list of API Keys.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
    /// </see>
    public class SendGridGetApiKeyListOptions : IHttpRequestOptions {

        #region Member methods

        /// <summary>
        /// Gets or sets the maximum amount if API keys to be returned. Default is <c>null</c>.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset. Default is <c>null</c>.
        /// </summary>
        public int? Offset { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();

            if (Limit != null) query.Add("limit", Limit);
            if (Offset != null) query.Add("offset", Offset);

            return HttpRequest.Get("/v3/api_keys", query);

        }

        #endregion

    }

}
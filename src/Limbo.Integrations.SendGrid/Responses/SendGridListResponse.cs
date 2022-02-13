using Limbo.Integrations.SendGrid.Models.Headers;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses {

    /// <summary>
    /// Class representing a list based response from the SendGrid API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SendGridListResponse<T> : SendGridResponse<T> {

        #region Properties

        /// <summary>
        /// Gets a reference to the <c>Link</c> header of the response.
        /// </summary>
        public SendGridLinkHeader Link { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        protected SendGridListResponse(IHttpResponse response) : base(response) {
            Link = SendGridLinkHeader.Parse(response);
        }

        #endregion

    }

}
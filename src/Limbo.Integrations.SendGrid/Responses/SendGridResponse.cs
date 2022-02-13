using System.Net;
using Limbo.Integrations.SendGrid.Exceptions;
using Limbo.Integrations.SendGrid.Models.Errors;
using Limbo.Integrations.SendGrid.Models.Headers;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json;

namespace Limbo.Integrations.SendGrid.Responses {

    /// <summary>
    /// Class representing a response from the SendGrid API.
    /// </summary>
    public class SendGridResponse : HttpResponseBase {

        #region Properties

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public SendGridRateLimiting RateLimiting { get; }

        /// <summary>
        /// Gets whether rate limiting informatyion is available for this response. 
        /// </summary>
        public bool HasRateLimit => RateLimiting != null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridResponse(IHttpResponse response) : base(response) {

            if (response.Headers["x-ratelimit-limit"] != null) RateLimiting = SendGridRateLimiting.GetFromResponse(response);

            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;
            if (response.StatusCode == HttpStatusCode.NoContent) return;

            SendGridErrorList body = JsonUtils.ParseJsonObject(response.Body, SendGridErrorList.Parse);

            throw new SendGridHttpException(response, body);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the SendGrid API.
    /// </summary>
    public class SendGridResponse<T> : SendGridResponse {

        /// <summary>
        /// /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridResponse(IHttpResponse response) : base(response) { }

    }

}
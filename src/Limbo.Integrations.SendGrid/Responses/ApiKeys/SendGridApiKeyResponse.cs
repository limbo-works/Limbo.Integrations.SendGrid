using Limbo.Integrations.SendGrid.Models.ApiKeys;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.ApiKeys {

    /// <summary>
    /// Class representing a response with information about a SendGrid API key.
    /// </summary>
    public class SendGridApiKeyResponse : SendGridListResponse<SendGridApiKey> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridApiKeyResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridApiKey.Parse);
        }

    }

}
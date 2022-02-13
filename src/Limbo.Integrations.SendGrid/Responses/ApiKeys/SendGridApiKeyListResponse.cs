using Limbo.Integrations.SendGrid.Models.ApiKeys;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.ApiKeys {

    /// <summary>
    /// Class representing a response with a list of SendGrid API keys.
    /// </summary>
    public class SendGridApiKeyListResponse : SendGridListResponse<SendGridApiKeyList> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridApiKeyListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridApiKeyList.Parse);
        }

    }

}
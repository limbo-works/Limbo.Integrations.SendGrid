using Limbo.Integrations.SendGrid.Models.AccessSettings;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.AccessSettings {

    /// <summary>
    /// Class representing a response with a <see cref="SendGridWhitelist"/>.
    /// </summary>
    public class SendGridWhitelistResponse : SendGridListResponse<SendGridWhitelist> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridWhitelistResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridWhitelist.Parse);
        }

    }

}
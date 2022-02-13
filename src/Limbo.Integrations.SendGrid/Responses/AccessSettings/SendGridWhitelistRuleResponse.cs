using Limbo.Integrations.SendGrid.Models.AccessSettings;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.AccessSettings {

    /// <summary>
    /// Class representing a response with information about a whitelist rule (allowed IP address).
    /// </summary>
    public class SendGridWhitelistRuleResponse : SendGridListResponse<SendGridWhitelistRuleResult> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridWhitelistRuleResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridWhitelistRuleResult.Parse);
        }

    }

}
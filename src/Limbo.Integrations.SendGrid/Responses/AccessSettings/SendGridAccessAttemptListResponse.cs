using Limbo.Integrations.SendGrid.Models.AccessSettings;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.AccessSettings {

    /// <summary>
    /// Class representing a response with a <see cref="SendGridAccessAttemptList"/>.
    /// </summary>
    public class SendGridAccessAttemptListResponse : SendGridResponse<SendGridAccessAttemptList> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridAccessAttemptListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridAccessAttemptList.Parse);
        }

    }

}
using Limbo.Integrations.SendGrid.Models.Users;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Responses.Users {

    /// <summary>
    /// Class representing a response with the username of a SendGrid user.
    /// </summary>
    public class SendGridUserUsernameResponse : SendGridListResponse<SendGridUserUsername> {
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridUserUsernameResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, SendGridUserUsername.Parse);
        }

    }

}
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Users {
    
    /// <summary>
    /// Class representing an object with the email address of a SendGrid user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-account-email-address</cref>
    /// </see>
    public class SendGridUserEmail : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SendGridUserEmail(JObject json) : base(json) {
            Email = json.GetString("email");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridUserEmail"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridUserEmail"/>.</returns>
        public static SendGridUserEmail Parse(JObject json) {
            return json == null ? null : new SendGridUserEmail(json);
        }

        #endregion

    }

}
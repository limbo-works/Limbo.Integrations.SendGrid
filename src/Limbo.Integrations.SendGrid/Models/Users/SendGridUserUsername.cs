using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Users {
    
    /// <summary>
    /// Class representing an object with the username of a SendGrid user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-username</cref>
    /// </see>
    public class SendGridUserUsername : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the user ID for your account.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Gets your account username.
        /// </summary>
        public string Username { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SendGridUserUsername(JObject json) : base(json) {
            UserId = json.GetInt32("user_id");
            Username = json.GetString("username");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridUserUsername"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridUserUsername"/>.</returns>
        public static SendGridUserUsername Parse(JObject json) {
            return json == null ? null : new SendGridUserUsername(json);
        }

        #endregion

    }

}
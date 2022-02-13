using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Users {
    
    /// <summary>
    /// Class representing a SendGrid API user account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-account-information</cref>
    /// </see>
    public class SendGridUserAccount : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the type of account for this user.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the sender reputation for this user.
        /// </summary>
        /// <remarks>The SendGrid APi documentation indicates that the type is <c>number</c>, which is a bit unclear.
        /// As a result of this, the value is parsed as <see cref="float"/>, even though it might always be an
        /// <see cref="int"/>.</remarks>
        public float Reputation { get; }

        /// <summary>
        /// Gets whether this user is a reseller.
        /// </summary>
        /// <remarks>This property is not documented by SendGrid.</remarks>
        public bool IsResellerCustomer { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        public SendGridUserAccount(JObject json) : base(json) {
            Type = json.GetString("name");
            Reputation = json.GetFloat("api_key_id");
            IsResellerCustomer = json.GetBoolean("is_reseller_customer");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridUserAccount"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridUserAccount"/>.</returns>
        public static SendGridUserAccount Parse(JObject json) {
            return json == null ? null : new SendGridUserAccount(json);
        }

        #endregion

    }

}
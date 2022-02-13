using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Users {

    /// <summary>
    /// Class representing a SendGrid user profile.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-profile</cref>
    /// </see>
    public class SendGridUserProfile : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the user's address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets the second line of the user's address.
        /// </summary>
        public string Address2 { get; }

        /// <summary>
        /// Gets the user's city.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// The name of the user's company.
        /// </summary>
        public string Company { get; }

        /// <summary>
        /// The user's country.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// The user's phone number.
        /// </summary>
        public string Phone { get; }

        /// <summary>
        /// The user's state.
        /// </summary>
        public string State { get; }

        /// <summary>
        /// The user's website URL.
        /// </summary>
        public string Website { get; }
        
        /// <summary>
        /// The user's zip code.
        /// </summary>
        public string Zip { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the user profile.</param>
        public SendGridUserProfile(JObject json) : base(json) {
            Address = json.GetString("address");
            Address2 = json.GetString("address2");
            City = json.GetString("city");
            Company = json.GetString("company");
            Country = json.GetString("country");
            FirstName = json.GetString("first_name");
            LastName = json.GetString("last_name");
            Phone = json.GetString("phone");
            State = json.GetString("state");
            Website = json.GetString("website");
            Zip = json.GetString("zip");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridUserProfile"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridUserProfile"/>.</returns>
        public static SendGridUserProfile Parse(JObject json) {
            return json == null ? null : new SendGridUserProfile(json);
        }

        #endregion

    }

}
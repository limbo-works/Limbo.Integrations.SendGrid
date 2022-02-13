using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.SendGrid.Models.AccessSettings {
    
    /// <summary>
    /// Class representing an access attempt to SendGrid account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
    /// </see>
    public class SendGridAccessAttempt : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets whether the IP address was granted access to the account.
        /// </summary>
        public bool IsAllowed { get; }

        /// <summary>
        /// Gets the authentication method used when attempting access.
        /// </summary>
        public string AuthMethod { get; }

        /// <summary>
        /// Gets a timestamp indicating when the first access attempt was made.
        /// </summary>
        public EssentialsTime FirstAt { get; }

        /// <summary>
        /// Gets the IP address used during the access attempt.
        /// </summary>
        public string Ip { get; }

        /// <summary>
        /// Gets a timestamp indicating when the most recent access attempt was made
        /// </summary>
        public EssentialsTime LastAt { get; }

        /// <summary>
        /// Gets the geographic location from which the access attempt originated.
        /// </summary>
        public string Location { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        protected SendGridAccessAttempt(JObject json) : base(json) {
            IsAllowed = json.GetBoolean("allowed");
            AuthMethod = json.GetString("auth_method");
            FirstAt = json.GetDouble("first_at", EssentialsTime.FromUnixTimestamp);
            Ip = json.GetString("ip");
            LastAt = json.GetDouble("last_at", EssentialsTime.FromUnixTimestamp);
            Location = json.GetString("location");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridAccessAttempt"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridAccessAttempt"/>.</returns>
        public static SendGridAccessAttempt Parse(JObject json) {
            return json == null ? null : new SendGridAccessAttempt(json);
        }

        #endregion

    }

}
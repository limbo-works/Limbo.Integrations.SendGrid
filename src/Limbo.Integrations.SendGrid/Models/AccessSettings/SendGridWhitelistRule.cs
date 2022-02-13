using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.SendGrid.Models.AccessSettings {
    
    /// <summary>
    /// Class representing whitelist rule of a SendGrid account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-list-of-currently-allowed-ips</cref>
    /// </see>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-specific-allowed-ip</cref>
    /// </see>
    public class SendGridWhitelistRule : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the allowed IP.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the allowed IP.
        /// </summary>
        public string Ip { get; }

        /// <summary>
        /// Gets a timestamp indicating when the IP was added to the allow list.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp indicating when the IPs allow status was most recently updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        public SendGridWhitelistRule(JObject json) : base(json) {
            Id = json.GetString("id");
            Ip = json.GetString("ip");
            CreatedAt = json.GetDouble("created_at", EssentialsTime.FromUnixTimestamp);
            UpdatedAt = json.GetDouble("updated_at", EssentialsTime.FromUnixTimestamp);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridWhitelistRule"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridWhitelistRule"/>.</returns>
        public static SendGridWhitelistRule Parse(JObject json) {
            return json == null ? null : new SendGridWhitelistRule(json);
        }

        #endregion

    }

}
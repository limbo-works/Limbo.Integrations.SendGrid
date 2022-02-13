using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.ApiKeys {

    /// <summary>
    /// Class representing a SendGrid API key.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/api-keys/retrieve-all-api-keys-belonging-to-the-authenticated-user</cref>
    /// </see>
    public class SendGridApiKey : SendGridApiKeyItem {

        #region Properties

        /// <summary>
        /// Gets an array of the scopes enabled for the API key.
        /// </summary>
        public string[] Scopes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        public SendGridApiKey(JObject json) : base(json) {
            Scopes = json.GetStringArray("scopes");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridApiKey"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridApiKey"/>.</returns>
        public static new SendGridApiKey Parse(JObject json) {
            return json == null ? null : new SendGridApiKey(json);
        }

        #endregion

    }

}
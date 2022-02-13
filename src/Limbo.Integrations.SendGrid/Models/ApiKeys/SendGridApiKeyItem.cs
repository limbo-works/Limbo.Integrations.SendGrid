using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.ApiKeys {

    /// <summary>
    /// Class representing a SendGrid API key item.
    /// </summary>
    public class SendGridApiKeyItem : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the friendly name of the API key.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID of the API key.
        /// </summary>
        public string ApiKeyId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        public SendGridApiKeyItem(JObject json) : base(json) {
            Name = json.GetString("name");
            ApiKeyId = json.GetString("api_key_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridApiKeyItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridApiKeyItem"/>.</returns>
        public static SendGridApiKeyItem Parse(JObject json) {
            return json == null ? null : new SendGridApiKeyItem(json);
        }

        #endregion

    }

}
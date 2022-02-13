using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.ApiKeys {

    /// <summary>
    /// Class representing a list of SendGrid API keys.
    /// </summary>
    public class SendGridApiKeyList : SendGridObject, IEnumerable<SendGridApiKeyItem> {

        #region Properties

        /// <summary>
        /// Gets an array representing the API keys in the list.
        /// </summary>
        public SendGridApiKeyItem[] Result { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SendGridApiKeyList(JObject json) : base(json) {
            Result = json.GetArrayItems("result", x => new SendGridApiKeyItem(x));
        }

        #endregion

        #region Member methods
        
        /// <inheritdoc />
        public IEnumerator<SendGridApiKeyItem> GetEnumerator() {
            return ((IEnumerable<SendGridApiKeyItem>) Result).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridApiKeyList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridApiKeyList"/>.</returns>
        public static SendGridApiKeyList Parse(JObject json) {
            return json == null ? null : new SendGridApiKeyList(json);
        }

        #endregion

    }

}
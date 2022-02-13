using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.AccessSettings {

    /// <summary>
    /// Class representing the whitelist of a SendGrid account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-list-of-currently-allowed-ips</cref>
    /// </see>
    public class SendGridWhitelist : SendGridObject, IEnumerable<SendGridWhitelistRule> {

        #region Properties
        
        /// <summary>
        /// Gets an array representing the rules in the list.
        /// </summary>
        public SendGridWhitelistRule[] Result { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the user profile.</param>
        public SendGridWhitelist(JObject json) : base(json) {
            Result = json.GetArrayItems("result", SendGridWhitelistRule.Parse);
        }

        #endregion

        #region Member methods
        
        /// <inheritdoc />
        public IEnumerator<SendGridWhitelistRule> GetEnumerator() {
            return ((IEnumerable<SendGridWhitelistRule>) Result).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridWhitelist"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridWhitelist"/>.</returns>
        public static SendGridWhitelist Parse(JObject json) {
            return json == null ? null : new SendGridWhitelist(json);
        }

        #endregion

    }

}
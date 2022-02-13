using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.AccessSettings {
    
    /// <summary>
    /// Class representing whitelist rule of a SendGrid account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-a-specific-allowed-ip</cref>
    /// </see>
    public class SendGridWhitelistRuleResult : SendGridObject {

        #region Properties

        /// <summary>
        /// A reference to the requested rule.
        /// </summary>
        public SendGridWhitelistRule Result { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SendGridWhitelistRuleResult(JObject json) : base(json) {
            Result = json.GetObject("result", SendGridWhitelistRule.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridWhitelistRuleResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridWhitelistRuleResult"/>.</returns>
        public static SendGridWhitelistRuleResult Parse(JObject json) {
            return json == null ? null : new SendGridWhitelistRuleResult(json);
        }

        #endregion

    }

}
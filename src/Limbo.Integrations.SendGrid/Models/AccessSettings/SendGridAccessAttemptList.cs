using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.AccessSettings {
    
    /// <summary>
    /// Class representing a list of access attempts to SendGrid account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/ip-access-management/retrieve-all-recent-access-attempts</cref>
    /// </see>
    public class SendGridAccessAttemptList : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the list of access attempts returned in the response.
        /// </summary>
        public IList<SendGridAccessAttempt> Result { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the API key.</param>
        protected SendGridAccessAttemptList(JObject json) : base(json) {
            Result = Array.AsReadOnly(json.GetArrayItems("result", SendGridAccessAttempt.Parse));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridAccessAttemptList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridAccessAttemptList"/>.</returns>
        public static SendGridAccessAttemptList Parse(JObject json) {
            return json == null ? null : new SendGridAccessAttemptList(json);
        }

        #endregion

    }

}
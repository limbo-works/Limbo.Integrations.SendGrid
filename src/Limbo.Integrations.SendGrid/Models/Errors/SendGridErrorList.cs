using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Errors {

    /// <summary>
    /// Class representing a a list of errors as returned by the SendGrid API.
    /// </summary>
    public class SendGridErrorList : SendGridObject, IEnumerable<SendGridError> {

        #region Properties

        /// <summary>
        /// Gets an array of individual errors.
        /// </summary>
        public SendGridError[] Errors { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the error.</param>
        public SendGridErrorList(JObject json) : base(json) {
            Errors = json.GetArrayItems("errors", SendGridError.Parse);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IEnumerator<SendGridError> GetEnumerator() {
            return ((IEnumerable<SendGridError>) Errors).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridErrorList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridErrorList"/>.</returns>
        public static SendGridErrorList Parse(JObject json) {
            return json == null ? null : new SendGridErrorList(json);
        }

        #endregion

    }

}
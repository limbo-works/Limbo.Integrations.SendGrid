using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.SendGrid.Models.Errors {

    /// <summary>
    /// Class representing an error as returned by the SendGrid API.
    /// </summary>
    public class SendGridError : SendGridObject {

        #region Properties

        /// <summary>
        /// Gets the field that triggered the error. May be <c>null</c> if the error is not related to a field.
        /// </summary>
        public string Field { get; }

        /// <summary>
        /// Gets the message of the error.
        /// </summary>
        public string Message { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the error.</param>
        public SendGridError(JObject json) : base(json) {
            Field = json.GetString("field");
            Message = json.GetString("message");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridError"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridError"/>.</returns>
        public static SendGridError Parse(JObject json) {
            return json == null ? null : new SendGridError(json);
        }

        #endregion

    }

}
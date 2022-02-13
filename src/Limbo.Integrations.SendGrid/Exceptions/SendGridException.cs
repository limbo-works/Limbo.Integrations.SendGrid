using System;

namespace Limbo.Integrations.SendGrid.Exceptions {

    /// <summary>
    /// Class representing a basic SendGrid exception.
    /// </summary>
    public class SendGridException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public SendGridException(string message) : base(message) { }

    }

}
using System.Net;
using Limbo.Integrations.SendGrid.Models.Errors;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Limbo.Integrations.SendGrid.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the SendGrid API.
    /// </summary>
    public class SendGridHttpException : SendGridException, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the SendGrid API.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the list of errors as returned by the SendGrid API.
        /// </summary>
        public SendGridErrorList ErrorList { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public SendGridHttpException(IHttpResponse response) : base("Invalid response received from the SendGrid API (status: " + (int) response.StatusCode + ")") {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <param name="errorList">The list of errors returned by the API.</param>
        public SendGridHttpException(IHttpResponse response, SendGridErrorList errorList) : base("Invalid response received from the SendGrid API (status: " + (int) response.StatusCode + ")") {
            Response = response;
            ErrorList = errorList;
        }
        
        #endregion

    }

}
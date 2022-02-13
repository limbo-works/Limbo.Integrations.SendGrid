using Limbo.Integrations.SendGrid.Http;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.SendGrid.Endpoints {
    
    /// <summary>
    /// Raw implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api</cref>
    /// </see>
    public class SendGridUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public SendGridHttpClient Client { get; }

        #endregion

        #region Constructors

        internal SendGridUsersRawEndpoint(SendGridHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns the profile of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-profile</cref>
        /// </see>
        public IHttpResponse GetProfile() {
            return Client.Get("/v3/user/profile");
        }

        /// <summary>
        /// Returns the account information of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-account-information</cref>
        /// </see>
        public IHttpResponse GetAccount() {
            return Client.Get("/v3/user/account");
        }

        /// <summary>
        /// Returns the email address of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-account-email-address</cref>
        /// </see>
        public IHttpResponse GetEmail() {
            return Client.Get("/v3/user/email");
        }

        /// <summary>
        /// Returns the username of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-username</cref>
        /// </see>
        public IHttpResponse GetUsername() {
            return Client.Get("/v3/user/username");
        }

        /// <summary>
        /// Returns the credit balance of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-credit-balance</cref>
        /// </see>
        public IHttpResponse GetCredits() {
            return Client.Get("/v3/user/credits");
        }

        #endregion

    }

}
using Limbo.Integrations.SendGrid.Responses.Users;

namespace Limbo.Integrations.SendGrid.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api</cref>
    /// </see>
    public class SendGridUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public SendGridHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public SendGridUsersRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal SendGridUsersEndpoint(SendGridHttpService service) {
            Service = service;
            Raw = service.Client.Users;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns the profile of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridUserProfileResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-profile</cref>
        /// </see>
        public SendGridUserProfileResponse GetProfile() {
            return new(Raw.GetProfile());
        }

        /// <summary>
        /// Returns the account information of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridUserAccountResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/get-a-users-account-information</cref>
        /// </see>
        public SendGridUserAccountResponse GetAccount() {
            return new(Raw.GetAccount());
        }

        /// <summary>
        /// Returns the email address of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridUserEmailResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-account-email-address</cref>
        /// </see>
        public SendGridUserEmailResponse GetEmail() {
            return new(Raw.GetEmail());
        }

        /// <summary>
        /// Returns the username of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridUserUsernameResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-username</cref>
        /// </see>
        public SendGridUserUsernameResponse GetUsername() {
            return new(Raw.GetUsername());
        }

        /// <summary>
        /// Returns the credit balance of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SendGridUserCreditsResponse"/> representing the response from the API.</returns>
        /// <see>
        ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-credit-balance</cref>
        /// </see>
        public SendGridUserCreditsResponse GetCredits() {
            return new(Raw.GetCredits());
        }

        #endregion

    }

}
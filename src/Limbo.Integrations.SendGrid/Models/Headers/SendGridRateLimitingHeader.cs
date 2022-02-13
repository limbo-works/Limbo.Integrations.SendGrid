using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.SendGrid.Models.Headers {

    /// <summary>
    /// Class with rate-limiting information about a response from the SendGrid API.
    /// </summary>
    public class SendGridRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total amount of calls that can be made to the API in the current timeframe.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the remaining amount of calls that can be made to the API in the current
        /// timeframe.
        /// </summary>
        public int Remaining { get; }

        /// <summary>
        /// Gets the timestamp of the next rate limit timeframe.
        /// </summary>
        public EssentialsTime Reset { get; }

        #endregion

        #region Constructors

        private SendGridRateLimiting(IHttpResponse response) {

            int.TryParse(response.Headers["x-ratelimit-limit"], out int limit);
            int.TryParse(response.Headers["x-ratelimit-remaining"], out int remaining);

            Limit = limit;
            Remaining = remaining;
            Reset = double.TryParse(response.Headers["x-ratelimit-reset"], out double reset) ? EssentialsTime.FromUnixTimestamp(reset) : null;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>An instance of <see cref="SendGridRateLimiting"/>.</returns>
        public static SendGridRateLimiting GetFromResponse(IHttpResponse response) {
            return new SendGridRateLimiting(response);
        }

        #endregion

    }

}
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.SendGrid.Models.Users {
    
    /// <summary>
    /// Class representing an object with the credit balance of a SendGrid user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.sendgrid.com/api-reference/users-api/retrieve-your-credit-balance</cref>
    /// </see>
    public class SendGridUserCredits : SendGridObject {

        #region Properties

        /// <summary>
        /// The remaining number of credits available on your account.
        /// </summary>
        public int Remain { get; }

        /// <summary>
        /// The total number of credits assigned to your account.
        /// </summary>
        public int Total { get; }
        
        /// <summary>
        /// The number of overdrawn credits for your account.
        /// </summary>
        public int Overage { get; }
        
        /// <summary>
        /// The number of credits that you have used.
        /// </summary>
        public int Used { get; }

        /// <summary>
        /// The date that your credit balance was last reset.
        /// </summary>
        public EssentialsDate LastReset { get; }

        /// <summary>
        /// The next date that your credit balance will be reset.
        /// </summary>
        public EssentialsDate NextReset { get; }
            
        /// <summary>
        /// The frequency at which your credit balance will be reset.
        /// </summary>
        public string ResetFrequency { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected SendGridUserCredits(JObject json) : base(json) {
            Remain = json.GetInt32("remain");
            Total = json.GetInt32("total");
            Overage = json.GetInt32("overage");
            Used = json.GetInt32("used");
            LastReset = json.GetString("last_reset", EssentialsDate.Parse);
            NextReset = json.GetString("next_reset", EssentialsDate.Parse);
            ResetFrequency = json.GetString("reset_frequency");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="SendGridUserCredits"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="SendGridUserCredits"/>.</returns>
        public static SendGridUserCredits Parse(JObject json) {
            return json == null ? null : new SendGridUserCredits(json);
        }

        #endregion

    }

}
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Limbo.Integrations.SendGrid.Models {

    /// <summary>
    /// Class representing a basic object from the SendGrid API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class SendGridObject : JsonObjectBase {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        public SendGridObject(JObject json) : base(json) { }

    }

}
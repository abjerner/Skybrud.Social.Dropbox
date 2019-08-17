using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Dropbox.Models {

    /// <summary>
    /// Class representing an object received from the Dropbox API.
    /// </summary>
    public class DropboxObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected DropboxObject(JObject obj) : base(obj) { }

        #endregion

    }

}
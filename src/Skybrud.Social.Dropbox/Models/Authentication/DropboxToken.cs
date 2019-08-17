using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Authentication {
    
    /// <summary>
    /// Class representing with information about an access token as received from the Dropbox API.
    /// </summary>
    public class DropboxToken : DropboxObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the access token. This will always be <c>bearer</c>.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets the account indentifier of the authenticated user.
        /// </summary>
        public string AccountId { get; }

        #endregion

        #region Constructors

        private DropboxToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            AccountId = obj.GetString("account_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxToken"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxToken"/>.</returns>
        public static DropboxToken Parse(JObject obj) {
            return obj == null ? null : new DropboxToken(obj);
        }

        #endregion

    }

}
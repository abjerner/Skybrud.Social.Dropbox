﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Objects.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get an access token.
    /// </summary>
    public class DropboxTokenResponseBody : DropboxObject {

        #region Properties

        public string AccessToken { get; }

        public string TokenType { get; }

        public string UserId { get; }

        #endregion

        #region Constructors

        private DropboxTokenResponseBody(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            UserId = obj.GetString("uid");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>DropboxTokenResponseBody</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static DropboxTokenResponseBody Parse(JObject obj) {
            return obj == null ? null : new DropboxTokenResponseBody(obj);
        }

        #endregion

    }

}
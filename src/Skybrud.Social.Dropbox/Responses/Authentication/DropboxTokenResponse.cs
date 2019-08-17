using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Models.Authentication;

namespace Skybrud.Social.Dropbox.Responses.Authentication {
    
    public class DropboxTokenResponse : DropboxResponse<DropboxToken> {
        
        #region Constructors

        private DropboxTokenResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, DropboxToken.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="DropboxTokenResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="DropboxTokenResponse"/>.</returns>
        public static DropboxTokenResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new DropboxTokenResponse(response);
        }

        #endregion

    }

}
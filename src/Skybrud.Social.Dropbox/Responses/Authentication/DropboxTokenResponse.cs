using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Objects.Authentication;

namespace Skybrud.Social.Dropbox.Responses.Authentication {
    
    public class DropboxTokenResponse : DropboxResponse<DropboxTokenResponseBody> {
        
        #region Constructors

        private DropboxTokenResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>DropboxTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>DropboxTokenResponse</code>.</returns>
        public static DropboxTokenResponse ParseResponse(IHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException(nameof(response));
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new DropboxTokenResponse(response) {
                Body = ParseJsonObject(response.Body, DropboxTokenResponseBody.Parse)
            };

        }

        #endregion

    }

}
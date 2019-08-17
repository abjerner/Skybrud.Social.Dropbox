using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Models.Files;

namespace Skybrud.Social.Dropbox.Responses.Files {

    public class DropboxListFolderResponse : DropboxResponse<DropboxListFolderResult> {
        
        #region Constructors

        private DropboxListFolderResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, DropboxListFolderResult.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="DropboxListFolderResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="DropboxListFolderResponse"/>.</returns>
        public static DropboxListFolderResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new DropboxListFolderResponse(response);
        }

        #endregion

    }

}
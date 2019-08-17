using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Models.Files;

namespace Skybrud.Social.Dropbox.Responses.Files {

    /// <summary>
    /// Options for a request to download a single Dropbox file.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
    /// </see>
    public class DropboxDownloadResponse : DropboxResponse {

        #region Properties

        /// <summary>
        /// Gets an array of <see cref="byte"/> representing the binary contents of the file.
        /// </summary>
        public byte[] Body => Response.BinaryBody;

        /// <summary>
        /// Gets metadata about the downloaded file.
        /// </summary>
        public DropboxFileMetadata Result { get; }

        #endregion

        #region Constructors

        private DropboxDownloadResponse(IHttpResponse response) : base(response) {
            string result = response.Headers["dropbox-api-result"];
            if (string.IsNullOrWhiteSpace(result)) return;
            Result = ParseJsonObject(result, DropboxFileMetadata.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="DropboxDownloadResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="DropboxDownloadResponse"/>.</returns>
        public static DropboxDownloadResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new DropboxDownloadResponse(response);
        }

        #endregion

    }

}
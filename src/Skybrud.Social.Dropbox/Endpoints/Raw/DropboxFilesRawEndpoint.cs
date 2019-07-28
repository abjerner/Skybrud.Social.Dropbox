using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.OAuth;
using Skybrud.Social.Dropbox.Options;

namespace Skybrud.Social.Dropbox.Endpoints.Raw {
    
    public class DropboxFilesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public DropboxOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal DropboxFilesRawEndpoint(DropboxOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public IHttpResponse GetMetadata(string path, DropboxGetMetadataOptions options) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Get("https://api.dropboxapi.com/1/metadata/" + path, options);
        }

        #endregion

    }

}
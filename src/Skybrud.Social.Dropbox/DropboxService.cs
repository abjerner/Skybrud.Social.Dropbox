using System;
using Skybrud.Social.Dropbox.Endpoints;
using Skybrud.Social.Dropbox.OAuth;

namespace Skybrud.Social.Dropbox {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the Toggl API.
    /// </summary>
    public class DropboxService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying OAuth client.
        /// </summary>
        public DropboxOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>Files</strong> endpoint.
        /// </summary>
        public DropboxFilesEndpoint Files { get; }

        #endregion

        #region Constructors

        private DropboxService(DropboxOAuthClient client) {
            Client = client;
            Files = new DropboxFilesEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="DropboxService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="DropboxService"/>.</returns>
        public static DropboxService CreateFromClient(DropboxOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new DropboxService(client);
        }

        /// <summary>
        /// Returns a new instance of <see cref="DropboxService"/> based on the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to be used.</param>
        /// <returns>A new instance of <see cref="DropboxService"/>.</returns>
        public static DropboxService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new DropboxService(new DropboxOAuthClient(accessToken));
        }

        #endregion

    }

}
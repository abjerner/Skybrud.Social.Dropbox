using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.Dropbox.Models.Files;
using Skybrud.Social.Dropbox.OAuth;
using Skybrud.Social.Dropbox.Options.Files;

namespace Skybrud.Social.Dropbox.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Files</strong> endpoint.
    /// </summary>
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

        public IHttpResponse GetMetadata(DropboxGetMetadataOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the contents of the root folder of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse ListFolder() {
            return Client.GetResponse(new DropboxListFolderOptions());
        }

        /// <summary>
        /// Gets the contents of the folder matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path of the folder.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse ListFolder(string path) {
            return Client.GetResponse(new DropboxListFolderOptions(path));
        }

        /// <summary>
        /// Gets the contents of a Dropbox folder.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse ListFolder(DropboxListFolderOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        public IHttpResponse GetThumbnailBatch(string[] paths) {
            return GetThumbnailBatch(paths, DropboxThumbnailFormat.Jpeg, DropboxThumbnailSize.W64H64, DropboxThumbnailMode.Strict);
        }

        public IHttpResponse GetThumbnailBatch(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {

            JObject body = new JObject();

            JArray entries = new JArray();
            body.Add("entries", entries);

            foreach (string path in paths) {
                entries.Add(new JObject {
                    {"path", path},
                    {"format", format.ToLower()},
                    {"size", size.ToLower()},
                    {"mode", mode.ToUnderscore()}
                });
            }

            return Client.DoHttpPostRequest("https://content.dropboxapi.com/2/files/get_thumbnail_batch", default(IHttpQueryString), body);

        }

        /// <summary>
        /// Downloads a file from the user's Dropbox.
        /// </summary>
        /// <param name="path">The path of the file to download.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
        /// </see>
        public IHttpResponse Download(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            return Client.GetResponse(new DropboxDownloadFileOptions(path));

        }

        /// <summary>
        /// Downloads a file from the user's Dropbox.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
        /// </see>
        public IHttpResponse Download(DropboxDownloadFileOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.Path)) throw new PropertyNotSetException(nameof(options.Path));
            return Client.GetResponse(options);
        }

        #endregion

    }

}
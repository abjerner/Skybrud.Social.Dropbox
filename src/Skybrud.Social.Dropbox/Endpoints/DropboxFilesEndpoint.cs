using Skybrud.Social.Dropbox.Endpoints.Raw;
using Skybrud.Social.Dropbox.Models.Files;
using Skybrud.Social.Dropbox.Options.Files;
using Skybrud.Social.Dropbox.Responses.Files;

namespace Skybrud.Social.Dropbox.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Files</strong> endpoint.
    /// </summary>
    public class DropboxFilesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public DropboxService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public DropboxFilesRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal DropboxFilesEndpoint(DropboxService service) {
            Service = service;
            Raw = service.Client.Files;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the contents of the root folder of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="DropboxListFolderResponse"/> representing the response.</returns>
        public DropboxListFolderResponse ListFolder() {
            return DropboxListFolderResponse.Parse(Raw.ListFolder());
        }

        /// <summary>
        /// Gets the contents of the folder matching the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path of the folder.</param>
        /// <returns>An instance of <see cref="DropboxListFolderResponse"/> representing the response.</returns>
        public DropboxListFolderResponse ListFolder(string path) {
            return DropboxListFolderResponse.Parse(Raw.ListFolder(path));
        }

        /// <summary>
        /// Gets the contents of a Dropbox folder.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="DropboxListFolderResponse"/> representing the response.</returns>
        public DropboxListFolderResponse ListFolder(DropboxListFolderOptions options) {
            return DropboxListFolderResponse.Parse(Raw.ListFolder(options));
        }

        public DropboxGetThumbnailBatchResponse GetThumbnailBatch(string[] paths) {
            return DropboxGetThumbnailBatchResponse.Parse(Raw.GetThumbnailBatch(paths));
        }

        public DropboxGetThumbnailBatchResponse GetThumbnailBatch(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            return DropboxGetThumbnailBatchResponse.Parse(Raw.GetThumbnailBatch(paths, format, size, mode));
        }

        /// <summary>
        /// Downloads a file from the user's Dropbox.
        /// </summary>
        /// <param name="path">The path of the file to download.</param>
        /// <returns>An instance of <see cref="DropboxDownloadResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
        /// </see>
        public DropboxDownloadResponse Download(string path) {
            return DropboxDownloadResponse.Parse(Raw.Download(path));
        }

        /// <summary>
        /// Downloads a file from the user's Dropbox.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="DropboxDownloadResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
        /// </see>
        public DropboxDownloadResponse Download(DropboxDownloadFileOptions options) {
            return DropboxDownloadResponse.Parse(Raw.Download(options));
        }

        #endregion

    }

}
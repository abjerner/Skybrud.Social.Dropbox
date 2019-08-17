using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.OAuth;
using Skybrud.Social.Dropbox.Options.Files;
using Skybrud.Social.Dropbox.Options.Files.Thumbnails;

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

        /// <summary>
        /// Gets metadata for a file or folder.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_metadata</cref>
        /// </see>
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

        /// <summary>
        /// Get thumbnails for a list of images. Up to 25 thumbnails is allowed in a single batch.
        /// 
        /// This method currently supports files with the following file extensions: <c>jpg</c>, <c>jpeg</c>,
        /// <c>png</c>, <c>tiff</c>, <c>tif</c>, <c>gif</c> and <c>bmp</c>. Photos that are larger than 20MB in size
        /// won't be converted to a thumbnail.
        /// </summary>
        /// <param name="paths">An array of the paths for the images to get thumbnails for.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public IHttpResponse GetThumbnailBatch(string[] paths) {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            return GetThumbnailBatch(paths, DropboxThumbnailFormat.Jpeg, DropboxThumbnailSize.W64H64, DropboxThumbnailMode.Strict);
        }

        /// <summary>
        /// Get thumbnails for a list of images. Up to 25 thumbnails is allowed in a single batch.
        /// 
        /// This method currently supports files with the following file extensions: <c>jpg</c>, <c>jpeg</c>,
        /// <c>png</c>, <c>tiff</c>, <c>tif</c>, <c>gif</c> and <c>bmp</c>. Photos that are larger than 20MB in size
        /// won't be converted to a thumbnail.
        /// </summary>
        /// <param name="paths">An array of the paths for the images to get thumbnails for.</param>
        /// <param name="format">The format for the thumbnail image, <see cref="DropboxThumbnailFormat.Jpeg"/> or <see cref="DropboxThumbnailFormat.Png"/>. For images that are photos, <see cref="DropboxThumbnailFormat.Jpeg"/> should be preferred, while <see cref="DropboxThumbnailFormat.Png"/> is better for screenshots and digital arts.</param>
        /// <param name="size">The size for the thumbnail image.</param>
        /// <param name="mode">How to resize and crop the image to achieve the desired size.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public IHttpResponse GetThumbnailBatch(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            if (paths == null) throw new ArgumentNullException(nameof(paths));
            return GetThumbnailBatch(new DropboxGetThumbnailBatchOptions(paths, format, size, mode));
        }

        /// <summary>
        /// Get thumbnails for a list of images. Up to 25 thumbnails is allowed in a single batch.
        /// 
        /// This method currently supports files with the following file extensions: <c>jpg</c>, <c>jpeg</c>,
        /// <c>png</c>, <c>tiff</c>, <c>tif</c>, <c>gif</c> and <c>bmp</c>. Photos that are larger than 20MB in size
        /// won't be converted to a thumbnail.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public IHttpResponse GetThumbnailBatch(DropboxGetThumbnailBatchOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (options.Entries == null) throw new PropertyNotSetException(nameof(options.Entries));
            return Client.GetResponse(options);
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
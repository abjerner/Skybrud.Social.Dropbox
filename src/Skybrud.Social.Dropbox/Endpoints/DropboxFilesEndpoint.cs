using Skybrud.Social.Dropbox.Endpoints.Raw;
using Skybrud.Social.Dropbox.Options.Files;
using Skybrud.Social.Dropbox.Options.Files.Thumbnails;
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

        /// <summary>
        /// Get thumbnails for a list of images. Up to 25 thumbnails is allowed in a single batch.
        /// 
        /// This method currently supports files with the following file extensions: <c>jpg</c>, <c>jpeg</c>,
        /// <c>png</c>, <c>tiff</c>, <c>tif</c>, <c>gif</c> and <c>bmp</c>. Photos that are larger than 20MB in size
        /// won't be converted to a thumbnail.
        /// </summary>
        /// <param name="paths">An array of the paths for the images to get thumbnails for.</param>
        /// <returns>An instance of <see cref="DropboxGetThumbnailBatchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public DropboxGetThumbnailBatchResponse GetThumbnailBatch(string[] paths) {
            return DropboxGetThumbnailBatchResponse.Parse(Raw.GetThumbnailBatch(paths));
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
        /// <returns>An instance of <see cref="DropboxGetThumbnailBatchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public DropboxGetThumbnailBatchResponse GetThumbnailBatch(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            return DropboxGetThumbnailBatchResponse.Parse(Raw.GetThumbnailBatch(paths, format, size, mode));
        }

        /// <summary>
        /// Get thumbnails for a list of images. Up to 25 thumbnails is allowed in a single batch.
        /// 
        /// This method currently supports files with the following file extensions: <c>jpg</c>, <c>jpeg</c>,
        /// <c>png</c>, <c>tiff</c>, <c>tif</c>, <c>gif</c> and <c>bmp</c>. Photos that are larger than 20MB in size
        /// won't be converted to a thumbnail.
        /// </summary>
        /// <param name="options">The options for the request to the Dropbox API.</param>
        /// <returns>An instance of <see cref="DropboxGetThumbnailBatchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
        /// </see>
        public DropboxGetThumbnailBatchResponse GetThumbnailBatch(DropboxGetThumbnailBatchOptions options) {
            return DropboxGetThumbnailBatchResponse.Parse(Raw.GetThumbnailBatch(options));
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
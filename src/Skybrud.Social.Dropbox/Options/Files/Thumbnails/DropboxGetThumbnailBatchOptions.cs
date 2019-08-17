using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files.Thumbnails {

    /// <summary>
    /// Class representing the options for a request to get a batch of thumbnails.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
    /// </see>
    public class DropboxGetThumbnailBatchOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets a list of entries/files to get thumbnails for.
        /// </summary>
        [JsonProperty("entries")]
        public List<DropboxThumbnailArg> Entries { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public DropboxGetThumbnailBatchOptions() {
            Entries = new List<DropboxThumbnailArg>();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="paths"/>.
        /// </summary>
        /// <param name="paths">An array of the paths for the images to get thumbnails for.</param>
        public DropboxGetThumbnailBatchOptions(string[] paths) {
            Entries = new List<DropboxThumbnailArg>();
            if (paths == null) return;
            foreach (string path in paths) {
                Entries.Add(new DropboxThumbnailArg(path));
            }
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="paths"/>.
        /// </summary>
        /// <param name="paths">An array of the paths for the images to get thumbnails for.</param>
        /// <param name="format">The format for the thumbnail image, <see cref="DropboxThumbnailFormat.Jpeg"/> or <see cref="DropboxThumbnailFormat.Png"/>. For images that are photos, <see cref="DropboxThumbnailFormat.Jpeg"/> should be preferred, while <see cref="DropboxThumbnailFormat.Png"/> is better for screenshots and digital arts.</param>
        /// <param name="size">The size for the thumbnail image.</param>
        /// <param name="mode">How to resize and crop the image to achieve the desired size.</param>
        public DropboxGetThumbnailBatchOptions(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            Entries = new List<DropboxThumbnailArg>();
            if (paths == null) return;
            foreach (string path in paths) {
                Entries.Add(new DropboxThumbnailArg(path, format, size, mode));
            }
        }

        /// <summary>
        /// Initializes a new instance based on the specified array of <paramref name="entries"/>.
        /// </summary>
        /// <param name="entries">The entries.</param>
        public DropboxGetThumbnailBatchOptions(params DropboxThumbnailArg[] entries) {
            Entries = new List<DropboxThumbnailArg>();
            if (entries == null) return;
            Entries.AddRange(entries);
        }

        /// <summary>
        /// Initializes a new instance based on the specified collection of <paramref name="entries"/>.
        /// </summary>
        /// <param name="entries">The entries.</param>
        public DropboxGetThumbnailBatchOptions(IEnumerable<DropboxThumbnailArg> entries) {
            Entries = new List<DropboxThumbnailArg>();
            if (entries == null) return;
            Entries.AddRange(entries);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public HttpRequest GetRequest() {
            if (Entries == null) throw new PropertyNotSetException(nameof(Entries));
            return HttpRequest.Post("https://content.dropboxapi.com/2/files/get_thumbnail_batch", JObject.FromObject(this));
        }

        #endregion

    }

}
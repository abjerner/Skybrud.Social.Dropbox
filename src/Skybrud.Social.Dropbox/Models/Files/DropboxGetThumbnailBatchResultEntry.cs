using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    /// <summary>
    /// Class representing an item in a result of a request to get thumbnails for a collection of images.
    /// </summary>
    public class DropboxGetThumbnailBatchResultEntry : DropboxObject {

        #region Properties

        /// <summary>
        /// Gets metadata about the file.
        /// </summary>
        public DropboxFileMetadata Metadata { get; }

        /// <summary>
        /// A string containing the base64-encoded thumbnail data for this file.
        /// </summary>
        public string Thumbnail { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        protected DropboxGetThumbnailBatchResultEntry(JObject obj) : base(obj) {
            Metadata = obj.GetObject("metadata", DropboxFileMetadata.Parse);
            Thumbnail = obj.GetString("thumbnail");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxGetThumbnailBatchResultEntry"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxGetThumbnailBatchResultEntry"/>.</returns>
        public static DropboxGetThumbnailBatchResultEntry Parse(JObject obj) {
            return obj == null ? null : new DropboxGetThumbnailBatchResultEntry(obj);
        }

        #endregion

    }

}
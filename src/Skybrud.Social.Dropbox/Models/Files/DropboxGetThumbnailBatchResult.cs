using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    /// <summary>
    /// Class representing the result of a request to get thumbnails for a collection of images.
    /// </summary>
    public class DropboxGetThumbnailBatchResult : DropboxObject {

        #region Properties

        /// <summary>
        /// Gets a list of files and their thumbnails
        /// </summary>
        public DropboxGetThumbnailBatchResultEntry[] Entries { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        protected DropboxGetThumbnailBatchResult(JObject obj) : base(obj) {
            Entries = obj.GetArrayItems("entries", DropboxGetThumbnailBatchResultEntry.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxMetadata"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxMetadata"/>.</returns>
        public static DropboxGetThumbnailBatchResult Parse(JObject obj) {
            return obj == null ? null : new DropboxGetThumbnailBatchResult(obj);
        }

        #endregion

    }

}
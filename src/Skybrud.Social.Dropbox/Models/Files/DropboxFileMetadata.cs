using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Dropbox.Models.Files {
    
    /// <summary>
    /// Class representing the metadata of a Dropbox file.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#FileMetadata</cref>
    /// </see>
    public class DropboxFileMetadata : DropboxMetadata {

        #region Properties

        /// <summary>
        /// Gets the modification time set by the desktop client when the file was added to Dropbox. Since this time is
        /// not verified (the Dropbox server stores whatever the desktop client sends up), this should only be used for
        /// display purposes (such as sorting) and not, for example, to determine if a file has changed or not.
        /// </summary>
        public EssentialsTime ClientModified { get; }

        /// <summary>
        /// Gets the last time the file was modified on Dropbox.
        /// </summary>
        public EssentialsTime ServerModified { get; }

        /// <summary>
        /// Gets a unique identifier for the current revision of a file. This field is the same rev as elsewhere in the
        /// API and can be used to detect changes and avoid conflicts.
        /// </summary>
        public string Rev { get; }

        /// <summary>
        /// Gets the size of the file in bytes.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets a hash of the file content. This field can be used to verify data integrity.
        /// </summary>
        public string ContentHash { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        protected internal DropboxFileMetadata(JObject obj) : base(obj) {
            ClientModified = obj.GetString("client_modified", EssentialsTime.Parse);
            ServerModified = obj.GetString("server_modified", EssentialsTime.Parse);
            Rev = obj.GetString("rev");
            Size = obj.GetInt64("size");
            ContentHash = obj.GetString("content_hash");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxFileMetadata"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxFileMetadata"/>.</returns>
        public new static DropboxFileMetadata Parse(JObject obj) {
            return obj == null ? null : new DropboxFileMetadata(obj);
        }

        #endregion

    }

}
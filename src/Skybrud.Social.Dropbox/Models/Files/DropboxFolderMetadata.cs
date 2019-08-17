using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    /// <summary>
    /// Class representing the metadata of a Dropbox folder.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#FolderMetadata</cref>
    /// </see>
    public class DropboxFolderMetadata : DropboxMetadata {

        #region Properties

        /// <summary>
        /// Gets sharing information about the folder or a parent folder is shared.
        /// </summary>
        public DropboxFolderSharingInfo SharingInfo { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        protected internal DropboxFolderMetadata(JObject obj) : base(obj) {
            SharingInfo = obj.GetObject("sharing_info", DropboxFolderSharingInfo.Parse);
        }

        #endregion

    }

}
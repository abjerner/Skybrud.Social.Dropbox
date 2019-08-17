using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    /// <summary>
    /// Class representing the sharing information of a Dropbox folder.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#FolderSharingInfo</cref>
    /// </see>
    public class DropboxFolderSharingInfo : DropboxObject {

        #region Properties

        /// <summary>
        /// <c>true</c> if the file or folder is inside a read-only shared folder.
        /// </summary>
        public bool ReadOnly { get; }

        /// <summary>
        /// Set if the folder is contained by a shared folder.
        /// </summary>
        public string ParentSharedFolderId { get; }

        /// <summary>
        /// If this folder is a shared folder mount point, the ID of the shared folder mounted at this location. This
        /// field is optional.
        /// </summary>
        public string SharedFolderId { get; }

        /// <summary>
        /// Specifies that the folder can only be traversed and the user can only see a limited subset of the contents
        /// of this folder because they don't have read access to this folder. They do, however, have access to some
        /// sub folder.
        /// </summary>
        public bool TraverseOnly { get; }

        /// <summary>
        /// Specifies that the folder cannot be accessed by the user.
        /// </summary>
        public bool NoAccess { get; }

        #endregion

        #region Constructors

        private DropboxFolderSharingInfo(JObject obj) : base(obj) {
            ReadOnly = obj.GetBoolean("read_only");
            ParentSharedFolderId = obj.GetString("parent_shared_folder_id");
            SharedFolderId = obj.GetString("shared_folder_id");
            TraverseOnly = obj.GetBoolean("traverse_only");
            NoAccess = obj.GetBoolean("no_access");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxFolderSharingInfo"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxFolderSharingInfo"/>.</returns>
        public static DropboxFolderSharingInfo Parse(JObject obj) {
            return obj == null ? null : new DropboxFolderSharingInfo(obj);
        }

        #endregion

    }

}
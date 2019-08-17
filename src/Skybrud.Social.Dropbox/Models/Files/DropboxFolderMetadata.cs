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

        public DropboxFolderSharingInfo SharingInfo { get; }

        #endregion

        #region Constructors

        internal DropboxFolderMetadata(JObject obj) : base(obj) {
            SharingInfo = obj.GetObject("sharing_info", DropboxFolderSharingInfo.Parse);
        }

        #endregion

    }

}
using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    public class DropboxMetadata : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the last component of the path (including extension). This never contains a slash.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a unique identifier for the file or folder.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the lowercased full path in the user's Dropbox. This always starts with a slash.
        /// </summary>
        public string PathLower { get; }

        /// <summary>
        /// Gets the cased path to be used for display purposes only.
        /// </summary>
        public string PathDisplay { get; }

        #endregion

        #region Constructors

        protected DropboxMetadata(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Id = obj.GetString("id");
            PathLower = obj.GetString("path_lower");
            PathDisplay = obj.GetString("path_display");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxMetadata"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxMetadata"/>.</returns>
        public static DropboxMetadata Parse(JObject obj) {

            string tag = obj.Value<string>(".tag");

            switch (tag) {

                case "file":
                    return new DropboxFileMetadata(obj);

                case "folder":
                    return new DropboxFolderMetadata(obj);

                default:
                    throw new Exception("Unknown type " + tag + "\r\n\r\n" + obj);

            }

        }

        #endregion

    }

}
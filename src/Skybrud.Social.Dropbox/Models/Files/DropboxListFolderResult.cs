﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Dropbox.Models.Files {

    /// <summary>
    /// Class representing the result of a request to get the contents of a Dropbox folder.
    /// </summary>
    public class DropboxListFolderResult : DropboxObject {

        #region Properties

        /// <summary>
        /// Gets an array with the files and (direct) subfolders in the folder.
        /// </summary>
        public DropboxMetadata[] Entries { get; }

        /// <summary>
        /// Gets the cursor.
        /// </summary>
        public string Cursor { get; }

        /// <summary>
        /// If <c>true</c>, then there are more entries available.
        /// </summary>
        public bool HasMore { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        protected DropboxListFolderResult(JObject obj) : base(obj) {
            Entries = obj.GetArrayItems("entries", DropboxMetadata.Parse);
            Cursor = obj.GetString("cursor");
            HasMore = obj.GetBoolean("has_more");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="DropboxListFolderResult"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="DropboxListFolderResult"/>.</returns>
        public static DropboxListFolderResult Parse(JObject obj) {
            return obj == null ? null : new DropboxListFolderResult(obj);
        }

        #endregion

    }

}
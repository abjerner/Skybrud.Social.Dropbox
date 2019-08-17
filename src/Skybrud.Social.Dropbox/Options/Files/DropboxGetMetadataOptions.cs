using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files {
    
    /// <summary>
    /// Options for a request to get metadata about a Dropbox file or folder.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_metadata</cref>
    /// </see>
    public class DropboxGetMetadataOptions : HttpRequestOptionsBase, IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the path of a file or folder on Dropbox.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// If <c>true</c>, media information will be available for photos and videos. Default is <c>false</c>.
        /// </summary>
        public bool IncludeMediaInfo { get; set; }

        public bool IncludeDeleted { get; set; }

        /// <summary>
        /// If <c>true</c>, the results will include a flag for each file indicating whether or not that file has any
        /// explicit members. Default is <c>false</c>.
        /// </summary>
        public bool IncludeHasExplicitSharedMembers { get; set; }
        
        #endregion

        #region Member methods

        public override HttpRequest GetRequest() {

            if (Path == null) throw new PropertyNotSetException(nameof(Path));

            JObject body = new JObject {
                {"path", Path}
            };

            if (IncludeMediaInfo) body.Add("include_media_info", "true");
            if (IncludeDeleted) body.Add("include_deleted", "true");
            if (IncludeHasExplicitSharedMembers) body.Add("include_has_explicit_shared_members", "true");

            return Post("/2/files/get_metadata", body);

        }

        #endregion

    }

}
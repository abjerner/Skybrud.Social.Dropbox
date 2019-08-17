using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files {
    
    /// <summary>
    /// Options for request to get the contents of a Dropboxo folder.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-list_folder</cref>
    /// </see>
    public class DropboxListFolderOptions : HttpRequestOptionsBase, IHttpRequestOptions {
        
        #region Properties

        /// <summary>
        /// Gets or sets the path of a Dropbox folder.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// If <c>true</c>, the results will include entries for files and folders that used to exist but were deleted.
        /// Default is <c>false</c>.
        /// </summary>
        public bool IncludeDeleted { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of results to return per request. Note: This is an approximate number and
        /// there can be slightly more entries returned in some cases. This field is optional. Minimum allowed value is
        /// <c>1</c> - maximum allowed value is <c>2000</c>.
        /// </summary>
        public int Limit { get; set; }

        #endregion

        #region Properties

        public DropboxListFolderOptions() { }

        public DropboxListFolderOptions(string path) {
            Path = path;
        }

        #endregion

        #region Member methods

        public override HttpRequest GetRequest() {
            
            JObject body = new JObject {
                {"path", Path ?? string.Empty}
            };

            if (IncludeDeleted) body.Add("include_deleted", "true");
            if (Limit > 0) body.Add("limit", Limit);

            return Post("/2/files/list_folder", body);

        }

        #endregion

    }

}
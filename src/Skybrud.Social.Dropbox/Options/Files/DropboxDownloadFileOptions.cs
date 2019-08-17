using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files {
    
    /// <summary>
    /// Class representing the options of a request to download a single Dropbox file.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-download</cref>
    /// </see>
    public class DropboxDownloadFileOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the path of a file on Dropbox.
        /// </summary>
        public string Path { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public DropboxDownloadFileOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path, ID or revision of the file to be downloaded.</param>
        public DropboxDownloadFileOptions(string path) {
            Path = path;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public HttpRequest GetRequest() {

            if (Path == null) throw new PropertyNotSetException(nameof(Path));

            JObject body = new JObject {
                {"path", Path}
            };

            HttpRequest request = new HttpRequest(HttpMethod.Post, "https://content.dropboxapi.com/2/files/download") {
                ContentType = "text/plain"
            };

            request.Headers.Add("Dropbox-API-Arg", body.ToString(Formatting.None));

            return request;

        }

        #endregion

    }

}
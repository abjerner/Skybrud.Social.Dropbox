using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files {

    public class DropboxDownloadFileOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the path of a file on Dropbox.
        /// </summary>
        public string Path { get; set; }

        #endregion

        #region Constructors

        public DropboxDownloadFileOptions() { }

        public DropboxDownloadFileOptions(string path) {
            Path = path;
        }

        #endregion

        #region Member methods

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
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Http;

namespace Skybrud.Social.Dropbox.Options.Files.Thumbnails {

    public class DropboxGetThumbnailBatchOptions : IHttpRequestOptions {

        #region Properties

        [JsonProperty("entries")]
        public List<DropboxThumbnailArg> Entries { get; set; }

        #endregion

        #region Constructors

        public DropboxGetThumbnailBatchOptions() {
            Entries = new List<DropboxThumbnailArg>();
        }

        public DropboxGetThumbnailBatchOptions(string[] paths) {
            Entries = new List<DropboxThumbnailArg>();
            if (paths == null) return;
            foreach (string path in paths) {
                Entries.Add(new DropboxThumbnailArg(path));
            }
        }

        public DropboxGetThumbnailBatchOptions(string[] paths, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            Entries = new List<DropboxThumbnailArg>();
            if (paths == null) return;
            foreach (string path in paths) {
                Entries.Add(new DropboxThumbnailArg(path, format, size, mode));
            }
        }

        public DropboxGetThumbnailBatchOptions(params DropboxThumbnailArg[] args) {
            Entries = new List<DropboxThumbnailArg>();
            if (args == null) return;
            Entries.AddRange(args);
        }

        public DropboxGetThumbnailBatchOptions(IEnumerable<DropboxThumbnailArg> args) {
            Entries = new List<DropboxThumbnailArg>();
            if (args == null) return;
            Entries.AddRange(args);
        }

        #endregion

        #region Member methods

        public HttpRequest GetRequest() {

            if (Entries == null) throw new PropertyNotSetException(nameof(Entries));

            JObject body = JObject.FromObject(this);

            throw new Exception(body + "");
            
            return HttpRequest.Post("https://content.dropboxapi.com/2/files/get_thumbnail_batch", body);

        }

        #endregion

    }

}
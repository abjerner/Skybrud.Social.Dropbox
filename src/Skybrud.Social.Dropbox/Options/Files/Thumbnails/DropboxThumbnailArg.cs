using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Dropbox.Options.Files.Thumbnails {

    public class DropboxThumbnailArg {

        #region Properties

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("format")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailFormat Format { get; set; }

        [JsonProperty("size")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailSize Size { get; set; }

        [JsonProperty("mode")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailMode Mode { get; set; }

        #endregion

        #region Constructors
        
        public DropboxThumbnailArg(string path) {
            Path = path;
            Format = DropboxThumbnailFormat.Jpeg;
            Size = DropboxThumbnailSize.W64H64;
            Mode = DropboxThumbnailMode.Strict;
        }

        public DropboxThumbnailArg(string path, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            Path = path;
            Format = format;
            Size = size;
            Mode = mode;
        }

        #endregion

    }

}
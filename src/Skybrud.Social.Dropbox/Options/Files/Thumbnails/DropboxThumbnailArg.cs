using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Dropbox.Options.Files.Thumbnails {

    /// <summary>
    /// Class representing an image to get the thumbnail for.
    /// </summary>
    /// <see>
    ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#files-get_thumbnail_batch</cref>
    /// </see>
    public class DropboxThumbnailArg {

        #region Properties

        /// <summary>
        /// Gets or sets the path, ID or revision of the file.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the format of the thumbnail.
        /// </summary>
        [JsonProperty("format")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailFormat Format { get; set; }

        /// <summary>
        /// Gets or sets the size of the thumbnail.
        /// </summary>
        [JsonProperty("size")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailSize Size { get; set; }

        /// <summary>
        /// Gets or sets the mode used for generating the thumbnail.
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
        public DropboxThumbnailMode Mode { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path, ID or revision of the image.</param>
        public DropboxThumbnailArg(string path) {
            Path = path;
            Format = DropboxThumbnailFormat.Jpeg;
            Size = DropboxThumbnailSize.W64H64;
            Mode = DropboxThumbnailMode.Strict;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path, ID or revision of the image.</param>
        /// <param name="format">The format for the thumbnail image, <see cref="DropboxThumbnailFormat.Jpeg"/> or <see cref="DropboxThumbnailFormat.Png"/>. For images that are photos, <see cref="DropboxThumbnailFormat.Jpeg"/> should be preferred, while <see cref="DropboxThumbnailFormat.Png"/> is better for screenshots and digital arts.</param>
        /// <param name="size">The size for the thumbnail image.</param>
        /// <param name="mode">How to resize and crop the image to achieve the desired size.</param>
        public DropboxThumbnailArg(string path, DropboxThumbnailFormat format, DropboxThumbnailSize size, DropboxThumbnailMode mode) {
            Path = path;
            Format = format;
            Size = size;
            Mode = mode;
        }

        #endregion

    }

}
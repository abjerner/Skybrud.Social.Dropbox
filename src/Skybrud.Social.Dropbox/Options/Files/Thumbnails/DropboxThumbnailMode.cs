namespace Skybrud.Social.Dropbox.Options.Files.Thumbnails {

    /// <summary>
    /// Enum class representing the mode that should be used when genrating a thumbnail.
    /// </summary>
    public enum DropboxThumbnailMode {
        
        /// <summary>
        /// Scale down the image to fit within the given size.
        /// </summary>
        Strict,

        /// <summary>
        /// Scale down the image to fit within the given size or its transpose.
        /// </summary>
        Bestfit,

        /// <summary>
        /// Scale down the image to completely cover the given size or its transpose.
        /// </summary>
        FitoneBestfit

    }

}
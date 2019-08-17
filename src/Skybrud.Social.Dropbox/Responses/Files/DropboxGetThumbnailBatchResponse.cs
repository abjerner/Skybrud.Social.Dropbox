﻿using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Models.Files;

namespace Skybrud.Social.Dropbox.Responses.Files {

    public class DropboxGetThumbnailBatchResponse : DropboxResponse<DropboxGetThumbnailBatchResult> {
        
        #region Constructors

        private DropboxGetThumbnailBatchResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, DropboxGetThumbnailBatchResult.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="DropboxGetThumbnailBatchResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="DropboxGetThumbnailBatchResponse"/>.</returns>
        public static DropboxGetThumbnailBatchResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new DropboxGetThumbnailBatchResponse(response);
        }

        #endregion

    }

}
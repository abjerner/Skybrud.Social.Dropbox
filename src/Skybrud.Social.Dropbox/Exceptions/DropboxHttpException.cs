using System;
using System.Net;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Dropbox.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Dropbox API.
    /// </summary>
    public class DropboxHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Toggl API.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public DropboxHttpException(IHttpResponse response) : base("Invalid response received from the Dropbox API (Status: " + (int) response.StatusCode + ")") {
            Response = response;
        }

        #endregion

    }

}
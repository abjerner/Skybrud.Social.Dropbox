using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Dropbox.Exceptions;

namespace Skybrud.Social.Dropbox.Responses {

    /// <summary>
    /// Class representing a response from of the Dropbox API.
    /// </summary>
    public abstract class DropboxResponse : HttpResponseBase {

        #region Constructor

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        protected DropboxResponse(IHttpResponse response) : base(response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Now throw some exceptions
            throw new DropboxHttpException(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from of the Dropbox API.
    /// </summary>
    public class DropboxResponse<T> : DropboxResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        protected DropboxResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}
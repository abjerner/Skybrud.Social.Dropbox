using Skybrud.Essentials.Http;

namespace Skybrud.Social.Dropbox.Http {

    /// <summary>
    /// Interface used for describing a HTTP request.
    /// </summary>
    public interface IHttpRequestOptions {

        /// <summary>
        /// Returns an instance of <see cref="HttpRequest"/>.
        /// </summary>
        /// <returns>An instance of <see cref="HttpRequest"/>.</returns>
        HttpRequest GetRequest();

    }

}
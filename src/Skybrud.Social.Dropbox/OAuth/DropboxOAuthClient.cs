using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Dropbox.Endpoints.Raw;
using Skybrud.Social.Dropbox.Http;
using Skybrud.Social.Dropbox.Responses.Authentication;

namespace Skybrud.Social.Dropbox.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Dropbox API as well as any OAuth 2.0 communication.
    /// </summary>
    public class DropboxOAuthClient : HttpClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region Endpoints

        /// <summary>
        /// Gets a reference to the raw <strong>Files</strong> endpoint.
        /// </summary>
        public DropboxFilesRawEndpoint Files { get; }
        
        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public DropboxOAuthClient() {
            Files = new DropboxFilesRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public DropboxOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public DropboxOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public DropboxOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId + string.Empty;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public DropboxOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public DropboxOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates the authorization URL based on the <see cref="ClientId"/> and <see cref="RedirectUri"/> properties as well as the <paramref name="state"/> parameter.
        /// </summary>
        /// <param name="state">Up to 500 bytes of arbitrary data that will be passed back to your redirect URI. This
        /// parameter should be used to protect against cross-site request forgery (CSRF).</param>
        /// <returns>An authorization URL based on the specified <paramref name="state"/>.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#oauth2-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));

            IHttpQueryString query = new HttpQueryString {
                {"response_type", "code"},
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"state", state}
            };

            return "https://www.dropbox.com/oauth2/authorize?" + query;

        }

        /// <summary>
        /// Generates the authorization URL based on the <see cref="ClientId"/> and <see cref="RedirectUri"/> properties as well as the <paramref name="state"/> parameter.
        /// </summary>
        /// <param name="state">Up to 500 bytes of arbitrary data that will be passed back to your redirect URI. This
        /// parameter should be used to protect against cross-site request forgery (CSRF).</param>
        /// <param name="forceReapprove">Whether or not to force the user to approve the app again if they've already
        /// done so. If <c>false</c> (default), a user who has already approved the application may be
        /// automatically redirected to the URI specified by <see cref="RedirectUri"/>>. If <c>true</c>, the user
        /// will not be automatically redirected and will have to approve the app again.</param>
        /// <returns>An authorization URL based on the specified <paramref name="state"/>.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#oauth2-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, bool forceReapprove) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));

            IHttpQueryString query = new HttpQueryString {
                {"response_type", "code"},
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"state", state},
                {"force_reapprove", forceReapprove ? "true" : "false"}
            };

            return "https://www.dropbox.com/oauth2/authorize?" + query;

        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Dropbox OAuth dialog.</param>
        /// <returns>An instance of <see cref="DropboxTokenResponse"/>.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers/documentation/http/documentation#oauth2-token</cref>
        /// </see>
        public DropboxTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            if (string.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (string.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (string.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (string.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the POST data
            IHttpPostData data = new HttpPostData {
                {"code", authCode},
                {"grant_type", "authorization_code"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri}
            };

            // Make the request to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://api.dropboxapi.com/oauth2/token", null, data);

            // Parse the response
            return DropboxTokenResponse.ParseResponse(response);

        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Set the "Authorization" header if an access token is present
            if (string.IsNullOrWhiteSpace(AccessToken) == false) {
                request.Authorization = "Bearer " + AccessToken;
            }

            if (request.Url.StartsWith("/")) {
                request.Url = "https://api.dropboxapi.com" + request.Url;
            }

        }

        /// <summary>
        /// Gets the response of the request as described by the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options describing the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetResponse(IHttpRequestOptions options) {
            HttpRequest request = options.GetRequest();
            PrepareHttpRequest(request);
            return request.GetResponse();
        }

        #endregion

    }

}
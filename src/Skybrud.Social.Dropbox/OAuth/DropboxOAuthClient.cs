using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Dropbox.Endpoints.Raw;
using Skybrud.Social.Dropbox.Responses.Authentication;

namespace Skybrud.Social.Dropbox.OAuth {
    
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
            ClientId = clientId + "";
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
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Microsoft OAuth login page.</param>
        /// <returns>Returns an authorization URL based on the specified <code>state</code>.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers-v1/core/docs#oa2-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state) {
            return string.Format(
                "https://www.dropbox.com/1/oauth2/authorize?response_type={0}&client_id={1}&redirect_uri={2}&state={3}",
                "code",
                ClientId,
                RedirectUri,
                state
            );
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">Up to 500 bytes of arbitrary data that will be passed back to your redirect URI. This
        /// parameter should be used to protect against cross-site request forgery (CSRF).</param>
        /// <param name="forceReapprove">Whether or not to force the user to approve the app again if they've already
        /// done so. If <code>false</code> (default), a user who has already approved the application may be
        /// automatically redirected to the URI specified by <code>RedirectUri</code>. If <code>true</code>, the user
        /// will not be automatically redirected and will have to approve the app again.</param>
        /// <returns>Returns an authorization URL based on the specified <code>state</code>.</returns>
        /// <see>
        ///     <cref>https://www.dropbox.com/developers-v1/core/docs#oa2-authorize</cref>
        /// </see>
        public string GetAuthorizationUrl(string state, bool forceReapprove) {
            return string.Format(
                "https://www.dropbox.com/1/oauth2/authorize?response_type={0}&client_id={1}&redirect_uri={2}&state={3}&force_reapprove={4}",
                "code",
                ClientId,
                RedirectUri,
                state,
                forceReapprove ? "true" : "false"
            );
        }
        
        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Dropbox OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public DropboxTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the POST data
            IHttpPostData data = new HttpPostData {
                {"code", authCode},
                {"grant_type", "authorization_code"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri}
            };

            // Make the request to the API
            IHttpResponse response = HttpUtils.Requests.Post("https://api.dropboxapi.com/1/oauth2/token", null, data);

            // Parse the response
            return DropboxTokenResponse.ParseResponse(response);

        }

        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if ((request.QueryString == null || string.IsNullOrWhiteSpace(request.QueryString["access_token"])) && string.IsNullOrWhiteSpace(AccessToken) == false) {
                request.QueryString = request.QueryString ?? new HttpQueryString();
                request.QueryString.Add("access_token", AccessToken);
            }

        }

        public IHttpResponse Get(string url, IHttpGetOptions options) {
            return DoHttpGetRequest(url, options);
        }

        #endregion

    }

}
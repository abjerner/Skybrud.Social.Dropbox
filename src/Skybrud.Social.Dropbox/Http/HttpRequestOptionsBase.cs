using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Dropbox.Http {

    public abstract class HttpRequestOptionsBase : IHttpRequestOptions {
        
        protected HttpRequest Post(string url) {
            return new HttpRequest().Post(url);
        }

        protected HttpRequest Post(string url, JObject body) {
            return new HttpRequest().Post(url, body);
        }

        protected HttpRequest Post(string url, IHttpQueryString queryString, JObject body) {
            return new HttpRequest().Post(url, queryString, body);
        }

        public abstract HttpRequest GetRequest();

    }

    public static class Hej {

        public static HttpRequest Post(this HttpRequest request) {
            request.Method = HttpMethod.Post;
            return request;
        }

        public static HttpRequest Post(this HttpRequest request, string url, JToken body) {
            request.Method = HttpMethod.Post;
            request.Url = url;
            request.ContentType = "application/json";
            request.Body = body?.ToString(Formatting.None) ?? string.Empty;
            return request;
        }

        public static HttpRequest Post(this HttpRequest request, string url, IHttpQueryString queryString, JToken body) {
            request.Method = HttpMethod.Post;
            request.Url = url;
            request.QueryString = queryString;
            request.ContentType = "application/json";
            request.Body = body?.ToString(Formatting.None) ?? string.Empty;
            return request;
        }

        public static HttpRequest Post(this HttpRequest request, string url) {
            request.Url = url;
            return request;
        }

        public static HttpRequest Body(this HttpRequest request, JToken body) {
            request.ContentType = "application/json";
            request.Body = body?.ToString(Formatting.None) ?? string.Empty;
            return request;
        }

    }

}
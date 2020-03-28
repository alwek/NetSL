using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetSL.Api.Utils {
    public static class HttpClientUtil {
        public static async Task<object> ReadHttpResponseMessage<T>(HttpResponseMessage response) { 
            string messageContent = await response.Content.ReadAsStringAsync();
            try {
                if(response.IsSuccessStatusCode && !string.IsNullOrEmpty(messageContent))
                    return JsonSerializer.Deserialize<T>(messageContent);
                else 
                    return null;
            } catch(Exception ex) {
                //log ex
                return null;
            }
        }

        public static HttpRequestMessage CreateHttpRequestMessage(HttpMethod method, Uri uri, string content){
            HttpRequestMessage request = new HttpRequestMessage {
                Method = method,
                RequestUri = uri,
                Content = content != null
                    ? new StringContent(content, Encoding.Default, "application/json")
                    : null
            };
            request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
            return request;
        }

        public static Uri CreateUri(Uri baseAddress, string key, string format, string additionalPath, string query = null){
            return new UriBuilder($"{baseAddress}/{additionalPath}.{format}"){
                Query = $"key={key}{(query ?? string.Empty)}" 
            }.Uri;
        }
    }
}
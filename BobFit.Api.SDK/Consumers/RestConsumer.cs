using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BobFit.Api.SDK.Consumers
{
    public class RestConsumer
    {
        private string _baseUrl;

        private const string ContentType = "application/json";

        private static HttpClient _client;

        public RestConsumer(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient();
        }

        private void ConfigureHeaders(string authToken = "")
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));

            if (!string.IsNullOrEmpty(authToken))
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authToken);
        }

        public T Get<T>(string endpoint, string authToken)
        {
            ConfigureHeaders(authToken);

            var response = _client.GetAsync(new Uri($"{_baseUrl}/{endpoint}")).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            return Serializer.Deserialize<T>(content);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.Shopping.API.Services
{
    public class ApiClient : IApiClient
    {
        private string Endpoint { get; set; }
        private string Token { get; set; }
        public ApiClient(string endpoint, string token = null)
        {
            Endpoint = endpoint;
            Token = token;
        }
        public async Task<T> GetAsync<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var response = await client.GetAsync(requestUri);
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync())
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public T Get<T>(string function)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var response = client.GetAsync(requestUri).Result;
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public T Post<T>(string function, T data)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            client.DefaultRequestHeaders.Add("X-API-Key", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                var response = client.PostAsync(requestUri, content).Result;
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
        public async Task<T> PostAsync<T>(string function, T data)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, content);
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
        public async Task<T> PutAsync<T>(string function, T data)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(requestUri, content);
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
        public T Put<T>(string function, T data)
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                var response = client.PutAsync(requestUri, content).Result;
                return response.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result)
                    : default;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
        public void Delete(string function)
        {
            HttpResponseMessage response;
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var requestUri = GetRequestUri(function);
                response = client.DeleteAsync(requestUri).Result;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
        private string GetRequestUri(string function) => Endpoint + (!function.StartsWith("/") ? $"/{function}" : function);
    }
}

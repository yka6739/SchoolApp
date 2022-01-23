using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SchoolApp.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolApp.Client.Services
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public HttpService(HttpClient httpClient,ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }
        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return (await sendRequest<T>(request));
        }

        public async Task<IEnumerable<T>> GetEntities<T>(string uri)
        {
            var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (accessToken != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = (await _httpClient.GetAsync(uri));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //_navigationManager.NavigateTo("logout");
                throw new UnauthorizedAccessException("Not Authorised"); ;
            }
            if (response.IsSuccessStatusCode)
            {

                return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            //var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            throw new Exception("Error Occurred!");
        }

        public async Task<IEnumerable<T>> GetFilteredEntities<T>(string uri, object value)
        {
            var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");

            if (accessToken != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var jsonSerialObject = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, jsonSerialObject);
            if (response.IsSuccessStatusCode)
            {
                return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<T>>
                    (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            throw new Exception(error["message"]);
        }

        public async Task<T> LoginAsync<T>(string uri, object value)
        {
            var jsonSerialObject = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, jsonSerialObject);
            if (response.IsSuccessStatusCode)
            {
                return await System.Text.Json.JsonSerializer.DeserializeAsync<T>
                    (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            //var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            throw new Exception("Error Occured");
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");
            //var user = await _localStorageService.GetItemAsync<AspNetUser>("user");
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (accessToken != null && isApiUrl)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //_navigationManager.NavigateTo("logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}

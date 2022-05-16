using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ciudadano.Api.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Ciudadano.Api.Services.Fcm
{
    public class FcmService : IFcmService
    {
        private const string FcmSubscription = "https://iid.googleapis.com/iid/v1";
        private const string FcmSend = "https://fcm.googleapis.com/fcm/send";
        private const string FcmInfo = "https://iid.googleapis.com/iid/info";
        private static FcmService _instance;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FcmService(IConfiguration configuration)
        {
            _configuration = configuration;
            var fcmApiKey = _configuration["Google:Fcm:ApiKey"];
            _httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 1024 * 1024 * 25 // 25Mb
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + fcmApiKey);
        }

        public static FcmService Instance(IConfiguration configuration) => _instance ?? (_instance = new FcmService(configuration));

        public async Task<string> Subscribe(string topic, List<string> tokens)
        {
            var endpoint = $"{FcmSubscription}:batchAdd";
            var uri = new Uri(endpoint);
            var body = new
            {
                to = $"/topics/{topic}",
                registration_tokens = tokens
            };
            var bodyStr = JsonConvert.SerializeObject(body);
            var httpContent = new StringContent(bodyStr, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, httpContent);
            if (!response.IsSuccessStatusCode) return null;
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }

        public async Task<string> Unsubscribe(string topic, List<string> tokens)
        {
            var endpoint = $"{FcmSubscription}:batchRemove";
            var uri = new Uri(endpoint);
            var body = new
            {
                to = $"/topics/{topic}",
                registration_tokens = tokens
            };
            var bodyStr = JsonConvert.SerializeObject(body);
            var httpContent = new StringContent(bodyStr, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, httpContent);
            if (!response.IsSuccessStatusCode) return null;
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }

        public async Task<dynamic> Info(string token)
        {
            var endpoint = $"{FcmInfo}/{token}?details=true";
            var uri = new Uri(endpoint);
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;
            var responseStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseStr);
        }

        public async Task<string> Send(FcmNotification fcmNotification)
        {
            var uri = new Uri(FcmSend);
            fcmNotification.To = "/topics/" + fcmNotification.To;
            var body = JsonConvert.SerializeObject(fcmNotification);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, httpContent);
            if (!response.IsSuccessStatusCode) return null;
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }

        public async Task Send(List<string> topics, FcmNotification notification, bool includeMe)
        {
            var currentUser = ""; // TODO Implementar
            foreach (var topic in topics)
            {
                if (!includeMe && currentUser.Equals(topic)) continue;
                notification.To = topic;
                await Send(notification);
            }
        }

        public void SendOnNewThread(FcmNotification fcmNotification)
        {
            var thread = new Thread(async () => await Send(fcmNotification));
            thread.Start();
        }
    }
}

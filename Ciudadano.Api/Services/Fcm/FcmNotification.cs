using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ciudadano.Api.Services.Fcm
{
    public class FcmNotification
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("android")]
        public AndroidConfig AndroidConfig { get; set; } = new AndroidConfig();
    }

    public class Data
    {
        public FcmNotificationType Type { get; set; }

        public string ModelName { get; set; }

        public string ModelId { get; set; }

        public bool ShowNotification { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public dynamic Extra { get; set; }
    }

    public enum FcmNotificationType
    {
        GET_ALL,
        GET_BY_ID,
        DELETE_ALL,
        DELETE_BY_ID,
    }

    public class AndroidConfig
    {
        public string priority { get; set; } = "high";

        public string ttl { get; set; } = "2419200s"; // 4 Semenas (Máximo permitido en FCM)
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Attributes;
using Newtonsoft.Json;

namespace Ciudadano.Api.Models
{
    public class Base
    {
        [StringLength(64)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? InsertedAt { get; set; }

        [StringLength(128)]
        public string InsertedBy { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? UpdatedAt { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? DeletedAt { get; set; }

        [StringLength(128)]
        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}

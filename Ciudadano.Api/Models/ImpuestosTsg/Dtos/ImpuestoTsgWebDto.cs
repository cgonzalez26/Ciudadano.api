using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Attributes;

namespace Ciudadano.Api.Models.ImpuestosTsg.Dtos
{
    public class ImpuestoTsgWebDto : Base
    {
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? dFecha_Pago { get; set; }
        public int? iAnio { get; set; }
        public int? iPeriodo { get; set; }
        public double? nMonto_Pagar { get; set; }

        [StringLength(50)]
        public string sCatastro { get; set; }
        public double? nPago { get; set; }
        public double? nSaldo { get; set; }
        public string tObservaciones { get; set; }

        [StringLength(64)]
        public string InmuebleId { get; set; }
    }
}

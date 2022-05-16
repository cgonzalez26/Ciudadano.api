using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Attributes;
using Ciudadano.Api.Models.Vehiculos;

namespace Ciudadano.Api.Models.ImpuestosAut
{
    [Table("Impuesto_Aut")]
    public class ImpuestoAut : Base
    {
        //iId_Imp_Aut
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? dFecha_Pago { get; set; }
        public int? iAnio { get; set; }
        public int? iPeriodo { get; set; }
        public double? nMonto_Pagar { get; set; }

        [StringLength(50)]
        public string sDominio { get; set; }
        public double? nPago { get; set; }
        public double? nSaldo { get; set; }
        public string tObservaciones { get; set; }

        [StringLength(64)]
        public string VehiculoId { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
    }
}

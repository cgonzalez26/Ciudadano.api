using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Titulares;
using Ciudadano.Api.Models.Vehiculos;

namespace Ciudadano.Api.Models.VehiculosTitulares.Dtos
{
    public class VehiculoTitularWebDto : Base
    {
        [StringLength(64)]
        public string VehiculoId { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }

        [StringLength(64)]
        public string TitularId { get; set; }

        [JsonIgnore]
        public virtual Titular Titular { get; set; }
    }
}

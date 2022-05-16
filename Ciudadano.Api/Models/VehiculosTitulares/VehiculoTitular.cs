using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Titulares;
using Ciudadano.Api.Models.Vehiculos;

namespace Ciudadano.Api.Models.VehiculosTitulares
{
    [Table("VehiculosTitulares")]

    public class VehiculoTitular : Base
    {
        [Required]
        [StringLength(64)]
        public string VehiculoId { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }

        [Required]
        [StringLength(64)]
        public string TitularId { get; set; }

        [JsonIgnore]
        public virtual Titular Titular { get; set; }
    }
}

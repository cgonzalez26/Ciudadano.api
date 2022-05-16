using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Inmuebles;
using Ciudadano.Api.Models.Titulares;

namespace Ciudadano.Api.Models.InmueblesTitulares
{
    [Table("InmueblesTitulares")]
    public class InmuebleTitular : Base
    {
        [Required]
        [StringLength(64)]
        public string InmuebleId { get; set; }

        [JsonIgnore]
        public virtual Inmueble Inmueble { get; set; }

        [Required]
        [StringLength(64)]
        public string TitularId { get; set; }

        [JsonIgnore]
        public virtual Titular Titular { get; set; }
    }
}

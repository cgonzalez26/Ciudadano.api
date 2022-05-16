using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.InmueblesTitulares;
using Ciudadano.Api.Models.VehiculosTitulares;
using Ciudadano.Api.Models.Zonas;

namespace Ciudadano.Api.Models.Titulares
{
    [Table("Titulares")]
    public class Titular : Base
    {
        [Required]
        [StringLength(50)]
        public string sNroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string sNombre { get; set; }
        
        [StringLength(50)]
        public string sApellido { get; set; }

        [StringLength(1024)]
        public string sDomicilio { get; set; }

        [StringLength(50)]
        public string sTelefono { get; set; }

        [StringLength(50)]
        public string sCelular { get; set; }

        [StringLength(128)]
        public string sMail { get; set; }

        [StringLength(64)]
        public string ZonaId { get; set; }
        [JsonIgnore]
        public virtual Zona Zonas { get; set; }

        [JsonIgnore]
        public virtual ICollection<InmuebleTitular> InmueblesTitulares { get; set; } = new HashSet<InmuebleTitular>();

        [JsonIgnore]
        public virtual ICollection<VehiculoTitular> VehiculosTitulares { get; set; } = new HashSet<VehiculoTitular>();
    }
}

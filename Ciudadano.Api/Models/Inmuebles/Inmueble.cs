using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosInm;
using Ciudadano.Api.Models.ImpuestosTsg;
using Ciudadano.Api.Models.InmueblesTitulares;
using Ciudadano.Api.Models.Zonas;

namespace Ciudadano.Api.Models.Inmuebles
{
    [Table("Inmuebles")]
    public class Inmueble : Base
    {
        [StringLength(50)]
        public string sTerreno { get; set; }

        public double nVal_Ed { get; set; }
        public double nVal_Fis { get; set; }

        [StringLength(255)]
        public string sDomicilio { get; set; }

        public int iPIN { get; set; }

        [StringLength(50)]
        public string sCatastro { get; set; }

        [StringLength(64)]
        public string ZonaId { get; set; }
        [JsonIgnore]
        public virtual Zona Zonas { get; set; }

        [JsonIgnore]
        public virtual ICollection<ImpuestoInm> ImpuestosInm { get; set; } = new HashSet<ImpuestoInm>();

        [JsonIgnore]
        public virtual ICollection<ImpuestoTsg> ImpuestosTsg { get; set; } = new HashSet<ImpuestoTsg>();

        [JsonIgnore]
        public virtual ICollection<InmuebleTitular> InmueblesTitulares { get; set; } = new HashSet<InmuebleTitular>();
    }
}

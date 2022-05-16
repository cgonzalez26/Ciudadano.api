using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Establecimientos;

namespace Ciudadano.Api.Models.TipoEstablecimientos
{
    [Table("TipoEstablecimientos")]

    public class TipoEstablecimiento : Base
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Establecimiento> Establecimientos { get; set; } = new HashSet<Establecimiento>();
    }
}

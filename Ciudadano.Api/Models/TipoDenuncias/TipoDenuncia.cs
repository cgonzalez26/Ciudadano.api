using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Denuncias;

namespace Ciudadano.Api.Models.TipoDenuncias
{
    [Table("TipoDenuncias")]

    public class TipoDenuncia : Base
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }
      
        [StringLength(512)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Denuncia> Denuncias { get; set; } = new HashSet<Denuncia>();
    }
}

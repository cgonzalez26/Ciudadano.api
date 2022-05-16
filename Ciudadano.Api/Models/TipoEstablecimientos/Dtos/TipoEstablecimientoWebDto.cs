using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.TipoEstablecimientos.Dtos
{
    public class TipoEstablecimientoWebDto : Base
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }
    }
}

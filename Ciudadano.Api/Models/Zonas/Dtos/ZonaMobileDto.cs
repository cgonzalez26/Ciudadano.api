using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Zonas.Dtos
{
    public class ZonaMobileDto : Base
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [StringLength(64)]
        public string PadreId { get; set; }

        [Required]
        [StringLength(1024)]
        public string FullId { get; set; }

        [Required]
        [StringLength(64)]
        public string TipoZonaId { get; set; }
    }
}

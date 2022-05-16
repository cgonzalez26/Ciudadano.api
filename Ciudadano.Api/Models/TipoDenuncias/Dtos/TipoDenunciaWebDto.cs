using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.TipoDenuncias.Dtos
{
    public class TipoDenunciaWebDto : Base
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [StringLength(512)]
        public string Descripcion { get; set; }
    }
}

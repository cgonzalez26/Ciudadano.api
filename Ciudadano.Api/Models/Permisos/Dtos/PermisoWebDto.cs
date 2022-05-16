using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Permisos.Dtos
{
    public class PermisoWebDto : Base
    {
        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(512)]
        public string Descripcion { get; set; }

        public int Orden { get; set; }

        public bool? Concedido { get; set; }
    }
}

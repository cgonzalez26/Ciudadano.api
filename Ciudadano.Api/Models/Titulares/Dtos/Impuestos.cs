using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Titulares.Dtos
{
    public class Impuestos
    {
        public int? iAnio { get; set; }
        public int? iPeriodo { get; set; }
        
        [StringLength(50)]
        public string TipoImpuesto { get; set; }
        [StringLength(50)]
        public string Propiedad { get; set; }
        public double? nSaldo { get; set; }
    }
}

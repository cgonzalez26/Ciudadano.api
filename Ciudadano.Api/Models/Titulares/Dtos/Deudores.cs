using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Titulares.Dtos
{
    public class Deudores
    {
        [StringLength(64)]
        public string ZonaId { get; set; }

        [StringLength(100)]
        public string Zona { get; set; }

        [StringLength(64)]
        public string TitularId { get; set; }

        [StringLength(50)]
        public string sNroDocumento { get; set; }

        [StringLength(50)]
        public string sApellido { get; set; }

        [StringLength(50)]
        public string sNombre { get; set; }

        [StringLength(1024)]
        public string sDomicilio { get; set; }

        public double? nSaldo { get; set; }
    }
}

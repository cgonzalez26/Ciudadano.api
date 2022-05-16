using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Vehiculos.Dtos
{
    public class VehiculoWebDto : Base
    {
        [StringLength(50)]
        public string sModelo { get; set; }

        [StringLength(50)]
        public string sMarca { get; set; }

        public int iAnio { get; set; }

        public double nVal_F_V { get; set; }

        [StringLength(255)]
        public string sDomicilio { get; set; }

        public int iPIN { get; set; }
    }
}

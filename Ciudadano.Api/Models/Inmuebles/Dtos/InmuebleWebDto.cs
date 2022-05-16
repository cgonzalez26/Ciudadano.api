using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Inmuebles.Dtos
{
    public class InmuebleWebDto : Base
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
    }
}

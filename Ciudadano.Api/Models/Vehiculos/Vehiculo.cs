using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosAut;
using Ciudadano.Api.Models.VehiculosTitulares;

namespace Ciudadano.Api.Models.Vehiculos
{
    [Table("Vehiculos")]
    public class Vehiculo : Base
    {
        [Required]
        [StringLength(50)]
        public string sDominio { get; set; }

        [StringLength(50)]
        public string sModelo { get; set; }

        [StringLength(50)]
        public string sMarca { get; set; }

        public int iAnio { get; set; }

        public double nVal_F_V { get; set; }

        [StringLength(255)]
        public string sDomicilio { get; set; }

        public int iPIN { get; set; }

        [JsonIgnore]
        public virtual ICollection<ImpuestoAut> ImpuestosAut { get; set; } = new HashSet<ImpuestoAut>();

        [JsonIgnore]
        public virtual ICollection<VehiculoTitular> VehiculosTitulares { get; set; } = new HashSet<VehiculoTitular>();
    }
}

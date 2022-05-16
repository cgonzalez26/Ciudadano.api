using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.TipoEstablecimientos;
using Ciudadano.Api.Models.Zonas;
using Ciudadano.Api.Models.Zonas.Dtos;

namespace Ciudadano.Api.Models.Establecimientos.Dtos
{
    public class EstablecimientoWebDto : Base
    {
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Domicilio { get; set; }

        [StringLength(64)]
        public string TipoEstablecimientoId { get; set; }

        [JsonIgnore]
        public virtual TipoEstablecimiento TipoEstablecimiento { get; set; }

        [StringLength(64)]
        public string ZonaId { get; set; }

        [JsonIgnore]
        public virtual Zona Zona { get; set; }

        [Column(TypeName = "decimal(19,10)")]
        public decimal? Latitud { get; set; }

        [Column(TypeName = "decimal(19,10)")]
        public decimal? Longitud { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.InmueblesTitulares.Dtos
{
    public class InmuebleTitularWebDto : Base
    {
        [Required]
        [StringLength(64)]
        public string InmuebleId { get; set; }
   
        [Required]
        [StringLength(64)]
        public string TitularId { get; set; }   
    }
}

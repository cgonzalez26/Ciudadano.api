using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Attributes;

namespace Ciudadano.Api.Models.Usuarios.Dtos
{
    public class AddUsuarioWebDto : Base
    {
        [Required]
        [StringLength(64)]
        public string UsuarioNombre { get; set; }

        [Required]
        [StringLength(1024)]        
        public string Password { get; set; }

        [StringLength(50)]
        public string sNroDocumento { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(64)]
        public string Apellidos { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(1024)]
        public string Foto { get; set; }

        [StringLength(8)]
        public string CodigoPostal { get; set; }

        [StringLength(16)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(64)]
        public string RolId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Usuarios.Dtos
{
    public class AuthenticationDto 
    {
        [Required]
        [StringLength(64)]
        public string UsuarioNombre { get; set; }

        [Required]
        [StringLength(1024)]
        public string Password { get; set; }
    }
}

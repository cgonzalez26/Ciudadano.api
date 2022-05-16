using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Authorization
{
    public class IdentityServerUser
    {
        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public string Mail { get; set; }
        public string Telefono1 { get; set; }
        public DateTimeOffset? FechaActualizacion { get; set; }
        public ICollection<IdentityServerRole> Roles { get; set; } = new List<IdentityServerRole>();
        public ICollection<string> Organizations { get; set; } = new List<string>();
    }
}

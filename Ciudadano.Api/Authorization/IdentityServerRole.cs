using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Authorization
{
    public class IdentityServerRole
    {
        public string CodSistema { get; set; }
        public string CodTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }
    }
}

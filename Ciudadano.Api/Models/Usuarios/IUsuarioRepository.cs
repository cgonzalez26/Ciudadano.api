using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Usuarios.Dtos;

namespace Ciudadano.Api.Models.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        UsuarioWebDto Authenticate(string UsuarioNombre, string password, string secretKey, int expires);
    }
}

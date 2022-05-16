using System.Collections.Generic;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Permisos.Dtos;

namespace Ciudadano.Api.Models.Permisos
{
    public interface IPermisoRepository : IRepository<Permiso>
    {
        ICollection<PermisoWebDto> GetByRolId(string rolId);

        Task<ICollection<PermisoWebDto>> GetByRolIdAsync(string rolId);
    }
}

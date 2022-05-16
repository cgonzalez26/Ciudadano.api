using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Permisos.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Ciudadano.Api.Models.Permisos
{
    public class PermisoRepository : Repository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<PermisoWebDto> GetByRolId(string rolId)
        {
            return Context.Permisos.Select(e => new PermisoWebDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Orden = e.Orden,
                Concedido = e.RolPermisos.FirstOrDefault(rp => rp.RolId.Equals(rolId)) != null
            }).OrderBy(e => e.Orden).ToList();
        }

        public async Task<ICollection<PermisoWebDto>> GetByRolIdAsync(string rolId)
        {
            return await Context.Permisos.Select(e => new PermisoWebDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Orden = e.Orden,
                Concedido = e.RolPermisos.FirstOrDefault(rp => rp.RolId.Equals(rolId)) != null
            }).OrderBy(e => e.Orden).ToListAsync();
        }
    }
}

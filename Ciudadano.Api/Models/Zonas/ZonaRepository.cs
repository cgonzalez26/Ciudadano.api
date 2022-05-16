using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ciudadano.Api.Models.Zonas
{
    public class ZonaRepository : Repository<Zona>, IZonaRepository
    {
        public ZonaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Zona> zonaByDepartamento(string departamentoId)
        {
            return Context.Zonas.Where(e => e.PadreId.Equals(departamentoId)).ToList();
        }

    }
}

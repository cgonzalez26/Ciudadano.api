using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Inmuebles
{
    public class InmuebleRepository : Repository<Inmueble>, IInmuebleRepository
    {
        public InmuebleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

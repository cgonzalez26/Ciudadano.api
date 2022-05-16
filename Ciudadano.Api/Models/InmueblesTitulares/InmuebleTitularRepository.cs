using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.InmueblesTitulares
{
    public class InmuebleTitularRepository : Repository<InmuebleTitular>, IInmuebleTitularRepository
    {
        public InmuebleTitularRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

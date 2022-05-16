using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.VehiculosTitulares
{
    public class VehiculoTitularRepository : Repository<VehiculoTitular>, IVehiculoTitularRepository
    {
        public VehiculoTitularRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

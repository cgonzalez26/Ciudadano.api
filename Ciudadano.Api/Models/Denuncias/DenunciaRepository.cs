using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Denuncias
{
    public class DenunciaRepository : Repository<Denuncia>, IDenunciaRepository
    {
        public DenunciaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

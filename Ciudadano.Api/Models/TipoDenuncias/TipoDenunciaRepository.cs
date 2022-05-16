using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.TipoDenuncias
{
    public class TipoDenunciaRepository : Repository<TipoDenuncia>, ITipoDenunciaRepository
    {
        public TipoDenunciaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

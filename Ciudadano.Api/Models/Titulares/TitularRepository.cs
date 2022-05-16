using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Titulares.Dtos;

namespace Ciudadano.Api.Models.Titulares
{
    public class TitularRepository : Repository<Titular>, ITitularRepository
    {
        public TitularRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Titular getByNroDocumento(string NroDocumento) 
        {
            return Context.Titulares.Where(e => e.sNroDocumento.Equals(NroDocumento)).FirstOrDefault();
        }

        public dynamic deudoresByZona(string zonaid)
        {
            List<Deudores> rows = new List<Deudores>();
            Context.LoadStoredProc("getDeudoresByZona")
                .AddParam("@ZonaId", zonaid)
                .Exec(r => rows = r.ToList<Deudores>());
            return rows;

        }

        public dynamic getDeudasByTitularId(string titularid)
        {
            List<Impuestos> rows = new List<Impuestos>();
            Context.LoadStoredProc("getDeudasByTitularId")
                .AddParam("@TitularId", titularid)
                .Exec(r => rows = r.ToList<Impuestos>());
            return rows;

        }
    }
}

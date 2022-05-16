using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Titulares.Dtos;

namespace Ciudadano.Api.Models.Titulares
{
    public interface ITitularRepository : IRepository<Titular>
    {
        Titular getByNroDocumento(string NroDocumento);
        public dynamic deudoresByZona(string zonaid);
        public dynamic getDeudasByTitularId(string titularid);
    }
}

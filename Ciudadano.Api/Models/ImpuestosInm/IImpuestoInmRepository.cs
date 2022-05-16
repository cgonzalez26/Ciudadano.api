using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosInm.Dtos;

namespace Ciudadano.Api.Models.ImpuestosInm
{
    public interface IImpuestoInmRepository : IRepository<ImpuestoInm>
    {
        ICollection<ImpuestoInmWebDto> getByNroDocumento(string NroDocumento);

        int getCountDeudaByNroDocumento(string NroDocumento);
    }
}

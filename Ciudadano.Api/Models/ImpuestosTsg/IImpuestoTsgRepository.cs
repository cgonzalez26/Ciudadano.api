using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosTsg.Dtos;

namespace Ciudadano.Api.Models.ImpuestosTsg
{
    public interface IImpuestoTsgRepository : IRepository<ImpuestoTsg>
    {
        ICollection<ImpuestoTsgWebDto> getByNroDocumento(string NroDocumento);

        int getCountDeudaByNroDocumento(string NroDocumento);
    }
}

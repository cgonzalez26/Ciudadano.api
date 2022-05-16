using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Establecimientos.Dtos;
using Ciudadano.Api.Models.ImpuestosAut.Dtos;

namespace Ciudadano.Api.Models.ImpuestosAut
{
    public interface IImpuestoAutRepository : IRepository<ImpuestoAut>
    {
        /* ICollection<EstablecimientoWebDto> CustomGetByQuery(EstablecimientoQuery query);

         ICollection<EstablecimientoWebDto> CustomGetAll();*/
        ICollection<ImpuestoAutWebDto> getByNroDocumento(string NroDocumento);
        int getCountDeudaByNroDocumento(string NroDocumento);
    }
}

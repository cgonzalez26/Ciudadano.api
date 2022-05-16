using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Establecimientos.Dtos;

namespace Ciudadano.Api.Models.Establecimientos
{
    public interface IEstablecimientoRepository : IRepository<Establecimiento>
    {
        ICollection<EstablecimientoWebDto> CustomGetByQuery(EstablecimientoQuery query);

        ICollection<EstablecimientoWebDto> CustomGetAll();
    }
}

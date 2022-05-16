    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Establecimientos.Dtos;
using Ciudadano.Api.Models.Zonas.Dtos;

namespace Ciudadano.Api.Models.Establecimientos
{
    public class EstablecimientoRepository : Repository<Establecimiento>, IEstablecimientoRepository
    {
        public EstablecimientoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<EstablecimientoWebDto> CustomGetByQuery(EstablecimientoQuery query)
        {
            if (query.Page < 0) return new List<EstablecimientoWebDto>();

            Expression<Func<Establecimiento, bool>> whereTrue = e => true;
            var where = query.Where ?? whereTrue;

            if (query.OrderBy == null && query.OrderByDescending == null)
            {
                return Context.Set<Establecimiento>().Where(where).Select(e => new EstablecimientoWebDto
                {
                    Id = e.Id,
                    Codigo = e.Codigo,
                    Nombre = e.Nombre,
                    Domicilio = e.Domicilio,
                    TipoEstablecimientoId = e.TipoEstablecimientoId,
                    ZonaId = e.ZonaId,
                    /*Zona = e.Zona == null ? null : new ZonaWebDto
                    {
                        Id = e.Zona.Id,
                        Nombre = e.Zona.Nombre,
                        PadreId = e.Zona.PadreId,
                        FullId = e.Zona.FullId,
                    },*/
                   
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,                    
                    IsDeleted = e.IsDeleted,
                    
                })
                    .OrderBy(e => e.InsertedAt)
                    .Skip(query.Page * query.Top)
                    .Take(query.Top)
                    .ToList();
            }

            if (query.OrderBy != null)
            {
                return Context.Set<Establecimiento>().Where(where).Select(e => new EstablecimientoWebDto
                {
                    Id = e.Id,
                    Codigo = e.Codigo,
                    Nombre = e.Nombre,
                    Domicilio = e.Domicilio,
                    TipoEstablecimientoId = e.TipoEstablecimientoId,
                    ZonaId = e.ZonaId,
                    /*Zona = e.Zona == null ? null : new ZonaWebDto
                    {
                        Id = e.Zona.Id,
                        Nombre = e.Zona.Nombre,
                        PadreId = e.Zona.PadreId,
                        FullId = e.Zona.FullId,
                    },*/
                    Latitud = e.Latitud,
                    Longitud = e.Longitud,
                    IsDeleted = e.IsDeleted,
                })
                    .OrderBy(query.OrderBy)
                    .Skip(query.Page * query.Top)
                    .Take(query.Top)
                    .ToList();
            }

            return Context.Set<Establecimiento>().Where(where).Select(e => new EstablecimientoWebDto
            {
                Id = e.Id,
                Codigo = e.Codigo,
                Nombre = e.Nombre,
                Domicilio = e.Domicilio,
                TipoEstablecimientoId = e.TipoEstablecimientoId,
                ZonaId = e.ZonaId,
                /*Zona = e.Zona == null ? null : new ZonaWebDto
                {
                    Id = e.Zona.Id,
                    Nombre = e.Zona.Nombre,
                    PadreId = e.Zona.PadreId,
                    FullId = e.Zona.FullId,
                },*/
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                IsDeleted = e.IsDeleted,
            })
                .OrderByDescending(query.OrderByDescending)
                .Skip(query.Page * query.Top)
                .Take(query.Top)
                .ToList();
        }

        public ICollection<EstablecimientoWebDto> CustomGetAll()
        {
            return Context.Establecimientos.Select(e => new EstablecimientoWebDto
            {
                Id = e.Id,
                Codigo = e.Codigo,
                Nombre = e.Nombre,
                Domicilio = e.Domicilio,
                TipoEstablecimientoId = e.TipoEstablecimientoId                
            }).OrderBy(e => e.Nombre).ToList();
        }
    }
}

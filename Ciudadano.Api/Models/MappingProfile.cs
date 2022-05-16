using AutoMapper;
using Ciudadano.Api.Models.Establecimientos;
using Ciudadano.Api.Models.Establecimientos.Dtos;
using Ciudadano.Api.Models.TipoZonas;
using Ciudadano.Api.Models.TipoZonas.Dtos;
using Ciudadano.Api.Models.Zonas;
using Ciudadano.Api.Models.Zonas.Dtos;

namespace Ciudadano.Api.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // TipoZona Web Dto
            CreateMap<TipoZona, TipoZonaWebDto>();
            CreateMap<TipoZonaWebDto, TipoZona>()
                .ForMember(m => m.Zonas, opt => opt.Ignore());

            // Zona Web Dto
            CreateMap<Zona, ZonaWebDto>();
            CreateMap<ZonaWebDto, Zona>()
                .ForMember(m => m.Padre, opt => opt.Ignore())
                .ForMember(m => m.Geometria, opt => opt.Ignore())
                .ForMember(m => m.TipoZona, opt => opt.Ignore());

            // Establecimiento Web Dto
            CreateMap<Establecimiento, EstablecimientoWebDto>();
            CreateMap<EstablecimientoWebDto, Establecimiento>()
                .ForMember(m => m.TipoEstablecimiento, opt => opt.Ignore())
                .ForMember(m => m.Zona, opt => opt.Ignore());
        }
    }
}

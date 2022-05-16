using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Roles;
using Ciudadano.Api.Services.Fcm;
using Ciudadano.Api.Services.HttpContext;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Ciudadano.Api.Models.Permisos;
using Ciudadano.Api.Models.RolPermisos;
using Ciudadano.Api.Models.TipoZonas;
using Ciudadano.Api.Models.Zonas;
using Ciudadano.Api.Models.Usuarios;
using Ciudadano.Api.Models.Establecimientos;
using Ciudadano.Api.Models.TipoEstablecimientos;
using AutoMapper;
using Ciudadano.Api.Models.ImpuestosAut;
using Ciudadano.Api.Models.ImpuestosInm;
using Ciudadano.Api.Models.InmueblesTitulares;
using Ciudadano.Api.Models.Titulares;
using Ciudadano.Api.Models.Inmuebles;
using Ciudadano.Api.Models.ImpuestosTsg;
using Ciudadano.Api.Models.TipoDenuncias;
using Ciudadano.Api.Models.Denuncias;
using Ciudadano.Api.Models.Vehiculos;
using Ciudadano.Api.Models.VehiculosTitulares;

namespace Ciudadano.Api
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IPermisoRepository), typeof(PermisoRepository));
            services.AddScoped(typeof(IRolRepository), typeof(RolRepository));
            services.AddScoped(typeof(IRolPermisoRepository), typeof(RolPermisoRepository));
            services.AddScoped(typeof(ITipoZonaRepository), typeof(TipoZonaRepository));
            services.AddScoped(typeof(IZonaRepository), typeof(ZonaRepository));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IEstablecimientoRepository), typeof(EstablecimientoRepository));
            services.AddScoped(typeof(ITipoEstablecimientoRepository), typeof(TipoEstablecimientoRepository));
            services.AddScoped(typeof(IImpuestoAutRepository), typeof(ImpuestoAutRepository));
            services.AddScoped(typeof(IImpuestoInmRepository), typeof(ImpuestoInmRepository));
            services.AddScoped(typeof(IImpuestoTsgRepository), typeof(ImpuestoTsgRepository));
            services.AddScoped(typeof(IInmuebleTitularRepository), typeof(InmuebleTitularRepository));
            services.AddScoped(typeof(ITitularRepository), typeof(TitularRepository));
            services.AddScoped(typeof(IInmuebleRepository), typeof(InmuebleRepository));
            services.AddScoped(typeof(ITipoDenunciaRepository), typeof(TipoDenunciaRepository));
            services.AddScoped(typeof(IDenunciaRepository), typeof(DenunciaRepository));
            services.AddScoped(typeof(IVehiculoRepository), typeof(VehiculoRepository));
            services.AddScoped(typeof(IVehiculoTitularRepository), typeof(VehiculoTitularRepository));

            // Scoped Services
            services.AddScoped<IFcmService, FcmService>();

            // Transient Services
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<HttpContextService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

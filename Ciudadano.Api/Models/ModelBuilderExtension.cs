using Ciudadano.Api.Migrations.Seed;
using Microsoft.EntityFrameworkCore;
using Ciudadano.Api.Models.Permisos;
using Ciudadano.Api.Models.Roles;
using Ciudadano.Api.Models.RolPermisos;
using Ciudadano.Api.Models.TipoZonas;
using Ciudadano.Api.Models.Zonas;
using Ciudadano.Api.Models.TipoEstablecimientos;
using Ciudadano.Api.Models.Establecimientos;
using Ciudadano.Api.Models.ImpuestosAut;
using Ciudadano.Api.Models.ImpuestosInm;
using Ciudadano.Api.Models.InmueblesTitulares;
using Ciudadano.Api.Models.Titulares;
using Ciudadano.Api.Models.Inmuebles;
using Ciudadano.Api.Models.ImpuestosTsg;
using Ciudadano.Api.Models.Denuncias;
using Ciudadano.Api.Models.TipoDenuncias;
using Ciudadano.Api.Models.Vehiculos;
using Ciudadano.Api.Models.VehiculosTitulares;
using Ciudadano.Api.Models.Usuarios;

namespace Ciudadano.Api.Models
{
    public static class ModelBuilderExtension
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermisoConfiguration());
            modelBuilder.ApplyConfiguration(new RolConfiguration());
            modelBuilder.ApplyConfiguration(new RolPermisoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoZonaConfiguration());
            modelBuilder.ApplyConfiguration(new ZonaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEstablecimientoConfiguration());
            modelBuilder.ApplyConfiguration(new EstablecimientoConfiguration());
            modelBuilder.ApplyConfiguration(new ImpuestoAutConfiguration());
            modelBuilder.ApplyConfiguration(new ImpuestoInmConfiguration());
            modelBuilder.ApplyConfiguration(new ImpuestoTsgConfiguration());
            modelBuilder.ApplyConfiguration(new InmuebleTitularConfiguration());
            modelBuilder.ApplyConfiguration(new TitularConfiguration());
            modelBuilder.ApplyConfiguration(new InmuebleConfiguration());
            modelBuilder.ApplyConfiguration(new DenunciaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDenunciaConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculoConfiguration());
            modelBuilder.ApplyConfiguration(new VehiculoTitularConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedPermisos();
            modelBuilder.SeedRoles();
            modelBuilder.SeedRolPermisos();
            modelBuilder.SeedTipoEstablecimientos();
            modelBuilder.SeedZonas();
            modelBuilder.SeedEstablecimientos();
            modelBuilder.SeedTipoDenuncias();
        }
    }
}

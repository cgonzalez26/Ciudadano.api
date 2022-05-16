using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ciudadano.Api.Models.Denuncias;
using Ciudadano.Api.Models.Establecimientos;
using Ciudadano.Api.Models.ImpuestosAut;
using Ciudadano.Api.Models.ImpuestosInm;
using Ciudadano.Api.Models.ImpuestosTsg;
using Ciudadano.Api.Models.Inmuebles;
using Ciudadano.Api.Models.InmueblesTitulares;
using Ciudadano.Api.Models.Permisos;
using Ciudadano.Api.Models.Roles;
using Ciudadano.Api.Models.RolPermisos;
using Ciudadano.Api.Models.TipoDenuncias;
using Ciudadano.Api.Models.TipoEstablecimientos;
using Ciudadano.Api.Models.TipoZonas;
using Ciudadano.Api.Models.Titulares;
using Ciudadano.Api.Models.Usuarios;
using Ciudadano.Api.Models.Vehiculos;
using Ciudadano.Api.Models.VehiculosTitulares;
using Ciudadano.Api.Models.Zonas;

namespace Ciudadano.Api.Models
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();
            modelBuilder.Seed();
        }

        public DbSet<Permiso> Permisos { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<RolPermiso> RolPermisos { get; set; }

        public DbSet<Zona> Zonas { get; set; }

        public DbSet<TipoZona> TipoZonas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Establecimiento> Establecimientos { get; set; }

        public DbSet<TipoEstablecimiento> TipoEstablecimientos { get; set; }

        public DbSet<ImpuestoAut> ImpuestosAut { get; set; }

        public DbSet<ImpuestoInm> ImpuestosInm { get; set; }

        public DbSet<ImpuestoTsg> ImpuestosTsg { get; set; }

        public DbSet<InmuebleTitular> InmueblesTitulares { get; set; }

        public DbSet<Titular> Titulares { get; set; }

        public DbSet<Inmueble> Inmuebles { get; set; }

        public DbSet<Denuncia> Denuncias { get; set; }

        public DbSet<TipoDenuncia> TipoDenuncias { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<VehiculoTitular> VehiculosTitulares { get; set; }

        public override int SaveChanges()
        {
            var currentUser = string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name) ? "Anonymous" : _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

            foreach (var entry in ChangeTracker.Entries<Base>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.State == EntityState.Added)
                    {
                        if (string.IsNullOrEmpty(entry.Entity.Id))
                        {
                            entry.Entity.Id = Guid.NewGuid().ToString();
                        }
                        entry.Entity.InsertedAt = entry.Entity.InsertedAt ?? DateTime.UtcNow;
                        entry.Entity.InsertedBy = currentUser;
                    }
                    else
                    {
                        entry.Property(p => p.InsertedAt).IsModified = false;
                        entry.Property(p => p.InsertedBy).IsModified = false;
                    }

                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = currentUser;
                }

                if (entry.State == EntityState.Deleted)
                {
                    SoftDelete(entry, this, currentUser);
                }
            }
            return base.SaveChanges();
        }

        public void SoftDelete(EntityEntry<Base> entry, ApplicationDbContext context, string deletedBy)
        {
            var properties = entry.OriginalValues.Properties;
            foreach (var property in properties)
            {
                entry.Property(property.Name).CurrentValue = entry.OriginalValues[property.Name];
            }
            entry.Property("IsDeleted").CurrentValue = true;
            entry.Property("DeletedAt").CurrentValue = DateTime.UtcNow;
            entry.Property("DeletedBy").CurrentValue = deletedBy;
            entry.State = EntityState.Modified;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.TipoEstablecimientos;

namespace Ciudadano.Api.Migrations.Seed
{
    public static class TipoEstablecimientoSeed
    {
        public static void SeedTipoEstablecimientos(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoEstablecimiento>().HasData(
                new TipoEstablecimiento { Id = "ID_ESCUELAS", Nombre = "ESCUELAS", Descripcion = "ESCUELAS" },
                new TipoEstablecimiento { Id = "ID_TECNICAS", Nombre = "TECNICAS", Descripcion = "TECNICAS" },
                new TipoEstablecimiento { Id = "ID_SECUNDARIOS", Nombre = "SECUNDARIOS", Descripcion = "SECUNDARIOS" },
                new TipoEstablecimiento { Id = "ID_INSTITUCIONES", Nombre = "INSTITUCIONES", Descripcion = "INSTITUCIONES" },
                new TipoEstablecimiento { Id = "ID_ESTABLECIMIENTOS", Nombre = "ESTABLECIMIENTOS", Descripcion = "ESTABLECIMIENTOS" }
            );
        }
    }
}

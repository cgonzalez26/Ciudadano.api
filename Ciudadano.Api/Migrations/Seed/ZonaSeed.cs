using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Zonas;

namespace Ciudadano.Api.Migrations.Seed
{
    public static class ZonaSeed
    {
        public static void SeedZonas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zona>().HasData(
                new Zona { Id = "66", Nombre = "Salta", PadreId = null, FullId = "66" },
                new Zona { Id = "66028", Nombre = "Capital", PadreId = "66", FullId = "66.66028" },
                new Zona { Id = "Id_Interior", Nombre = "Interior", PadreId = "66", FullId = "66.Id_Interior" },
                new Zona { Id = "ID_NORTE", Nombre = "NORTE", PadreId = "66028", FullId = "66.66028.ID_NORTE" },
                new Zona { Id = "ID_SUR", Nombre = "SUR", PadreId = "66028", FullId = "66.66028.ID_SUR" },
                new Zona { Id = "ID_ESTE", Nombre = "ESTE", PadreId = "66028", FullId = "66.66028.ID_ESTE" },
                new Zona { Id = "ID_OESTE", Nombre = "OESTE", PadreId = "66028", FullId = "66.66028.ID_OESTE" },
                new Zona { Id = "ID_CENTRO", Nombre = "CENTRO", PadreId = "66028", FullId = "66.66028.ID_CENTRO" }
            );
        }
    }
}

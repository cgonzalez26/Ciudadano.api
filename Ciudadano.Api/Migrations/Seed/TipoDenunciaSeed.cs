using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.TipoDenuncias;

namespace Ciudadano.Api.Migrations.Seed
{
    public static class TipoDenunciaSeed
    {
        public static void SeedTipoDenuncias(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDenuncia>().HasData(
                new TipoDenuncia { Id = "ID_BASURAL", Nombre = "BASURAL", Descripcion = "BASURAL" },
                new TipoDenuncia { Id = "ID_BACHE", Nombre = "BACHE", Descripcion = "BACHE" },
                new TipoDenuncia { Id = "ID_PERDIDA_AGUA", Nombre = "PERDIDA DE AGUA", Descripcion = "PERDIDA DE AGUA" },
                new TipoDenuncia { Id = "ID_DESBORDE_CLOACAL", Nombre = "DESBORDE CLOACAL", Descripcion = "DESBORDE CLOACAL" },
                new TipoDenuncia { Id = "ID_OCUPACION_VIA_PUBLICA", Nombre = "OCUPACION INDEBIDA DE LA VIA PUBLICA", Descripcion = "OCUPACION INDEBIDA DE LA VIA PUBLICA" },
                new TipoDenuncia { Id = "ID_OBSTRUCCION_RAMPAS", Nombre = "OBSTRUCCION DE RAMPAS ACCESIBILIDAD", Descripcion = "OBSTRUCCION DE RAMPAS ACCESIBILIDAD" },
                new TipoDenuncia { Id = "ID_OTRO", Nombre = "OTRO", Descripcion = "OTRO" }
            );
        }
    }
}

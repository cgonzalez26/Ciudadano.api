using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Inmuebles
{
    public class InmuebleConfiguration : IEntityTypeConfiguration<Inmueble>
    {
        public void Configure(EntityTypeBuilder<Inmueble> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

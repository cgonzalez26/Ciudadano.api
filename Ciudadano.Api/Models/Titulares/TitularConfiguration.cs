using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.Titulares
{
    public class TitularConfiguration : IEntityTypeConfiguration<Titular>
    {
        public void Configure(EntityTypeBuilder<Titular> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.InmueblesTitulares
{
    public class InmuebleTitularConfiguration : IEntityTypeConfiguration<InmuebleTitular>
    {
        public void Configure(EntityTypeBuilder<InmuebleTitular> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

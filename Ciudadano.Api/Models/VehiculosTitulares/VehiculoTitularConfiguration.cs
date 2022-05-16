using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.VehiculosTitulares
{
    public class VehiculoTitularConfiguration : IEntityTypeConfiguration<VehiculoTitular>
    {
        public void Configure(EntityTypeBuilder<VehiculoTitular> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

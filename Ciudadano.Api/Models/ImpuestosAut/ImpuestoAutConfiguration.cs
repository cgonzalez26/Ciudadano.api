using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.ImpuestosAut
{
    public class ImpuestoAutConfiguration : IEntityTypeConfiguration<ImpuestoAut>
    {
        public void Configure(EntityTypeBuilder<ImpuestoAut> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

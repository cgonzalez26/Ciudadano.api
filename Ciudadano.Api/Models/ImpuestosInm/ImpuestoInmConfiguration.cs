using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.ImpuestosInm
{
    public class ImpuestoInmConfiguration : IEntityTypeConfiguration<ImpuestoInm>
    {
        public void Configure(EntityTypeBuilder<ImpuestoInm> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.ImpuestosTsg
{
    public class ImpuestoTsgConfiguration : IEntityTypeConfiguration<ImpuestoTsg>
    {
        public void Configure(EntityTypeBuilder<ImpuestoTsg> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

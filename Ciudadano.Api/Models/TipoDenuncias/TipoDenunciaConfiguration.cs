using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciudadano.Api.Models.TipoDenuncias
{
    public class TipoDenunciaConfiguration : IEntityTypeConfiguration<TipoDenuncia>
    {
        public void Configure(EntityTypeBuilder<TipoDenuncia> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

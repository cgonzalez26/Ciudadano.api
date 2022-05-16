using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ciudadano.Api.Models.Zonas
{
    public class ZonaConfiguration : IEntityTypeConfiguration<Zona>
    {
        public void Configure(EntityTypeBuilder<Zona> builder)
        {
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}

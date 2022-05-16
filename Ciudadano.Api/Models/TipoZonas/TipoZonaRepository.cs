namespace Ciudadano.Api.Models.TipoZonas
{
    public class TipoZonaRepository : Repository<TipoZona>, ITipoZonaRepository
    {
        public TipoZonaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

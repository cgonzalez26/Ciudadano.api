namespace Ciudadano.Api.Models.RolPermisos
{
    public class RolPermisoRepository : Repository<RolPermiso>, IRolPermisoRepository
    {
        public RolPermisoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
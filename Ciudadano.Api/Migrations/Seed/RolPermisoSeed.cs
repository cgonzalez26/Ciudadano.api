using Ciudadano.Api.Models.RolPermisos;
using Microsoft.EntityFrameworkCore;

namespace Ciudadano.Api.Migrations.Seed
{
    public static class RolPermisoSeed
    {
        public static void SeedRolPermisos(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolPermiso>().HasData(
                new RolPermiso { Id = "ID_SA_PH", RolId = "COD_ADMIN", PermisoId = "PAGES_HOME" },

                new RolPermiso { Id = "ID_SA_PM", RolId = "COD_ADMIN", PermisoId = "PAGES_MANAGEMENT" },
                new RolPermiso { Id = "ID_SA_PM_ES", RolId = "COD_ADMIN", PermisoId = "PAGES_MANAGEMENT_ESTABLECIMIENTOS" },
                new RolPermiso { Id = "ID_SA_PM_ES_ADD", RolId = "COD_ADMIN", PermisoId = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD" },
                new RolPermiso { Id = "ID_SA_PM_ES_EDIT", RolId = "COD_ADMIN", PermisoId = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT" },
                new RolPermiso { Id = "ID_SA_PM_ES_DELETE", RolId = "COD_ADMIN", PermisoId = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE" },

                new RolPermiso { Id = "ID_SA_PS", RolId = "COD_ADMIN", PermisoId = "PAGES_SECURITY" },
                new RolPermiso { Id = "ID_SA_PS_RP", RolId = "COD_ADMIN", PermisoId = "PAGES_SECURITY_ROLES_AND_PERMISSIONS" },
                new RolPermiso { Id = "ID_SA_PS_RP_ADD", RolId = "COD_ADMIN", PermisoId = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD" },
                new RolPermiso { Id = "ID_SA_PS_RP_EDIT", RolId = "COD_ADMIN", PermisoId = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT" },
                new RolPermiso { Id = "ID_SA_PS_RP_DELETE", RolId = "COD_ADMIN", PermisoId = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE" }
            );
        }
    }
}

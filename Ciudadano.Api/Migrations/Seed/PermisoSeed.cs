using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.Permisos;
using Microsoft.EntityFrameworkCore;

namespace Ciudadano.Api.Migrations.Seed
{
    public static class PermisoSeed
    {
        public static void SeedPermisos(this ModelBuilder model)
        {
            model.Entity<Permiso>().HasData(
                new Permiso { Id = "PAGES_HOME", Nombre = "Inicio", Descripcion = "Inicio", Orden = 100 },

                new Permiso { Id = "PAGES_MANAGEMENT", Nombre = "Administración", Descripcion = "Administración", Orden = 200 },

                new Permiso { Id = "PAGES_MANAGEMENT_ESTABLECIMIENTOS", Nombre = "Administración > Establecimientos", Descripcion = "Administración > Establecimientos", Orden = 300 },
                new Permiso { Id = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD", Nombre = "Administración > Establecimientos > Agregar Establecimiento", Descripcion = "Administración > Establecimientos > Agregar Establecimiento", Orden = 301 },
                new Permiso { Id = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT", Nombre = "Administración > Establecimientos > Editar Establecimiento", Descripcion = "Administración > Establecimientos > Editar Establecimiento", Orden = 302 },
                new Permiso { Id = "PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE", Nombre = "Administración > Establecimientos > Eliminar Establecimiento", Descripcion = "Administración > Establecimientos > Eliminar Establecimiento", Orden = 303 },

                new Permiso { Id = "PAGES_SECURITY", Nombre = "Seguridad", Descripcion = "Seguridad", Orden = 400 },

                new Permiso { Id = "PAGES_SECURITY_ROLES_AND_PERMISSIONS", Nombre = "Seguridad > Roles y Permisos", Descripcion = "Seguridad > Roles y Permisos", Orden = 500 },
                new Permiso { Id = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD", Nombre = "Seguridad > Roles y Permisos > Agregar Rol", Descripcion = "Seguridad > Roles y Permisos > Agregar Rol", Orden = 501 },
                new Permiso { Id = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT", Nombre = "Seguridad > Roles y Permisos > Editar Rol", Descripcion = "Seguridad > Roles y Permisos > Editar Rol", Orden = 502 },
                new Permiso { Id = "PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE", Nombre = "Seguridad > Roles y Permisos > Eliminar Rol", Descripcion = "Seguridad > Roles y Permisos > Eliminar Rol", Orden = 503 }


            );
        }
    }
}

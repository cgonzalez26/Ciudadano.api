using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Ciudadano.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedAt = table.Column<DateTime>(nullable: true),
                    InsertedBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 512, nullable: false),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedAt = table.Column<DateTime>(nullable: true),
                    InsertedBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoZonas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedAt = table.Column<DateTime>(nullable: true),
                    InsertedBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoZonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolPermisos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedAt = table.Column<DateTime>(nullable: true),
                    InsertedBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RolId = table.Column<string>(maxLength: 64, nullable: false),
                    PermisoId = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 64, nullable: false),
                    InsertedAt = table.Column<DateTime>(nullable: true),
                    InsertedBy = table.Column<string>(maxLength: 128, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 128, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    PadreId = table.Column<string>(maxLength: 64, nullable: true),
                    Geometria = table.Column<Geometry>(nullable: true),
                    FullId = table.Column<string>(maxLength: 1024, nullable: false),
                    TipoZonaId = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zonas_Zonas_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zonas_TipoZonas_TipoZonaId",
                        column: x => x.TipoZonaId,
                        principalTable: "TipoZonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Descripcion", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "Orden", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "PAGES_HOME", null, null, "Inicio", null, null, false, "Inicio", 100, null, null },
                    { "PAGES_MANAGEMENT", null, null, "Administración", null, null, false, "Administración", 200, null, null },
                    { "PAGES_MANAGEMENT_ESTABLECIMIENTOS", null, null, "Administración > Establecimientos", null, null, false, "Administración > Establecimientos", 300, null, null },
                    { "PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD", null, null, "Administración > Establecimientos > Agregar Establecimiento", null, null, false, "Administración > Establecimientos > Agregar Establecimiento", 301, null, null },
                    { "PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT", null, null, "Administración > Establecimientos > Editar Establecimiento", null, null, false, "Administración > Establecimientos > Editar Establecimiento", 302, null, null },
                    { "PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE", null, null, "Administración > Establecimientos > Eliminar Establecimiento", null, null, false, "Administración > Establecimientos > Eliminar Establecimiento", 303, null, null },
                    { "PAGES_SECURITY", null, null, "Seguridad", null, null, false, "Seguridad", 400, null, null },
                    { "PAGES_SECURITY_ROLES_AND_PERMISSIONS", null, null, "Seguridad > Roles y Permisos", null, null, false, "Seguridad > Roles y Permisos", 500, null, null },
                    { "PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD", null, null, "Seguridad > Roles y Permisos > Agregar Rol", null, null, false, "Seguridad > Roles y Permisos > Agregar Rol", 501, null, null },
                    { "PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT", null, null, "Seguridad > Roles y Permisos > Editar Rol", null, null, false, "Seguridad > Roles y Permisos > Editar Rol", 502, null, null },
                    { "PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE", null, null, "Seguridad > Roles y Permisos > Eliminar Rol", null, null, false, "Seguridad > Roles y Permisos > Eliminar Rol", 503, null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Descripcion", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "COD_ADMIN", null, null, "Super Admin", null, null, false, "Super Admin", null, null });

            migrationBuilder.InsertData(
                table: "RolPermisos",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "InsertedAt", "InsertedBy", "IsDeleted", "PermisoId", "RolId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ID_SA_PH", null, null, null, null, false, "PAGES_HOME", "COD_ADMIN", null, null },
                    { "ID_SA_PM", null, null, null, null, false, "PAGES_MANAGEMENT", "COD_ADMIN", null, null },
                    { "ID_SA_PM_ES", null, null, null, null, false, "PAGES_MANAGEMENT_ESTABLECIMIENTOS", "COD_ADMIN", null, null },
                    { "ID_SA_PM_ES_ADD", null, null, null, null, false, "PAGES_MANAGEMENT_ESTABLECIMIENTOS_ADD", "COD_ADMIN", null, null },
                    { "ID_SA_PM_ES_EDIT", null, null, null, null, false, "PAGES_MANAGEMENT_ESTABLECIMIENTOS_EDIT", "COD_ADMIN", null, null },
                    { "ID_SA_PM_ES_DELETE", null, null, null, null, false, "PAGES_MANAGEMENT_ESTABLECIMIENTOS_DELETE", "COD_ADMIN", null, null },
                    { "ID_SA_PS", null, null, null, null, false, "PAGES_SECURITY", "COD_ADMIN", null, null },
                    { "ID_SA_PS_RP", null, null, null, null, false, "PAGES_SECURITY_ROLES_AND_PERMISSIONS", "COD_ADMIN", null, null },
                    { "ID_SA_PS_RP_ADD", null, null, null, null, false, "PAGES_SECURITY_ROLES_AND_PERMISSIONS_ADD", "COD_ADMIN", null, null },
                    { "ID_SA_PS_RP_EDIT", null, null, null, null, false, "PAGES_SECURITY_ROLES_AND_PERMISSIONS_EDIT", "COD_ADMIN", null, null },
                    { "ID_SA_PS_RP_DELETE", null, null, null, null, false, "PAGES_SECURITY_ROLES_AND_PERMISSIONS_DELETE", "COD_ADMIN", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Nombre",
                table: "Roles",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_PermisoId",
                table: "RolPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_RolId",
                table: "RolPermisos",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_PadreId",
                table: "Zonas",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolPermisos");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TipoZonas");
        }
    }
}

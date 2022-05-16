using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Usuarios_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
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
                    UsuarioNombre = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 1024, nullable: false),
                    Nombres = table.Column<string>(maxLength: 64, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 64, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    Foto = table.Column<string>(maxLength: 1024, nullable: true),
                    CodigoPostal = table.Column<string>(maxLength: 8, nullable: true),
                    Telefono = table.Column<string>(maxLength: 16, nullable: true),
                    RolId = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

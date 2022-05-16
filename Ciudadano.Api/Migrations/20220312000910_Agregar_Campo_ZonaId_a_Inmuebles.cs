using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Campo_ZonaId_a_Inmuebles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sZona",
                table: "Inmuebles");

            migrationBuilder.AddColumn<string>(
                name: "ZonaId",
                table: "Inmuebles",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioNombre",
                table: "Usuarios",
                column: "UsuarioNombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_ZonaId",
                table: "Inmuebles",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Zonas_ZonaId",
                table: "Inmuebles",
                column: "ZonaId",
                principalTable: "Zonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Zonas_ZonaId",
                table: "Inmuebles");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioNombre",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Inmuebles_ZonaId",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "ZonaId",
                table: "Inmuebles");

            migrationBuilder.AddColumn<string>(
                name: "sZona",
                table: "Inmuebles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

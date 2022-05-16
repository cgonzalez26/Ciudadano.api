using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_ZonaId_Titulares_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZonaId",
                table: "Titulares",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Titulares_ZonaId",
                table: "Titulares",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titulares_Zonas_ZonaId",
                table: "Titulares",
                column: "ZonaId",
                principalTable: "Zonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titulares_Zonas_ZonaId",
                table: "Titulares");

            migrationBuilder.DropIndex(
                name: "IX_Titulares_ZonaId",
                table: "Titulares");

            migrationBuilder.DropColumn(
                name: "ZonaId",
                table: "Titulares");
        }
    }
}

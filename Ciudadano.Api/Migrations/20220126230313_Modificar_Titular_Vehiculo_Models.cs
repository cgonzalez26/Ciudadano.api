using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Modificar_Titular_Vehiculo_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sDominio",
                table: "Vehiculos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sNroDocumento",
                table: "Titulares",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehiculoId",
                table: "Impuesto_Aut",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Impuesto_Aut_VehiculoId",
                table: "Impuesto_Aut",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Impuesto_Aut_Vehiculos_VehiculoId",
                table: "Impuesto_Aut",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impuesto_Aut_Vehiculos_VehiculoId",
                table: "Impuesto_Aut");

            migrationBuilder.DropIndex(
                name: "IX_Impuesto_Aut_VehiculoId",
                table: "Impuesto_Aut");

            migrationBuilder.DropColumn(
                name: "sDominio",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "sNroDocumento",
                table: "Titulares");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Impuesto_Aut");
        }
    }
}

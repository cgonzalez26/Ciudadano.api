using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Impuestos_Aut_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impuesto_Aut",
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
                    dFecha_Pago = table.Column<DateTime>(nullable: false),
                    iAnio = table.Column<int>(nullable: false),
                    iPeriodo = table.Column<int>(nullable: false),
                    nMonto_Pagar = table.Column<double>(nullable: false),
                    sDominio = table.Column<string>(maxLength: 50, nullable: true),
                    nPago = table.Column<double>(nullable: false),
                    nSaldo = table.Column<double>(nullable: false),
                    tObservaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuesto_Aut", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impuesto_Aut");
        }
    }
}

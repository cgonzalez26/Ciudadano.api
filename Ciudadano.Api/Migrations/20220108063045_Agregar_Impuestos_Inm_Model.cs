using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Impuestos_Inm_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inmuebles",
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
                    sZona = table.Column<string>(maxLength: 50, nullable: true),
                    sTerreno = table.Column<string>(maxLength: 50, nullable: true),
                    nVal_Ed = table.Column<double>(nullable: false),
                    nVal_Fis = table.Column<double>(nullable: false),
                    sDomicilio = table.Column<string>(maxLength: 255, nullable: true),
                    iPIN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titulares",
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
                    sNombre = table.Column<string>(maxLength: 50, nullable: false),
                    sApellido = table.Column<string>(maxLength: 50, nullable: true),
                    sDomicilio = table.Column<string>(maxLength: 1024, nullable: true),
                    sTelefono = table.Column<string>(maxLength: 50, nullable: true),
                    sCelular = table.Column<string>(maxLength: 50, nullable: true),
                    sMail = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Impuesto_Inm",
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
                    sCatastro = table.Column<string>(maxLength: 50, nullable: true),
                    nPago = table.Column<double>(nullable: false),
                    nSaldo = table.Column<double>(nullable: false),
                    tObservaciones = table.Column<string>(nullable: true),
                    InmuebleId = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuesto_Inm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impuesto_Inm_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmueblesTitulares",
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
                    InmuebleId = table.Column<string>(maxLength: 64, nullable: false),
                    TitularId = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmueblesTitulares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmueblesTitulares_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InmueblesTitulares_Titulares_TitularId",
                        column: x => x.TitularId,
                        principalTable: "Titulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impuesto_Inm_InmuebleId",
                table: "Impuesto_Inm",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmueblesTitulares_InmuebleId",
                table: "InmueblesTitulares",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmueblesTitulares_TitularId",
                table: "InmueblesTitulares",
                column: "TitularId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impuesto_Inm");

            migrationBuilder.DropTable(
                name: "InmueblesTitulares");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Titulares");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Denuncias_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDenuncias",
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
                    Descripcion = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDenuncias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
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
                    sNroDocumento = table.Column<string>(maxLength: 20, nullable: true),
                    sNombre = table.Column<string>(maxLength: 50, nullable: true),
                    sApellido = table.Column<string>(maxLength: 50, nullable: true),
                    sMail = table.Column<string>(maxLength: 128, nullable: true),
                    sTelefono = table.Column<string>(maxLength: 50, nullable: true),
                    sDireccion = table.Column<string>(maxLength: 1024, nullable: true),
                    sEntre_Calle = table.Column<string>(maxLength: 1024, nullable: true),
                    sLongitud = table.Column<string>(maxLength: 20, nullable: true),
                    sLatitud = table.Column<string>(maxLength: 20, nullable: true),
                    tRelato = table.Column<string>(nullable: true),
                    TipoDenunciaId = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denuncias_TipoDenuncias_TipoDenunciaId",
                        column: x => x.TipoDenunciaId,
                        principalTable: "TipoDenuncias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoDenuncias",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Descripcion", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ID_BASURAL", null, null, "BASURAL", null, null, false, "BASURAL", null, null },
                    { "ID_BACHE", null, null, "BACHE", null, null, false, "BACHE", null, null },
                    { "ID_PERDIDA_AGUA", null, null, "PERDIDA DE AGUA", null, null, false, "PERDIDA DE AGUA", null, null },
                    { "ID_DESBORDE_CLOACAL", null, null, "DESBORDE CLOACAL", null, null, false, "DESBORDE CLOACAL", null, null },
                    { "ID_OCUPACION_VIA_PUBLICA", null, null, "OCUPACION INDEBIDA DE LA VIA PUBLICA", null, null, false, "OCUPACION INDEBIDA DE LA VIA PUBLICA", null, null },
                    { "ID_OBSTRUCCION_RAMPAS", null, null, "OBSTRUCCION DE RAMPAS ACCESIBILIDAD", null, null, false, "OBSTRUCCION DE RAMPAS ACCESIBILIDAD", null, null },
                    { "ID_OTRO", null, null, "OTRO", null, null, false, "OTRO", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_TipoDenunciaId",
                table: "Denuncias",
                column: "TipoDenunciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "TipoDenuncias");
        }
    }
}

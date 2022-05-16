using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciudadano.Api.Migrations
{
    public partial class Agregar_Establecimientos_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas");

            migrationBuilder.AlterColumn<string>(
                name: "TipoZonaId",
                table: "Zonas",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateTable(
                name: "TipoEstablecimientos",
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
                    Nombre = table.Column<string>(maxLength: 120, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstablecimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Establecimientos",
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
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(maxLength: 128, nullable: false),
                    Domicilio = table.Column<string>(maxLength: 500, nullable: true),
                    TipoEstablecimientoId = table.Column<string>(maxLength: 64, nullable: true),
                    ZonaId = table.Column<string>(maxLength: 64, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(19,10)", nullable: true),
                    Longitud = table.Column<decimal>(type: "decimal(19,10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establecimientos_TipoEstablecimientos_TipoEstablecimientoId",
                        column: x => x.TipoEstablecimientoId,
                        principalTable: "TipoEstablecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Establecimientos_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoEstablecimientos",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "Descripcion", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ID_ESCUELAS", null, null, "ESCUELAS", null, null, false, "ESCUELAS", null, null },
                    { "ID_TECNICAS", null, null, "TECNICAS", null, null, false, "TECNICAS", null, null },
                    { "ID_SECUNDARIOS", null, null, "SECUNDARIOS", null, null, false, "SECUNDARIOS", null, null },
                    { "ID_INSTITUCIONES", null, null, "INSTITUCIONES", null, null, false, "INSTITUCIONES", null, null },
                    { "ID_ESTABLECIMIENTOS", null, null, "ESTABLECIMIENTOS", null, null, false, "ESTABLECIMIENTOS", null, null }
                });

            migrationBuilder.InsertData(
                table: "Zonas",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "FullId", "Geometria", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "PadreId", "TipoZonaId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "66", null, null, "66", null, null, null, false, "Salta", null, null, null, null });

            migrationBuilder.InsertData(
                table: "Zonas",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "FullId", "Geometria", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "PadreId", "TipoZonaId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "66028", null, null, "66.66028", null, null, null, false, "Capital", "66", null, null, null });

            migrationBuilder.InsertData(
                table: "Zonas",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "FullId", "Geometria", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "PadreId", "TipoZonaId", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "Id_Interior", null, null, "66.Id_Interior", null, null, null, false, "Interior", "66", null, null, null });

            migrationBuilder.InsertData(
                table: "Zonas",
                columns: new[] { "Id", "DeletedAt", "DeletedBy", "FullId", "Geometria", "InsertedAt", "InsertedBy", "IsDeleted", "Nombre", "PadreId", "TipoZonaId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ID_NORTE", null, null, "66.66028.ID_NORTE", null, null, null, false, "NORTE", "66028", null, null, null },
                    { "ID_SUR", null, null, "66.66028.ID_SUR", null, null, null, false, "SUR", "66028", null, null, null },
                    { "ID_ESTE", null, null, "66.66028.ID_ESTE", null, null, null, false, "ESTE", "66028", null, null, null },
                    { "ID_OESTE", null, null, "66.66028.ID_OESTE", null, null, null, false, "OESTE", "66028", null, null, null },
                    { "ID_CENTRO", null, null, "66.66028.ID_CENTRO", null, null, null, false, "CENTRO", "66028", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Establecimientos",
                columns: new[] { "Id", "Codigo", "DeletedAt", "DeletedBy", "Domicilio", "InsertedAt", "InsertedBy", "IsDeleted", "Latitud", "Longitud", "Nombre", "TipoEstablecimientoId", "UpdatedAt", "UpdatedBy", "ZonaId" },
                values: new object[,]
                {
                    { "N01", "N01", null, null, "DONATO ALVAREZ S/Nº - Cº DEL MILAGRO", null, null, false, null, null, "PEDRO B. PALACIOS", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "O33", "O33", null, null, "ENTRE RIOS 1551", null, null, false, null, null, "REM.ESC. DE SAN MARTIN", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O31", "O31", null, null, "OHIGGINS 1550", null, null, false, null, null, "BARTOLOME MITRE", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O30", "O30", null, null, "NECOCHEA Y BROWN- TURNO TARDE", null, null, false, null, null, "ESC. TEC. DIF. Nº 27", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O29", "O29", null, null, "NECOCHEA Y BROWN", null, null, false, null, null, "ESC. DIF. TOBAR GARCIA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O28", "O28", null, null, "POSTA DE YATASTO Y DR. ANZOATEGUI", null, null, false, null, null, "JUAN FCO. DE CASTRO", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O24", "O24", null, null, "PEDERNERA 1243 Vº LUJAN", null, null, false, null, null, "MARTIN FIERRO", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O23BIS", "O23BIS", null, null, "CNEL SUAREZ 317", null, null, false, null, null, "NUCLEO ED. Nº 7002", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O23", "O23", null, null, "CNEL SUAREZ 317", null, null, false, null, null, "SANTA EUFRASIA PELLETIER", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O22", "O22", null, null, "GRAL PAEZ 47", null, null, false, null, null, "BRIG. ALVAREZ Y ARENALES", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O35", "O35", null, null, "IBAZETA 885 - Bº 20 DE FEBRERO", null, null, false, null, null, "JARDIN INF. DIENTE FLOJO", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O20BIS", "O20BIS", null, null, "MENDOZA Y PJE. VICTORIA", null, null, false, null, null, "NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O19", "O19", null, null, "DEJAR EN LA POLICIA DE LA CIENAGA", null, null, false, null, null, "ANEXO NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O18BIS", "O18BIS", null, null, "DEJAR EN LA POLICIA DE LA CIENAGA", null, null, false, null, null, "NUCLEO ED. Nº 7042 - LA CIENAGA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O18", "O18", null, null, "RIO PARANA S/Nº Vº PARQUE LAS VERTIENTES", null, null, false, null, null, "NTRA. SRA. DEL CARMEN", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O17BIS", "O17BIS", null, null, "MANZ. 486 - Bº PALERMO I", null, null, false, null, null, "ANEXO NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O17", "O17", null, null, "MANZ. 486 - Bº PALERMO I", null, null, false, null, null, "PROF. OSCAR OÑATIVIA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O16bis", "O16bis", null, null, "CALLE SAN GABRIEL S/Nº Bº ROBERTO ROMERO", null, null, false, null, null, "ANEXO NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O16", "O16", null, null, "CALLE SAN GABRIEL S/Nº Bº ROBERTO ROMERO", null, null, false, null, null, "ROBERTO ROMERO", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O15", "O15", null, null, "Bº GUEMES -ARA PORTAVIONES 25 DE MAYO S/N", null, null, false, null, null, "GUSTAVO CUCHI LEGUIZAMON", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O14BIS", "O14BIS", null, null, "VILLA ASUNCION", null, null, false, null, null, "ANEXO NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O20", "O20", null, null, "MENDOZA Y PJE. VICTORIA", null, null, false, null, null, "MARIANO CABEZON", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O14", "O14", null, null, "VILLA ASUNCION MZA 282 - L3", null, null, false, null, null, "NTRA SRA. DE LA ASUNCION", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O36", "O36", null, null, "12 DE OCTUBRE 2061", null, null, false, null, null, "PREJARDIN ATRAPASUEÑOS", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "OI02", "OI02", null, null, "ANZOATEGUI 586", null, null, false, null, null, "NTRA SRA. DEL PILAR", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI40", "OI40", null, null, "RIVADAVIA 1640 - LUNES YOGUR - MIER. Y VIERNES LECHE", null, null, false, null, null, "HOGAR DIVINO NIÑO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI39", "OI39", null, null, "SAN MARTIN Nº 2540", null, null, false, null, null, "CLUB ABUELOS CRISTINO ZERPA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI34", "OI34", null, null, "PJE.BALDOMERO CASTRO 1769", null, null, false, null, null, "GUARDERIA 4790- MUNDO FELIZ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI31", "OI31", null, null, "SAN LUIS 1224 - TEL 4310428 - Fany Elena Gutierrez", null, null, false, null, null, "PARR.NTRA. SRA DE LOS ANGELES", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI29", "OI29", null, null, "CALLE8-MED 234 - TEL4340881 - SABADOS UNICAMENTE", null, null, false, null, null, "PARROQUIA Bº SANTA LUCIA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI26", "OI26", null, null, "Bº RIBERA - LOTE 6 -Bº STA. LUCIA CALLE 14", null, null, false, null, null, "MERENDERO LA RIBERA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI25", "OI25", null, null, "AVDA. LOS PAJAROS 3078- FRENTE FRIG.BRUNETTI", null, null, false, null, null, "IGLESIA SAN CAYETANO LA VERBENA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI24", "OI24", null, null, "12 DE OCTUBRE  Nº 2230 - Vº LUJAN", null, null, false, null, null, "POL. INF. COMISARIA 5TA.", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI22", "OI22", null, null, "PAVO REAL 1756 - Bº SOLIS PIZARRO", null, null, false, null, null, "GUARDERIA COMEDOR LOS SALTEÑITOS", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI01", "OI01", null, null, "BOLIVAR 605", null, null, false, null, null, "A.P.A.D.I.", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI19", "OI19", null, null, "LAS GAVIOTAS Y LAS GARZAS", null, null, false, null, null, "COMEDOR MI NINITO JESUS ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI16", "OI16", null, null, "BOLIVAR 425 ", null, null, false, null, null, "FUNDACION  ANIDAR", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI14", "OI14", null, null, "CLERICO S/Nº -Bº SANTA LUCIA", null, null, false, null, null, "CPO. INFANTIL COMISARIA 8VA.", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI12", "OI12", null, null, "PJE. RAWSON Y MARIO DEL PIN- Bº STA. RITA", null, null, false, null, null, "PROYECTO CUNIAVIHORTICOLA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI11", "OI11", null, null, "ASUNCION ESQ. FATIMA - Vª ASUNCION", null, null, false, null, null, "GUARDERIA NIÑOS DE BELEN", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI08", "OI08", null, null, "10 DE OCTUBRE 551", null, null, false, null, null, "BIBLIOT. J.C. DAVALOS", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI07", "OI07", null, null, "JUAN LARREA 1161 - Bº SAN JOSE", null, null, false, null, null, "PARROQUIA SAN JOSE OBRERO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI06", "OI06", null, null, "MARIANO MORENO 1911", null, null, false, null, null, "CASITA DE BELEN", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI04", "OI04", null, null, "SGO. DEL ESTERO 1951", null, null, false, null, null, "H.I.R.P.A.C.E", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI03", "OI03", null, null, "MENDOZA 1430", null, null, false, null, null, "A.P.N.A.P.", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI17", "OI17", null, null, "CASA 58 - Bº SANTA RITA", null, null, false, null, null, "MERENDERO EL PANALCITO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "O13", "O13", null, null, "CARLOS CORTEZ Nº13- Bº EL PROGRESO", null, null, false, null, null, "MERCEDES LAVIN", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O12", "O12", null, null, " Bº SANTA LUCIA CALLE 6 - M 390", null, null, false, null, null, "SANTA LUCIA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O11", "O11", null, null, "EL CONDOR 3155 Bº SOLIS PIZARRO", null, null, false, null, null, "EVARISTO PIÑON ARIAS", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "EI22", "EI22", null, null, "MANZ. 1 CASA 21 - BARRIO LAS COLINAS", null, null, false, null, null, "MERENDERO ESCUELA DEPORTIVA Bº LAS COLINAS", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI21Bis", "EI21Bis", null, null, "CUBA 1045 - BARRIO EL MILAGRO", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI21", "EI21", null, null, "CUBA 1045 - BARRIO EL MILAGRO", null, null, false, null, null, "MERENDERO BARRIO EL MILAGRO", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI20", "EI20", null, null, "EMILIO WIERNA Nº 1301 Bº EL JARDIN", null, null, false, null, null, "CENTRO VECINAL - Bº JARDIN", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI19", "EI19", null, null, "AVDA DE LAS AMERICAS ESQ. VENEZUELA", null, null, false, null, null, "CLUB ATLETICO MITRE", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI18", "EI18", null, null, "GOMEZ RECIO 632 Bº PORTEZUELO", null, null, false, null, null, "CUERPO INFANTIL COM. 9na.", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI16", "EI16", null, null, "MANZ. 5 LOTE 8 ASENT. LAS COLINAS", null, null, false, null, null, "MERENDERO NIÑOS DEL FUTURO", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI12", "EI12", null, null, "AVDA CANADA 1672 - Bº EL MILAGRO", null, null, false, null, null, "MERENDERO AMANCAY", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI05", "EI05", null, null, "CUBA 969 - Bº EL MILAGRO- SABADO POR MEDIO-", null, null, false, null, null, "CATEQUESIS CEFERINO NAMUNCURA", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI23", "EI23", null, null, "AVDA. GURRUCHAGA 250", null, null, false, null, null, "SUBCOMISARIA VILLA EL SOL", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI04", "EI04", null, null, "J.M. GORRITI 1726 - Vª FLORESTA", null, null, false, null, null, "MERENDERO AMOR Y FE", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "E12", "E12", null, null, "FCO. DE GURRUCHAGA 50", null, null, false, null, null, "CORINA LONA", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E11", "E11", null, null, "ALCIDES JUAREZ TELLES 60- Bº MIRADOR", null, null, false, null, null, "FRAY HONORATO PISTOIA", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E10BIS", "E10BIS", null, null, "AVDA. ASUNCION S/Nº Bº AUTODROMO", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E10", "E10", null, null, "AVDA. ASUNCION S/Nº Bº AUTODROMO", null, null, false, null, null, "CAMPAÑA DEL DESIERTO", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E08BIS", "E08BIS", null, null, "AVDA. POMPILIO GUZ MAN Y ALDERETE", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E08", "E08", null, null, "AVDA. POMPILIO GUZ MAN Y ALDERETE", null, null, false, null, null, "EJERCITO ARGENTINO", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E07BIS", "E07BIS", null, null, "AVDA ARTIGAS 100 - Bº CERAMICA", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E07", "E07", null, null, "AVDA. ARTIGAS 100- Bº CERAMICA", null, null, false, null, null, "FRAY LUIS BELTRAN", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E04", "E04", null, null, "LOS LIRIOS 190-VILLA LAS ROSAS", null, null, false, null, null, "JOAQUIN CASTELLANOS", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "EI01", "EI01", null, null, "AV. POMPILO GUZMAN Nº 1850 - Vº MITRE", null, null, false, null, null, "CPO. INF. COM. 4TA.", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI24", "EI24", null, null, "PJE. SOCOMPA Nº 1800", null, null, false, null, null, "MERENDERO LUZ DE LOS NIÑOS EN ESPERANZA", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI25", "EI25", null, null, "OSCAR CABALEN Nº 530- Bº AUTODROMO", null, null, false, null, null, "CPO.INF.POLICIA FEMENINA ", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI26", "EI26", null, null, "CEMENTERIO DE LA SANTA CRUZ", null, null, false, null, null, "DIRECCION CEMENTERIO PUBLICO", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "O10", "O10", null, null, "MARIANO MORENO 1911", null, null, false, null, null, "SAGRADA FAMILIA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O09", "O09", null, null, "USANDIVARAS 1396 - Bº SAN JOSE", null, null, false, null, null, "SAN JOSE", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O07 BIS", "O07 BIS", null, null, "CARLOS DEL CASTILLO 870 - VILLA PRIMAVERA", null, null, false, null, null, "ANEXO NUCLEO ED. 7005", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O07", "O07", null, null, "CARLOS DEL CASTILLO 870 - VILLA PRIMAVERA", null, null, false, null, null, "JUAN CARLOS DAVALOS", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O06", "O06", null, null, " CABO ALBERTO VIZGARRA Nº 659 Y MONGE ORTEGA", null, null, false, null, null, "AMERICA LATINA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O04", "O04", null, null, "CNEL VIDT Y CNEL MOLDES", null, null, false, null, null, "MARIANO BOEDO", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O03", "O03", null, null, "FINAL MOLDES - VILLA COSTANERA", null, null, false, null, null, "NTRA. SRA. DE LA CANDELARIA", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O02", "O02", null, null, "ORAN 1595 Vº LAS CHARTAS", null, null, false, null, null, "ARMADA NACIONAL", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O01BIS", "O01BIS", null, null, "ISLAS MALVINAS Y TUCUMAN", null, null, false, null, null, "NUCLEO ED. Nº 7001", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "O01", "O01", null, null, "ISLAS MALVINAS Y TUCUMAN", null, null, false, null, null, "AML. GUILLERMO BROWN", "ID_ESCUELAS", null, null, "ID_OESTE" },
                    { "ET02", "ET02", null, null, "JULIA ALDERETE 1450 - VILLA MITRE", null, null, false, null, null, "CENTRO DE FORMACION PROFESIONAL", "ID_TECNICAS", null, null, "ID_ESTE" },
                    { "ET01", "ET01", null, null, "JULIA ALDERETE 1450 - VILLA MITRE", null, null, false, null, null, "ESCUELA Nº 3148 -OTTO KRAUSE", "ID_TECNICAS", null, null, "ID_ESTE" },
                    { "ES07", "ES07", null, null, "FILIBERTO DE MENES Nº 536 - VILLA JUANITA.", null, null, false, null, null, "COLEGIO SECUNDARIO MARIA TERESA CADENA DE HESSLING", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "ES06", "ES06", null, null, "FCO VELEZ Nº 318- VILLA 20 DE JUNIO", null, null, false, null, null, "COLEGIO BETANIA DEL SAGRADO CORAZON", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "ES05", "ES05", null, null, "HIPOLITO IRIGOYEN 841", null, null, false, null, null, "COLEGIO DEL PORTEZUELO", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "ES03", "ES03", null, null, "HIPOLITO IRIGOYEN 841", null, null, false, null, null, "FRAY MAMERTO ESQUIU", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "ES02", "ES02", null, null, "BARRIO AUTODROMO", null, null, false, null, null, "COLEGIO SECUNDARIO Nº 5167 - MIGUEL RAGONE", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "ES01", "ES01", null, null, "CARMEN SALAS Nº 1349 - VILLA MITRE", null, null, false, null, null, "COLEGIO SECUNDARIO SARGENTO CABRAL", "ID_SECUNDARIOS", null, null, "ID_ESTE" },
                    { "EI30", "EI30", null, null, "LOS GLADIOLOS Nº 89 VILLA LAS ROSAS", null, null, false, null, null, "MERENDERO LOS PITUFUTOS", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI27", "EI27", null, null, "MANZ. 358- LOTE 17 - Bº LA FAMA - TEL.155130359", null, null, false, null, null, "MERENDERO BARRIO LA FAMA", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "EI26BIS", "EI26BIS", null, null, "CEMENTERIO SAN ANTONIO DE PADUA", null, null, false, null, null, "DIRECCION CEMENTERIO PUBLICO", "ID_INSTITUCIONES", null, null, "ID_ESTE" },
                    { "OI46", "OI46", null, null, "MANZ. 440C LOTE 13- Bº PALERMO II - TEL.4363230", null, null, false, null, null, "MERENDERO POR UN NIÑO FELIZ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "E03", "E03", null, null, "FCO.VELEZ 318-VILLA 20 DE JUNIO", null, null, false, null, null, "BETANIA DEL SGDO. CORAZON", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "OI55", "OI55", null, null, "JUAN RAMON BOEDO Nº 968 - Vª PRIMAVERA -TEL.4344047", null, null, false, null, null, "MERENDERO MI NIÑO JESUS", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI60", "OI60", null, null, "MANZ. 426B - LOTE 1- Bº PALERMO 1", null, null, false, null, null, "CATEQ. PARR. SAN EXEQUIEL MORENO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "CI22", "CI22", null, null, "PELLEGRINI 56", null, null, false, null, null, "FUNDACION REVIVIR", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI21", "CI21", null, null, "SAN LUIS 491", null, null, false, null, null, "FUNDACION SALTEÑA DE CIEGOS", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI19", "CI19", null, null, "25 DE MAYO 580 - PORTERIA COLEGIO", null, null, false, null, null, "PARROQUIA SAN ALFONSO ", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI17", "CI17", null, null, "ESPAÑA 1550", null, null, false, null, null, "IGLESIA BUENAS NUEVAS", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI16", "CI16", null, null, "BALCARCE 380 Y J.M. LEGUIZAMON", null, null, false, null, null, "CENTRO TERAPEUTICO ANIDAR", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI15", "CI15", null, null, "CASEROS 1250", null, null, false, null, null, "BATALLON Nº 9 - M.M. GUEMES", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI14", "CI14", null, null, "PELLEGRINI 250", null, null, false, null, null, "CENTRO ORTODOXO DE SALTA", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI13", "CI13", null, null, "JUJUY 835", null, null, false, null, null, "SOCIEDAD DE LA ESTRELLA", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI12", "CI12", null, null, "florida 880", null, null, false, null, null, "I.N.P.R.E.D.", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI23", "CI23", null, null, "ESPAÑA 820", null, null, false, null, null, "CTRO. TERAPEUTICO CRECIENDO", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI10", "CI10", null, null, "JOAQUIN CASTELLANOS 650", null, null, false, null, null, "ASOC. SAN ANTONIO DE PADUA", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI07", "CI07", null, null, "CASEROS 1737", null, null, false, null, null, "DIRECCION DE DISCAPACIDAD", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI06", "CI06", null, null, "MARTIN CORNEJO 98", null, null, false, null, null, "A.D.A.N.A.", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI05", "CI05", null, null, "VICARIO TOSCANO 48 - VILLA SOLEDAD", null, null, false, null, null, "I.E.F.E.L.", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI04", "CI04", null, null, "TUCUMAN 667", null, null, false, null, null, "C.R.I.O.S.", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI03", "CI03", null, null, "ALVARADO 116", null, null, false, null, null, "ALBERGUE COOPERADORA ASISTENCIAL", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI02", "CI02", null, null, "CASEROS 108", null, null, false, null, null, "HOGAR SAN VTE. DE PAUL", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI01", "CI01", null, null, "CATAMARCA 718 ", null, null, false, null, null, "HOGAR CRISTO REY", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "C26", "C26", null, null, "BELGRANO 447 - 4227622 SRA. MARTA", null, null, false, null, null, "ANEXO NUCLEO ED. 7006 CTRO DE DIA ", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C25", "C25", null, null, "VICENTE LOPEZ 38- EDIF. COL. F.ZUVIRIA", null, null, false, null, null, "JOSE EVARISTO URIBURU", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "CI08", "CI08", null, null, "ALSINA 450", null, null, false, null, null, "ONG TODO PARA TODOS", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "C23", "C23", null, null, "AV. BICENT. BATALLA DE SALTA 160", null, null, false, null, null, "INDALECIO GOMEZ", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "CI25", "CI25", null, null, "PELLEGRINI 44", null, null, false, null, null, "SUBSECRETARIA DE PUEBLOS ORIGINARIOS", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI27", "CI27", null, null, "LERMA 649", null, null, false, null, null, "CENTRO JUVENTUD ANTONIANA", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CT03", "CT03", null, null, "CASEROS 1615", null, null, false, null, null, "GRAL MARTIN MIGUEL DE GUEMES", "ID_TECNICAS", null, null, "ID_CENTRO" },
                    { "CT02", "CT02", null, null, "GRAL LAVALLE 875", null, null, false, null, null, "JUANA AZURDUY DE PADILLA", "ID_TECNICAS", null, null, "ID_CENTRO" },
                    { "CT01", "CT01", null, null, "20 DE FEBRERO  131", null, null, false, null, null, "DR. JOAQUIN CASTELLANOS ", "ID_TECNICAS", null, null, "ID_CENTRO" },
                    { "CS13", "CS13", null, null, "MITRE 892 ", null, null, false, null, null, "SEMINARIO METROPOLITANO ", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS12", "CS12", null, null, "DEAN FUNES Nº 750", null, null, false, null, null, "COLEGIO MIGUEL RAGONE", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS11", "CS11", null, null, "ZUVIRIA 290", null, null, false, null, null, "COLEGIO FRANCISCO DE GURRUCHAGA", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS10", "CS10", null, null, "MITRE Nº 767", null, null, false, null, null, "ESCUELA NORMAL SUPERIOR GRAL MANUEL BELGRANO", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS08BIS", "CS08BIS", null, null, "ITUZAINGO 371", null, null, false, null, null, "COLEGIO CENTRO POLIVALENTE DE ARTE- ANEXO", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS08", "CS08", null, null, "BELGRANO 474", null, null, false, null, null, "COLEGIO CENTRO POLIVALENTE DE ARTE", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CI26", "CI26", null, null, "MITRE Nº 383 TEL 4314024", null, null, false, null, null, "UNIVERSIDAD ABIERTA DE LA 3RA EDAD", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CS07", "CS07", null, null, "LEGUIZAMON Nº 129", null, null, false, null, null, "ESCUELA DE COMERCIO VICTORINO DE LA PLAZA", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS05", "CS05", null, null, "PASEO GUEMES  Nº 51", null, null, false, null, null, "COLEGIO MANUEL CASTRO", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS04", "CS04", null, null, "MITRE Nº 468", null, null, false, null, null, "COLEGIO DR. ARTURO ILLIA", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS03", "CS03", null, null, "MITRE 349", null, null, false, null, null, "ESCUELA DE COMERCIO Nº 5047-B. ZORRILLA", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS02", "CS02", null, null, "CASEROS Nª 1866", null, null, false, null, null, "COLEGIO 20 DE FEBRERO", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CS01", "CS01", null, null, "GRAL. MITRE Nº 468", null, null, false, null, null, "ESCUELA DE COMERCIO HIPOLITO IRIGOYEN", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "CI31", "CI31", null, null, "ZUVIRIA Nº 552 154456419", null, null, false, null, null, "FUNDACION ESPACIOS", "ID_INSTITUCIONES", null, null, "ID_CENTRO" }
                });

            migrationBuilder.InsertData(
                table: "Establecimientos",
                columns: new[] { "Id", "Codigo", "DeletedAt", "DeletedBy", "Domicilio", "InsertedAt", "InsertedBy", "IsDeleted", "Latitud", "Longitud", "Nombre", "TipoEstablecimientoId", "UpdatedAt", "UpdatedBy", "ZonaId" },
                values: new object[,]
                {
                    { "CI30", "CI30", null, null, "LAVALLE 760", null, null, false, null, null, "CLUB ATLETICO INDEPENDIENTE", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI29", "CI29", null, null, "pasa a buscar por planta proveedora", null, null, false, null, null, "ESC.DE FUT B° AUTODROMO-SR.TISSERA", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CI27B", "CI27B", null, null, "LERMA 649-CEL 154586655 - SR. MOYA", null, null, false, null, null, "CENTRO JUVENTUD ANTONIANA-NIÑOS ESP.", "ID_INSTITUCIONES", null, null, "ID_CENTRO" },
                    { "CS06", "CS06", null, null, "PASEO GUEMES  Nº 51", null, null, false, null, null, "COLEGIO ADOLFO GUEMES Nº 5082", "ID_SECUNDARIOS", null, null, "ID_CENTRO" },
                    { "C18", "C18", null, null, "MENDOZA 315", null, null, false, null, null, "EDUCACION INTERMEDIA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C17", "C17", null, null, "AMEGHINO 520", null, null, false, null, null, "GRAL. JOSE DE SAN MARTIN", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C15", "C15", null, null, "DEAN FUNES 750", null, null, false, null, null, "JACOBA SARAVIA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "OS05", "OS05", null, null, "MENSOZA Y PJE. SANTA VICTORIA - VESPERTINO", null, null, false, null, null, "COLEGIO SECUNDARIO DR. RAUL ALFONSIN", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS04", "OS04", null, null, "USANDIVARAS Y 20 DE JUNIO- BARRIO SAN JOSE", null, null, false, null, null, "COLEGIO SECUNDARIO SAN JOSE DE CALAZANZ", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS03", "OS03", null, null, "IBAZETA Nº 690", null, null, false, null, null, "ESCUELA DE COMERCIO 25 DE MAYO", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS02", "OS02", null, null, "10 DE OCTUBRE Nº 551", null, null, false, null, null, "COLEGIO SECUNDARIO JUAN CALCHAQUI", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS01", "OS01", null, null, "CALLE 13 Y 10 - Bº SANTA LUCIA.", null, null, false, null, null, "COLEGIO SECUNDARIO PROF. NESTOR PALACIOS", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OI111", "OI111", null, null, "REPUBLICA DE SIRIA Nº 49 Bº CAMPO CASEROS", null, null, false, null, null, "ESC. DE BOX CIRILO GIL", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI110", "OI110", null, null, "Bº LAS MAGDALENAS MNA. 124B CASA 7 ", null, null, false, null, null, "CLUB PELLEGRINI ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI105", "OI105", null, null, "BOLIVAR 270", null, null, false, null, null, "EXPLORADORAS ARG.MA.AUXILIADORA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI79", "OI79", null, null, "MAN.459 A-LOTE 5-B° ALTO LA VIÑA-SRA. BEATRIZ JESUS-155192496", null, null, false, null, null, "MERENDERO CARITA FELIZ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OS06", "OS06", null, null, "CNEL. MOLDES Y CNEL. VIDT. - TURNO VESPERTINO", null, null, false, null, null, "ESC. DE COM. 5084 EX. COMB DE MALVINAS", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OI77", "OI77", null, null, "MANZ. 426 C - LOTE 13 - Bº PALERMO I - TEL. 4361926", null, null, false, null, null, "BIBLIOTECA POPULAR Bº -PALERMO I", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI75", "OI75", null, null, "MANZ. 180 - LOTE 3 -BARRIO ROBERTO ROMERO", null, null, false, null, null, "MERENDERO DULCE ESPERANZA", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI74", "OI74", null, null, "AVDA DI PASCUO S/Nº - 155013000- ANA SOL- A PARTIR HS. 17.00", null, null, false, null, null, "VICARIA VIRGEN DE LAS LAGRIMAS ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI73", "OI73", null, null, "CARLOS GARDEL 628 - VILLA LOS SAUCES", null, null, false, null, null, "CATEQUESIS  VICARIA SAN PABLO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI72", "OI72", null, null, "CARLOS GARDEL ESQ. MONGE ORTEGA - VILLA LOS SAUCES", null, null, false, null, null, "CATEQUESIS VICARIA CRISTO REY", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI68", "OI68", null, null, "ENTRE RIOS 1498", null, null, false, null, null, "CLUB CENTRAL NORTE", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI67", "OI67", null, null, "DE HUERGO 850 - VILLA PRIMAVERA - TEL. 4342040", null, null, false, null, null, "PARROQUIA SAN PEDRO APOSTOL", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI66", "OI66", null, null, "MANZ. 256 - LOTE 7 - Bº SAN PABLO - TEL. 4386009", null, null, false, null, null, "MERENDERO SAN PABLO", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI65", "OI65", null, null, "POSTA DE YATASTO Nº 1489- SANTA LUCIA", null, null, false, null, null, "BIBLIOTECA CASIMIRO COBOS", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI61", "OI61", null, null, "JOSE LEON CABEZON Y SANTA VICTORIA ", null, null, false, null, null, "CATEQ. PARR. NTRA. SRA DE LAS VICTORIAS ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OI76", "OI76", null, null, "ALVEAR 560 (llevar insumos de 9 a 12 o 14hs) LACTEOS LUNES UNIC", null, null, false, null, null, "FUNDACION ENCUENTRO ", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "OS07", "OS07", null, null, "12 DE OCTUBRE Nº 654", null, null, false, null, null, "ESCUELA DE COMERCIO 5075", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS08", "OS08", null, null, "MARIANO MORENO 1911", null, null, false, null, null, "COLEGIO SEC. SAGRADA FAMILIA", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS09", "OS09", null, null, "EL CONDOR 3150", null, null, false, null, null, "COLEGIO SEC. EVARISTO PIÑON ARIAS", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "C14", "C14", null, null, "ZUVIRIA 290", null, null, false, null, null, "JUSTO JOSE DE URQUIZA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C13", "C13", null, null, "BALCARCE 764", null, null, false, null, null, "GRAL MANUEL BELGRANO -NIVEL INICIAL", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C12", "C12", null, null, "MITRE 767", null, null, false, null, null, "GRAL MANUEL BELGRANO - PRIMARIA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C11", "C11", null, null, "BELGRANO 666", null, null, false, null, null, "MARTIN M. DE GUEMES", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C10", "C10", null, null, "CASEROS 1150", null, null, false, null, null, "JUAN B. ALBERDI", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C08", "C08", null, null, "ALVARADO 427", null, null, false, null, null, "DOMINGO FAUSTINO SARMIENTO", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C07", "C07", null, null, "INGRESO 25 DE MAYO PRIMERA CUADRA", null, null, false, null, null, "ZORRILLA - 20 DE FEBRERO", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C06", "C06", null, null, "25 DE MAYO PRIMERA CUADRA", null, null, false, null, null, "ESCUELA Nº 7.001  PRIMARIA P/JOVENES", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C04BIS", "C04BIS", null, null, "SANTA FE 875", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C04", "C04", null, null, "SANTA FE 875", null, null, false, null, null, "JUANA AZURDUY DE PADILLA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C02", "C02", null, null, "SAN JUAN 619", null, null, false, null, null, "MARIANO CASTEX", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "C01", "C01", null, null, "BUENOS AIRES  750", null, null, false, null, null, "JULIO A. ROCA", "ID_ESCUELAS", null, null, "ID_CENTRO" },
                    { "OT05", "OT05", null, null, "MANZ. A - Bº JESUS MARIA", null, null, false, null, null, "DR. JULIO MERA FIGUEROA", "ID_TECNICAS", null, null, "ID_OESTE" },
                    { "OT04", "OT04", null, null, "12 DE OCTUBRE E IBAZETA", null, null, false, null, null, "DR. FCO. DE GURRUCHAGA", "ID_TECNICAS", null, null, "ID_OESTE" },
                    { "OT03", "OT03", null, null, "AVDA ENTRE RIOS Nº 1895", null, null, false, null, null, "MARTINA SILVA DE GURRUCHAGA", "ID_TECNICAS", null, null, "ID_OESTE" },
                    { "OT02", "OT02", null, null, "ALMIRANTE BROWN S/Nº", null, null, false, null, null, "REPUBLICA DE LA INDIA", "ID_TECNICAS", null, null, "ID_OESTE" },
                    { "OT01", "OT01", null, null, "CARLOS DEL CASTILLO 870 - VILLA PRIMAVERA", null, null, false, null, null, "ESCUELA Nº 3105", "ID_TECNICAS", null, null, "ID_OESTE" },
                    { "OS12", "OS12", null, null, "AVDA HIPODROMO DE SAN ISIDRO 750", null, null, false, null, null, "COLEGIO SEC. Nº 5159- Bº PALERMO I", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS11", "OS11", null, null, "AVDA PORTAVIONES S/Nº -POLO REINGRESO", null, null, false, null, null, "POLO REINGRESO COL. SEC. Nº 5159 Bº PALERMO", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS10 BIS", "OS10 BIS", null, null, "SAN MARTIN 1800", null, null, false, null, null, "ANEXO POLO REINGRESO", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OS10", "OS10", null, null, "SAN MARTIN 1800", null, null, false, null, null, "BACHILLERATO  INTEGRAL RAUL SCALABRINI ORTIZ", "ID_SECUNDARIOS", null, null, "ID_OESTE" },
                    { "OI56", "OI56", null, null, "SENADOR MORON ESQ. AVDA LA PLATA - Bº OLIVOS", null, null, false, null, null, "SUBCOMISARIA VILLA ASUNCION", "ID_INSTITUCIONES", null, null, "ID_OESTE" },
                    { "CT04", "CT04", null, null, "JJ.URQUIZA  529", null, null, false, null, null, "ESCUELA TECNICA MARCELO LOTUFFO", "ID_TECNICAS", null, null, "ID_CENTRO" },
                    { "E02BIS", "E02BIS", null, null, "R.LEVENE Y MIRANDA - vª 20 DE JUNIO", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "E01BIS", "E01BIS", null, null, "COMEDOR EL MILAGRO-CUBA 1045 -Bº EL MILAGRO", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004-", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "S03", "S03", null, null, "ITUZAINGO 1012 Vº SAN ANTONIO", null, null, false, null, null, "REINO DE BELGICA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S02", "S02", null, null, "LOS LANCEROS E INDEPENDENCIA", null, null, false, null, null, "BRIG. ALVAREZ Y ARENALES", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S01", "S01", null, null, "FCO. ARIAS 824 - Vª SOLEDAD", null, null, false, null, null, "25 DE MAYO DE 1810", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "NT01", "NT01", null, null, "CAPITAN PAIVA ESQ CORONEL QUESADA - Cº DEL MILAGRO", null, null, false, null, null, "ESCUELA DE ED. TECNICA Nº 3141", "ID_TECNICAS", null, null, "ID_NORTE" },
                    { "NS10", "NS10", null, null, "PERITO MORENO 256 Bº UNIVERSITARIO TEL 4251259", null, null, false, null, null, "COLEGIO SAN JOSE", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS09", "NS09", null, null, "AVDA. DEMOCRACIA S/Nº - Bº EL HUAYCO", null, null, false, null, null, "BACHILLERATO TOMAS CABRERA", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS08", "NS08", null, null, "ALCAIDIA GRAL-COMPLEJO CDAD. JUDICIAL", null, null, false, null, null, "ANEXO FRAY MAMERTO ESQUIU", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS07", "NS07", null, null, "AVDA. DEMOCRACIA S/Nº - Bº EL HUAYCO II", null, null, false, null, null, "ESCUELA DE COMERCIO 5075", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS06", "NS06", null, null, "LOS PIQUILLINES 450", null, null, false, null, null, "COLEGIO SALVADOR MAZZA", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "S04", "S04", null, null, "MAR TIRRENO 1145 - Bº SAN REMO", null, null, false, null, null, "ALEJANDRO GAUFFIN", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "NS05", "NS05", null, null, "LAS ROSAS  253", null, null, false, null, null, "COLEGIO SECUNDARIO REYES CATOLICOS", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS03", "NS03", null, null, "CHULUPIES Y ARAUCANOS - Bº Pº BELGRANO", null, null, false, null, null, "COLEGIO Nº 5048 - JUANA MANUELA GORRITI", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS02", "NS02", null, null, "25 DE MAYO 1150", null, null, false, null, null, "BACHILLERATO PROF. AMADEO SIROLLI", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NS01", "NS01", null, null, "FRAGATA SARMIENTO S/Nº - Bº CIUDAD DEL MILAGRO", null, null, false, null, null, "COLEGIO SECUNDARIO C. DEL MILAGRO", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NI52", "NI52", null, null, "RUTA 9 KM 1610", null, null, false, null, null, "MERENDERO PARRQ DE LA RESURRECCION", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI49", "NI49", null, null, "MANZ. 403 - B lote 6 Bº 17 DE OCTUBRE- TEL.256886", null, null, false, null, null, "MERENDERO AMANDITA", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI47", "NI47", null, null, "COMPL DEP B°M. ORTIZ ZUVIRIA N°2750", null, null, false, null, null, "CUERPO INF. COM 3ra", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI46", "NI46", null, null, "LOS OMBUES 392 - Bº TRES CERITOS - SRA RAQUEL", null, null, false, null, null, "S.E.R.", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI45", "NI45", null, null, "AV. ARENALES 2500 - Bº MILITAR.", null, null, false, null, null, "PREJARDIN DIVINO NIÑO", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI44", "NI44", null, null, "LAGUNA BLANCA MNA. 388A-LOTE24 Bº 17 DE OCTUBRE", null, null, false, null, null, "CUERPO INFANTIL COM. Nº 103", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NS04", "NS04", null, null, "Bº UNIVERSITARIO", null, null, false, null, null, "COLEGIO BATALLA DE SALTA", "ID_SECUNDARIOS", null, null, "ID_NORTE" },
                    { "NI43", "NI43", null, null, "MANZ. 356A LOTE 6 Bº UNION", null, null, false, null, null, "CUERPO INFANTIL COM. Nº 103", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "S05", "S05", null, null, "REP. DEL LIBANO 850 - Bº CASINO", null, null, false, null, null, "REPUBLICA ARGENTINA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S07BIS", "S07BIS", null, null, "DR.URIBURU ESQ. M. LEZAMA", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7004", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S23", "S23", null, null, "PATAGONIA ARGENTINA 2950- Bº INTERSINDICAL", null, null, false, null, null, "MARIQUITA SANCHEZ DE THOMPSON", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S22BIS", "S22BIS", null, null, "AVDA. ROBERTO ROMERO S/Nº - Bº EL TRIBUNO", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S22", "S22", null, null, "AVDA. ROBERTO ROMERO S/Nº - Bº EL TRIBUNO", null, null, false, null, null, "MARIANO MORENO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S20", "S20", null, null, "MANZ. 465 A - Bº SOLIDARIDAD 2DA. ETAPA", null, null, false, null, null, "CTRO. ED. FE Y ALEGRIA BLANCA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S18 BIS", "S18 BIS", null, null, "MANZ. 4 - BARRIO SAN IGNACIO", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S18", "S18", null, null, "MANZ. 4 - BARRIO SAN IGNACIO 674", null, null, false, null, null, "RICARDO DURAND", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S17", "S17", null, null, "PJE. FELIPE VALLESE S/Nº - BOULOGNE SUR MER", null, null, false, null, null, "CRISTOBAL COLON ", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S16", "S16", null, null, "RUTA 26 - FINCA VELARDE", null, null, false, null, null, "MA. REYES DE CAMPOS", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S15", "S15", null, null, "MANSILLA S/Nº - Bº JUAN CALCHAQUI", null, null, false, null, null, "INDEPENDENCIA NACIONAL", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S07", "S07", null, null, "DR. URIBURU ESQ. M. LEZAMA - VILLA MARIA ESTER", null, null, false, null, null, "9 DE JULIO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S14BIS", "S14BIS", null, null, "MANZ. 252 L - Bº SAN FCO. SOLANO-TEC 3118", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S13BIS", "S13BIS", null, null, "PJE. FELIPE VALLESE S/Nº - BOULOGNE SUR MER", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S13", "S13", null, null, "PJE. FELIPE VALLESE S/Nº - BOULOGNE SUR MER", null, null, false, null, null, "DELFIN LEGUIZAMON", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S12BIS C", "S12BIS C", null, null, "RIO PIEDRAS Nº 280 - COL. AMERICA LATINA", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S12BIS B", "S12BIS B", null, null, "CARLOS OUTES 260 Vº LAVALLE-GUARDERIA JUAN GALO", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S12BISA", "S12BISA", null, null, "RIO MEDINA Y RIO SAN CARLOS Nº 590 - Vª LAVALLE", null, null, false, null, null, "NUCLEO ED. Nº 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S12", "S12", null, null, "RIO MEDINA Y RIO SAN CARLOS Nº 590 - Vª LAVALLE", null, null, false, null, null, "MIGUEL DE C. SAAVEDRA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S11", "S11", null, null, "FCO. LOPEZ 1630- Vª MARIA ESTHER", null, null, false, null, null, "PCIA. DE BS.AS.", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S10", "S10", null, null, "LIBERTAD Y MANUELA G. DE TODD -Bº MUNICIPAL", null, null, false, null, null, "RAUL GOYTEA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S09", "S09", null, null, "FCO. ARIAS Y LEZCANO VILLA ESTELA", null, null, false, null, null, "JARDIN INF. Vª ESTELA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S14", "S14", null, null, "ANDRES CHAZARRETA 436- Bº STA CECILIA", null, null, false, null, null, "PCIA. DE SALTA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "NI42", "NI42", null, null, "ZUVIRIA 2076 ", null, null, false, null, null, "MERENDERO PANCITAS FELICES", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI38", "NI38", null, null, "B° PARQ. GRAL BELR. ETAPA 4-MAN 1-DUPLEX 1-SRA. VIOLETA", null, null, false, null, null, "ANEXO ESC. DE MUSICA MOV. INT. VEC.", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI34", "NI34", null, null, "MANZ. 327C - LOTE 17 - BARRIO 1RO. DE MAYO", null, null, false, null, null, "MERENDERO EL ARCA DE NOE", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "N15", "N15", null, null, "MANDARINOS Y LAS PALTAS Bº 3 CERRITOS", null, null, false, null, null, "BENJAMIN DAVALOS Y AVILES", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N14BIS", "N14BIS", null, null, "AVDA. J.B. JUSTO 350 - Bº POSTAL - BASE", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N14", "N14", null, null, "AVDA. J.B. JUSTO 350 - Bº POSTAL", null, null, false, null, null, "20 DE FEBRERO ", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N13BIS", "N13BIS", null, null, "MITRE 2000", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N13", "N13", null, null, "MITRE 2000", null, null, false, null, null, "JOSE VICENTE SOLA ", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N12BIS", "N12BIS", null, null, "PJE. EL JARDIN 48 - Bº MIGUEL ORTIZ", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N12", "N12", null, null, "PJE. EL JARDIN 48 - Bº MIGUEL ORTIZ", null, null, false, null, null, "MIGUEL ORTIZ", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N11", "N11", null, null, "AVDA. BOLIVIA Y AV. YPF", null, null, false, null, null, "PEREYRA ROSAS", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N10BIS", "N10BIS", null, null, "AVDA. PEÑALBA S/Nº -Bº J.M.CASTILLA", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N16", "N16", null, null, "AVDA. REYES CATOLICOS 1580", null, null, false, null, null, "JOAQUIN CASTELLANOS", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N10", "N10", null, null, "AVDA. PEÑALBA S/Nº -Bº J.M.CASTILLA", null, null, false, null, null, "RAFAEL SOSA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N08bis", "N08bis", null, null, "AVDA. HUSSEIN S/Nº Bº CASTAÑARES", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N08", "N08", null, null, "AVDA. HUSSEIN S/Nº Bº CASTAÑARES", null, null, false, null, null, "MONSEÑOR PEREZ ", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N07", "N07", null, null, "PERITO MORENO S/Nº BARRIO UNIVERSITARIO", null, null, false, null, null, "NICOLAS AVELLANEDA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N06BIS", "N06BIS", null, null, "MANZ. 334- Bº LEOPOLDO LUGONES", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N06", "N06", null, null, "MANZ. 334- Bº LEOPOLDO LUGONES", null, null, false, null, null, "LEOPOLDO LUGONES", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N05", "N05", null, null, "PARQUE GRAL. BELGRANO MZA. 13 - 6TA ETAPA", null, null, false, null, null, "RENE FAVALORO", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N03", "N03", null, null, "M.PRADO Y FCO CRUZ Cº DEL MILAGRO", null, null, false, null, null, "JARDIN INF. 4TA. ETAPA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N02", "N02", null, null, "J.C.SANCHEZ Y ETCHEGOYEN-Cº DEL MILAGRO", null, null, false, null, null, "JARDIN INF. 3ª ETAPA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N01BIS", "N01BIS", null, null, "DONATO ALVAREZ S/Nº - Cº DEL MILAGRO", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N09", "N09", null, null, "PADRE R. ADUAGA S/Nº -GPO 298-Bº CASTAÑARES", null, null, false, null, null, "EVA PERON", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N17", "N17", null, null, "VICENTE LOPEZ 1560", null, null, false, null, null, "JARDIN MATERNO INF. Nº4767", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N18", "N18", null, null, "DEAN FUNES 1151 Vª BELGRANO", null, null, false, null, null, "PAULA ALBARRACIN", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N19", "N19", null, null, "25 DE MAYO 1150", null, null, false, null, null, "BERNARDINO RIVADAVIA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "NI33", "NI33", null, null, "MANZ. 350 - Bº JUAN PABLO II", null, null, false, null, null, "VICARIA NTRA SRA DE LOURDES", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI32", "NI32", null, null, "LUIS AGOTE Y PERITO MORENO-MANZ.235B LOTE 8 -Bº UNIV.", null, null, false, null, null, "ANEXO ABORDAJE EN DROGAS", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI30", "NI30", null, null, "AVDA.SANANTONIO DE LOS COBRES  4 -Bº CASTAÑARES", null, null, false, null, null, "ASOC. TRABAJ. DE LA SANIDAD ARG.", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI29", "NI29", null, null, "MANZ. 421C LOTE 1 -Bº 17 DE OCTUBRE", null, null, false, null, null, "CLUB ABUELOS SONRISAS DE OTOÑO", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI28", "NI28", null, null, "MANZ J LOTE 15 Bº 15 DE SETIEMBRE", null, null, false, null, null, "MERENDERO FUNDACION SALTA CRECER", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI24", "NI24", null, null, "Bº P.GRAL BELGRANO - ETAPA 3 - AVDA JAIME DURAN", null, null, false, null, null, "FUNDACION ANPÙY", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI23", "NI23", null, null, "MANZ. 357 A- LOTE - Bº UNION", null, null, false, null, null, "C.I.C Bº UNION", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI22", "NI22", null, null, "PJE. ALFONSO PERALTA 425 - Bº MIGUEL ORTIZ", null, null, false, null, null, "CLUB ABUELOS ANGEL DE LA GUARDA", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI13", "NI13", null, null, "LOS MIRASOLES 486 B - CASA 10 -", null, null, false, null, null, "ESCUELA DE FUTBOL SUPER BOYS", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI09", "NI09", null, null, "JAIME DURAND Y PERITO MORENO Bº UNIVERSITARIO", null, null, false, null, null, "SUBCOMISARIA CASTAÑARES", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI06", "NI06", null, null, "LOS AZAHARES 63 - Bº TRES CERRITOS", null, null, false, null, null, "CASITA DE BELEN", "ID_INSTITUCIONES", null, null, "ID_NORTE" }
                });

            migrationBuilder.InsertData(
                table: "Establecimientos",
                columns: new[] { "Id", "Codigo", "DeletedAt", "DeletedBy", "Domicilio", "InsertedAt", "InsertedBy", "IsDeleted", "Latitud", "Longitud", "Nombre", "TipoEstablecimientoId", "UpdatedAt", "UpdatedBy", "ZonaId" },
                values: new object[,]
                {
                    { "NI05", "NI05", null, null, "TNE. MAYOL S/Nº CIUDAD DEL MILAGRO", null, null, false, null, null, "CPO.  POLICIA INF. COM. 6TA.", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI04", "NI04", null, null, "ZUVIRIA 752", null, null, false, null, null, "AYUDAME A CRECER", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI02", "NI02", null, null, "B. HUSSAIN S/Nº - Bº CASTAÑARES", null, null, false, null, null, "ESC. ESP. COMISARIA  MENOR", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "NI01", "NI01", null, null, "PERITO MORENO S/Nº - Bº UNIVERSITARIO", null, null, false, null, null, "DIR. GRAL. DE JUSTICIA PENAL JUVENIL", "ID_INSTITUCIONES", null, null, "ID_NORTE" },
                    { "N27", "N27", null, null, "Bº EL HUAICO - FRANCISCO CORBALAN S/Nº", null, null, false, null, null, "BICENTENARIO DE LA INDEPENDENCIA NACIONAL", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N26", "N26", null, null, "Bº EL HUAICO - AVDA DEMOCRACIA S/Nº", null, null, false, null, null, "E.F.E.T.A.", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N25", "N25", null, null, "RUTA 28 Km 11 ", null, null, false, null, null, "Ma. ELVIRA CASTELLANOS DE URIBURU", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N23BIS", "N23BIS", null, null, "Bº JUAN PABLO II", null, null, false, null, null, "NUCLEO ED. Nº 7003", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N23", "N23", null, null, "AV. EJERCITO ARG. Y RAUL GALAN Bº JUAN PABLO II", null, null, false, null, null, "ESCUELA Nº 4817-Bº JUAN PABLO II", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "N20", "N20", null, null, "25 DE MAYO 1150", null, null, false, null, null, "CORDOBA", "ID_ESCUELAS", null, null, "ID_NORTE" },
                    { "S24", "S24", null, null, "LRA RADIO NACIONAL Nº3495 - Bº INTERSINDICAL ", null, null, false, null, null, "CLARA  SARAVIA LINARES DE ARIAS", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "E02", "E02", null, null, "R. LEVENE Y MIRANDA - Vª 20 DE JUNIO", null, null, false, null, null, "ARTURO OÑATIVIA", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "S25", "S25", null, null, "LAS GOLONDRINAS Y LOS HORNEROS-BANCARIO", null, null, false, null, null, "MARIA DEL Rº DE SAN NICOLAS", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S27", "S27", null, null, "AVDA PERU - PJE 12 - Bº SANTA ANA I", null, null, false, null, null, "IV CENT. FUND. DE SALTA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "SI125", "SI125", null, null, "DESTACAMENTO VILLA PALACIOS", null, null, false, null, null, "CUERPO INF.COM.Vª PALACIOS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI124", "SI124", null, null, "MANZ.252 B - LOTE 22 - Bº SAN FRANCISCO SOLANO", null, null, false, null, null, "MERENDERO SUEÑOS DE NIÑOS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI122", "SI122", null, null, "435 C- BARRIO LA PAZ-SUM-SRA. FABIOLA -CEL 155054130", null, null, false, null, null, "MERENDERO ANGELITOS DE LA PAZ", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI117", "SI117", null, null, "SAN FELIPE Y SANTIAGO 2100 Vº MARIA ESTHER", null, null, false, null, null, "CUERPO INF. POL. ECOLOGICA ", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI116", "SI116", null, null, "MANZ F LOTE 9 Bº JUSTICIA CEL 156844629", null, null, false, null, null, "MERENDERO JESUS PAN DE VIDA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI115", "SI115", null, null, "MANZ. 321 A - CASA11 - BARRIO SAN BENITO-4385411", null, null, false, null, null, "MERENDERO MADRES UNIDAS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI114", "SI114", null, null, "MANZ. 618 A - CASA 11 - FINCA VALDIVIA", null, null, false, null, null, "ESCUELA DE FUTBOL FINCA VALDIVIA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI113", "SI113", null, null, "AVDA. FELIPE VARELA 1421 FLIA ESTRADA YLLESCA BºNORTE GRANDE", null, null, false, null, null, "MEREND. CTRO. MISIONERO DIVINA MISERICORDIA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI112", "SI112", null, null, "MANZ. 36 CASA 30 - BARRIO SAN IGNACIO", null, null, false, null, null, "FUNDACION CORAZON Y ESFUERZO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI130", "SI130", null, null, "MANZANA 508 B LOTE 8 BARRIO PRIMERA JUNTA", null, null, false, null, null, "MEREN.MARCELINO PAN Y VINO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI111", "SI111", null, null, "MANZ. 1 - LOTE D - Bº CONVIVENCIA", null, null, false, null, null, "PREJARDIN MARTINA TESI", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI102", "SI102", null, null, "MANZ. E CASA13 - Bº 23 DE AGOSTO", null, null, false, null, null, "MERENDERO Bº 23 DE AGOSTO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI100", "SI100", null, null, "MNA 302B Bº JUAN CALCHAQUI", null, null, false, null, null, "MERENDERO FUNDACION LLANKAY", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI99", "SI99", null, null, "DESTACAMENTO POLICIA Bº SOLIDARIDAD 4TA. ETAPA", null, null, false, null, null, "CUERPO INF. COM. 17 - Bº SOLIDARIDAD - 4TA. ETAPA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI98", "SI98", null, null, "DESTACAMENTO POL. Bº SAN IGNACIO", null, null, false, null, null, "CUERPO INFANTIL COM. Bº SAN IGNACIO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI97", "SI97", null, null, "AVDA. FELIPE VARELA 500 Bº SANTA CECILIA", null, null, false, null, null, "CUERPO INFANTIL COM. 10º", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI96", "SI96", null, null, "MANZ. 368 B - LOTE 14 - Bº DEMOCRACIA (EXMANZ.17- LOTE 9)", null, null, false, null, null, "MERENDERO PANCITAS FELICES-Bº DEMOCRACIA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI95", "SI95", null, null, "VICARIO ZAMBRANO Nº66 - Bº. CEFERINO", null, null, false, null, null, "MERENDERO CEFERINO FUTBOL CLUB", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI94", "SI94", null, null, "ETAPA 4 - MANZ. 1 - CASA 7- Bº LIMACHE", null, null, false, null, null, "CENTRO DE ABUELOS MARIA DEL ROSARIO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI90", "SI90", null, null, "MANZ. 337B - LOTE 37 - Bº FRATERNIDAD", null, null, false, null, null, "MERENDERO Bº FRATERNIDAD", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI106", "SI106", null, null, "MNA.414B-ETAPA 4 - Bº SOLIDARIDAD", null, null, false, null, null, "C.I.C. CARLOS XAMENA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI89", "SI89", null, null, "JOAQUIN CASTELLENOS 999", null, null, false, null, null, "GUARDERIA MUNICIPAL EL NIÑO FELIZ", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI131", "SI131", null, null, "PJE. FELIPE VALLESE S/Nº - BOULOGNE SUR MER", null, null, false, null, null, "BSPA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI133", "SI133", null, null, "MNA 316 LOTE 1 Bº SAN BENITO", null, null, false, null, null, "CDI. MONSEÑOR ENRIQUE ANGELELLI", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "E01", "E01", null, null, "CUBA 969 - Bº EL MILAGRO", null, null, false, null, null, "CEFERINO NAMUNCURA", "ID_ESCUELAS", null, null, "ID_ESTE" },
                    { "ST03", "ST03", null, null, "RUTA AVDA KENEDY", null, null, false, null, null, "ESCUELA GRAL MARTIN MIGUEL DE GUEMES ", "ID_TECNICAS", null, null, "ID_SUR" },
                    { "ST02", "ST02", null, null, "MANZ. 252 L - BARRIO SAN FCO. SOLANO", null, null, false, null, null, "ESCUELA Nº 3118", "ID_TECNICAS", null, null, "ID_SUR" },
                    { "ST01", "ST01", null, null, "MAR BLANCO 350 - BARRIO SAN REMO", null, null, false, null, null, "MAESTRO DANIEL O. REYES N° 3117", "ID_TECNICAS", null, null, "ID_SUR" },
                    { "SS15", "SS15", null, null, "LIBERTAD ESQ. MANUELA G. DE TOOD", null, null, false, null, null, "RAUL  GOYTIA", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS14", "SS14", null, null, "MANZ. 417 A BARRIO SOLIDARIDAD - 3RA. ETAPA", null, null, false, null, null, "CENTRO ED. FE Y ALEGRIA AMARILLA", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS13", "SS13", null, null, "FELIPE SOLA S/Nº - VILLA ESMERALDA", null, null, false, null, null, "COLEGIO SECUNDARIO VILLA ESMERALDA", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS12", "SS12", null, null, "AVDA. RICARDO BALBIN Nº 900", null, null, false, null, null, "COLEGIO WALTER ADET", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS11", "SS11", null, null, "AVDA. DIAZ VILLALBA S/Nº", null, null, false, null, null, "COLEGIO SECUNDARIO SIGLO XXI", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SI132", "SI132", null, null, "MNA 471D CASA 21 Bº LOS LAPACHOS ", null, null, false, null, null, "MERENDERO NTRA SRA DE URKUPIÑA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SS10", "SS10", null, null, "AVDA. DEL TRABAJO S/Nº - VILLA PALACIOS", null, null, false, null, null, "ESCUELA DE COMERCIO DR. RENE FAVALORO", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS08", "SS08", null, null, "AVDA. RALLE Y VICTOR H. JUAREZ - BARRIO LIMACHE", null, null, false, null, null, "COLEGIO JUAN CARLOS SARAVIA", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS06", "SS06", null, null, "ITUZAINGO 1002", null, null, false, null, null, "COLEGIO JUAN PABLO II", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS04", "SS04", null, null, "RIO PIEDRAS Nº 280", null, null, false, null, null, "COLEGIO SECUNDARIO AMERICA LATINA", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS03", "SS03", null, null, "RADIO ESQUEL DE CHUBUT - BARRIO INTERSINDICAL", null, null, false, null, null, "ESCUELA DE COMERCIO DR. ERNESTO ARAOZ", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS02B", "SS02B", null, null, "LOS LANCEROS E INDEPENDENCIA", null, null, false, null, null, "COLEGIO SECUNDARIO  GRAL JOSE DE SAN MARTIN", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS02", "SS02", null, null, "AVDA. REPUBLICA DEL LIBANO S/N - BARRIO CASINO", null, null, false, null, null, "COLEGIO SECUNDARIO GRAL JOSE DE SAN MARTIN", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SS01", "SS01", null, null, "FCO. ARIAS Y ANSELMO ROJO. ", null, null, false, null, null, "COLEGIO 2 DE ABRIL 1982", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SI135", "SI135", null, null, "MZA 447 B LOTE 13 3ra ETAPA Bº SOLIDARIDAD ", null, null, false, null, null, "ESC. DE BOX AMILCAR BRUSA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI134", "SI134", null, null, "JOAQUIN V. GONZALEZ 488 - Bº BOULOGNE SUR MER", null, null, false, null, null, "ESC. DE BOX BOULOGNE SUR MER", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SS09", "SS09", null, null, "AVDA. RALLE Y VICTOR H. JUAREZ - BARRIO LIMACHE", null, null, false, null, null, "COLEGIO  JUAN CARLOS SARAVIA - ANEXO-", "ID_SECUNDARIOS", null, null, "ID_SUR" },
                    { "SI88", "SI88", null, null, "ARTURO DAVALOS 71 - Vº SOLEDAD / Pan pasa a buscar de planta", null, null, false, null, null, "ESC.FUTBOL POR SIEMPRE UNIDOS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI87", "SI87", null, null, "MANZ. 449 A - LOTE 11 - 3RA ETAPA Bº SOLIDAR.", null, null, false, null, null, "CENTRO SAN MARTIN DE PORRES", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI86", "SI86", null, null, "AVDA RALLE ESQ CABO PRIMERA CISTERNA", null, null, false, null, null, "SUBCOMISARIA Bº LIMACHE", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI13", "SI13", null, null, "REPUBLICA DE SIRIA 611", null, null, false, null, null, "FUNDACION DESARROLLO 2000", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI05", "SI05", null, null, "MANZ. 317- LOTE B- Bº SAN BENITO", null, null, false, null, null, "SALON USOS M. SAN BENITO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "S47BIS", "S47BIS", null, null, "LUCIO MANSILLA Y SANTILLAN -Bº DEMOCRACIA", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S47", "S47", null, null, "LUCIO MANSILLA Y SANTILLAN -Bº DEMOCRACIA", null, null, false, null, null, "ESCUELA BICENTENARIO BATALLA SALTA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S46BIS", "S46BIS", null, null, "Bº SOLIDARIDAD 4TA. ETAPA- FRENTE AL C.I.C.", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S46", "S46", null, null, "MZA 438 A-3RA ETAPA- B° SOLIDARIDAD", null, null, false, null, null, "ESCUELA Nº 4811- 2 DE MAYO CRUCERO A.R.A GRAL. BELGRANO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S43BIS", "S43BIS", null, null, "AVDA DIAZ VILLALBA S/Nº", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S43", "S43", null, null, "AVDA DIAZ VILLALBA S/Nº MZA 355A-B Bº SIGLO XXI", null, null, false, null, null, "ESC. ELSA SALFITTY ", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S42BIS", "S42BIS", null, null, "Bº LIBERTAD MZA 391  B ", null, null, false, null, null, "ANEXO NUCLEO ED. 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "SI22", "SI22", null, null, "PJE. 23 CASA 1553-ESQUINA-B° SANTA ANA 1- SRA. LUCIA CASTRO", null, null, false, null, null, "S.P.E.S.", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "S42", "S42", null, null, "Bº LIBERTAD MZA 391  B ", null, null, false, null, null, "ESC. GRAL JUAN JOSE VALLE", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S35", "S35", null, null, "GABRIEL GUEMES 243 - Bº DON EMILIO", null, null, false, null, null, "ROQUE CHIELLI", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S34", "S34", null, null, "MANZ. 51 Bº SAN CARLOS", null, null, false, null, null, "Bº SAN CARLOS", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S33", "S33", null, null, "IVONE RETAMOZO DE IÑIGUEZ S/Nº E-11-Bº LIMACHE", null, null, false, null, null, "NTRA. SRA. DEL MILAGRO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S32", "S32", null, null, "FELIPE SOLA S/Nº - VILLA ESMERALDA", null, null, false, null, null, "RUDECINDO ALVARADO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S31", "S31", null, null, "AVDA. RALLE S/Nº - Bº LIMACHE", null, null, false, null, null, "LEGADO GRAL BELGRANO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S30", "S30", null, null, "RUTA 51 KM. 842 - SAN LUIS", null, null, false, null, null, "SUBMARINO ARA", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S29", "S29", null, null, "RUTA 68 - RIO ANCHO", null, null, false, null, null, "MARCOS SASTRE", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S28", "S28", null, null, "PJE 21 - ALT. 1400 - Bº SANTA ANA", null, null, false, null, null, "CESAR FERMIN PERDIGUERO", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S27BIS", "S27BIS", null, null, "AVDA PERU - PJE 12 - Bº SANTA ANA I", null, null, false, null, null, "ANEXO NUCLEO ED. Nº 7006", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "S41", "S41", null, null, "ANSELMO ROJO Nº 51 -Bº MUNICIPAL", null, null, false, null, null, "GUARDERIA MONSEÑOR PÈREZ", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "SI28", "SI28", null, null, "RUTA 51 - SAN LUIS", null, null, false, null, null, "SUBCOMISARIA DE SAN LUIS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI29", "SI29", null, null, "etapa 6 manz. 2 - Casa 5 - Flia Liendro", null, null, false, null, null, "PARROQUIA ENCARNACION DEL VERBO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI31", "SI31", null, null, "LA RAZON Y LOS ANDES Bº EL TRIBUNO", null, null, false, null, null, "CPO. INF. COM. EL TRIBUNO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI81", "SI81", null, null, "CORDOBA 1810 - Bº CEFERINO", null, null, false, null, null, "VICARIA NTRA.SRA.Rº SAN NICOLAS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI80", "SI80", null, null, "PJE DEL MILAGRO 1581 Bº MUNICIPAL", null, null, false, null, null, "MERENDERO FUNDACION DULCE SOL", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI79", "SI79", null, null, "FLORIDA 1548", null, null, false, null, null, "COMEDOR PADRE SALUSTIANO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI78", "SI78", null, null, "PJE. LOS INFERNALES 1526 - Vª SAN ANTONIO", null, null, false, null, null, "MERENDERO LA NUEVA ILUSION", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI76", "SI76", null, null, "Bº LIMACHE - ETAPA 10 - MANZ 3 - CASA 3", null, null, false, null, null, "FUND.EMPRENDEDORES FOR.EM.ES", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI75", "SI75", null, null, "MANZ. Q.CASA Nº 5 - Bº STA. CECILIA ", null, null, false, null, null, "MOV. DE INTEGRACION VECINAL", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI72", "SI72", null, null, "MANUELA G. DE TODD Nº 1600", null, null, false, null, null, "MERENDERO BARRIO MUNICIPAL", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI70", "SI70", null, null, "MAR MEDITERRANEO 223- Bº SAN REMO", null, null, false, null, null, "CPO. INF. COM. 15", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI68", "SI68", null, null, "AVDA. DR. ERNESTO GUEVARA - VILLA SAN ANTONIO", null, null, false, null, null, "GUARDERIA SANTA TERESA DE JESUS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI65", "SI65", null, null, "AVDA. FELIPE VARELA  ESQ. A. MEDINA-Bº SAN FCO. SOL", null, null, false, null, null, "PREJARDIN DIVINO NIÑO-PARR.MA. REINA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI64", "SI64", null, null, "LA RAZON 4001- Bº EL TRIBUNO 4240900", null, null, false, null, null, "PARROQUIA MARIA REINA ", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI61", "SI61", null, null, "CARLOS OUTE 341 Vº LAVALLE", null, null, false, null, null, "MERENDERO FERNANDO SUÑER", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI60", "SI60", null, null, "manz. K - casa 4 - bº circulo 1", null, null, false, null, null, "CAT. PARROQUIA STELLA MARIS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI58", "SI58", null, null, "MANZ. 202 LOTE 7 Bº NORTE GRANDE", null, null, false, null, null, "ESC. MUNICIPAL DE BOX -Bº NORTE GRANDE", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI57", "SI57", null, null, "MANZ.25 LOTE 16 - BARRIO LA PAZ", null, null, false, null, null, "MERENDERO MERA FIGUEROA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI56", "SI56", null, null, "BARRIO SANTA CECILIA", null, null, false, null, null, "C.I.C. BARRIO SANTA CECILIA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI44", "SI44", null, null, "ESTANISLAO  LOPEZ 191 - FINCA INDEPENDENCIA", null, null, false, null, null, "ESC. DE POL. INF. DE TRANSITO", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI39", "SI39", null, null, "ESTEBAN ECHEVERRIA S/Nº Bº JUAN CALCHAQUI", null, null, false, null, null, "FUNDACION CHANGUITO DIOS", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI37", "SI37", null, null, "MANZ. 514 D - LOTE 13 - Bº 1RA. JUNTA- 155120711", null, null, false, null, null, "MERENDERO NIÑO JESUS DE PRAGA", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI34", "SI34", null, null, "LERMA 1445", null, null, false, null, null, "HOGAR DE CIEGOS HABID YAZLLE", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "SI33", "SI33", null, null, "DEST. COMISARIA Nº 12- Bº STA. ANA 1", null, null, false, null, null, "POL. INF. COM. 12 - Bº STA. ANA 1", "ID_INSTITUCIONES", null, null, "ID_SUR" },
                    { "S26", "S26", null, null, "LOS HORNEROS 4420 - Bº BANCARIO", null, null, false, null, null, "RAUL CORTAZAR", "ID_ESCUELAS", null, null, "ID_SUR" },
                    { "CT05", "CT05", null, null, "TUCUMAN 505", null, null, false, null, null, "ALBERTO EINSTEIN", "ID_TECNICAS", null, null, "ID_CENTRO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establecimientos_TipoEstablecimientoId",
                table: "Establecimientos",
                column: "TipoEstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Establecimientos_ZonaId",
                table: "Establecimientos",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas");

            migrationBuilder.DropTable(
                name: "Establecimientos");

            migrationBuilder.DropTable(
                name: "TipoEstablecimientos");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "ID_CENTRO");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "ID_ESTE");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "Id_Interior");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "ID_NORTE");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "ID_OESTE");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "ID_SUR");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "66028");

            migrationBuilder.DeleteData(
                table: "Zonas",
                keyColumn: "Id",
                keyValue: "66");

            migrationBuilder.AlterColumn<string>(
                name: "TipoZonaId",
                table: "Zonas",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_TipoZonas_TipoZonaId",
                table: "Zonas",
                column: "TipoZonaId",
                principalTable: "TipoZonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

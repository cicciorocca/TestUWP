using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestUWP.Migrations
{
    public partial class FirstMigrationAppCodFisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comuni",
                columns: table => new
                {
                    ComuneCodCatId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    codiceCatastale = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuni", x => x.ComuneCodCatId);
                });

            migrationBuilder.CreateTable(
                name: "SoggettiFiscali",
                columns: table => new
                {
                    SoggettoFiscaleId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CodiceCatastale = table.Column<string>(nullable: true),
                    CodiceFiscale = table.Column<string>(nullable: true),
                    Cognome = table.Column<string>(nullable: true),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sesso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoggettiFiscali", x => x.SoggettoFiscaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comuni");

            migrationBuilder.DropTable(
                name: "SoggettiFiscali");
        }
    }
}

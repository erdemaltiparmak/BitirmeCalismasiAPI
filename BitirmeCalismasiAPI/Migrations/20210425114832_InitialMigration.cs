using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitirmeCalismasiAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bilekliks",
                columns: table => new
                {
                    BileklikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilekliks", x => x.BileklikID);
                });

            migrationBuilder.CreateTable(
                name: "Hastas",
                columns: table => new
                {
                    HastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BileklikID = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<int>(type: "int", nullable: false),
                    HastaAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaYas = table.Column<int>(type: "int", nullable: false),
                    HastaOyku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaIletisimNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaAcikAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HastaKonumX = table.Column<double>(type: "float", nullable: false),
                    HastaKonumY = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastas", x => x.HastaID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSifre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilekliks");

            migrationBuilder.DropTable(
                name: "Hastas");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}

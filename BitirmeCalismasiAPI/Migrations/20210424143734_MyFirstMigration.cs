using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitirmeCalismasiAPI.Migrations
{
    public partial class MyFirstMigration : Migration
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
                    table.ForeignKey(
                        name: "FK_Hastas_Bilekliks_BileklikID",
                        column: x => x.BileklikID,
                        principalTable: "Bilekliks",
                        principalColumn: "BileklikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hastas_Personels_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "Personels",
                        principalColumn: "PersonelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hastas_BileklikID",
                table: "Hastas",
                column: "BileklikID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hastas_PersonelID",
                table: "Hastas",
                column: "PersonelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hastas");

            migrationBuilder.DropTable(
                name: "Bilekliks");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}

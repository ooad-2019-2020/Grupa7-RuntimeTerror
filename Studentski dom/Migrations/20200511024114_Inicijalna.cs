using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studentski_dom.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrijavaStudenta",
                columns: table => new
                {
                    PrijavaStudentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    AdresaStanovanja = table.Column<string>(nullable: true),
                    Fakultet = table.Column<string>(nullable: true),
                    GodinaStudiranja = table.Column<int>(nullable: false),
                    CiklusStudija = table.Column<int>(nullable: false),
                    BrojIndeksa = table.Column<int>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fotografija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaStudenta", x => x.PrijavaStudentaID);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    SobaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSobe = table.Column<int>(nullable: false),
                    Zauzeta = table.Column<bool>(nullable: false),
                    Sprat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaID);
                });

            migrationBuilder.CreateTable(
                name: "UposlenikDoma",
                columns: table => new
                {
                    UposlenikDomaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikDoma", x => x.UposlenikDomaID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SobaID = table.Column<int>(nullable: false),
                    BrojBonova = table.Column<int>(nullable: false),
                    PrijavaStudentaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_PrijavaStudenta_PrijavaStudentaID",
                        column: x => x.PrijavaStudentaID,
                        principalTable: "PrijavaStudenta",
                        principalColumn: "PrijavaStudentaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "SobaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radnik",
                columns: table => new
                {
                    RadnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikID = table.Column<int>(nullable: false),
                    UposlenikDomaID = table.Column<int>(nullable: true),
                    Usluga = table.Column<string>(nullable: true),
                    ImePrezime = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.RadnikID);
                    table.ForeignKey(
                        name: "FK_Radnik_UposlenikDoma_UposlenikDomaID",
                        column: x => x.UposlenikDomaID,
                        principalTable: "UposlenikDoma",
                        principalColumn: "UposlenikDomaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaKvara",
                columns: table => new
                {
                    PrijavaKvaraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    TipKvara = table.Column<string>(nullable: true),
                    OpisKvara = table.Column<string>(nullable: true),
                    VrijemePrijave = table.Column<DateTime>(nullable: false),
                    VrijemeRjesenja = table.Column<DateTime>(nullable: false),
                    HitanKvar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaKvara", x => x.PrijavaKvaraID);
                    table.ForeignKey(
                        name: "FK_PrijavaKvara_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijavaObroka",
                columns: table => new
                {
                    PrijavaObrokaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    Rucak = table.Column<bool>(nullable: false),
                    Vecera = table.Column<bool>(nullable: false),
                    ZaPonijetRucak = table.Column<bool>(nullable: false),
                    ZaPonijetVecera = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaObroka", x => x.PrijavaObrokaID);
                    table.ForeignKey(
                        name: "FK_PrijavaObroka_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaKvara_StudentID",
                table: "PrijavaKvara",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaObroka_StudentID",
                table: "PrijavaObroka",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Radnik_UposlenikDomaID",
                table: "Radnik",
                column: "UposlenikDomaID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PrijavaStudentaID",
                table: "Student",
                column: "PrijavaStudentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SobaID",
                table: "Student",
                column: "SobaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrijavaKvara");

            migrationBuilder.DropTable(
                name: "PrijavaObroka");

            migrationBuilder.DropTable(
                name: "Radnik");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "UposlenikDoma");

            migrationBuilder.DropTable(
                name: "PrijavaStudenta");

            migrationBuilder.DropTable(
                name: "Soba");
        }
    }
}

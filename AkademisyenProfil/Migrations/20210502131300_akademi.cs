using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademisyenProfil.Migrations
{
    public partial class akademi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fakultelers",
                columns: table => new
                {
                    fakulteno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fakultead = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fakultelers", x => x.fakulteno);
                });

            migrationBuilder.CreateTable(
                name: "bolumlers",
                columns: table => new
                {
                    bolumno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bolumad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fakulteno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bolumlers", x => x.bolumno);
                    table.ForeignKey(
                        name: "FK_bolumlers_fakultelers_fakulteno",
                        column: x => x.fakulteno,
                        principalTable: "fakultelers",
                        principalColumn: "fakulteno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "akademisyenlers",
                columns: table => new
                {
                    akano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    akaunvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akaad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akasoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akaemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akatel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bolumno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_akademisyenlers", x => x.akano);
                    table.ForeignKey(
                        name: "FK_akademisyenlers_bolumlers_bolumno",
                        column: x => x.bolumno,
                        principalTable: "bolumlers",
                        principalColumn: "bolumno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bildirilers",
                columns: table => new
                {
                    bildirino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ulusal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uluslararası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bildirilers", x => x.bildirino);
                    table.ForeignKey(
                        name: "FK_bildirilers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gorevlers",
                columns: table => new
                {
                    gorevno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gorevad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gorevlers", x => x.gorevno);
                    table.ForeignKey(
                        name: "FK_gorevlers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hakemliklers",
                columns: table => new
                {
                    hakemno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hakemad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hakemliklers", x => x.hakemno);
                    table.ForeignKey(
                        name: "FK_hakemliklers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kitaplars",
                columns: table => new
                {
                    kitapno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaplars", x => x.kitapno);
                    table.ForeignKey(
                        name: "FK_kitaplars_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "makalelers",
                columns: table => new
                {
                    makaleno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    makalead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makalelers", x => x.makaleno);
                    table.ForeignKey(
                        name: "FK_makalelers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "odullers",
                columns: table => new
                {
                    odulno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    odulad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odullers", x => x.odulno);
                    table.ForeignKey(
                        name: "FK_odullers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ogrenimbilgilers",
                columns: table => new
                {
                    ogrenimno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    arastirmaalan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doktora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yukseklisans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lisans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ogrenimbilgilers", x => x.ogrenimno);
                    table.ForeignKey(
                        name: "FK_ogrenimbilgilers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projelers",
                columns: table => new
                {
                    projeno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Projead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projelers", x => x.projeno);
                    table.ForeignKey(
                        name: "FK_projelers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sertifikalars",
                columns: table => new
                {
                    sertifakano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sertifikaad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sertifikalars", x => x.sertifakano);
                    table.ForeignKey(
                        name: "FK_sertifikalars_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_akademisyenlers_bolumno",
                table: "akademisyenlers",
                column: "bolumno");

            migrationBuilder.CreateIndex(
                name: "IX_bildirilers_akano",
                table: "bildirilers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_bolumlers_fakulteno",
                table: "bolumlers",
                column: "fakulteno");

            migrationBuilder.CreateIndex(
                name: "IX_gorevlers_akano",
                table: "gorevlers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_hakemliklers_akano",
                table: "hakemliklers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_kitaplars_akano",
                table: "kitaplars",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_makalelers_akano",
                table: "makalelers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_odullers_akano",
                table: "odullers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_ogrenimbilgilers_akano",
                table: "ogrenimbilgilers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_projelers_akano",
                table: "projelers",
                column: "akano");

            migrationBuilder.CreateIndex(
                name: "IX_sertifikalars_akano",
                table: "sertifikalars",
                column: "akano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bildirilers");

            migrationBuilder.DropTable(
                name: "gorevlers");

            migrationBuilder.DropTable(
                name: "hakemliklers");

            migrationBuilder.DropTable(
                name: "kitaplars");

            migrationBuilder.DropTable(
                name: "makalelers");

            migrationBuilder.DropTable(
                name: "odullers");

            migrationBuilder.DropTable(
                name: "ogrenimbilgilers");

            migrationBuilder.DropTable(
                name: "projelers");

            migrationBuilder.DropTable(
                name: "sertifikalars");

            migrationBuilder.DropTable(
                name: "akademisyenlers");

            migrationBuilder.DropTable(
                name: "bolumlers");

            migrationBuilder.DropTable(
                name: "fakultelers");
        }
    }
}

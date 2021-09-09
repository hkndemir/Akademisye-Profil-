using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademisyenProfil.Migrations
{
    public partial class guncel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "derslers",
                columns: table => new
                {
                    dersno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dersad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    akano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_derslers", x => x.dersno);
                    table.ForeignKey(
                        name: "FK_derslers_akademisyenlers_akano",
                        column: x => x.akano,
                        principalTable: "akademisyenlers",
                        principalColumn: "akano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_derslers_akano",
                table: "derslers",
                column: "akano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "derslers");
        }
    }
}

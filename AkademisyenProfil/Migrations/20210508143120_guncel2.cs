using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademisyenProfil.Migrations
{
    public partial class guncel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fakultelogo",
                table: "fakultelers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bollogo",
                table: "bolumlers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fakultelogo",
                table: "fakultelers");

            migrationBuilder.DropColumn(
                name: "bollogo",
                table: "bolumlers");
        }
    }
}

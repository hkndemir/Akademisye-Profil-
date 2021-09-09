using Microsoft.EntityFrameworkCore.Migrations;

namespace AkademisyenProfil.Migrations
{
    public partial class guncel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "akasoyad",
                table: "akademisyenlers",
                newName: "akafoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "akafoto",
                table: "akademisyenlers",
                newName: "akasoyad");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopping.Migrations.ShoppingDb
{
    public partial class pictureWay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureWay",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureWay",
                table: "Products");
        }
    }
}

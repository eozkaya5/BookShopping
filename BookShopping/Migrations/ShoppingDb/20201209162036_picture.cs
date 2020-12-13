using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopping.Migrations.ShoppingDb
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "PictureWay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureWay",
                table: "Products",
                newName: "Picture");
        }
    }
}

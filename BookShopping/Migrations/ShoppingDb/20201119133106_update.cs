using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopping.Migrations.ShoppingDb
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UseId",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Categories");
        }
    }
}

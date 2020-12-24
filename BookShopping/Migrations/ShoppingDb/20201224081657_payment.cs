using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShopping.Migrations.ShoppingDb
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_PaymentId",
                table: "UserComments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentId",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Payments_PaymentId",
                table: "Payments",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Payments_PaymentId",
                table: "UserComments",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Payments_PaymentId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Payments_PaymentId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_PaymentId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PaymentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Payments");
        }
    }
}

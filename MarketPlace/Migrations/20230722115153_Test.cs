using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Receipt_receiptIdreceipt",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "receiptIdreceipt",
                table: "Order",
                newName: "Receiptid");

            migrationBuilder.RenameIndex(
                name: "IX_Order_receiptIdreceipt",
                table: "Order",
                newName: "IX_Order_Receiptid");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Receipt_Receiptid",
                table: "Order",
                column: "Receiptid",
                principalTable: "Receipt",
                principalColumn: "Idreceipt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Receipt_Receiptid",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Receiptid",
                table: "Order",
                newName: "receiptIdreceipt");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Receiptid",
                table: "Order",
                newName: "IX_Order_receiptIdreceipt");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Receipt_receiptIdreceipt",
                table: "Order",
                column: "receiptIdreceipt",
                principalTable: "Receipt",
                principalColumn: "Idreceipt");
        }
    }
}

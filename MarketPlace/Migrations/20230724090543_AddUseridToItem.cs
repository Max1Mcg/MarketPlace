using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class AddUseridToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Userid",
                table: "Item",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Item_Userid",
                table: "Item",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_Userid",
                table: "Item",
                column: "Userid",
                principalTable: "User",
                principalColumn: "iduser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_Userid",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Userid",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Item");
        }
    }
}

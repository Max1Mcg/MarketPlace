using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idcategory = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Category_pkey", x => x.idcategory);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    iddelivery = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Delivery_pkey", x => x.iddelivery);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    iditem = table.Column<Guid>(type: "uuid", nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    weight = table.Column<string>(type: "text", nullable: true),
                    sold = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Item_pkey", x => x.iditem);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    idstatus = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Status_pkey", x => x.idstatus);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    iduser = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    patronymic = table.Column<string>(type: "text", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pkey", x => x.iduser);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "integer", nullable: false),
                    itemid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CategoryItem_pkey", x => new { x.categoryid, x.itemid });
                    table.ForeignKey(
                        name: "CategoryItem_categoryid_fkey",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "idcategory");
                    table.ForeignKey(
                        name: "CategoryItem_itemid_fkey",
                        column: x => x.itemid,
                        principalTable: "Item",
                        principalColumn: "iditem");
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    idbasket = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    item_count = table.Column<int>(type: "integer", nullable: true),
                    summary_cost = table.Column<double>(type: "double precision", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Basket_pkey", x => x.idbasket);
                    table.ForeignKey(
                        name: "Basket_userid_fkey",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "iduser");
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    basketid = table.Column<Guid>(type: "uuid", nullable: false),
                    itemid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BacketItem_pkey", x => new { x.basketid, x.itemid });
                    table.ForeignKey(
                        name: "BasketItem_basketid_fkey",
                        column: x => x.basketid,
                        principalTable: "Basket",
                        principalColumn: "idbasket");
                    table.ForeignKey(
                        name: "BasketItem_itemid_fkey",
                        column: x => x.itemid,
                        principalTable: "Item",
                        principalColumn: "iditem");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    idorder = table.Column<Guid>(type: "uuid", nullable: false),
                    statusid = table.Column<int>(type: "integer", nullable: false),
                    basketid = table.Column<Guid>(type: "uuid", nullable: false),
                    deliveryid = table.Column<int>(type: "integer", nullable: false),
                    additional_information = table.Column<string>(type: "text", nullable: true),
                    formed_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    closed_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pkey", x => x.idorder);
                    table.ForeignKey(
                        name: "Order_basketid_fkey",
                        column: x => x.basketid,
                        principalTable: "Basket",
                        principalColumn: "idbasket");
                    table.ForeignKey(
                        name: "Order_deliveryid_fkey",
                        column: x => x.deliveryid,
                        principalTable: "Delivery",
                        principalColumn: "iddelivery");
                    table.ForeignKey(
                        name: "Order_statusid_fkey",
                        column: x => x.statusid,
                        principalTable: "Status",
                        principalColumn: "idstatus");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_userid",
                table: "Basket",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_itemid",
                table: "BasketItem",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_itemid",
                table: "CategoryItem",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_basketid",
                table: "Order",
                column: "basketid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryid",
                table: "Order",
                column: "deliveryid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_statusid",
                table: "Order",
                column: "statusid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

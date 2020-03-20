using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    SId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrUId = table.Column<long>(nullable: true),
                    strSId = table.Column<long>(nullable: true),
                    cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OId);
                    table.ForeignKey(
                        name: "FK_Order_Store_strSId",
                        column: x => x.strSId,
                        principalTable: "Store",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_usrUId",
                        column: x => x.usrUId,
                        principalTable: "User",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustId = table.Column<long>(nullable: true),
                    SizeId = table.Column<long>(nullable: true),
                    ordOId = table.Column<long>(nullable: true),
                    cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_ordOId",
                        column: x => x.ordOId,
                        principalTable: "Order",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaPId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustId);
                    table.ForeignKey(
                        name: "FK_Crusts_Pizza_PizzaPId",
                        column: x => x.PizzaPId,
                        principalTable: "Pizza",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaPId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Sizes_Pizza_PizzaPId",
                        column: x => x.PizzaPId,
                        principalTable: "Pizza",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustId", "Name", "PizzaPId", "Price" },
                values: new object[,]
                {
                    { 1L, "Gluten Free", null, 5.00m },
                    { 2L, "Deep Dish", null, 3.50m },
                    { 3L, "New York Style", null, 2.50m },
                    { 4L, "Thin Crust", null, 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Name", "PizzaPId", "Price" },
                values: new object[,]
                {
                    { 1L, "Large", null, 12.00m },
                    { 2L, "Medium", null, 10.00m },
                    { 3L, "Small", null, 8.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_PizzaPId",
                table: "Crusts",
                column: "PizzaPId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_strSId",
                table: "Order",
                column: "strSId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_usrUId",
                table: "Order",
                column: "usrUId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ordOId",
                table: "Pizza",
                column: "ordOId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_PizzaPId",
                table: "Sizes",
                column: "PizzaPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crusts_CrustId",
                table: "Pizza",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "CrustId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Sizes_SizeId",
                table: "Pizza",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_Pizza_PizzaPId",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Pizza_PizzaPId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
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
                    table.PrimaryKey("PK_Stores", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
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
                    table.PrimaryKey("PK_Orders", x => x.OId);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_strSId",
                        column: x => x.strSId,
                        principalTable: "Stores",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_usrUId",
                        column: x => x.usrUId,
                        principalTable: "Users",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
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
                    table.PrimaryKey("PK_Pizzas", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_ordOId",
                        column: x => x.ordOId,
                        principalTable: "Orders",
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
                        name: "FK_Crusts_Pizzas_PizzaPId",
                        column: x => x.PizzaPId,
                        principalTable: "Pizzas",
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
                        name: "FK_Sizes_Pizzas_PizzaPId",
                        column: x => x.PizzaPId,
                        principalTable: "Pizzas",
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

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "SId", "location", "password", "username" },
                values: new object[,]
                {
                    { 1L, "Domino's", "dominos", "dominos" },
                    { 2L, "Papa John's", "papajohn", "papajohn" },
                    { 3L, "Nick's Pizza", "deepdishonly", "nickspizza" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UId", "password", "username" },
                values: new object[,]
                {
                    { 1L, "password", "nick" },
                    { 2L, "password12345", "fred" },
                    { 3L, "passwordrandom", "random" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_PizzaPId",
                table: "Crusts",
                column: "PizzaPId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_strSId",
                table: "Orders",
                column: "strSId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_usrUId",
                table: "Orders",
                column: "usrUId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustId",
                table: "Pizzas",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ordOId",
                table: "Pizzas",
                column: "ordOId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_PizzaPId",
                table: "Sizes",
                column: "PizzaPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "CrustId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_Pizzas_PizzaPId",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Pizzas_PizzaPId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

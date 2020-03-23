using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeId",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaPId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Types_Pizzas_PizzaPId",
                        column: x => x.PizzaPId,
                        principalTable: "Pizzas",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name", "PizzaPId", "Price" },
                values: new object[] { 1L, "Pepperoni", null, 3.00m });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name", "PizzaPId", "Price" },
                values: new object[] { 2L, "Sausage", null, 3.00m });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name", "PizzaPId", "Price" },
                values: new object[] { 3L, "Vegetable", null, 3.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_TypeId",
                table: "Pizzas",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PizzaPId",
                table: "Types",
                column: "PizzaPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Types_TypeId",
                table: "Pizzas",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Types_TypeId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_TypeId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Pizzas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeriaEfPost.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_categoryId",
                table: "Pizzas",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Category_categoryId",
                table: "Pizzas",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Category_categoryId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_categoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Pizzas");
        }
    }
}

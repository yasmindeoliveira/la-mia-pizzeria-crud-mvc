using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeriaEfPost.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeDbTerzaProva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categories_categoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Pizzas",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_categoryId",
                table: "Pizzas",
                newName: "IX_Pizzas_CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categories_CategoryId",
                table: "Pizzas",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categories_CategoryId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Pizzas",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CategoryId",
                table: "Pizzas",
                newName: "IX_Pizzas_categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categories_categoryId",
                table: "Pizzas",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

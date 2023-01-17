using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeriaEfPost.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    foto = table.Column<string>(type: "varchar(300)", nullable: false),
                    descrizione = table.Column<string>(type: "text", nullable: false),
                    prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.nome);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}

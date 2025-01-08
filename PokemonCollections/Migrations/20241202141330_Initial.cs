using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCardPokemonCollection",
                columns: table => new
                {
                    Cardsid = table.Column<int>(type: "int", nullable: false),
                    Collectionsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardPokemonCollection", x => new { x.Cardsid, x.Collectionsid });
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonCollection_Cards_Cardsid",
                        column: x => x.Cardsid,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonCollection_Collections_Collectionsid",
                        column: x => x.Collectionsid,
                        principalTable: "Collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardPokemonCollection_Collectionsid",
                table: "PokemonCardPokemonCollection",
                column: "Collectionsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonCardPokemonCollection");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}

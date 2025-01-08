using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class newDefinitionOfManyToManyDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardCollections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PokemonCollectionId = table.Column<int>(type: "int", nullable: false),
                    PokemonCardid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCollections", x => new { x.CardId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_CardCollections_Cards_PokemonCardid",
                        column: x => x.PokemonCardid,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCollections_Collections_PokemonCollectionId",
                        column: x => x.PokemonCollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardCollections_PokemonCardid",
                table: "CardCollections",
                column: "PokemonCardid");

            migrationBuilder.CreateIndex(
                name: "IX_CardCollections_PokemonCollectionId",
                table: "CardCollections",
                column: "PokemonCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCollections");
        }
    }
}

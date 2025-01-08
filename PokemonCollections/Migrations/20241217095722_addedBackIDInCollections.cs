using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class addedBackIDInCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCardPokemonCollection_Collections_Collectionsid",
                table: "PokemonCardPokemonCollection");

            migrationBuilder.RenameColumn(
                name: "Collectionsid",
                table: "PokemonCardPokemonCollection",
                newName: "CollectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonCardPokemonCollection_Collectionsid",
                table: "PokemonCardPokemonCollection",
                newName: "IX_PokemonCardPokemonCollection_CollectionsId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Collections",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCardPokemonCollection_Collections_CollectionsId",
                table: "PokemonCardPokemonCollection",
                column: "CollectionsId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCardPokemonCollection_Collections_CollectionsId",
                table: "PokemonCardPokemonCollection");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "CollectionsId",
                table: "PokemonCardPokemonCollection",
                newName: "Collectionsid");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonCardPokemonCollection_CollectionsId",
                table: "PokemonCardPokemonCollection",
                newName: "IX_PokemonCardPokemonCollection_Collectionsid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Collections",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCardPokemonCollection_Collections_Collectionsid",
                table: "PokemonCardPokemonCollection",
                column: "Collectionsid",
                principalTable: "Collections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

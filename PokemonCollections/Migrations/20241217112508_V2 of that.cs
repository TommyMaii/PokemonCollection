using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class V2ofthat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardCollections_Cards_PokemonCardid",
                table: "CardCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_CardCollections_Collections_PokemonCollectionId",
                table: "CardCollections");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonCollectionId",
                table: "CardCollections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonCardid",
                table: "CardCollections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CardCollections_Cards_PokemonCardid",
                table: "CardCollections",
                column: "PokemonCardid",
                principalTable: "Cards",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardCollections_Collections_PokemonCollectionId",
                table: "CardCollections",
                column: "PokemonCollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardCollections_Cards_PokemonCardid",
                table: "CardCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_CardCollections_Collections_PokemonCollectionId",
                table: "CardCollections");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonCollectionId",
                table: "CardCollections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PokemonCardid",
                table: "CardCollections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardCollections_Cards_PokemonCardid",
                table: "CardCollections",
                column: "PokemonCardid",
                principalTable: "Cards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardCollections_Collections_PokemonCollectionId",
                table: "CardCollections",
                column: "PokemonCollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

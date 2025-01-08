using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections");

            migrationBuilder.DropTable(
                name: "PokemonCardPokemonCollection");

            migrationBuilder.DropIndex(
                name: "IX_Collections_PokemonUserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_CardCollections_PokemonCardid",
                table: "CardCollections");

            migrationBuilder.DropIndex(
                name: "IX_CardCollections_PokemonCollectionId",
                table: "CardCollections");

            migrationBuilder.DropColumn(
                name: "PokemonUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "PokemonCardid",
                table: "CardCollections");

            migrationBuilder.DropColumn(
                name: "PokemonCollectionId",
                table: "CardCollections");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Collections",
                newName: "CollectionId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cards",
                newName: "CardId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CardCollectionPokemonCard",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CardCollectionsCardId = table.Column<int>(type: "int", nullable: false),
                    CardCollectionsCollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCollectionPokemonCard", x => new { x.CardId, x.CardCollectionsCardId, x.CardCollectionsCollectionId });
                    table.ForeignKey(
                        name: "FK_CardCollectionPokemonCard_CardCollections_CardCollectionsCardId_CardCollectionsCollectionId",
                        columns: x => new { x.CardCollectionsCardId, x.CardCollectionsCollectionId },
                        principalTable: "CardCollections",
                        principalColumns: new[] { "CardId", "CollectionId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCollectionPokemonCard_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardCollectionPokemonCollection",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    CardCollectionsCardId = table.Column<int>(type: "int", nullable: false),
                    CardCollectionsCollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCollectionPokemonCollection", x => new { x.CollectionId, x.CardCollectionsCardId, x.CardCollectionsCollectionId });
                    table.ForeignKey(
                        name: "FK_CardCollectionPokemonCollection_CardCollections_CardCollectionsCardId_CardCollectionsCollectionId",
                        columns: x => new { x.CardCollectionsCardId, x.CardCollectionsCollectionId },
                        principalTable: "CardCollections",
                        principalColumns: new[] { "CardId", "CollectionId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCollectionPokemonCollection_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardCollectionPokemonCard_CardCollectionsCardId_CardCollectionsCollectionId",
                table: "CardCollectionPokemonCard",
                columns: new[] { "CardCollectionsCardId", "CardCollectionsCollectionId" });

            migrationBuilder.CreateIndex(
                name: "IX_CardCollectionPokemonCollection_CardCollectionsCardId_CardCollectionsCollectionId",
                table: "CardCollectionPokemonCollection",
                columns: new[] { "CardCollectionsCardId", "CardCollectionsCollectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections");

            migrationBuilder.DropTable(
                name: "CardCollectionPokemonCard");

            migrationBuilder.DropTable(
                name: "CardCollectionPokemonCollection");

            migrationBuilder.DropIndex(
                name: "IX_Collections_UserId",
                table: "Collections");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "Collections",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Collections",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PokemonUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonCardid",
                table: "CardCollections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonCollectionId",
                table: "CardCollections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PokemonCardPokemonCollection",
                columns: table => new
                {
                    Cardsid = table.Column<int>(type: "int", nullable: false),
                    CollectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCardPokemonCollection", x => new { x.Cardsid, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonCollection_Cards_Cardsid",
                        column: x => x.Cardsid,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCardPokemonCollection_Collections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardCollections_PokemonCardid",
                table: "CardCollections",
                column: "PokemonCardid");

            migrationBuilder.CreateIndex(
                name: "IX_CardCollections_PokemonCollectionId",
                table: "CardCollections",
                column: "PokemonCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCardPokemonCollection_CollectionsId",
                table: "PokemonCardPokemonCollection",
                column: "CollectionsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

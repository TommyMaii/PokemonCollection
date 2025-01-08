using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class addedLargeCardUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardUrl",
                table: "Cards",
                newName: "SmallCardUrl");

            migrationBuilder.AddColumn<string>(
                name: "LargeCardUrl",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeCardUrl",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "SmallCardUrl",
                table: "Cards",
                newName: "CardUrl");
        }
    }
}

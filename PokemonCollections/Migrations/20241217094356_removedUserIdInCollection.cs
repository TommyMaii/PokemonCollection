using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class removedUserIdInCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Collections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

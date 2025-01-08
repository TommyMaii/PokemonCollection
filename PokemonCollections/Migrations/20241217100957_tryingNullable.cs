using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class tryingNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections");

            migrationBuilder.AlterColumn<string>(
                name: "PokemonUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections");

            migrationBuilder.AlterColumn<string>(
                name: "PokemonUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

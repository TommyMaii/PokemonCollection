using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonCollections.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_PokemonUser_PokemonUserUserId",
                table: "Collections");

            migrationBuilder.DropTable(
                name: "PokemonUser");

            migrationBuilder.DropIndex(
                name: "IX_Collections_PokemonUserUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "PokemonUserUserId",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "PokemonUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections",
                column: "PokemonUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_PokemonUserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_PokemonUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "PokemonUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Initials",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "PokemonUserUserId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PokemonUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonUser", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_PokemonUserUserId",
                table: "Collections",
                column: "PokemonUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_PokemonUser_PokemonUserUserId",
                table: "Collections",
                column: "PokemonUserUserId",
                principalTable: "PokemonUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

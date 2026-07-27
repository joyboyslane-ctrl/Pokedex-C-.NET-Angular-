using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGermanNamesAndDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlavorText",
                table: "Pokemon",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Generation",
                table: "Pokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameDe",
                table: "Pokemon",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlavorText",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "NameDe",
                table: "Pokemon");
        }
    }
}

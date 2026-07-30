using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEvolvesFromId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvolvesFromId",
                table: "Pokemon",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolvesFromId",
                table: "Pokemon");
        }
    }
}

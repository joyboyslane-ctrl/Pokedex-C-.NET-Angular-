using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixPokeTypeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokeTypes_Pokemon_PokemonId",
                table: "PokeTypes");

            migrationBuilder.DropIndex(
                name: "IX_PokeTypes_PokemonId",
                table: "PokeTypes");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "PokeTypes");

            migrationBuilder.CreateTable(
                name: "PokeTypePokemon",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeTypePokemon", x => new { x.PokemonsId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_PokeTypePokemon_PokeTypes_TypesId",
                        column: x => x.TypesId,
                        principalTable: "PokeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokeTypePokemon_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokeTypePokemon_TypesId",
                table: "PokeTypePokemon",
                column: "TypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokeTypePokemon");

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "PokeTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokeTypes_PokemonId",
                table: "PokeTypes",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokeTypes_Pokemon_PokemonId",
                table: "PokeTypes",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id");
        }
    }
}

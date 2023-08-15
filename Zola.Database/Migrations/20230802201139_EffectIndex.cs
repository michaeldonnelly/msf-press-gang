using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class EffectIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EffectIndices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    EffectId = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterId = table.Column<string>(type: "TEXT", nullable: false),
                    AbilityType = table.Column<int>(type: "INTEGER", nullable: false),
                    AbilityLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectIndices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EffectIndices_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EffectIndices_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EffectIndices_CharacterId",
                table: "EffectIndices",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_EffectIndices_EffectId",
                table: "EffectIndices",
                column: "EffectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EffectIndices");
        }
    }
}

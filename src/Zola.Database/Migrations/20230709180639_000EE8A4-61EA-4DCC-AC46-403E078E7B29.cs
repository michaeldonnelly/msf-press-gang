using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _000EE8A461EA4DCCAC46403E078E7B29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId1",
                table: "GearTier");

            migrationBuilder.DropIndex(
                name: "IX_GearTier_CharacterInfoId1",
                table: "GearTier");

            migrationBuilder.DropColumn(
                name: "CharacterInfoId1",
                table: "GearTier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharacterInfoId1",
                table: "GearTier",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GearTier_CharacterInfoId1",
                table: "GearTier",
                column: "CharacterInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId1",
                table: "GearTier",
                column: "CharacterInfoId1",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}

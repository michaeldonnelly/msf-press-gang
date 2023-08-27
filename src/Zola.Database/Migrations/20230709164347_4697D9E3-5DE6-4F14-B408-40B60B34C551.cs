using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _4697D9E35DE64F14B40840B60B34C551 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CharacterInfoId",
                table: "GearTier",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharacterInfoId1",
                table: "GearTier",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GearTier_CharacterInfoId",
                table: "GearTier",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GearTier_CharacterInfoId1",
                table: "GearTier",
                column: "CharacterInfoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId",
                table: "GearTier",
                column: "CharacterInfoId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId1",
                table: "GearTier",
                column: "CharacterInfoId1",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId",
                table: "GearTier");

            migrationBuilder.DropForeignKey(
                name: "FK_GearTier_Characters_CharacterInfoId1",
                table: "GearTier");

            migrationBuilder.DropIndex(
                name: "IX_GearTier_CharacterInfoId",
                table: "GearTier");

            migrationBuilder.DropIndex(
                name: "IX_GearTier_CharacterInfoId1",
                table: "GearTier");

            migrationBuilder.DropColumn(
                name: "CharacterInfoId",
                table: "GearTier");

            migrationBuilder.DropColumn(
                name: "CharacterInfoId1",
                table: "GearTier");
        }
    }
}

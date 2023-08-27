using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _835DA7CAE70A426D9563F887D871C0FC : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "GearTier",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "GearTier");

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

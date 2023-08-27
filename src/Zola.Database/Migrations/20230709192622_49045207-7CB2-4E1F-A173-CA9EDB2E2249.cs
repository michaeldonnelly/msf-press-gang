using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _490452077CB24E1FA173CA9EDB2E2249 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level1Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level2Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level3Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level4Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level5Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level6Id",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability_AbilityLevel_Level7Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level1Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level2Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level3Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level4Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level5Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level6Id",
                table: "Ability");

            migrationBuilder.DropIndex(
                name: "IX_Ability_Level7Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level1Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level2Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level3Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level4Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level5Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level6Id",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "Level7Id",
                table: "Ability");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level1Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level2Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level3Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level4Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level5Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level6Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level7Id",
                table: "Ability",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level1Id",
                table: "Ability",
                column: "Level1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level2Id",
                table: "Ability",
                column: "Level2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level3Id",
                table: "Ability",
                column: "Level3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level4Id",
                table: "Ability",
                column: "Level4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level5Id",
                table: "Ability",
                column: "Level5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level6Id",
                table: "Ability",
                column: "Level6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_Level7Id",
                table: "Ability",
                column: "Level7Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level1Id",
                table: "Ability",
                column: "Level1Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level2Id",
                table: "Ability",
                column: "Level2Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level3Id",
                table: "Ability",
                column: "Level3Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level4Id",
                table: "Ability",
                column: "Level4Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level5Id",
                table: "Ability",
                column: "Level5Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level6Id",
                table: "Ability",
                column: "Level6Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_AbilityLevel_Level7Id",
                table: "Ability",
                column: "Level7Id",
                principalTable: "AbilityLevel",
                principalColumn: "Id");
        }
    }
}

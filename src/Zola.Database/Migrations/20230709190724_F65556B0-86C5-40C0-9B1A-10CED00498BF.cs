using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class F65556B086C540C09B1A10CED00498BF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbilityId",
                table: "AbilityLevel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AbilityLevel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AbilityLevel_AbilityId",
                table: "AbilityLevel",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbilityLevel_Ability_AbilityId",
                table: "AbilityLevel",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbilityLevel_Ability_AbilityId",
                table: "AbilityLevel");

            migrationBuilder.DropIndex(
                name: "IX_AbilityLevel_AbilityId",
                table: "AbilityLevel");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "AbilityLevel");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AbilityLevel");
        }
    }
}

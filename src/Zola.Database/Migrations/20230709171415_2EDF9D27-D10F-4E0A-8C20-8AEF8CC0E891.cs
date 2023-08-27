using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _2EDF9D27D10F4E0A8C208AEF8CC0E891 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier10Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier11Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier12Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier13Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier14Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier15Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier16Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier17Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier1Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier2Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier3Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier4Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier5Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier6Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier7Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier8Id",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GearTier_GearTier9Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier10Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier11Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier12Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier13Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier14Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier15Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier16Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier17Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier1Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier2Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier3Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier4Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier5Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier6Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier7Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier8Id",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GearTier9Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier10Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier11Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier12Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier13Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier14Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier15Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier16Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier17Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier1Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier2Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier3Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier4Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier5Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier6Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier7Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier8Id",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GearTier9Id",
                table: "Characters");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "GearTier10Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier11Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier12Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier13Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier14Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier15Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier16Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier17Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier1Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier2Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier3Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier4Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier5Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier6Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier7Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier8Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GearTier9Id",
                table: "Characters",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier10Id",
                table: "Characters",
                column: "GearTier10Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier11Id",
                table: "Characters",
                column: "GearTier11Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier12Id",
                table: "Characters",
                column: "GearTier12Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier13Id",
                table: "Characters",
                column: "GearTier13Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier14Id",
                table: "Characters",
                column: "GearTier14Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier15Id",
                table: "Characters",
                column: "GearTier15Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier16Id",
                table: "Characters",
                column: "GearTier16Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier17Id",
                table: "Characters",
                column: "GearTier17Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier1Id",
                table: "Characters",
                column: "GearTier1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier2Id",
                table: "Characters",
                column: "GearTier2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier3Id",
                table: "Characters",
                column: "GearTier3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier4Id",
                table: "Characters",
                column: "GearTier4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier5Id",
                table: "Characters",
                column: "GearTier5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier6Id",
                table: "Characters",
                column: "GearTier6Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier7Id",
                table: "Characters",
                column: "GearTier7Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier8Id",
                table: "Characters",
                column: "GearTier8Id");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GearTier9Id",
                table: "Characters",
                column: "GearTier9Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier10Id",
                table: "Characters",
                column: "GearTier10Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier11Id",
                table: "Characters",
                column: "GearTier11Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier12Id",
                table: "Characters",
                column: "GearTier12Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier13Id",
                table: "Characters",
                column: "GearTier13Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier14Id",
                table: "Characters",
                column: "GearTier14Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier15Id",
                table: "Characters",
                column: "GearTier15Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier16Id",
                table: "Characters",
                column: "GearTier16Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier17Id",
                table: "Characters",
                column: "GearTier17Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier1Id",
                table: "Characters",
                column: "GearTier1Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier2Id",
                table: "Characters",
                column: "GearTier2Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier3Id",
                table: "Characters",
                column: "GearTier3Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier4Id",
                table: "Characters",
                column: "GearTier4Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier5Id",
                table: "Characters",
                column: "GearTier5Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier6Id",
                table: "Characters",
                column: "GearTier6Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier7Id",
                table: "Characters",
                column: "GearTier7Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier8Id",
                table: "Characters",
                column: "GearTier8Id",
                principalTable: "GearTier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GearTier_GearTier9Id",
                table: "Characters",
                column: "GearTier9Id",
                principalTable: "GearTier",
                principalColumn: "Id");
        }
    }
}

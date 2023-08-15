using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class DE72A787B7D24B1AAA09907771EE1CA3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: true),
                    Armor = table.Column<int>(type: "INTEGER", nullable: true),
                    BlockAmount = table.Column<int>(type: "INTEGER", nullable: true),
                    BlockChance = table.Column<int>(type: "INTEGER", nullable: true),
                    CritChance = table.Column<int>(type: "INTEGER", nullable: true),
                    CritDamageBonus = table.Column<int>(type: "INTEGER", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: true),
                    DamageReduction = table.Column<int>(type: "INTEGER", nullable: true),
                    DodgeChance = table.Column<int>(type: "INTEGER", nullable: true),
                    ExtraHeal = table.Column<int>(type: "INTEGER", nullable: true),
                    Focus = table.Column<int>(type: "INTEGER", nullable: true),
                    Health = table.Column<int>(type: "INTEGER", nullable: true),
                    Resist = table.Column<int>(type: "INTEGER", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearTier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    StatsId = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterInfoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearTier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearTier_Characters_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GearTier_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemMember1",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FullArt = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    IsCalendar = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsOrb = table.Column<bool>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NoDeco = table.Column<bool>(type: "INTEGER", nullable: true),
                    NoInv = table.Column<bool>(type: "INTEGER", nullable: true),
                    ShopArt = table.Column<string>(type: "TEXT", nullable: true),
                    StatsId = table.Column<string>(type: "TEXT", nullable: true),
                    Tier = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMember1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMember1_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ItemMember1Id = table.Column<string>(type: "TEXT", nullable: true),
                    SerializationHint = table.Column<string>(type: "TEXT", nullable: true),
                    String = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemMember1_ItemMember1Id",
                        column: x => x.ItemMember1Id,
                        principalTable: "ItemMember1",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GearSlot",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: true),
                    PieceId = table.Column<string>(type: "TEXT", nullable: true),
                    GearTierId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GearSlot_GearTier_GearTierId",
                        column: x => x.GearTierId,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GearSlot_Item_PieceId",
                        column: x => x.PieceId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GearSlot_GearTierId",
                table: "GearSlot",
                column: "GearTierId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSlot_PieceId",
                table: "GearSlot",
                column: "PieceId");

            migrationBuilder.CreateIndex(
                name: "IX_GearTier_CharacterInfoId",
                table: "GearTier",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GearTier_StatsId",
                table: "GearTier",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemMember1Id",
                table: "Item",
                column: "ItemMember1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMember1_StatsId",
                table: "ItemMember1",
                column: "StatsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GearSlot");

            migrationBuilder.DropTable(
                name: "GearTier");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemMember1");

            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}

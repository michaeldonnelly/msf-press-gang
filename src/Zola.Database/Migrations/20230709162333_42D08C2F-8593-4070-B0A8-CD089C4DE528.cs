using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zola.Database.Migrations
{
    /// <inheritdoc />
    public partial class _42D08C2F85934070B0A8CD089C4DE528 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityLevel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CostEnergy = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    NextUpgrade = table.Column<string>(type: "TEXT", nullable: true),
                    StartEnergy = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityLevel", x => x.Id);
                });

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
                name: "Traits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    IconList = table.Column<string>(type: "TEXT", nullable: false),
                    Level1Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level2Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level3Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level4Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level5Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level6Id = table.Column<string>(type: "TEXT", nullable: true),
                    Level7Id = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level1Id",
                        column: x => x.Level1Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level2Id",
                        column: x => x.Level2Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level3Id",
                        column: x => x.Level3Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level4Id",
                        column: x => x.Level4Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level5Id",
                        column: x => x.Level5Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level6Id",
                        column: x => x.Level6Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ability_AbilityLevel_Level7Id",
                        column: x => x.Level7Id,
                        principalTable: "AbilityLevel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GearTier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    StatsId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearTier", x => x.Id);
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
                name: "AbilityKit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    BasicId = table.Column<string>(type: "TEXT", nullable: true),
                    PassiveId = table.Column<string>(type: "TEXT", nullable: true),
                    SpecialId = table.Column<string>(type: "TEXT", nullable: true),
                    UltimateId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityKit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityKit_Ability_BasicId",
                        column: x => x.BasicId,
                        principalTable: "Ability",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilityKit_Ability_PassiveId",
                        column: x => x.PassiveId,
                        principalTable: "Ability",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilityKit_Ability_SpecialId",
                        column: x => x.SpecialId,
                        principalTable: "Ability",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbilityKit_Ability_UltimateId",
                        column: x => x.UltimateId,
                        principalTable: "Ability",
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
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Portrait = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UnlockStars = table.Column<int>(type: "INTEGER", nullable: true),
                    AbilityKitId = table.Column<string>(type: "TEXT", nullable: true),
                    EmpoweredAbilityKitId = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier1Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier2Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier3Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier4Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier5Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier6Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier7Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier8Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier9Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier10Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier11Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier12Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier13Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier14Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier15Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier16Id = table.Column<string>(type: "TEXT", nullable: true),
                    GearTier17Id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_AbilityKit_AbilityKitId",
                        column: x => x.AbilityKitId,
                        principalTable: "AbilityKit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_AbilityKit_EmpoweredAbilityKitId",
                        column: x => x.EmpoweredAbilityKitId,
                        principalTable: "AbilityKit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier10Id",
                        column: x => x.GearTier10Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier11Id",
                        column: x => x.GearTier11Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier12Id",
                        column: x => x.GearTier12Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier13Id",
                        column: x => x.GearTier13Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier14Id",
                        column: x => x.GearTier14Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier15Id",
                        column: x => x.GearTier15Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier16Id",
                        column: x => x.GearTier16Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier17Id",
                        column: x => x.GearTier17Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier1Id",
                        column: x => x.GearTier1Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier2Id",
                        column: x => x.GearTier2Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier3Id",
                        column: x => x.GearTier3Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier4Id",
                        column: x => x.GearTier4Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier5Id",
                        column: x => x.GearTier5Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier6Id",
                        column: x => x.GearTier6Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier7Id",
                        column: x => x.GearTier7Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier8Id",
                        column: x => x.GearTier8Id,
                        principalTable: "GearTier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_GearTier_GearTier9Id",
                        column: x => x.GearTier9Id,
                        principalTable: "GearTier",
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

            migrationBuilder.CreateTable(
                name: "CharacterInfoTrait",
                columns: table => new
                {
                    CharactersId = table.Column<string>(type: "TEXT", nullable: false),
                    TraitsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInfoTrait", x => new { x.CharactersId, x.TraitsId });
                    table.ForeignKey(
                        name: "FK_CharacterInfoTrait_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterInfoTrait_Traits_TraitsId",
                        column: x => x.TraitsId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AbilityKit_BasicId",
                table: "AbilityKit",
                column: "BasicId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityKit_PassiveId",
                table: "AbilityKit",
                column: "PassiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityKit_SpecialId",
                table: "AbilityKit",
                column: "SpecialId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityKit_UltimateId",
                table: "AbilityKit",
                column: "UltimateId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInfoTrait_TraitsId",
                table: "CharacterInfoTrait",
                column: "TraitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AbilityKitId",
                table: "Characters",
                column: "AbilityKitId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EmpoweredAbilityKitId",
                table: "Characters",
                column: "EmpoweredAbilityKitId");

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

            migrationBuilder.CreateIndex(
                name: "IX_GearSlot_GearTierId",
                table: "GearSlot",
                column: "GearTierId");

            migrationBuilder.CreateIndex(
                name: "IX_GearSlot_PieceId",
                table: "GearSlot",
                column: "PieceId");

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
                name: "CharacterInfoTrait");

            migrationBuilder.DropTable(
                name: "GearSlot");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "AbilityKit");

            migrationBuilder.DropTable(
                name: "GearTier");

            migrationBuilder.DropTable(
                name: "ItemMember1");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "AbilityLevel");
        }
    }
}

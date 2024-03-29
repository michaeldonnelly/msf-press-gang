﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zola.Database;

#nullable disable

namespace Zola.Database.Migrations
{
    [DbContext(typeof(MsfDbContext))]
    [Migration("20230709210919_40813AE0-C71B-42EE-9564-4BE111FD5830")]
    partial class _40813AE0C71B42EE95644BE111FD5830
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("CharacterInfoTrait", b =>
                {
                    b.Property<string>("CharactersId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TraitsId")
                        .HasColumnType("TEXT");

                    b.HasKey("CharactersId", "TraitsId");

                    b.HasIndex("TraitsId");

                    b.ToTable("CharacterInfoTrait");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Ability", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<string>("IconList")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.AbilityKit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("BasicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassiveId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UltimateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BasicId");

                    b.HasIndex("PassiveId");

                    b.HasIndex("SpecialId");

                    b.HasIndex("UltimateId");

                    b.ToTable("AbilityKit");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.AbilityLevel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AbilityId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CostEnergy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NextUpgrade")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StartEnergy")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.ToTable("AbilityLevel");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.CharacterInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AbilityKitId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmpoweredAbilityKitId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Portrait")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UnlockStars")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AbilityKitId");

                    b.HasIndex("EmpoweredAbilityKitId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.GearSlot", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("GearTierId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PieceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GearTierId");

                    b.HasIndex("PieceId");

                    b.ToTable("GearSlot");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.GearTier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharacterInfoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StatsId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterInfoId");

                    b.HasIndex("StatsId");

                    b.ToTable("GearTier");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemMember1Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerializationHint")
                        .HasColumnType("TEXT");

                    b.Property<string>("String")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemMember1Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.ItemMember1", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CharacterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullArt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsCalendar")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsOrb")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("NoDeco")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("NoInv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShopArt")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatsId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Tier")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

                    b.ToTable("ItemMember1");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Stats", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Accuracy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Armor")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BlockAmount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BlockChance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CritChance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CritDamageBonus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DamageReduction")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DodgeChance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExtraHeal")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Focus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Resist")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Trait", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Traits");
                });

            modelBuilder.Entity("CharacterInfoTrait", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.CharacterInfo", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zola.MsfClient.Models.Trait", null)
                        .WithMany()
                        .HasForeignKey("TraitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zola.MsfClient.Models.AbilityKit", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.Ability", "Basic")
                        .WithMany()
                        .HasForeignKey("BasicId");

                    b.HasOne("Zola.MsfClient.Models.Ability", "Passive")
                        .WithMany()
                        .HasForeignKey("PassiveId");

                    b.HasOne("Zola.MsfClient.Models.Ability", "Special")
                        .WithMany()
                        .HasForeignKey("SpecialId");

                    b.HasOne("Zola.MsfClient.Models.Ability", "Ultimate")
                        .WithMany()
                        .HasForeignKey("UltimateId");

                    b.Navigation("Basic");

                    b.Navigation("Passive");

                    b.Navigation("Special");

                    b.Navigation("Ultimate");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.AbilityLevel", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.Ability", null)
                        .WithMany("AbilityLevelCollection")
                        .HasForeignKey("AbilityId");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.CharacterInfo", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.AbilityKit", "AbilityKit")
                        .WithMany()
                        .HasForeignKey("AbilityKitId");

                    b.HasOne("Zola.MsfClient.Models.AbilityKit", "EmpoweredAbilityKit")
                        .WithMany()
                        .HasForeignKey("EmpoweredAbilityKitId");

                    b.Navigation("AbilityKit");

                    b.Navigation("EmpoweredAbilityKit");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.GearSlot", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.GearTier", null)
                        .WithMany("Slots")
                        .HasForeignKey("GearTierId");

                    b.HasOne("Zola.MsfClient.Models.Item", "Piece")
                        .WithMany()
                        .HasForeignKey("PieceId");

                    b.Navigation("Piece");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.GearTier", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.CharacterInfo", null)
                        .WithMany("GearTierCollection")
                        .HasForeignKey("CharacterInfoId");

                    b.HasOne("Zola.MsfClient.Models.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Item", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.ItemMember1", "ItemMember1")
                        .WithMany()
                        .HasForeignKey("ItemMember1Id");

                    b.Navigation("ItemMember1");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.ItemMember1", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.Ability", b =>
                {
                    b.Navigation("AbilityLevelCollection");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.CharacterInfo", b =>
                {
                    b.Navigation("GearTierCollection");
                });

            modelBuilder.Entity("Zola.MsfClient.Models.GearTier", b =>
                {
                    b.Navigation("Slots");
                });
#pragma warning restore 612, 618
        }
    }
}

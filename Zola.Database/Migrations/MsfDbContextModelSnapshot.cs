﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zola.Database;

#nullable disable

namespace Zola.Database.Migrations
{
    [DbContext(typeof(MsfDbContext))]
    partial class MsfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Zola.Database.Models.Effect", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Effects");
                });

            modelBuilder.Entity("Zola.Database.Models.EffectIndex", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AbilityLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbilityType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CharacterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EffectId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("EffectId");

                    b.ToTable("EffectIndices");
                });

            modelBuilder.Entity("Zola.Database.Models.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("State");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Zola.Database.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccessToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AccessTokenExpiration")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MsfPid")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiscordId")
                        .IsUnique();

                    b.ToTable("Users");
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

            modelBuilder.Entity("Zola.Database.Models.EffectIndex", b =>
                {
                    b.HasOne("Zola.MsfClient.Models.CharacterInfo", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zola.Database.Models.Effect", "Effect")
                        .WithMany()
                        .HasForeignKey("EffectId");

                    b.Navigation("Character");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("Zola.Database.Models.Ticket", b =>
                {
                    b.HasOne("Zola.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
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

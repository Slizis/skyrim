﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20221215164456_Pokaifu")]
    partial class Pokaifu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defecne")
                        .HasColumnType("int");

                    b.Property<int?>("EnchantmentId")
                        .HasColumnType("int");

                    b.Property<int>("Enchantment_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnchantmentId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("WebApplication1.Biom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biom_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weather")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bioms");
                });

            modelBuilder.Entity("WebApplication1.Enchantment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Ench_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnchantmentId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnchantmentId");

                    b.ToTable("Enchantments");
                });

            modelBuilder.Entity("WebApplication1.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Quest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApplication1.NPC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BiomId")
                        .HasColumnType("int");

                    b.Property<int>("Biom_Id")
                        .HasColumnType("int");

                    b.Property<string>("Fraction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("MP")
                        .HasColumnType("int");

                    b.Property<int?>("NPCId")
                        .HasColumnType("int");

                    b.Property<string>("NPC_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BiomId");

                    b.HasIndex("NPCId");

                    b.ToTable("NPCs");
                });

            modelBuilder.Entity("WebApplication1.Perks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<int>("access_lvl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Perks");
                });

            modelBuilder.Entity("WebApplication1.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BiomId")
                        .HasColumnType("int");

                    b.Property<int>("Biom_Id")
                        .HasColumnType("int");

                    b.Property<string>("Effect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BiomId");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("WebApplication1.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WebApplication1.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NPCId")
                        .HasColumnType("int");

                    b.Property<int>("NPC_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<string>("Receving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recewing")
                        .HasColumnType("int");

                    b.Property<int>("acess_lvl")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NPCId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("WebApplication1.Scream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<string>("Type_Scream")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Screams");
                });

            modelBuilder.Entity("WebApplication1.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MP_cost")
                        .HasColumnType("int");

                    b.Property<int?>("NPCId")
                        .HasColumnType("int");

                    b.Property<int>("NPC_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<string>("Spell_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NPCId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Spells");
                });

            modelBuilder.Entity("WebApplication1.Talent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<string>("Talent_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Talent_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Talents");
                });

            modelBuilder.Entity("WebApplication1.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EnchantmentId")
                        .HasColumnType("int");

                    b.Property<int>("Enchantment_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<string>("Weapon_class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnchantmentId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("WebApplication1.Armor", b =>
                {
                    b.HasOne("WebApplication1.Enchantment", "Enchantment")
                        .WithMany()
                        .HasForeignKey("EnchantmentId");

                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Armors")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Enchantment");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Enchantment", b =>
                {
                    b.HasOne("WebApplication1.Enchantment", null)
                        .WithMany("Enchantments")
                        .HasForeignKey("EnchantmentId");
                });

            modelBuilder.Entity("WebApplication1.Item", b =>
                {
                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Items")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.NPC", b =>
                {
                    b.HasOne("WebApplication1.Biom", "Biom")
                        .WithMany("NPCs")
                        .HasForeignKey("BiomId");

                    b.HasOne("WebApplication1.NPC", null)
                        .WithMany("NPCs")
                        .HasForeignKey("NPCId");

                    b.Navigation("Biom");
                });

            modelBuilder.Entity("WebApplication1.Perks", b =>
                {
                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Perks")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Plant", b =>
                {
                    b.HasOne("WebApplication1.Biom", "Biom")
                        .WithMany("Plants")
                        .HasForeignKey("BiomId");

                    b.Navigation("Biom");
                });

            modelBuilder.Entity("WebApplication1.Quest", b =>
                {
                    b.HasOne("WebApplication1.NPC", "NPC")
                        .WithMany()
                        .HasForeignKey("NPCId");

                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Quests")
                        .HasForeignKey("PlayerId");

                    b.Navigation("NPC");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Scream", b =>
                {
                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Screams")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Spell", b =>
                {
                    b.HasOne("WebApplication1.NPC", "NPC")
                        .WithMany()
                        .HasForeignKey("NPCId");

                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Spells")
                        .HasForeignKey("PlayerId");

                    b.Navigation("NPC");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Talent", b =>
                {
                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Talents")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Weapon", b =>
                {
                    b.HasOne("WebApplication1.Enchantment", "Enchantment")
                        .WithMany()
                        .HasForeignKey("EnchantmentId");

                    b.HasOne("WebApplication1.Player", "Player")
                        .WithMany("Weapons")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Enchantment");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Biom", b =>
                {
                    b.Navigation("NPCs");

                    b.Navigation("Plants");
                });

            modelBuilder.Entity("WebApplication1.Enchantment", b =>
                {
                    b.Navigation("Enchantments");
                });

            modelBuilder.Entity("WebApplication1.NPC", b =>
                {
                    b.Navigation("NPCs");
                });

            modelBuilder.Entity("WebApplication1.Player", b =>
                {
                    b.Navigation("Armors");

                    b.Navigation("Items");

                    b.Navigation("Perks");

                    b.Navigation("Quests");

                    b.Navigation("Screams");

                    b.Navigation("Spells");

                    b.Navigation("Talents");

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
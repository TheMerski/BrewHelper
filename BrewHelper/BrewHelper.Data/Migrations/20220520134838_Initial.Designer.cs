﻿// <auto-generated />
using System;
using BrewHelper.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrewHelper.Data.Migrations
{
    [DbContext(typeof(BrewhelperContext))]
    [Migration("20220520134838_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrewHelper.Data.Entities.Fermentable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Color")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StockAmount")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<double>("Yield")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Fermentables");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Hop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Alpha")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StockAmount")
                        .HasColumnType("bigint");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hops");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Misc", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Use")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Miscs");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("BatchSize")
                        .HasColumnType("float");

                    b.Property<double>("BoilSize")
                        .HasColumnType("float");

                    b.Property<double>("BoilTime")
                        .HasColumnType("float");

                    b.Property<string>("Brewer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Water", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Bicarbonate")
                        .HasColumnType("float");

                    b.Property<double>("Calcium")
                        .HasColumnType("float");

                    b.Property<double>("Chloride")
                        .HasColumnType("float");

                    b.Property<double>("Magnesium")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Sodium")
                        .HasColumnType("float");

                    b.Property<double>("Sulfate")
                        .HasColumnType("float");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Waters");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Yeast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Form")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Yeasts");
                });

            modelBuilder.Entity("BrewHelper.Data.Entities.Recipe", b =>
                {
                    b.OwnsMany("BrewHelper.Data.Entities.HopIngredient", "Hops", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Time")
                                .HasColumnType("float");

                            b1.Property<int>("Use")
                                .HasColumnType("int");

                            b1.HasKey("RecipeId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("HopIngredient");

                            b1.HasOne("BrewHelper.Data.Entities.Hop", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.Navigation("Ingredient");
                        });

                    b.OwnsOne("BrewHelper.Data.Entities.Mash", "Mash", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<double>("GrainTemp")
                                .HasColumnType("float");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Notes")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Version")
                                .HasColumnType("int");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.OwnsMany("BrewHelper.Data.Entities.MashStep", "MashSteps", b2 =>
                                {
                                    b2.Property<long>("MashRecipeId")
                                        .HasColumnType("bigint");

                                    b2.Property<long>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<long>("Id"), 1L, 1);

                                    b2.Property<double?>("InfuseAmount")
                                        .HasColumnType("float");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Notes")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<double>("StepTemp")
                                        .HasColumnType("float");

                                    b2.Property<int>("StepTime")
                                        .HasColumnType("int");

                                    b2.Property<int>("Type")
                                        .HasColumnType("int");

                                    b2.Property<int>("Version")
                                        .HasColumnType("int");

                                    b2.HasKey("MashRecipeId", "Id");

                                    b2.ToTable("MashStep");

                                    b2.WithOwner()
                                        .HasForeignKey("MashRecipeId");
                                });

                            b1.Navigation("MashSteps");
                        });

                    b.OwnsMany("BrewHelper.Data.Entities.RecipeIngredient<BrewHelper.Data.Entities.Fermentable>", "Fermentables", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Time")
                                .HasColumnType("float");

                            b1.HasKey("RecipeId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("RecipeIngredient<Fermentable>");

                            b1.HasOne("BrewHelper.Data.Entities.Fermentable", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.Navigation("Ingredient");
                        });

                    b.OwnsMany("BrewHelper.Data.Entities.RecipeIngredient<BrewHelper.Data.Entities.Misc>", "Miscs", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Time")
                                .HasColumnType("float");

                            b1.HasKey("RecipeId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("RecipeIngredient<Misc>");

                            b1.HasOne("BrewHelper.Data.Entities.Misc", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.Navigation("Ingredient");
                        });

                    b.OwnsMany("BrewHelper.Data.Entities.RecipeIngredient<BrewHelper.Data.Entities.Water>", "Waters", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Time")
                                .HasColumnType("float");

                            b1.HasKey("RecipeId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("RecipeIngredient<Water>");

                            b1.HasOne("BrewHelper.Data.Entities.Water", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.Navigation("Ingredient");
                        });

                    b.OwnsMany("BrewHelper.Data.Entities.RecipeIngredient<BrewHelper.Data.Entities.Yeast>", "Yeasts", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Time")
                                .HasColumnType("float");

                            b1.HasKey("RecipeId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("RecipeIngredient<Yeast>");

                            b1.HasOne("BrewHelper.Data.Entities.Yeast", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.Navigation("Ingredient");
                        });

                    b.OwnsOne("BrewHelper.Data.Entities.Style", "Style", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Category")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CategoryNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("ColorMax")
                                .HasColumnType("float");

                            b1.Property<double>("ColorMin")
                                .HasColumnType("float");

                            b1.Property<double>("IBU_Max")
                                .HasColumnType("float");

                            b1.Property<double>("IBU_Min")
                                .HasColumnType("float");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Notes")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<double>("OG_Max")
                                .HasColumnType("float");

                            b1.Property<double>("OG_Min")
                                .HasColumnType("float");

                            b1.Property<string>("StyleGuide")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StyleLetter")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Type")
                                .HasColumnType("int");

                            b1.Property<int>("Version")
                                .HasColumnType("int");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Styles");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.Navigation("Fermentables");

                    b.Navigation("Hops");

                    b.Navigation("Mash")
                        .IsRequired();

                    b.Navigation("Miscs");

                    b.Navigation("Style")
                        .IsRequired();

                    b.Navigation("Waters");

                    b.Navigation("Yeasts");
                });
#pragma warning restore 612, 618
        }
    }
}

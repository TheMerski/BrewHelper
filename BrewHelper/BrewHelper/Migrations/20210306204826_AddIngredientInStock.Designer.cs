﻿// <auto-generated />
using System;
using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrewHelper.Migrations
{
    [DbContext(typeof(BrewhelperContext))]
    [Migration("20210306204826_AddIngredientInStock")]
    partial class AddIngredientInStock
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrewHelper.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InStock")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("BrewHelper.Models.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlcoholPercentage")
                        .HasColumnType("float");

                    b.Property<long?>("BoilingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EBC")
                        .HasColumnType("float");

                    b.Property<int>("EndSG")
                        .HasColumnType("int");

                    b.Property<double>("IBU")
                        .HasColumnType("float");

                    b.Property<double>("MashWater")
                        .HasColumnType("float");

                    b.Property<long?>("MashingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReadyAfter")
                        .HasColumnType("bigint");

                    b.Property<double>("RinseWater")
                        .HasColumnType("float");

                    b.Property<int>("StartSG")
                        .HasColumnType("int");

                    b.Property<long?>("YeastingId")
                        .HasColumnType("bigint");

                    b.Property<int>("Yield")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoilingId");

                    b.HasIndex("MashingId");

                    b.HasIndex("YeastingId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("BrewHelper.Models.RecipeStep", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Temperature")
                        .HasColumnType("float");

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("BrewHelper.Models.Recipe", b =>
                {
                    b.HasOne("BrewHelper.Models.RecipeStep", "Boiling")
                        .WithMany()
                        .HasForeignKey("BoilingId");

                    b.HasOne("BrewHelper.Models.RecipeStep", "Mashing")
                        .WithMany()
                        .HasForeignKey("MashingId");

                    b.HasOne("BrewHelper.Models.RecipeStep", "Yeasting")
                        .WithMany()
                        .HasForeignKey("YeastingId");

                    b.Navigation("Boiling");

                    b.Navigation("Mashing");

                    b.Navigation("Yeasting");
                });

            modelBuilder.Entity("BrewHelper.Models.RecipeStep", b =>
                {
                    b.OwnsMany("BrewHelper.Models.RecipeIngredient", "Ingredients", b1 =>
                        {
                            b1.Property<long>("RecipeStepId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("AddAfter")
                                .HasColumnType("bigint");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Weight")
                                .HasColumnType("int");

                            b1.HasKey("RecipeStepId", "Id");

                            b1.HasIndex("IngredientId");

                            b1.ToTable("RecipeIngredient");

                            b1.HasOne("BrewHelper.Models.Ingredient", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("RecipeStepId");

                            b1.Navigation("Ingredient");
                        });

                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
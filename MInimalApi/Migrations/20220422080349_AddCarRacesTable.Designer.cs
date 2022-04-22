﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MInimalApi.Migrations
{
    [DbContext(typeof(RaceDb))]
    [Migration("20220422080349_AddCarRacesTable")]
    partial class AddCarRacesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarRaceId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceCoverdInMiles")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedRace")
                        .HasColumnType("bit");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int>("RacedForHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarRaceId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarRaces");
                });

            modelBuilder.Entity("Motorbike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DistanceCoverdInMiles")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedRace")
                        .HasColumnType("bit");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int>("RacedForHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motorbikes");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.HasOne("CarRace", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarRaceId");
                });

            modelBuilder.Entity("CarRace", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}

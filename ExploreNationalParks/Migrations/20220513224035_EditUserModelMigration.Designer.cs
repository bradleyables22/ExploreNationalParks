﻿// <auto-generated />
using ExploreNationalParks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExploreNationalParks.Migrations
{
    [DbContext(typeof(NationalParkDBContext))]
    [Migration("20220513224035_EditUserModelMigration")]
    partial class EditUserModelMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ExploreNationalParks.NationalPark", b =>
                {
                    b.Property<int>("ParkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Acres")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateEstablished")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Km2")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("NpsLink")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Visitors")
                        .HasColumnType("TEXT");

                    b.HasKey("ParkID");

                    b.ToTable("nationalParks");
                });

            modelBuilder.Entity("ExploreNationalParks.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateCreated")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petshop.Api.Persistence;

namespace Petshop.Api.Persistence.Migrations
{
    [DbContext(typeof(PetshopDbContext))]
    [Migration("20210228181246_SecaMigrations")]
    partial class SecaMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Petshop.Api.Entities.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccommodationStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Petshop.Api.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GuardianAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuardianPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HealthCondition")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonHospitalization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Petshop.Api.Entities.Accommodation", b =>
                {
                    b.HasOne("Petshop.Api.Entities.Animal", "Animal")
                        .WithOne("Accommodation")
                        .HasForeignKey("Petshop.Api.Entities.Accommodation", "AnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

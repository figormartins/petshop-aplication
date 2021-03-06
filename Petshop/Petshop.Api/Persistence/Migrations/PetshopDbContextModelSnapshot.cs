﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Petshop.Api.Persistence;

namespace Petshop.Api.Persistence.Migrations
{
    [DbContext(typeof(PetshopDbContext))]
    partial class PetshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Petshop.Api.Entities.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccommodationStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Petshop.Api.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccommodationId")
                        .HasColumnType("uuid");

                    b.Property<string>("GuardianAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuardianName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GuardianPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HealthCondition")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReasonHospitalization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId")
                        .IsUnique();

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Petshop.Api.Entities.Animal", b =>
                {
                    b.HasOne("Petshop.Api.Entities.Accommodation", "Accommodation")
                        .WithOne("Animal")
                        .HasForeignKey("Petshop.Api.Entities.Animal", "AccommodationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

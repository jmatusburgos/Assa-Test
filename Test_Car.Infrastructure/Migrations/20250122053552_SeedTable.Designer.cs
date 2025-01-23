﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Test_Car.Infrastructure.Context;

#nullable disable

namespace Test_Car.Infrastructure.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20250122053552_SeedTable")]
    partial class SeedTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Test_Car.Domain.Models.Car.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MarcasAutos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "system",
                            CreatedDate = new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Local).AddTicks(5811),
                            Description = "Toyota Motor Corporation",
                            ModifiedBy = "",
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "system",
                            CreatedDate = new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Local).AddTicks(5811),
                            Description = "Nissan Motor Corporation",
                            ModifiedBy = "",
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "system",
                            CreatedDate = new DateTime(2025, 1, 21, 23, 35, 51, 508, DateTimeKind.Local).AddTicks(5811),
                            Description = "Bayerische Motoren Werke GmbH",
                            ModifiedBy = "",
                            Name = "BMW"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

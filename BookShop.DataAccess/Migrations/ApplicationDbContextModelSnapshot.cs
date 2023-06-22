﻿// <auto-generated />
using System;
using BookShop.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookShop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8459),
                            DisplayOrder = 1,
                            Name = "helu"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8485),
                            DisplayOrder = 1,
                            Name = "helu"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8487),
                            DisplayOrder = 1,
                            Name = "helu"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8489),
                            DisplayOrder = 1,
                            Name = "helu"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8490),
                            DisplayOrder = 1,
                            Name = "helu"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDateTime = new DateTime(2023, 6, 20, 20, 21, 33, 861, DateTimeKind.Local).AddTicks(8492),
                            DisplayOrder = 1,
                            Name = "helu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
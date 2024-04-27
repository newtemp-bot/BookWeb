﻿// <auto-generated />
using BookWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240425165632_Dataseeding")]
    partial class Dataseeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookWeb.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatId"));

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DispalyOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            CatName = "Drama",
                            DispalyOrder = "1"
                        },
                        new
                        {
                            CatId = 2,
                            CatName = "Action",
                            DispalyOrder = "2"
                        },
                        new
                        {
                            CatId = 3,
                            CatName = "Sci-fi",
                            DispalyOrder = "3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

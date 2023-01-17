﻿// <auto-generated />
using System;
using LaMiaPizzeriaEfPost.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaMiaPizzeriaEfPost.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20230117151846_UpgradeDb")]
    partial class UpgradeDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LaMiaPizzeriaEfPost.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LaMiaPizzeriaEfPost.Models.Pizza", b =>
                {
                    b.Property<string>("nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("descrizione")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("foto")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<double>("prezzo")
                        .HasColumnType("float");

                    b.HasKey("nome");

                    b.HasIndex("categoryId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("LaMiaPizzeriaEfPost.Models.Pizza", b =>
                {
                    b.HasOne("LaMiaPizzeriaEfPost.Models.Category", "category")
                        .WithMany("Pizzas")
                        .HasForeignKey("categoryId");

                    b.Navigation("category");
                });

            modelBuilder.Entity("LaMiaPizzeriaEfPost.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyMon_Blazor.Data;
using MonkeyMon_Blazor.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MonkeyMon_Blazor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241106101950_Monkeys")]
    partial class Monkeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MonkeyMon_Blazor.Data.Models.Monkey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Attack")
                        .HasColumnType("integer");

                    b.Property<int?>("Defense")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("HealthPoints")
                        .HasColumnType("integer");

                    b.Property<string>("KnownFrom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SpecialAttack")
                        .HasColumnType("integer");

                    b.Property<int?>("SpecialDefense")
                        .HasColumnType("integer");

                    b.Property<string>("Weaknesses")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Monkeys");
                });
#pragma warning restore 612, 618
        }
    }
}
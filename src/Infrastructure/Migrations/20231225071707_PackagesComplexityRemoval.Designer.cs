﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231225071707_PackagesComplexityRemoval")]
    partial class PackagesComplexityRemoval
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Domain.Entities.Food.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("GUID");

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("DATE");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPerishable")
                        .HasColumnType("BOOL");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Food", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Package.PackageReceived", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("GUID");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("GUID");

                    b.Property<string>("FoodList")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PackageCreation")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("PackageReceived", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Package.PackageSent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("GUID");

                    b.Property<string>("FoodList")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PackageCreation")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("GUID");

                    b.HasKey("Id");

                    b.ToTable("PackageSent", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ThirdPartyRegister.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("GUID");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("BOOL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Donor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ThirdPartyRegister.Receiver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("GUID");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("BOOL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Receiver", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

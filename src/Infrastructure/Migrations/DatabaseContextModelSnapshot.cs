﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Domain.Entities.ThirdPartyRegister.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("GUID");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("BOOL")
                        .HasColumnName("IsCompany");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Donor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ThirdPartyRegister.Receiver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("GUID");

                    b.Property<bool>("IsCompany")
                        .HasColumnType("BOOL")
                        .HasColumnName("IsCompany");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Receiver", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

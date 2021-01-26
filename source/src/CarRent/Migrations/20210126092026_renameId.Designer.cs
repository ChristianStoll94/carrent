﻿// <auto-generated />
using CarRent.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRent.Migrations
{
    [DbContext(typeof(carrentContext))]
    [Migration("20210126092026_renameId")]
    partial class renameId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarRent.CustomerManagement.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
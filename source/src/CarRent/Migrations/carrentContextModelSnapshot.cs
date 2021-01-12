﻿// <auto-generated />
using CarRent.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRent.Migrations
{
    [DbContext(typeof(carrentContext))]
    partial class carrentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarRent.CustomerManagement.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Adress")
                        .HasColumnName("adress")
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

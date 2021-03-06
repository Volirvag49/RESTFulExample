﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RESTFulExample.DAL.EF;
using RESTFulExample.DAL.Entities;
using System;

namespace RESTFulExample.DAL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20180113220653_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Air", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("TravellerId");

                    b.HasKey("Id");

                    b.HasIndex("TravellerId");

                    b.ToTable("Airs");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Cart", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Employee", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Hotel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Checkin");

                    b.Property<DateTime>("Checkout");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Provider")
                        .IsRequired();

                    b.Property<int?>("TravellerId");

                    b.HasKey("Id");

                    b.HasIndex("TravellerId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Order", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CartId")
                        .IsRequired();

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("ServiceTipe");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Train", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<string>("ArrivalStation")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("DepartureDate");

                    b.Property<string>("DepartureStation")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Provider")
                        .IsRequired();

                    b.Property<int?>("TravellerId");

                    b.HasKey("Id");

                    b.HasIndex("TravellerId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Air", b =>
                {
                    b.HasOne("RESTFulExample.DAL.Entities.Employee", "Traveller")
                        .WithMany("Airs")
                        .HasForeignKey("TravellerId");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Cart", b =>
                {
                    b.HasOne("RESTFulExample.DAL.Entities.Employee", "Employee")
                        .WithOne("Cart")
                        .HasForeignKey("RESTFulExample.DAL.Entities.Cart", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Hotel", b =>
                {
                    b.HasOne("RESTFulExample.DAL.Entities.Employee", "Traveller")
                        .WithMany("Hotels")
                        .HasForeignKey("TravellerId");
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Order", b =>
                {
                    b.HasOne("RESTFulExample.DAL.Entities.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RESTFulExample.DAL.Entities.Train", b =>
                {
                    b.HasOne("RESTFulExample.DAL.Entities.Employee", "Traveller")
                        .WithMany("Trains")
                        .HasForeignKey("TravellerId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using BookingMS.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingMS.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20201016141114_BookingModel")]
    partial class BookingModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthenticateApi.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Contact_Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookingMS.Model.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_of_Booking")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total_Fare")
                        .HasColumnType("int");

                    b.Property<int>("Total_Km")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("Username");

                    b.HasIndex("VehicleID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("VehicleWebApi.Model.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost_Per_Km")
                        .HasColumnType("int");

                    b.Property<int>("No_of_Seats")
                        .HasColumnType("int");

                    b.Property<int>("Number_InStock")
                        .HasColumnType("int");

                    b.Property<string>("Vehicle_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("BookingMS.Model.Booking", b =>
                {
                    b.HasOne("AuthenticateApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.HasOne("VehicleWebApi.Model.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

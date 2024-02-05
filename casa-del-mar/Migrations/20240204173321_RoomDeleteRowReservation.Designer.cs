﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using casa_del_mar.Models;

#nullable disable

namespace casa_del_mar.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240204173321_RoomDeleteRowReservation")]
    partial class RoomDeleteRowReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("casa_del_mar.Models.ReservatedDates", b =>
                {
                    b.Property<int>("reservationDatesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("reservationDatesID"));

                    b.Property<DateTime?>("end")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("roomID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("reservationDatesID");

                    b.ToTable("ReservatedDates");
                });

            modelBuilder.Entity("casa_del_mar.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("text");

                    b.Property<int?>("Price")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}

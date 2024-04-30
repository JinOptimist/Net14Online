﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealEstateNet14Web.DbStuff;

#nullable disable

namespace RealEstateNet14Web.MigrationsRealEstate
{
    [DbContext(typeof(WebRealEstateDbContext))]
    [Migration("20240405043437_UpdateTableRealEstate")]
    partial class UpdateTableRealEstate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlertRealEstateOwner", b =>
                {
                    b.Property<int>("NotificatedRealEstateOwnersId")
                        .HasColumnType("integer");

                    b.Property<int>("SeenAlertsId")
                        .HasColumnType("integer");

                    b.HasKey("NotificatedRealEstateOwnersId", "SeenAlertsId");

                    b.HasIndex("SeenAlertsId");

                    b.ToTable("AlertRealEstateOwner");
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("NumberApartament")
                        .HasColumnType("integer");

                    b.Property<int?>("RealEstateOwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("Size")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateOwnerId");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.RealEstateOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("KindOfActivity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RealEstateOwners");
                });

            modelBuilder.Entity("AlertRealEstateOwner", b =>
                {
                    b.HasOne("RealEstateNet14Web.DbStuff.Models.RealEstateOwner", null)
                        .WithMany()
                        .HasForeignKey("NotificatedRealEstateOwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateNet14Web.DbStuff.Models.Alert", null)
                        .WithMany()
                        .HasForeignKey("SeenAlertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.Alert", b =>
                {
                    b.HasOne("RealEstateNet14Web.DbStuff.Models.RealEstateOwner", "Creator")
                        .WithMany("CreatedAlerts")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.RealEstate", b =>
                {
                    b.HasOne("RealEstateNet14Web.DbStuff.Models.RealEstateOwner", "RealEstateOwner")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateOwnerId");

                    b.Navigation("RealEstateOwner");
                });

            modelBuilder.Entity("RealEstateNet14Web.DbStuff.Models.RealEstateOwner", b =>
                {
                    b.Navigation("CreatedAlerts");

                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
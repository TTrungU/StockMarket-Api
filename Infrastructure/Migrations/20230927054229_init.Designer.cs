﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230927054229_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entity.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entity.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("longtext");

                    b.Property<string>("Industry")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("MarketCap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sector")
                        .HasColumnType("longtext");

                    b.Property<string>("StockType")
                        .HasColumnType("longtext");

                    b.Property<string>("Symbol")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Domain.Entity.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("Change")
                        .HasColumnType("float");

                    b.Property<decimal?>("Close")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Low")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Open")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entity.WatchList", b =>
                {
                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StockId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("WatchLists");
                });

            modelBuilder.Entity("Domain.Entity.Notification", b =>
                {
                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.StockPrice", b =>
                {
                    b.HasOne("Domain.Entity.Stock", "Stock")
                        .WithMany("StockPrices")
                        .HasForeignKey("StockId");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Domain.Entity.WatchList", b =>
                {
                    b.HasOne("Domain.Entity.Stock", "Stock")
                        .WithMany("WatchLists")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("WatchLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.Stock", b =>
                {
                    b.Navigation("StockPrices");

                    b.Navigation("WatchLists");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("WatchLists");
                });
#pragma warning restore 612, 618
        }
    }
}

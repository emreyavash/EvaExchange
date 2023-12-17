﻿// <auto-generated />
using System;
using EveExchange.DataAccess.EvaExchangeDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EveExchange.DataAccess.Migrations
{
    [DbContext(typeof(EvaExchangeContext))]
    [Migration("20231216150536_ShareBeforePriceAdd")]
    partial class ShareBeforePriceAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EveExchange.DataAccess.Entitiy.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("TotalBalance")
                        .HasColumnType("double");

                    b.Property<double>("TotalShareBalance")
                        .HasColumnType("double");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("EveExchange.DataAccess.Entitiy.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("BeforePrice")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAtTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Lot")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ShareName")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortShareName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAtTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Shares");
                });

            modelBuilder.Entity("EveExchange.DataAccess.Entitiy.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("BuyOrSell")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Lot")
                        .HasColumnType("int");

                    b.Property<int>("ShareId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("EveExchange.DataAccess.Entitiy.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EveExchange.DataAccess.Entitiy.UserLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ShareId")
                        .HasColumnType("int");

                    b.Property<double>("TotalBalanceOfShare")
                        .HasColumnType("double");

                    b.Property<int>("TotalNumberOfShare")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserLots");
                });
#pragma warning restore 612, 618
        }
    }
}

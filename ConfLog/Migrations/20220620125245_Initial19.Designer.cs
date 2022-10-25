﻿// <auto-generated />
using System;
using ConfLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfLog.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20220620125245_Initial19")]
    partial class Initial19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConfLog.Models.Constructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("ConfLog.Models.Field", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("ConfLog.Models.FType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("functionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("FType");
                });

            modelBuilder.Entity("ConfLog.Models.Function", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isBase")
                        .HasColumnType("bit");

                    b.Property<int?>("level")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("toUse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeID");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("ConfLog.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("orderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ConfLog.Models.Using", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usings");
                });

            modelBuilder.Entity("ConstructorOrder", b =>
                {
                    b.Property<int>("constructorsId")
                        .HasColumnType("int");

                    b.Property<int>("ordersid")
                        .HasColumnType("int");

                    b.HasKey("constructorsId", "ordersid");

                    b.HasIndex("ordersid");

                    b.ToTable("ConstructorOrder");
                });

            modelBuilder.Entity("FieldFunction", b =>
                {
                    b.Property<int>("fieldsid")
                        .HasColumnType("int");

                    b.Property<int>("functionsid")
                        .HasColumnType("int");

                    b.HasKey("fieldsid", "functionsid");

                    b.HasIndex("functionsid");

                    b.ToTable("FieldFunction");
                });

            modelBuilder.Entity("FunctionOrder", b =>
                {
                    b.Property<int>("functionsid")
                        .HasColumnType("int");

                    b.Property<int>("ordersid")
                        .HasColumnType("int");

                    b.HasKey("functionsid", "ordersid");

                    b.HasIndex("ordersid");

                    b.ToTable("FunctionOrder");
                });

            modelBuilder.Entity("FunctionUsing", b =>
                {
                    b.Property<int>("functionsid")
                        .HasColumnType("int");

                    b.Property<int>("usingsid")
                        .HasColumnType("int");

                    b.HasKey("functionsid", "usingsid");

                    b.HasIndex("usingsid");

                    b.ToTable("FunctionUsing");
                });

            modelBuilder.Entity("ConfLog.Models.Function", b =>
                {
                    b.HasOne("ConfLog.Models.FType", "type")
                        .WithMany("functions")
                        .HasForeignKey("typeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("type");
                });

            modelBuilder.Entity("ConstructorOrder", b =>
                {
                    b.HasOne("ConfLog.Models.Constructor", null)
                        .WithMany()
                        .HasForeignKey("constructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfLog.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("ordersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FieldFunction", b =>
                {
                    b.HasOne("ConfLog.Models.Field", null)
                        .WithMany()
                        .HasForeignKey("fieldsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfLog.Models.Function", null)
                        .WithMany()
                        .HasForeignKey("functionsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FunctionOrder", b =>
                {
                    b.HasOne("ConfLog.Models.Function", null)
                        .WithMany()
                        .HasForeignKey("functionsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfLog.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("ordersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FunctionUsing", b =>
                {
                    b.HasOne("ConfLog.Models.Function", null)
                        .WithMany()
                        .HasForeignKey("functionsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConfLog.Models.Using", null)
                        .WithMany()
                        .HasForeignKey("usingsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConfLog.Models.FType", b =>
                {
                    b.Navigation("functions");
                });
#pragma warning restore 612, 618
        }
    }
}

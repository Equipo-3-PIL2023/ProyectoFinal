﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartInvest.Repositories;

#nullable disable

namespace SmartInvest.Migrations.TransaccionDB
{
    [DbContext(typeof(TransaccionDBContext))]
    [Migration("20231015194219_Transaccion")]
    partial class Transaccion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartInvest.Models.TransaccionModel", b =>
                {
                    b.Property<int>("idTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTransaccion"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<float>("comision")
                        .HasColumnType("real");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idAccion")
                        .HasColumnType("int");

                    b.Property<int>("idCuenta")
                        .HasColumnType("int");

                    b.Property<float>("precioCompra")
                        .HasColumnType("real");

                    b.HasKey("idTransaccion");

                    b.ToTable("Transaccion");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartInvest.Repositories;

#nullable disable

namespace SmartInvest.Migrations.CuentaDB
{
    [DbContext(typeof(CuentaDBContext))]
    partial class CuentaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartInvest.Models.CuentaModel", b =>
                {
                    b.Property<int>("idCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCuenta"));

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<float>("saldo")
                        .HasColumnType("decimal");

                    b.HasKey("idCuenta");

                    b.ToTable("Cuenta");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartInvest.Repositories;

#nullable disable

namespace SmartInvest.Migrations.AccionDB
{
    [DbContext(typeof(AccionDBContext))]
    [Migration("20231015194233_Acciones")]
    partial class Acciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmartInvest.Models.AccionModel", b =>
                {
                    b.Property<int>("idAccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAccion"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("simbolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAccion");

                    b.ToTable("Acciones");
                });
#pragma warning restore 612, 618
        }
    }
}

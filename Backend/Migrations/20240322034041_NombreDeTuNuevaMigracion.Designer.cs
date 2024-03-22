﻿// <auto-generated />
using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(VentasVehiculosContext))]
    [Migration("20240322034041_NombreDeTuNuevaMigracion")]
    partial class NombreDeTuNuevaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ClienteId")
                        .HasName("PK__Clientes__71ABD0A7CC0121A9");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Backend.Models.Concesionario", b =>
                {
                    b.Property<int>("ConcesionarioId")
                        .HasColumnType("int")
                        .HasColumnName("ConcesionarioID");

                    b.Property<string>("Ciudad")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ConcesionarioId")
                        .HasName("PK__Concesio__CFF65D10380DF6EE");

                    b.ToTable("Concesionarios");
                });

            modelBuilder.Entity("Backend.Models.Transaccione", b =>
                {
                    b.Property<int>("TransaccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TransaccionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransaccionId"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    b.Property<int?>("ConcesionarioId")
                        .HasColumnType("int")
                        .HasColumnName("ConcesionarioID");

                    b.Property<DateTime?>("FechaVenta")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("PrecioVenta")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("VehiculoId")
                        .HasColumnType("int")
                        .HasColumnName("VehiculoID");

                    b.HasKey("TransaccionId")
                        .HasName("PK__Transacc__86A849DE41277288");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ConcesionarioId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Backend.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .HasColumnType("int")
                        .HasColumnName("VehiculoID");

                    b.Property<int?>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("VehiculoId")
                        .HasName("PK__Vehiculo__AA088620750440D2");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Backend.Models.Transaccione", b =>
                {
                    b.HasOne("Backend.Models.Cliente", "Cliente")
                        .WithMany("Transacciones")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("FK__Transacci__Clien__690797E6");

                    b.HasOne("Backend.Models.Concesionario", "Concesionario")
                        .WithMany("Transacciones")
                        .HasForeignKey("ConcesionarioId")
                        .HasConstraintName("FK__Transacci__Conce__69FBBC1F");

                    b.HasOne("Backend.Models.Vehiculo", "Vehiculo")
                        .WithMany("Transacciones")
                        .HasForeignKey("VehiculoId")
                        .HasConstraintName("FK__Transacci__Vehic__681373AD");

                    b.Navigation("Cliente");

                    b.Navigation("Concesionario");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Backend.Models.Cliente", b =>
                {
                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("Backend.Models.Concesionario", b =>
                {
                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("Backend.Models.Vehiculo", b =>
                {
                    b.Navigation("Transacciones");
                });
#pragma warning restore 612, 618
        }
    }
}

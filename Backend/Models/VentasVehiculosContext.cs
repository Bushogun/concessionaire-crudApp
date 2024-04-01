using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class VentasVehiculosContext : DbContext
{
    public VentasVehiculosContext()
    {
    }

    public VentasVehiculosContext(DbContextOptions<VentasVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MINOTAURO\\SQLEXPRESS; DataBase=VentasVehiculos; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A71631344F");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.HasKey(e => e.ConcesionarioId).HasName("PK__Concesio__CFF65D10543D01CC");

            entity.Property(e => e.ConcesionarioId)
                .ValueGeneratedNever()
                .HasColumnName("ConcesionarioID");
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("PK__Transacc__86A849DECBBD3BC0");

            entity.HasIndex(e => e.VehiculoId, "UQ__Transacc__AA08862182B70625").IsUnique();

            entity.Property(e => e.TransaccionId).HasColumnName("TransaccionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Transacci__Clien__2116E6DF");

            entity.HasOne(d => d.Vehiculo).WithOne(p => p.Transaccione)
                .HasForeignKey<Transaccione>(d => d.VehiculoId)
                .HasConstraintName("FK__Transacci__Vehic__2022C2A6");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08862047037CFC");

            entity.Property(e => e.VehiculoId)
                .ValueGeneratedNever()
                .HasColumnName("VehiculoID");
            entity.Property(e => e.ConcesionarioId).HasColumnName("ConcesionarioID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Concesionario).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.ConcesionarioId)
                .HasConstraintName("FK__Vehiculos__Conce__1A69E950");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

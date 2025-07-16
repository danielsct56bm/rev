using System;
using System.Collections.Generic;
using infrastructure.Data.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data.EF;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<clientes> clientes { get; set; }

    public virtual DbSet<servicios> servicios { get; set; }

    public virtual DbSet<tickets> tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<clientes>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.Property(e => e.id).HasColumnType("int(11)");
            entity.Property(e => e.correo).HasMaxLength(32);
            entity.Property(e => e.fechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.nombre).HasMaxLength(64);
        });

        modelBuilder.Entity<servicios>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.idCliente, "idx_servicios_idCliente");

            entity.Property(e => e.id).HasColumnType("int(11)");
            entity.Property(e => e.fechaInicio)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.fechaRenovacion).HasColumnType("datetime");
            entity.Property(e => e.idCliente).HasColumnType("int(11)");
            entity.Property(e => e.monto).HasPrecision(10, 2);
            entity.Property(e => e.servicio).HasMaxLength(32);

            entity.HasOne(d => d.idClienteNavigation).WithMany(p => p.servicios)
                .HasForeignKey(d => d.idCliente)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("servicios_ibfk_1");
        });

        modelBuilder.Entity<tickets>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");

            entity.HasIndex(e => e.idCliente, "idx_tickets_idCliente");

            entity.HasIndex(e => e.idServicio, "idx_tickets_idServicio");

            entity.HasIndex(e => e.status, "idx_tickets_status");

            entity.HasIndex(e => e.ticket, "ticket").IsUnique();

            entity.Property(e => e.id).HasColumnType("int(11)");
            entity.Property(e => e.asunto).HasMaxLength(64);
            entity.Property(e => e.fechaFin).HasColumnType("datetime");
            entity.Property(e => e.fechaInicio)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.idCliente).HasColumnType("int(11)");
            entity.Property(e => e.idServicio).HasColumnType("int(11)");
            entity.Property(e => e.status).HasMaxLength(1);
            entity.Property(e => e.statusFinal).HasMaxLength(1);
            entity.Property(e => e.ticket).HasMaxLength(6);

            entity.HasOne(d => d.idClienteNavigation).WithMany(p => p.tickets)
                .HasForeignKey(d => d.idCliente)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tickets_ibfk_1");

            entity.HasOne(d => d.idServicioNavigation).WithMany(p => p.tickets)
                .HasForeignKey(d => d.idServicio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tickets_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

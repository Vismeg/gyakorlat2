using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace fogado.Models;

public partial class FogadoContext : DbContext
{
    public FogadoContext()
    {
    }

    public FogadoContext(DbContextOptions<FogadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Foglalasok> Foglalasoks { get; set; }

    public virtual DbSet<Szobak> Szobaks { get; set; }

    public virtual DbSet<Vendegek> Vendegeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=fogado;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Foglalasok>(entity =>
        {
            entity.HasKey(e => e.Fsorsz).HasName("PRIMARY");

            entity.ToTable("foglalasok");

            entity.HasIndex(e => e.Szoba, "szoba");

            entity.HasIndex(e => e.Vendeg, "vendeg");

            entity.Property(e => e.Fsorsz)
                .HasColumnType("int(11)")
                .HasColumnName("fsorsz");
            entity.Property(e => e.Erk)
                .HasColumnType("date")
                .HasColumnName("erk");
            entity.Property(e => e.Fo)
                .HasColumnType("int(11)")
                .HasColumnName("fo");
            entity.Property(e => e.Szoba)
                .HasColumnType("int(11)")
                .HasColumnName("szoba");
            entity.Property(e => e.Tav)
                .HasColumnType("date")
                .HasColumnName("tav");
            entity.Property(e => e.Vendeg)
                .HasColumnType("int(11)")
                .HasColumnName("vendeg");

            entity.HasOne(d => d.SzobaNavigation).WithMany(p => p.Foglalasoks)
                .HasForeignKey(d => d.Szoba)
                .HasConstraintName("foglalasok_ibfk_2");

            entity.HasOne(d => d.VendegNavigation).WithMany(p => p.Foglalasoks)
                .HasForeignKey(d => d.Vendeg)
                .HasConstraintName("foglalasok_ibfk_1");
        });

        modelBuilder.Entity<Szobak>(entity =>
        {
            entity.HasKey(e => e.Szazon).HasName("PRIMARY");

            entity.ToTable("szobak");

            entity.Property(e => e.Szazon)
                .HasColumnType("int(11)")
                .HasColumnName("szazon");
            entity.Property(e => e.Agy)
                .HasColumnType("int(11)")
                .HasColumnName("agy");
            entity.Property(e => e.Potagy)
                .HasColumnType("int(11)")
                .HasColumnName("potagy");
            entity.Property(e => e.Sznev)
                .HasColumnType("text")
                .HasColumnName("sznev");
        });

        modelBuilder.Entity<Vendegek>(entity =>
        {
            entity.HasKey(e => e.Vsorsz).HasName("PRIMARY");

            entity.ToTable("vendegek");

            entity.HasIndex(e => e.Vnev, "vnev");

            entity.Property(e => e.Vsorsz)
                .HasColumnType("int(11)")
                .HasColumnName("vsorsz");
            entity.Property(e => e.Irsz)
                .HasColumnType("int(11)")
                .HasColumnName("irsz");
            entity.Property(e => e.Vnev)
                .HasColumnType("text")
                .HasColumnName("vnev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

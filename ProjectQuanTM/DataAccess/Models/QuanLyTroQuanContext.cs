using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class QuanLyTroQuanContext : DbContext
{
    public QuanLyTroQuanContext()
    {
    }

    public QuanLyTroQuanContext(DbContextOptions<QuanLyTroQuanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local)\\SQLABC;database=QuanLyTroQuan;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rent>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Rents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rent_Customer");

            entity.HasOne(d => d.Room).WithMany(p => p.Rents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rent_Room");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Rent).WithMany(p => p.Services)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_Rent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

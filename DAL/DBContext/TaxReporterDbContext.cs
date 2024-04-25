﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaxReporter.Entities;

namespace TaxReporter.DAL.DBContext;

public partial class TaxReporterDbContext : DbContext
{
    public TaxReporterDbContext()
    {
    }

    public TaxReporterDbContext(DbContextOptions<TaxReporterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvoiceInfo> InvoiceInfos { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceInfo>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__InvoiceI__D796AAB5A4110C4F");

            entity.ToTable("InvoiceInfo");

            entity.Property(e => e.AmountWithoutItbis)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AmountWithoutITBIS");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).IsUnicode(false);
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Itbis)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ITBIS");
            entity.Property(e => e.Nfc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NFC");
            entity.Property(e => e.Rnc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RNC");
            entity.Property(e => e.ServicePercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.InvoiceInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__InvoiceIn__UserI__44FF419A");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED23092228191");

            entity.ToTable("Menu");

            entity.Property(e => e.IconMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrlMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.MenuRolId).HasName("PK__MenuRol__6640AD0C7D10FE2D");

            entity.ToTable("MenuRol");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__MenuRol__MenuId__3C69FB99");

            entity.HasOne(d => d.Rol).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__MenuRol__RolId__3D5E1FD2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F1F09F850D");

            entity.ToTable("Rol");

            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4CA8B47FA0");

            entity.ToTable("UserInfo");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberId).HasColumnName("NumberID");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfo__RolId__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

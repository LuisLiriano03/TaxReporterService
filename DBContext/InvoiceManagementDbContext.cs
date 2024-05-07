using Microsoft.EntityFrameworkCore;
using TaxReporter.Entities;

namespace TaxReporter.DBContext;

public partial class InvoiceManagementDbContext : DbContext
{
    public InvoiceManagementDbContext()
    {
    }

    public InvoiceManagementDbContext(DbContextOptions<InvoiceManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvoiceInfo> InvoiceInfos { get; set; }

    public virtual DbSet<InvoiceState> InvoiceStates { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceInfo>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__InvoiceI__D796AAB5D496096A");

            entity.ToTable("InvoiceInfo");

            entity.Property(e => e.AmountWithoutItbis)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AmountWithoutITBIS");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
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

            entity.HasOne(d => d.State).WithMany(p => p.InvoiceInfos)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__InvoiceIn__State__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.InvoiceInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__InvoiceIn__UserI__47DBAE45");
        });

        modelBuilder.Entity<InvoiceState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__InvoiceS__C3BA3B3AD7BB5651");

            entity.ToTable("InvoiceState");

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED23027290A17");

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
            entity.HasKey(e => e.MenuRolId).HasName("PK__MenuRol__6640AD0C2A668663");

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
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F1FDAEF2AD");

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
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4CD5C241EC");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationCard)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfo__RolId__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using Microsoft.EntityFrameworkCore;
using Test.Millon.Core.Entities;

namespace Test.Millon.Infraestructure.Percistences;

public partial class TestMillonContext : DbContext
{
    public TestMillonContext()
    {
    }

    public TestMillonContext(DbContextOptions<TestMillonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyImage> PropertyImages { get; set; }

    public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.IdOwner);

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Photo).HasColumnType("image");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.IdProperty).HasName("PK_Property");

            entity.Property(e => e.IdProperty).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CodeInternal)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Properties)
                .HasForeignKey(d => d.IdOwner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Properties_Owners");
        });

        modelBuilder.Entity<PropertyImage>(entity =>
        {
            entity.HasKey(e => e.IdPropertyImage);

            entity.Property(e => e.FileImage).HasColumnType("image");

            entity.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.IdProperty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyImages_Properties");
        });

        modelBuilder.Entity<PropertyTrace>(entity =>
        {
            entity.HasKey(e => e.IdPropertyTrace);

            entity.Property(e => e.IdPropertyTrace).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Value)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdPropertyNavigation).WithMany(p => p.PropertyTraces)
                .HasForeignKey(d => d.IdProperty)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PropertyTraces_Properties");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

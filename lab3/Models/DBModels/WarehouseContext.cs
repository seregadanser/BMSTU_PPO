using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_course.Models.DBModels;

public interface IConnection
{
    public string Type { get; set; }
}

public partial class WarehouseContext : DbContext, IConnection
{
    public string Type { get; set; }
    public WarehouseContext()
    {
    }

    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InventoryProduct> InventoryProducts { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceofObject> PlaceofObjects { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Useful> Usefuls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryProduct>(entity =>
        {
            entity.HasKey(e => e.InventoryNumber).HasName("PK__Inventor__070F296D33815378");

            entity.ToTable("InventoryProduct", "warehouse2");

            entity.Property(e => e.InventoryNumber)
                .ValueGeneratedNever()
                .HasColumnName("inventory_number");
            entity.Property(e => e.ProductId).HasColumnName("product_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__produ__52593CB8");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("PK__Persons__5E55825A7D236D07");

            entity.HasIndex(e => e.Password, "UQ__Persons__6E2DBEDEE13B4EDB").IsUnique();

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirthday).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumberOfCome).HasColumnName("number_of_come");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Place__3214EC07D1BD5286");

            entity.ToTable("Place", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NumberLayer).HasColumnName("number_layer");
            entity.Property(e => e.NumberStay).HasColumnName("number_stay");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<PlaceofObject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceofO__3214EC0743E2FEF6");

            entity.ToTable("PlaceofObject", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Inventory).WithMany(p => p.PlaceofObjects)
                .HasForeignKey(d => d.InventoryId)
                .HasConstraintName("FK__PlaceofOb__Inven__5812160E");

            entity.HasOne(d => d.Place).WithMany(p => p.PlaceofObjects)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__PlaceofOb__Place__571DF1D5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07ADD5DA18");

            entity.ToTable("Products", "warehouse2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCome)
                .HasColumnType("date")
                .HasColumnName("dateCome");
            entity.Property(e => e.DateProduction)
                .HasColumnType("date")
                .HasColumnName("dateProduction");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Useful>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Useful__F5FDE6B3EA3D563F");

            entity.ToTable("Useful", "warehouse2");

            entity.Property(e => e.InventoryId).ValueGeneratedNever();
            entity.Property(e => e.DateOfStart).HasColumnType("date");
            entity.Property(e => e.PersonId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Inventory).WithOne(p => p.Useful)
                .HasForeignKey<Useful>(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Useful__Inventor__6C190EBB");

            entity.HasOne(d => d.Person).WithMany(p => p.Usefuls)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Useful__PersonId__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

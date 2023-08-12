using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OrderApp.Domain.Entities;

namespace OrderApp.Domain.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lummiense\\source\\repos\\OrderApp\\OrderApp.Domain\\Data\\DB.mdf");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F6394B22E");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .HasColumnName("id");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(1)
                .HasColumnName("Order_Date");
            entity.Property(e => e.TotalOrderPrice).HasColumnName("Total_Order_Price");
            entity.Property(e => e.UserId).HasMaxLength(1);

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Order__UserId__44FF419A");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3213E83F6B792E3C");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .HasColumnName("id");
            entity.Property(e => e.ItemCount).HasColumnName("Item_Count");
            entity.Property(e => e.OrderId).HasMaxLength(1);
            entity.Property(e => e.ProductId).HasMaxLength(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__3C69FB99");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__45F365D3");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F9DDD15D7");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83F0F3628C6");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F28BF6CBA");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(1)
                .HasColumnName("id");
            entity.Property(e => e.Login).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(1);
            entity.Property(e => e.Password).HasMaxLength(1);
            entity.Property(e => e.RoleId).HasMaxLength(1);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

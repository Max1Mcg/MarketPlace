using System;
using System.Collections.Generic;
using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Contexts;

public partial class MarketPlaceContext : DbContext
{
    IConfiguration _configuration;

    public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options,
        IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetValue<string>("ConnectionStrings:MarketPlace"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.Idbasket).HasName("Basket_pkey");

            entity.ToTable("Basket");

            entity.Property(e => e.Idbasket)
                .ValueGeneratedNever()
                .HasColumnName("idbasket");
            entity.Property(e => e.ItemCount).HasColumnName("item_count");
            entity.Property(e => e.SummaryCost).HasColumnName("summary_cost");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Basket_userid_fkey");

            entity.HasMany(d => d.Items).WithMany(p => p.Baskets)
                .UsingEntity<Dictionary<string, object>>(
                    "BasketItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("BasketItem_itemid_fkey"),
                    l => l.HasOne<Basket>().WithMany()
                        .HasForeignKey("Basketid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("BasketItem_basketid_fkey"),
                    j =>
                    {
                        j.HasKey("Basketid", "Itemid").HasName("BacketItem_pkey");
                        j.ToTable("BasketItem");
                        j.IndexerProperty<Guid>("Basketid").HasColumnName("basketid");
                        j.IndexerProperty<Guid>("Itemid").HasColumnName("itemid");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("Category_pkey");

            entity.ToTable("Category");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("idcategory");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasMany(d => d.Items).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CategoryItem_itemid_fkey"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CategoryItem_categoryid_fkey"),
                    j =>
                    {
                        j.HasKey("Categoryid", "Itemid").HasName("CategoryItem_pkey");
                        j.ToTable("CategoryItem");
                        j.IndexerProperty<int>("Categoryid").HasColumnName("categoryid");
                        j.IndexerProperty<Guid>("Itemid").HasColumnName("itemid");
                    });
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.Iddelivery).HasName("Delivery_pkey");

            entity.ToTable("Delivery");

            entity.Property(e => e.Iddelivery)
                .ValueGeneratedNever()
                .HasColumnName("iddelivery");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iditem).HasName("Item_pkey");

            entity.ToTable("Item");

            entity.Property(e => e.Iditem)
                .ValueGeneratedNever()
                .HasColumnName("iditem");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Sold)
                .HasDefaultValueSql("false")
                .HasColumnName("sold");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.Idorder)
                .ValueGeneratedNever()
                .HasColumnName("idorder");
            entity.Property(e => e.AdditionalInformation).HasColumnName("additional_information");
            entity.Property(e => e.Basketid).HasColumnName("basketid");
            entity.Property(e => e.ClosedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("closed_at");
            entity.Property(e => e.Deliveryid).HasColumnName("deliveryid");
            entity.Property(e => e.FormedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("formed_at");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Basket).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Basketid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_basketid_fkey");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Deliveryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_deliveryid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_statusid_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Idstatus).HasName("Status_pkey");

            entity.ToTable("Status");

            entity.Property(e => e.Idstatus)
                .ValueGeneratedNever()
                .HasColumnName("idstatus");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

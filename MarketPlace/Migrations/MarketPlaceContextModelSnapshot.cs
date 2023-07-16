﻿// <auto-generated />
using System;
using MarketPlace.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketPlace.Migrations
{
    [DbContext(typeof(MarketPlaceContext))]
    partial class MarketPlaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BasketItem", b =>
                {
                    b.Property<Guid>("Basketid")
                        .HasColumnType("uuid")
                        .HasColumnName("basketid");

                    b.Property<Guid>("Itemid")
                        .HasColumnType("uuid")
                        .HasColumnName("itemid");

                    b.HasKey("Basketid", "Itemid")
                        .HasName("BacketItem_pkey");

                    b.HasIndex("Itemid");

                    b.ToTable("BasketItem", (string)null);
                });

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.Property<int>("Categoryid")
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    b.Property<Guid>("Itemid")
                        .HasColumnType("uuid")
                        .HasColumnName("itemid");

                    b.HasKey("Categoryid", "Itemid")
                        .HasName("CategoryItem_pkey");

                    b.HasIndex("Itemid");

                    b.ToTable("CategoryItem", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Basket", b =>
                {
                    b.Property<Guid>("Idbasket")
                        .HasColumnType("uuid")
                        .HasColumnName("idbasket");

                    b.Property<int?>("ItemCount")
                        .HasColumnType("integer")
                        .HasColumnName("item_count");

                    b.Property<double?>("SummaryCost")
                        .HasColumnType("double precision")
                        .HasColumnName("summary_cost");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("Userid")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Idbasket")
                        .HasName("Basket_pkey");

                    b.HasIndex("Userid");

                    b.ToTable("Basket", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Category", b =>
                {
                    b.Property<int>("Idcategory")
                        .HasColumnType("integer")
                        .HasColumnName("idcategory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Idcategory")
                        .HasName("Category_pkey");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Delivery", b =>
                {
                    b.Property<int>("Iddelivery")
                        .HasColumnType("integer")
                        .HasColumnName("iddelivery");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Iddelivery")
                        .HasName("Delivery_pkey");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Item", b =>
                {
                    b.Property<Guid>("Iditem")
                        .HasColumnType("uuid")
                        .HasColumnName("iditem");

                    b.Property<double?>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool?>("Sold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("sold")
                        .HasDefaultValueSql("false");

                    b.Property<string>("Weight")
                        .HasColumnType("text")
                        .HasColumnName("weight");

                    b.HasKey("Iditem")
                        .HasName("Item_pkey");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Order", b =>
                {
                    b.Property<Guid>("Idorder")
                        .HasColumnType("uuid")
                        .HasColumnName("idorder");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("text")
                        .HasColumnName("additional_information");

                    b.Property<Guid>("Basketid")
                        .HasColumnType("uuid")
                        .HasColumnName("basketid");

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("closed_at");

                    b.Property<int>("Deliveryid")
                        .HasColumnType("integer")
                        .HasColumnName("deliveryid");

                    b.Property<DateTime?>("FormedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("formed_at");

                    b.Property<int>("Statusid")
                        .HasColumnType("integer")
                        .HasColumnName("statusid");

                    b.HasKey("Idorder")
                        .HasName("Order_pkey");

                    b.HasIndex("Basketid");

                    b.HasIndex("Deliveryid");

                    b.HasIndex("Statusid");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.Status", b =>
                {
                    b.Property<int>("Idstatus")
                        .HasColumnType("integer")
                        .HasColumnName("idstatus");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Idstatus")
                        .HasName("Status_pkey");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("MarketPlace.Models.User", b =>
                {
                    b.Property<Guid>("Iduser")
                        .HasColumnType("uuid")
                        .HasColumnName("iduser");

                    b.Property<int?>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Iduser")
                        .HasName("User_pkey");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BasketItem", b =>
                {
                    b.HasOne("MarketPlace.Models.Basket", null)
                        .WithMany()
                        .HasForeignKey("Basketid")
                        .IsRequired()
                        .HasConstraintName("BasketItem_basketid_fkey");

                    b.HasOne("MarketPlace.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("Itemid")
                        .IsRequired()
                        .HasConstraintName("BasketItem_itemid_fkey");
                });

            modelBuilder.Entity("CategoryItem", b =>
                {
                    b.HasOne("MarketPlace.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("Categoryid")
                        .IsRequired()
                        .HasConstraintName("CategoryItem_categoryid_fkey");

                    b.HasOne("MarketPlace.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("Itemid")
                        .IsRequired()
                        .HasConstraintName("CategoryItem_itemid_fkey");
                });

            modelBuilder.Entity("MarketPlace.Models.Basket", b =>
                {
                    b.HasOne("MarketPlace.Models.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("Basket_userid_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarketPlace.Models.Order", b =>
                {
                    b.HasOne("MarketPlace.Models.Basket", "Basket")
                        .WithMany("Orders")
                        .HasForeignKey("Basketid")
                        .IsRequired()
                        .HasConstraintName("Order_basketid_fkey");

                    b.HasOne("MarketPlace.Models.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("Deliveryid")
                        .IsRequired()
                        .HasConstraintName("Order_deliveryid_fkey");

                    b.HasOne("MarketPlace.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("Statusid")
                        .IsRequired()
                        .HasConstraintName("Order_statusid_fkey");

                    b.Navigation("Basket");

                    b.Navigation("Delivery");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MarketPlace.Models.Basket", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MarketPlace.Models.Delivery", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MarketPlace.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MarketPlace.Models.User", b =>
                {
                    b.Navigation("Baskets");
                });
#pragma warning restore 612, 618
        }
    }
}

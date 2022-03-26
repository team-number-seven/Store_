﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Store.DAL;

namespace Store.DAL.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ItemUser", b =>
                {
                    b.Property<Guid>("BagItemsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BagUsersId")
                        .HasColumnType("uuid");

                    b.HasKey("BagItemsId", "BagUsersId");

                    b.HasIndex("BagUsersId");

                    b.ToTable("BagItemsUser");
                });

            modelBuilder.Entity("ItemUser1", b =>
                {
                    b.Property<Guid>("FavoriteItemsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FavoriteUsersId")
                        .HasColumnType("uuid");

                    b.HasKey("FavoriteItemsId", "FavoriteUsersId");

                    b.HasIndex("FavoriteUsersId");

                    b.ToTable("FavoriteItemsUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Store.DAL.Entities.AgeTypeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("AgeTypesItem");
                });

            modelBuilder.Entity("Store.DAL.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LogoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("LogoId")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Store.DAL.Entities.BusinessCharacteristicItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ArticleNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ArticleNumber")
                        .IsUnique();

                    b.HasIndex("CountryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("BusinessCharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.CharacteristicItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AgeTypeItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SeasonItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SizeItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubTypeItemId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AgeTypeItemId");

                    b.HasIndex("ColorId");

                    b.HasIndex("GenderId");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("SeasonItemId");

                    b.HasIndex("SizeItemId");

                    b.HasIndex("SubTypeItemId");

                    b.ToTable("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Store.DAL.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("InitializeCountries");
                });

            modelBuilder.Entity("Store.DAL.Entities.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Store.DAL.Entities.ImageFormat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Format")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.HasIndex("Format")
                        .IsUnique();

                    b.ToTable("ImageFormats");
                });

            modelBuilder.Entity("Store.DAL.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessCharacteristicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacteristicItemId")
                        .HasColumnType("uuid");

                    b.Property<long>("CountItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("CountSales")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<Guid>("MainItemImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("WarehouseItemId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("BusinessCharacteristicId")
                        .IsUnique();

                    b.HasIndex("CharacteristicItemId")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.HasIndex("WarehouseItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Store.DAL.Entities.ItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Store.DAL.Entities.Logo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageFormatId")
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageFormatId");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("Logos");
                });

            modelBuilder.Entity("Store.DAL.Entities.MainItemImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageFormatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageFormatId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("MainItemImages");
                });

            modelBuilder.Entity("Store.DAL.Entities.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Store.DAL.Entities.SeasonItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("SeasonTypes");
                });

            modelBuilder.Entity("Store.DAL.Entities.SecondaryItemImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ImageFormatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ImageFormatId");

                    b.HasIndex("ItemId");

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("SecondaryItemImages");
                });

            modelBuilder.Entity("Store.DAL.Entities.SizeTypeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("Size")
                        .IsUnique();

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Store.DAL.Entities.SubItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("SubItemTypes");
                });

            modelBuilder.Entity("Store.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2022, 3, 26, 18, 50, 20, 468, DateTimeKind.Local).AddTicks(2498));

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Store.DAL.Entities.WarehouseItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("WarehouseItems");
                });

            modelBuilder.Entity("ItemUser", b =>
                {
                    b.HasOne("Store.DAL.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("BagItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("BagUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemUser1", b =>
                {
                    b.HasOne("Store.DAL.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("FavoriteItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FavoriteUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Store.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Store.DAL.Entities.Brand", b =>
                {
                    b.HasOne("Store.DAL.Entities.Logo", "Logo")
                        .WithOne("Brand")
                        .HasForeignKey("Store.DAL.Entities.Brand", "LogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Logo");
                });

            modelBuilder.Entity("Store.DAL.Entities.BusinessCharacteristicItem", b =>
                {
                    b.HasOne("Store.DAL.Entities.Country", "Country")
                        .WithMany("BusinessCharacteristicItems")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.Manufacturer", "Manufacturer")
                        .WithMany("BusinessCharacteristicItem")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Store.DAL.Entities.CharacteristicItem", b =>
                {
                    b.HasOne("Store.DAL.Entities.AgeTypeItem", "AgeTypeItem")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("AgeTypeItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.Color", "Color")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.Gender", "Gender")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.ItemType", "ItemType")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.SeasonItem", "SeasonItem")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("SeasonItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.SizeTypeItem", "SizeTypeItem")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("SizeItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.SubItemType", "SubItemType")
                        .WithMany("CharacteristicItems")
                        .HasForeignKey("SubTypeItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeTypeItem");

                    b.Navigation("Color");

                    b.Navigation("Gender");

                    b.Navigation("ItemType");

                    b.Navigation("SeasonItem");

                    b.Navigation("SizeTypeItem");

                    b.Navigation("SubItemType");
                });

            modelBuilder.Entity("Store.DAL.Entities.Item", b =>
                {
                    b.HasOne("Store.DAL.Entities.Brand", "Brand")
                        .WithMany("Items")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.BusinessCharacteristicItem", "BusinessCharacteristic")
                        .WithOne("Item")
                        .HasForeignKey("Store.DAL.Entities.Item", "BusinessCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.CharacteristicItem", "CharacteristicItem")
                        .WithOne("Item")
                        .HasForeignKey("Store.DAL.Entities.Item", "CharacteristicItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.WarehouseItem", "WarehouseItem")
                        .WithMany("Items")
                        .HasForeignKey("WarehouseItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("BusinessCharacteristic");

                    b.Navigation("CharacteristicItem");

                    b.Navigation("WarehouseItem");
                });

            modelBuilder.Entity("Store.DAL.Entities.Logo", b =>
                {
                    b.HasOne("Store.DAL.Entities.ImageFormat", "ImageFormat")
                        .WithMany("Logos")
                        .HasForeignKey("ImageFormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageFormat");
                });

            modelBuilder.Entity("Store.DAL.Entities.MainItemImage", b =>
                {
                    b.HasOne("Store.DAL.Entities.ImageFormat", "ImageFormat")
                        .WithMany("MainItemImages")
                        .HasForeignKey("ImageFormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.Item", "Item")
                        .WithOne("MainItemImage")
                        .HasForeignKey("Store.DAL.Entities.MainItemImage", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageFormat");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Store.DAL.Entities.SecondaryItemImage", b =>
                {
                    b.HasOne("Store.DAL.Entities.ImageFormat", "ImageFormat")
                        .WithMany("SecondaryItemImage")
                        .HasForeignKey("ImageFormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.DAL.Entities.Item", "Item")
                        .WithMany("SecondaryItemImages")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageFormat");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Store.DAL.Entities.SizeTypeItem", b =>
                {
                    b.HasOne("Store.DAL.Entities.ItemType", "ItemType")
                        .WithMany("SizeItems")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("Store.DAL.Entities.SubItemType", b =>
                {
                    b.HasOne("Store.DAL.Entities.ItemType", "ItemType")
                        .WithMany("SubItemTypes")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("Store.DAL.Entities.User", b =>
                {
                    b.HasOne("Store.DAL.Entities.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Store.DAL.Entities.AgeTypeItem", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.Brand", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Store.DAL.Entities.BusinessCharacteristicItem", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("Store.DAL.Entities.CharacteristicItem", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("Store.DAL.Entities.Color", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.Country", b =>
                {
                    b.Navigation("BusinessCharacteristicItems");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Store.DAL.Entities.Gender", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.ImageFormat", b =>
                {
                    b.Navigation("Logos");

                    b.Navigation("MainItemImages");

                    b.Navigation("SecondaryItemImage");
                });

            modelBuilder.Entity("Store.DAL.Entities.Item", b =>
                {
                    b.Navigation("MainItemImage");

                    b.Navigation("SecondaryItemImages");
                });

            modelBuilder.Entity("Store.DAL.Entities.ItemType", b =>
                {
                    b.Navigation("CharacteristicItems");

                    b.Navigation("SizeItems");

                    b.Navigation("SubItemTypes");
                });

            modelBuilder.Entity("Store.DAL.Entities.Logo", b =>
                {
                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Store.DAL.Entities.Manufacturer", b =>
                {
                    b.Navigation("BusinessCharacteristicItem");
                });

            modelBuilder.Entity("Store.DAL.Entities.SeasonItem", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.SizeTypeItem", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.SubItemType", b =>
                {
                    b.Navigation("CharacteristicItems");
                });

            modelBuilder.Entity("Store.DAL.Entities.WarehouseItem", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

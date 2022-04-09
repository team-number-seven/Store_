using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Store.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AgeTypesItem",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AgeTypesItem", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Name = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Colors",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Colors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Genders",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Genders", x => x.Id); });

            migrationBuilder.CreateTable(
                "ImageFormats",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Format = table.Column<string>("character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_ImageFormats", x => x.Id); });

            migrationBuilder.CreateTable(
                "InitializeCountries",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Name = table.Column<string>("character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_InitializeCountries", x => x.Id); });

            migrationBuilder.CreateTable(
                "ItemTypes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("text", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_ItemTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Manufacturers",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Manufacturers", x => x.Id); });

            migrationBuilder.CreateTable(
                "SeasonTypes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_SeasonTypes", x => x.Id); });

            migrationBuilder.CreateTable(
                "WarehouseItems",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_WarehouseItems", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>("uuid", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Logos",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Path = table.Column<string>("text", nullable: false),
                    ImageFormatId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                    table.ForeignKey(
                        "FK_Logos_ImageFormats_ImageFormatId",
                        x => x.ImageFormatId,
                        "ImageFormats",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    CreateDate = table.Column<DateTime>("timestamp without time zone", nullable: false,
                        defaultValue: new DateTime(2022, 3, 26, 18, 50, 20, 468, DateTimeKind.Local).AddTicks(2498)),
                    CountryId = table.Column<Guid>("uuid", nullable: false),
                    UserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>("text", nullable: true),
                    SecurityStamp = table.Column<string>("text", nullable: true),
                    ConcurrencyStamp = table.Column<string>("text", nullable: true),
                    PhoneNumber = table.Column<string>("text", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUsers_InitializeCountries_CountryId",
                        x => x.CountryId,
                        "InitializeCountries",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Sizes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Size = table.Column<string>("character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>("text", nullable: true),
                    ItemTypeId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        "FK_Sizes_ItemTypes_ItemTypeId",
                        x => x.ItemTypeId,
                        "ItemTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SubTypes",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    ItemTypeId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemTypes", x => x.Id);
                    table.ForeignKey(
                        "FK_SubItemTypes_ItemTypes_ItemTypeId",
                        x => x.ItemTypeId,
                        "ItemTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "BusinessCharacteristicItems",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    ArticleNumber = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<Guid>("uuid", nullable: false),
                    ManufacturerId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCharacteristicItems", x => x.Id);
                    table.ForeignKey(
                        "FK_BusinessCharacteristicItems_InitializeCountries_CountryId",
                        x => x.CountryId,
                        "InitializeCountries",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_BusinessCharacteristicItems_Manufacturers_ManufacturerId",
                        x => x.ManufacturerId,
                        "Manufacturers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Brands",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    LogoId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        "FK_Brands_Logos_LogoId",
                        x => x.LogoId,
                        "Logos",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    ClaimType = table.Column<string>("text", nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>("text", nullable: false),
                    ProviderKey = table.Column<string>("text", nullable: false),
                    ProviderDisplayName = table.Column<string>("text", nullable: true),
                    UserId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    RoleId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<Guid>("uuid", nullable: false),
                    LoginProvider = table.Column<string>("text", nullable: false),
                    Name = table.Column<string>("text", nullable: false),
                    Value = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Characteristics",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    ColorId = table.Column<Guid>("uuid", nullable: false),
                    SizeItemId = table.Column<Guid>("uuid", nullable: false),
                    AgeTypeItemId = table.Column<Guid>("uuid", nullable: false),
                    SeasonItemId = table.Column<Guid>("uuid", nullable: false),
                    GenderId = table.Column<Guid>("uuid", nullable: false),
                    SubTypeItemId = table.Column<Guid>("uuid", nullable: false),
                    ItemTypeId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicItems", x => x.Id);
                    table.ForeignKey(
                        "FK_CharacteristicItems_AgeTypesItem_AgeTypeItemId",
                        x => x.AgeTypeItemId,
                        "AgeTypesItem",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_Colors_ColorId",
                        x => x.ColorId,
                        "Colors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_Genders_GenderId",
                        x => x.GenderId,
                        "Genders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_ItemTypes_ItemTypeId",
                        x => x.ItemTypeId,
                        "ItemTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_SeasonTypes_SeasonItemId",
                        x => x.SeasonItemId,
                        "SeasonTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_Sizes_SizeItemId",
                        x => x.SizeItemId,
                        "Sizes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CharacteristicItems_SubItemTypes_SubTypeItemId",
                        x => x.SubTypeItemId,
                        "SubTypes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Items",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Title = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>("character varying(2000)", maxLength: 2000, nullable: false),
                    CountSales = table.Column<long>("bigint", nullable: false, defaultValue: 0L),
                    CountItem = table.Column<long>("bigint", nullable: false, defaultValue: 0L),
                    CharacteristicItemId = table.Column<Guid>("uuid", nullable: false),
                    BusinessCharacteristicId = table.Column<Guid>("uuid", nullable: false),
                    MainItemImageId = table.Column<Guid>("uuid", nullable: false),
                    WarehouseItemId = table.Column<Guid>("uuid", nullable: false),
                    BrandId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        "FK_Items_Brands_BrandId",
                        x => x.BrandId,
                        "Brands",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Items_BusinessCharacteristicItems_BusinessCharacteristicId",
                        x => x.BusinessCharacteristicId,
                        "BusinessCharacteristicItems",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Items_CharacteristicItems_CharacteristicItemId",
                        x => x.CharacteristicItemId,
                        "Characteristics",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Items_WarehouseItems_WarehouseItemId",
                        x => x.WarehouseItemId,
                        "WarehouseItems",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "BagItemsUser",
                table => new
                {
                    BagItemsId = table.Column<Guid>("uuid", nullable: false),
                    BagUsersId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItemsUser", x => new {x.BagItemsId, x.BagUsersId});
                    table.ForeignKey(
                        "FK_BagItemsUser_AspNetUsers_BagUsersId",
                        x => x.BagUsersId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_BagItemsUser_Items_BagItemsId",
                        x => x.BagItemsId,
                        "Items",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "FavoriteItemsUser",
                table => new
                {
                    FavoriteItemsId = table.Column<Guid>("uuid", nullable: false),
                    FavoriteUsersId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItemsUser", x => new {x.FavoriteItemsId, x.FavoriteUsersId});
                    table.ForeignKey(
                        "FK_FavoriteItemsUser_AspNetUsers_FavoriteUsersId",
                        x => x.FavoriteUsersId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_FavoriteItemsUser_Items_FavoriteItemsId",
                        x => x.FavoriteItemsId,
                        "Items",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "MainItemImages",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Path = table.Column<string>("text", nullable: false),
                    ImageFormatId = table.Column<Guid>("uuid", nullable: false),
                    ItemId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainItemImages", x => x.Id);
                    table.ForeignKey(
                        "FK_MainItemImages_ImageFormats_ImageFormatId",
                        x => x.ImageFormatId,
                        "ImageFormats",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_MainItemImages_Items_ItemId",
                        x => x.ItemId,
                        "Items",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SecondaryItemImages",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Path = table.Column<string>("text", nullable: false),
                    ImageFormatId = table.Column<Guid>("uuid", nullable: false),
                    ItemId = table.Column<Guid>("uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryItemImages", x => x.Id);
                    table.ForeignKey(
                        "FK_SecondaryItemImages_ImageFormats_ImageFormatId",
                        x => x.ImageFormatId,
                        "ImageFormats",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_SecondaryItemImages_Items_ItemId",
                        x => x.ItemId,
                        "Items",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AgeTypesItem_Title",
                "AgeTypesItem",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "IX_AspNetUsers_CountryId",
                "AspNetUsers",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUsers_PhoneNumber",
                "AspNetUsers",
                "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_BagItemsUser_BagUsersId",
                "BagItemsUser",
                "BagUsersId");

            migrationBuilder.CreateIndex(
                "IX_Brands_LogoId",
                "Brands",
                "LogoId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Brands_Title",
                "Brands",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_BusinessCharacteristicItems_ArticleNumber",
                "BusinessCharacteristicItems",
                "ArticleNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_BusinessCharacteristicItems_CountryId",
                "BusinessCharacteristicItems",
                "CountryId");

            migrationBuilder.CreateIndex(
                "IX_BusinessCharacteristicItems_ManufacturerId",
                "BusinessCharacteristicItems",
                "ManufacturerId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_AgeTypeItemId",
                "Characteristics",
                "AgeTypeItemId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_ColorId",
                "Characteristics",
                "ColorId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_GenderId",
                "Characteristics",
                "GenderId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_ItemTypeId",
                "Characteristics",
                "ItemTypeId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_SeasonItemId",
                "Characteristics",
                "SeasonItemId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_SizeItemId",
                "Characteristics",
                "SizeItemId");

            migrationBuilder.CreateIndex(
                "IX_CharacteristicItems_SubTypeItemId",
                "Characteristics",
                "SubTypeItemId");

            migrationBuilder.CreateIndex(
                "IX_Colors_Title",
                "Colors",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_FavoriteItemsUser_FavoriteUsersId",
                "FavoriteItemsUser",
                "FavoriteUsersId");

            migrationBuilder.CreateIndex(
                "IX_Genders_Title",
                "Genders",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ImageFormats_Format",
                "ImageFormats",
                "Format",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_InitializeCountries_Name",
                "InitializeCountries",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Items_BrandId",
                "Items",
                "BrandId");

            migrationBuilder.CreateIndex(
                "IX_Items_BusinessCharacteristicId",
                "Items",
                "BusinessCharacteristicId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Items_CharacteristicItemId",
                "Items",
                "CharacteristicItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Items_Title",
                "Items",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Items_WarehouseItemId",
                "Items",
                "WarehouseItemId");

            migrationBuilder.CreateIndex(
                "IX_ItemTypes_Title",
                "ItemTypes",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Logos_ImageFormatId",
                "Logos",
                "ImageFormatId");

            migrationBuilder.CreateIndex(
                "IX_Logos_Path",
                "Logos",
                "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_MainItemImages_ImageFormatId",
                "MainItemImages",
                "ImageFormatId");

            migrationBuilder.CreateIndex(
                "IX_MainItemImages_ItemId",
                "MainItemImages",
                "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_MainItemImages_Path",
                "MainItemImages",
                "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Manufacturers_Title",
                "Manufacturers",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_SeasonTypes_Title",
                "SeasonTypes",
                "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_SecondaryItemImages_ImageFormatId",
                "SecondaryItemImages",
                "ImageFormatId");

            migrationBuilder.CreateIndex(
                "IX_SecondaryItemImages_ItemId",
                "SecondaryItemImages",
                "ItemId");

            migrationBuilder.CreateIndex(
                "IX_SecondaryItemImages_Path",
                "SecondaryItemImages",
                "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Sizes_ItemTypeId",
                "Sizes",
                "ItemTypeId");

            migrationBuilder.CreateIndex(
                "IX_Sizes_Size",
                "Sizes",
                "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_SubItemTypes_ItemTypeId",
                "SubTypes",
                "ItemTypeId");

            migrationBuilder.CreateIndex(
                "IX_SubItemTypes_Title",
                "SubTypes",
                "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "BagItemsUser");

            migrationBuilder.DropTable(
                "FavoriteItemsUser");

            migrationBuilder.DropTable(
                "MainItemImages");

            migrationBuilder.DropTable(
                "SecondaryItemImages");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "Items");

            migrationBuilder.DropTable(
                "Brands");

            migrationBuilder.DropTable(
                "BusinessCharacteristicItems");

            migrationBuilder.DropTable(
                "Characteristics");

            migrationBuilder.DropTable(
                "WarehouseItems");

            migrationBuilder.DropTable(
                "Logos");

            migrationBuilder.DropTable(
                "InitializeCountries");

            migrationBuilder.DropTable(
                "Manufacturers");

            migrationBuilder.DropTable(
                "AgeTypesItem");

            migrationBuilder.DropTable(
                "Colors");

            migrationBuilder.DropTable(
                "Genders");

            migrationBuilder.DropTable(
                "SeasonTypes");

            migrationBuilder.DropTable(
                "Sizes");

            migrationBuilder.DropTable(
                "SubTypes");

            migrationBuilder.DropTable(
                "ImageFormats");

            migrationBuilder.DropTable(
                "ItemTypes");
        }
    }
}
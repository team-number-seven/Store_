﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Store.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormatsImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Format = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatsImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Format = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    ImageFormatId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_FormatsImage_ImageFormatId",
                        column: x => x.ImageFormatId,
                        principalTable: "FormatsImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LogoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Logos_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SubItemTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTypes_SubItemTypes_SubItemTypeId",
                        column: x => x.SubItemTypeId,
                        principalTable: "SubItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ArticleNumber = table.Column<string>(type: "text", nullable: true),
                    CountItem = table.Column<long>(type: "bigint", nullable: false),
                    NumberSales = table.Column<long>(type: "bigint", nullable: false),
                    GenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    ColorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AgeTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uuid", nullable: false),
                    MainImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AgeTypes_AgeTypeId",
                        column: x => x.AgeTypeId,
                        principalTable: "AgeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Images_MainImageId",
                        column: x => x.MainImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BagItemUser",
                columns: table => new
                {
                    BagItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BagUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagItemUser", x => new { x.BagItemsId, x.BagUsersId });
                    table.ForeignKey(
                        name: "FK_BagItemUser_AspNetUsers_BagUsersId",
                        column: x => x.BagUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagItemUser_Items_BagItemsId",
                        column: x => x.BagItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteItemUser",
                columns: table => new
                {
                    FavoriteItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteUsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteItemUser", x => new { x.FavoriteItemsId, x.FavoriteUsersId });
                    table.ForeignKey(
                        name: "FK_FavoriteItemUser_AspNetUsers_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteItemUser_Items_FavoriteItemsId",
                        column: x => x.FavoriteItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageItem",
                columns: table => new
                {
                    ImagesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageItem", x => new { x.ImagesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ImageItem_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7f3e8119-16b6-428e-992f-b8bad9ce1c81"), "Absolute Zero" },
                    { new Guid("7bf02b1b-045d-43e4-a15c-0c99406d5c85"), "Payne's Grey" },
                    { new Guid("2e2ebd09-b619-417e-84d0-6e4107f1d899"), "Patriarch" },
                    { new Guid("5bdaa256-4704-4c4d-9b88-445dd4007d04"), "Pastel Yellow" },
                    { new Guid("a4c5a3ca-5347-4e01-a026-b19b8befa0cf"), "Pastel Violet" },
                    { new Guid("f42a1057-635f-407c-865d-50c8ebe4429e"), "Pastel Red" },
                    { new Guid("73abb0b8-0d1f-4ffe-af5d-51828f3f89f3"), "Pastel Purple" },
                    { new Guid("52ef103b-9722-4ed0-a805-82913430e98f"), "Pastel Pink" },
                    { new Guid("21c0480c-9ce8-4d5a-a3b6-1e97097d68af"), "Pastel Orange" },
                    { new Guid("fc79a177-2426-4efb-b4fc-3121033123ff"), "Pastel Magenta" },
                    { new Guid("8943e7f1-311f-4dc8-b450-cbc23812aba1"), "Pastel Green" },
                    { new Guid("f1f13755-fad4-4175-9930-876c0634b68a"), "Pastel Gray" },
                    { new Guid("b97ae929-8abf-494d-89ed-ad60c3d1cf48"), "Pastel Brown" },
                    { new Guid("44c4d1f5-03b2-4b2f-9e3c-c1b5cb8453c2"), "Pastel Blue" },
                    { new Guid("f357ab48-3a8b-4f46-adf8-af9102e60244"), "Paris Green" },
                    { new Guid("20bfa6c8-0008-484f-b3ab-cc9f0a485dc1"), "Paradise Pink" },
                    { new Guid("60d0eda0-fdd8-41f1-9649-808b60d12864"), "Peach" },
                    { new Guid("bd5787cc-94f2-47e5-9681-3fc87ef3aa08"), "Peach-Orange" },
                    { new Guid("09e7771f-378b-4a9b-9e91-51b8ff0f0c65"), "Peach Puff" },
                    { new Guid("6ca7bbd6-4596-462f-b5cf-14f4a3f97a20"), "Peach-Yellow" },
                    { new Guid("9fda479c-ccd1-4922-8757-cb14509fd24a"), "Persimmon" },
                    { new Guid("88956838-bdd5-49ac-8f73-87636e64baad"), "Persian Rose" },
                    { new Guid("1deabbfc-4018-4845-b3bf-256a7530d111"), "Persian Red" },
                    { new Guid("d1946dd1-391c-453f-ab6f-9a8f47b52d30"), "Persian Plum" },
                    { new Guid("f4a1e842-d074-48a5-9585-da070213fa7a"), "Persian Pink" },
                    { new Guid("682636a3-d2c5-4c0c-bd6b-74f1f0b94bfc"), "Persian Orange" },
                    { new Guid("29996c64-a268-4089-9d81-dba389c762ab"), "Persian Indigo" },
                    { new Guid("63f08c88-8055-4e7e-aca4-efb49a43e401"), "Papaya Whip" },
                    { new Guid("bca57018-c55a-47f6-a219-1f60c070d403"), "Persian Green" },
                    { new Guid("335a6972-d96f-4814-ab37-f3d98a5ef8be"), "Permanent Geranium Lake" },
                    { new Guid("87f264d3-016f-44e9-b471-f3019c49939f"), "Periwinkle" },
                    { new Guid("a6794355-0b65-4d01-8c67-835ca67741f6"), "Peridot" },
                    { new Guid("d8fa5715-63ee-4843-a64a-61d3ef7f5de5"), "Pearly Purple" },
                    { new Guid("0f1e0589-a61b-47b1-9db4-32d04c0cff70"), "Pearl Aqua" },
                    { new Guid("f1d952d6-3374-4e8b-a153-59a4fbc3c288"), "Pearl" },
                    { new Guid("f0ab1ec9-7008-4b22-a29b-d029c44cb031"), "Pear" },
                    { new Guid("90626042-467a-4d42-9001-df34274d85f6"), "Persian Blue" },
                    { new Guid("488ce9a9-2a4e-40b1-8ec2-09e6b5f7c996"), "Peru" },
                    { new Guid("b259ff82-f885-44a2-8cc4-ae6f89ce6635"), "Paolo Veronese Green" },
                    { new Guid("6b00dfc0-f9a7-43cd-b90a-28a8053a5d3b"), "Pale Violet-Red" },
                    { new Guid("061339d3-a8d9-44a3-903e-ca47b2aa573e"), "Pale Carmine" },
                    { new Guid("b4dffc04-246f-43df-99d6-acfb0f492531"), "Pale Brown" },
                    { new Guid("ff208796-2a9a-4b7d-87c7-ad36d6d4bda3"), "Pale Blue" },
                    { new Guid("c6a4c2a4-7879-4c0d-9238-e3b44b87b7bd"), "Pale Aqua" },
                    { new Guid("064f0226-0e47-489c-b3fe-65a9a61c20f3"), "Palatinate Purple" },
                    { new Guid("64103120-fa9a-4ad1-a05a-9f3377e25055"), "Palatinate Blue" },
                    { new Guid("41865b24-62cc-4446-b42b-75416c80acd6"), "Pakistan Green" },
                    { new Guid("37bb3be3-7d8b-4261-8399-40329e6767a0"), "Pacific Blue" },
                    { new Guid("5e2f872b-6875-49bf-993c-fd38e7e054ff"), "OU Crimson Red" },
                    { new Guid("e5d8e25e-861b-4c08-be23-3892c3f45d6a"), "Oxford Blue" },
                    { new Guid("146549a3-bc81-4495-aaf7-76b9049cbce6"), "Outrageous Orange" },
                    { new Guid("b1a699a7-19cf-44e1-b139-05d4ca846ea7"), "Outer Space" },
                    { new Guid("5bdefbbb-324e-4689-a40f-165e114bd1d8"), "Otter Brown" },
                    { new Guid("ee9ec9ae-a25a-4fdc-a2d4-a14ef15b74bb"), "Orioles Orange" },
                    { new Guid("cfc24d48-c300-4013-8822-0cf155918700"), "Orchid Pink" },
                    { new Guid("2de58736-2ca4-4502-ade0-41f837f23478"), "Pale Cerulean" },
                    { new Guid("bef94fd4-46d8-4368-8842-a1299e534737"), "Pale Chestnut" },
                    { new Guid("2976595b-a3e3-43b6-ae38-34d6e8fd504e"), "Pale Copper" },
                    { new Guid("6a5298ae-eb53-47d7-8f16-f12aeb1e898a"), "Pale Cornflower Blue" },
                    { new Guid("5b8378fb-9879-4ce5-99da-3824e0a4b2ce"), "Pale Violet" },
                    { new Guid("88ff96ae-ad53-4a81-8d54-ed4f4c3f6af5"), "Pale Turquoise" },
                    { new Guid("ebc7701d-ff13-42e5-aed5-0ec7bb9ba4a7"), "Pale Taupe" },
                    { new Guid("7d3ee98f-9169-4cb5-b6b0-cf71e4ccfc11"), "Pale Spring Bud" },
                    { new Guid("064a7bb4-0042-405f-9776-0e67865c08fb"), "Pale Silver" },
                    { new Guid("2febbd37-2c58-4646-89c1-76acf6d0c56f"), "Pale Robin Egg Blue" },
                    { new Guid("2ca300f0-63d8-432b-99e8-0dacc188bdd9"), "Pale Red-Violet" },
                    { new Guid("35ce66bb-4c10-4f66-a914-29f4eccec5c6"), "Pansy Purple" },
                    { new Guid("e3d19fb7-8488-4e75-9d88-3580ce97655b"), "Pale Plum" },
                    { new Guid("375b58a8-f6c2-49a9-8df1-3642cb034a8e"), "Pale Magenta-Pink" },
                    { new Guid("dc2ea6b2-7036-4c0a-aa42-4703f184b250"), "Pale Magenta" },
                    { new Guid("ff17eebb-a0cb-4987-ab73-c658685060ef"), "Pale Lavender" },
                    { new Guid("271575a1-0af7-4720-b371-4722f28436da"), "Pale Green" },
                    { new Guid("74643a10-f962-4c49-8bf0-6bd06e3712d5"), "Pale Goldenrod" },
                    { new Guid("4b88eb33-1925-4039-b780-782f8e30fc30"), "Pale Gold" },
                    { new Guid("b90e743e-9c73-4a04-8710-f5e1f1a1d626"), "Pale Cyan" },
                    { new Guid("0c3f8b1f-8438-4794-b3df-5a0673223144"), "Pale Pink" },
                    { new Guid("439036ac-ecdb-47b4-88ec-013b6b4fa81d"), "Orchid" },
                    { new Guid("d3040860-1f3b-4a27-9e00-8b6b8abbe69e"), "Pewter Blue" },
                    { new Guid("c298051d-b25a-497e-b828-eb581f806df5"), "Phthalo Blue" },
                    { new Guid("2249d5cc-cb9d-4594-9fb5-7bd553523953"), "Raisin Black" },
                    { new Guid("cbfe6fee-d124-4ddb-8243-18ab8a53b303"), "Radical Red" },
                    { new Guid("3788d348-65d8-4011-b196-a60310e2c60c"), "Rackley" },
                    { new Guid("6ffe8303-23c7-41a0-af46-db240ebe446d"), "Quinacridone Magenta" },
                    { new Guid("81fcc324-7447-40dd-855e-5272b41dcc35"), "Quick Silver" },
                    { new Guid("80d7f4f7-5ca1-421e-84d6-920aefed27df"), "Queen Pink" },
                    { new Guid("cc6dc2cf-4484-44a1-8f8c-9e46b774f8d9"), "Queen Blue" },
                    { new Guid("30c62965-91ef-49e3-8734-485ef14e1df7"), "Quartz" },
                    { new Guid("438b07ec-ad1c-4adb-95c4-76086ecf6d46"), "Purpureus" },
                    { new Guid("1dda3288-16a3-4419-8879-1761c75ba0cd"), "Purple Taupe" },
                    { new Guid("0ded8e74-02fd-4cf3-96b8-f973bba30720"), "Purple Plum" },
                    { new Guid("31fde518-46d8-485b-bd77-98a59336059d"), "Purple Pizzazz" },
                    { new Guid("df638da0-cfc0-420e-aa4f-8912f4a2f21b"), "Purple Navy" },
                    { new Guid("301ed6a9-726b-4624-9bcb-79a96e834eea"), "Purple Mountain Majesty" },
                    { new Guid("2b9f6eda-fc32-4054-ba8c-255b1a2f0da1"), "Purple Heart" },
                    { new Guid("97d13bbc-f86d-4ef6-8d95-ea6ce22f9213"), "Rajah" },
                    { new Guid("ec76a2c2-47f9-468e-870c-9b3756d21207"), "Raspberry" },
                    { new Guid("eac6fd47-de53-46f7-ab90-1e550874580a"), "Raspberry Glace" },
                    { new Guid("587f27b9-83f1-40e4-9f1e-84df49c9219b"), "Raspberry Pink" },
                    { new Guid("7b0d1859-ad17-48ce-a16b-0920ae0b2202"), "Red Devil" },
                    { new Guid("b99038df-aa33-4a0f-a1e7-0e5face5ad1d"), "Red-Brown" },
                    { new Guid("f5e39cc1-1fea-48c1-a334-26c01da99a1b"), "Red (RYB)" },
                    { new Guid("ab1cebed-65ea-4d01-b8a6-11f9d4790080"), "Red (Pigment)" },
                    { new Guid("17055c10-cf7c-4f1f-abb2-518a06b24f5f"), "Red (Pantone)" },
                    { new Guid("e463a841-35a9-4ced-a8d7-e9c316880ead"), "Red (NCS)" },
                    { new Guid("10db4745-c7af-49df-b48e-e7ab2a1a558d"), "Red (Munsell)" },
                    { new Guid("92e2591f-d135-42d2-959f-ae58f73981af"), "Purple (X11)" },
                    { new Guid("f9a767ac-2c83-44b3-991b-8f79baac9c35"), "Red (Crayola)" },
                    { new Guid("fbded74e-428e-4665-affe-b00492b23176"), "Rebecca Purple" },
                    { new Guid("9945ce9f-b791-405e-9649-fa399367b50a"), "Razzmic Berry" },
                    { new Guid("704b722d-88db-4622-a7fc-2b1b023b8ba4"), "Razzmatazz" },
                    { new Guid("db37d9a4-f847-4923-b926-cf08134d9622"), "Razzle Dazzle Rose" },
                    { new Guid("e0c21f3e-41db-4aa1-a4de-372c97ba247b"), "Raw Umber" },
                    { new Guid("ea382fe6-6fce-4bcd-8a8f-6f140556a502"), "Raw Sienna" },
                    { new Guid("cc153b2a-dc4e-4a61-a780-b05204111d9a"), "Raspberry Rose" },
                    { new Guid("ef08768b-e83e-4b94-ae88-690b881ccc4f"), "Red" },
                    { new Guid("ca8d3658-2109-47ae-8105-dff8a826e771"), "Phlox" },
                    { new Guid("166010cf-0f43-4b3d-847b-4a159a1fc455"), "Purple (Munsell)" },
                    { new Guid("e6598e14-f95e-4e67-9cb7-cee7371fa6ec"), "Pumpkin" },
                    { new Guid("59988059-92d3-47d3-88a6-f7ce874ce41d"), "Pink Sherbet" },
                    { new Guid("58d563bd-2848-45a2-a476-30b541c3d403"), "Pink Raspberry" },
                    { new Guid("da94b760-56f2-4d5e-9888-1a021df020ed"), "Pink Pearl" },
                    { new Guid("9561b2af-037e-4344-ae5e-d5787cb1bd1e"), "Pink-Orange" },
                    { new Guid("18f23075-fa84-4911-a532-afb5c1fa8865"), "Pink Lavender" },
                    { new Guid("e783a5a7-af76-4023-a01f-7a4cc2ddea3a"), "Pink Lace" },
                    { new Guid("1b0ec78c-d9ce-449d-867e-695a304d2ba5"), "Pink Flamingo" },
                    { new Guid("2ccf69fc-5f34-4fda-b9fe-29ccb28640df"), "Pink (Pantone)" },
                    { new Guid("0d9ea5f8-abb8-4659-a45c-630ff63d4866"), "Pink" },
                    { new Guid("9f006123-a364-4850-bb65-8003afd1d290"), "Pineapple" },
                    { new Guid("51ab4e29-da6c-4eee-a7dd-15f5b659a7ef"), "Pine Green" },
                    { new Guid("06fbfa6b-6a30-485b-b5d2-f97a9f82d762"), "Piggy Pink" },
                    { new Guid("fecb709a-f260-4f90-b2b3-b016f421d3ad"), "Pictorial Carmine" },
                    { new Guid("5903fa37-2901-4c2c-a487-0f3c7a684fba"), "Picton Blue" },
                    { new Guid("09226640-42a6-4056-9072-eec476271e42"), "Phthalo Green" },
                    { new Guid("740395e5-dd78-4255-908c-23400f2ad03c"), "Pistachio" },
                    { new Guid("e27c0c2b-c140-4a83-82dc-6014f462f7fb"), "Pixie Powder" },
                    { new Guid("1959c69f-6b12-4d2d-9607-be2f8123e6b6"), "Platinum" },
                    { new Guid("39ab015e-79f7-4988-8bfc-1f92a9d103f9"), "Plum" },
                    { new Guid("e92a883e-3b42-486c-acbb-692280db93a8"), "Pullman Green" },
                    { new Guid("c536fcc0-57d1-4482-a1a1-38af53ac0041"), "Pullman Brown (UPS Brown)" },
                    { new Guid("ff0dfd03-a526-4d0f-a942-e4541d93a721"), "Puce Red" },
                    { new Guid("8a918ab3-9759-46a1-aab3-e4ac0f1eac8f"), "Puce" },
                    { new Guid("4d82c160-3948-490c-bc0b-8d15c365596f"), "Psychedelic Purple" },
                    { new Guid("7b9a5ef3-f9d9-45d3-928f-dffe52e1836a"), "Prussian Blue" },
                    { new Guid("2cd7c347-d069-4d19-9451-ee8fe60a86f2"), "Prune" },
                    { new Guid("eb947a90-149c-4d99-82d3-277a95e02c5f"), "Purple (HTML)" },
                    { new Guid("a6c01928-60d4-4599-aff4-31bf662f409b"), "Princeton Orange" },
                    { new Guid("dfcdf155-87e0-4313-a670-d050dc248497"), "Powder Blue" },
                    { new Guid("8d447140-5955-4bcc-beca-42a23fc51372"), "Portland Orange" },
                    { new Guid("47daa4be-de92-469d-b471-7aee143eeace"), "Popstar" },
                    { new Guid("e0b6c26a-4c7c-4996-bd43-cc5ce1a0d8b8"), "Pomp And Power" },
                    { new Guid("092e54cc-3f28-4e74-87a1-d94ef83043f1"), "Polished Pine" },
                    { new Guid("12eb6dc0-499f-40c8-a563-d3961cd8b602"), "Plump Purple" },
                    { new Guid("82902715-cb17-4c1d-b6ec-c3ec6cc0ccc4"), "Plum (Web)" },
                    { new Guid("eeb7bd64-f0be-400d-9348-5cf2b9ffb60b"), "Princess Perfume" },
                    { new Guid("1fb8c305-22d4-4c88-83f7-b9889bdfee0e"), "Orange-Yellow" },
                    { new Guid("a6f01079-3295-4238-bc18-9045a9f53567"), "Orange Soda" },
                    { new Guid("c52aaa99-fdd9-47c5-9bfb-59eed3163a6d"), "Orange-Red" },
                    { new Guid("2b808069-3b01-4d63-a5dc-53c988a77f1b"), "Maya Blue" },
                    { new Guid("4d0b54ff-3381-40d5-82a7-07f513d1812b"), "May Green" },
                    { new Guid("845b5f48-d55d-4e1f-a5cf-be87ab6af297"), "Maximum Yellow" },
                    { new Guid("d58269a4-5581-4e6f-8f73-aa3d074a5b7e"), "Maximum Blue" },
                    { new Guid("18aca111-c9b2-4f7f-a36b-b1047e41405c"), "Mauvelous" },
                    { new Guid("2bc4deee-3634-44bb-8ee9-4c086b2e07cb"), "Mauve Taupe" },
                    { new Guid("906b3f22-fc1b-4e5a-b5bb-6f6382bb3c8d"), "Mauve" },
                    { new Guid("0bc9b884-2f75-459d-ad38-bd8f3e53d6b9"), "Maroon (X11)" },
                    { new Guid("b7454d6d-1ac0-4516-8dae-553413a4ce87"), "Maroon (HTML/CSS)" },
                    { new Guid("5f6ce551-acf3-4009-9fbf-9bc9ebb564b8"), "Maroon (Crayola)" },
                    { new Guid("47342af6-9e4d-4daf-8630-7cbcc3fc1e16"), "Marigold" },
                    { new Guid("1a3caea0-06f6-43aa-a142-4cdaf21ae9df"), "Mardi Gras" },
                    { new Guid("c8b7e11b-352c-40dd-b304-53768f78bfd9"), "Mantis" },
                    { new Guid("dfa78859-6925-486f-9d79-6660ed53caaa"), "Mango Tango" },
                    { new Guid("794550b0-40b4-4730-9275-b29c39e3f84f"), "Mandarin" },
                    { new Guid("9072df24-3109-498e-b963-d45e683e24f1"), "Meat Brown" },
                    { new Guid("aaae6add-585a-47cc-ae61-7508eeea5ac3"), "Medium Aquamarine" },
                    { new Guid("8e86248d-4083-4777-8c56-2ee21a438cdc"), "Medium Blue" },
                    { new Guid("50a5f98b-e6f4-4860-a41d-b906d2c34625"), "Medium Candy Apple Red" },
                    { new Guid("f8b22cd2-5ee8-4e4b-9f2c-de5a44855aa5"), "Medium Taupe" },
                    { new Guid("38dfcbe4-c4fa-4d62-b447-bd9e957dbb95"), "Medium Spring Green" },
                    { new Guid("192d2728-5560-4b24-9d0c-20e23684f5e7"), "Medium Spring Bud" },
                    { new Guid("c8e978da-64ac-48b8-aca8-2f7c12eb0481"), "Medium Slate Blue" },
                    { new Guid("9be4a626-f474-4048-b25c-35f7af41d79f"), "Medium Sky Blue" },
                    { new Guid("49929e8d-92b6-46bc-ba26-0be166947c7f"), "Medium Sea Green" },
                    { new Guid("ea236efc-acc0-4d09-bf63-25758f941de4"), "Medium Ruby" },
                    { new Guid("56042367-76f0-49e9-bd86-f246b010817c"), "Manatee" },
                    { new Guid("8ab08946-2d96-4fc2-913b-bab5b54f48cf"), "Medium Red-Violet" },
                    { new Guid("7e223078-9300-4bf6-b030-572573317b11"), "Medium Persian Blue" },
                    { new Guid("bdef1302-3f6a-40ed-8ac5-2c48fccfd6a1"), "Medium Orchid" },
                    { new Guid("6404fd71-e270-46c9-893a-cc5483db7e2f"), "Medium Lavender Magenta" },
                    { new Guid("61e2a5d7-5dec-430f-87ea-aeb311a17c72"), "Medium Jungle Green" },
                    { new Guid("4183a372-e242-42b3-8f0d-96ea96041f6d"), "Medium Electric Blue" },
                    { new Guid("8d0ef3b3-820d-4b80-a065-30dbea879bbf"), "Medium Champagne" },
                    { new Guid("8834a7be-a80b-48ff-af95-d9ef115148d3"), "Medium Carmine" },
                    { new Guid("be7ab970-3b86-431b-9872-5952c4e0349e"), "Medium Purple" },
                    { new Guid("9557d977-8001-41ce-9edc-371a98d389c6"), "Medium Turquoise" },
                    { new Guid("a89c5cc4-8e50-463a-b2d2-344e6c2c7302"), "Malachite" },
                    { new Guid("c45a3b9b-78c4-4ad7-96e8-e0b6c32aa280"), "Maize" },
                    { new Guid("408e5425-a6c9-4670-b3b0-ca0493173a7b"), "Liseran Purple" },
                    { new Guid("ef5150d9-4925-45cb-b98a-909c945c4838"), "Lion" },
                    { new Guid("b70b36a7-e7db-4c2a-b2c6-0483301b4f0b"), "Linen" },
                    { new Guid("e72c8f5d-c73c-43f7-8a1c-688a974d18e2"), "Lincoln Green" },
                    { new Guid("9b1c13c7-3efc-455c-a1e9-2843dfc683a3"), "Limerick" },
                    { new Guid("43eb40c2-2bf4-45a2-b5eb-6972ca04ec17"), "Lime Green" },
                    { new Guid("76d9094a-6d06-4071-a42b-bcaa7f3e5896"), "Lime (Web) (X11 Green)" },
                    { new Guid("45113722-e1ab-4401-9bf6-e67e1fde5e9f"), "Lime (Color Wheel)" },
                    { new Guid("ac2c0393-5853-4219-ab13-36881eb5236a"), "Lilac Luster" },
                    { new Guid("2e2d2397-ef70-4671-bbeb-50cc06a80302"), "Lilac" },
                    { new Guid("ef867c8e-84ce-4a9c-8116-436176e61ec0"), "Light Yellow" },
                    { new Guid("46a2ceaf-a43f-4cc8-8540-ce96d5e83822"), "Light Thulian Pink" },
                    { new Guid("b299eb03-3fb9-4e69-b0a2-19a09a91b535"), "Light Taupe" },
                    { new Guid("65adf1e2-850f-4dff-82b5-989f0dd0b2fa"), "Light Steel Blue" },
                    { new Guid("2858490c-df3c-4644-9b5f-b3f21d0a8a70"), "Light Slate Gray" },
                    { new Guid("9f3f827a-b8a7-4c73-a2e3-a368ec0a3749"), "Little Boy Blue" },
                    { new Guid("0da0748d-048f-42b2-90f4-643c8c188b24"), "Liver" },
                    { new Guid("f8cd5246-87ab-454c-86d3-e4a2eb479bfc"), "Liver (Dogs)" },
                    { new Guid("f1a98730-1907-47b4-ae46-9154e647692f"), "Liver (Organ)" },
                    { new Guid("7bfdab83-16b2-4825-a782-4aa15d7d6045"), "Mahogany" },
                    { new Guid("94865a5d-5484-4b7a-a3fb-04a73797fec5"), "Magnolia" },
                    { new Guid("aa4f96d5-c487-4008-8650-211bb7a406f6"), "Magic Potion" },
                    { new Guid("42f552e7-77fd-4a31-a6be-2b1d735137d0"), "Magic Mint" },
                    { new Guid("04fc5e64-759f-41a3-af4d-a4cfcc242257"), "Magenta-Pink" },
                    { new Guid("32cb7a6e-6998-48e9-bebc-d4a6ccff64b6"), "Magenta Haze" },
                    { new Guid("481476f2-1355-43fb-84b5-f49b6293ee0c"), "Magenta (Process)" },
                    { new Guid("06343d96-a878-41ab-9905-2ecae9f7e0a7"), "Majorelle Blue" },
                    { new Guid("ad9a53ae-663c-4924-a078-b656127661e3"), "Magenta (Pantone)" },
                    { new Guid("b9e193ce-d493-41af-8bb6-65e75ebdd464"), "Magenta (Crayola)" },
                    { new Guid("ba38bb3e-5bd3-41ed-b1fc-77ea2896a331"), "Magenta" },
                    { new Guid("7a130666-2bb6-4326-ac33-88ff21fdbbbb"), "Macaroni And Cheese" },
                    { new Guid("533252ac-4a93-4358-a37c-3e806c819df6"), "Lust" },
                    { new Guid("78c2fb60-961e-4259-993d-65a45f28d590"), "Lumber" },
                    { new Guid("2183900c-5e8f-4d30-84a5-2176b60c4991"), "Livid" },
                    { new Guid("a2eeece9-8c1c-45a9-8c2c-9b29f2390def"), "Liver Chestnut" },
                    { new Guid("3867435e-ef0a-48e1-95b7-fe9c86d49c35"), "Magenta (Dye)" },
                    { new Guid("a9f0b178-6b90-4615-975a-1bb7eedebf0d"), "Medium Tuscan Red" },
                    { new Guid("2d72cf05-b51e-4b13-81a5-42378856e871"), "Medium Vermilion" },
                    { new Guid("c2479d09-736a-4439-bb20-4d6f9bbc1092"), "Medium Violet-Red" },
                    { new Guid("4c7f08e1-f558-4e92-9f49-c2729814b39e"), "Old Burgundy" },
                    { new Guid("d1b3224c-5eef-429e-956e-b225391726bb"), "Ogre Odor" },
                    { new Guid("c58e064e-b077-4acc-93e5-0d87aaee6c22"), "Office Green" },
                    { new Guid("c80aa8d3-b27e-485d-80b0-d7c864973d31"), "Ochre" },
                    { new Guid("8776b3d0-cd3b-4fa2-b5b1-2841df690583"), "Ocean Green" },
                    { new Guid("bc231dfa-7d8c-49e1-8d2d-1c3b0ce1577c"), "Ocean Boat Blue" },
                    { new Guid("78e57333-09fe-461e-89ad-17660c510b22"), "Ocean Blue" },
                    { new Guid("4c0cecad-e65f-4a31-a3ce-d89ffe9efaa0"), "Nyanza" },
                    { new Guid("499660dd-53d4-42f1-aad4-a32ffa8955e6"), "North Texas Green" },
                    { new Guid("5ec303f0-36d1-41ff-b174-a68fc3faab60"), "Non-Photo Blue" },
                    { new Guid("f577a322-c66e-4549-8b2f-9aa5327fcce5"), "Nickel" },
                    { new Guid("233f1b7e-9648-48ea-a505-9347c7c9e392"), "New York Pink" },
                    { new Guid("18105000-d733-4c43-a4df-4e8a8929cac5"), "New Car" },
                    { new Guid("aa40eaa0-eb1d-4507-b8f9-583bfdb9111e"), "Neon Green" },
                    { new Guid("c9b0fe1f-8f56-4dd3-9d3b-04978d4a62e8"), "Neon Fuchsia" },
                    { new Guid("4aa1291d-2b52-412d-a8cf-10ce98064340"), "Old Gold" },
                    { new Guid("5ee0e80b-4dc7-4aca-902e-eaccdfebe78f"), "Old Heliotrope" },
                    { new Guid("96f2086e-099d-4548-8822-1eeeb945852b"), "Old Lace" },
                    { new Guid("95a71e2c-0785-482e-9c9d-d3b9dcaa45a6"), "Old Lavender" },
                    { new Guid("0310ec78-52b9-4807-b6d6-0bfeefca2e68"), "Orange Peel" },
                    { new Guid("63202eaf-83ad-4741-8a5e-2ca4fe45bedb"), "Orange (Web)" },
                    { new Guid("254bdfa9-abc8-457e-b5fd-2309132c9523"), "Orange (RYB)" },
                    { new Guid("9731e6d5-62e5-41f3-a93e-4e6c75e351db"), "Orange (Pantone)" },
                    { new Guid("23606a18-f9c0-413e-b1cf-df4e1c0f90aa"), "Orange (Crayola)" },
                    { new Guid("32e186e0-5c8e-463a-beb8-021ea7f4c7fc"), "Orange (Color Wheel)" },
                    { new Guid("b24a636d-a172-4d64-b8b2-9d7fec091e48"), "Opera Mauve" },
                    { new Guid("b74a026e-6193-4eff-b5bc-e0d1e964de6d"), "Neon Carrot" },
                    { new Guid("0d810bd1-e9e1-4c9c-be6a-89e97813595a"), "Onyx" },
                    { new Guid("e56dedcc-b3f5-4594-8506-bfe3f01c3af4"), "Olive Drab #7" },
                    { new Guid("b24f7bbc-ea0e-450d-aeb6-b5d55eb12898"), "Olive Drab (#3)" },
                    { new Guid("3b0062be-9865-4417-a05b-06cbe92a6745"), "Olive" },
                    { new Guid("3c8b52ff-a108-49cd-bbea-3b358ed62e14"), "Old Silver" },
                    { new Guid("7f09a8ed-5f6c-4c64-b7eb-57cd5fec3b24"), "Old Rose" },
                    { new Guid("65130f10-02fa-49cc-a69a-68ab4735dcb0"), "Old Moss Green" },
                    { new Guid("79355032-aeff-4e9d-ba23-002bf801929f"), "Old Mauve" },
                    { new Guid("27c56fe0-19ec-4963-b125-551b834a7f08"), "Olivine" },
                    { new Guid("8a70af29-2702-49a9-8e84-2eb6051a8276"), "Navy Purple" },
                    { new Guid("64b1e272-f4fd-468f-b1b7-5272e109286f"), "Navy" },
                    { new Guid("54af9813-221a-4bb0-ae45-bc1122e1a136"), "Navajo White" },
                    { new Guid("6208374c-ff4a-4708-8115-acb3db80485b"), "Mint Cream" },
                    { new Guid("64d02cad-c0dd-4ca5-8f9c-7ab3df1ebb70"), "Mint" },
                    { new Guid("d906991f-6ad5-4af4-bcce-9fdd5e3b1daf"), "Minion Yellow" },
                    { new Guid("e5584411-b491-4588-b9f3-c9ac2b62912a"), "Ming" },
                    { new Guid("085eadb6-ce85-4621-85c2-cf990f41f530"), "Mindaro" },
                    { new Guid("244dca63-b4b6-4b41-bfcc-b5d5bf0e3f8f"), "Mikado Yellow" },
                    { new Guid("f54b2904-89f2-4032-be98-d959178fc5fd"), "Midnight Green (Eagle Green)" },
                    { new Guid("5e57a36f-17a2-4d9a-84ac-e1bef6b046fd"), "Mint Green" },
                    { new Guid("fc9ca826-d605-4bd6-a43e-2abf7d31f5b9"), "Midnight Blue" },
                    { new Guid("6f527e5a-ce52-4c5f-a7f5-4e68a0acb50a"), "Mexican Pink" },
                    { new Guid("4bf4fea3-57e3-4cd0-bfc5-ace2fd3e6ba2"), "Metal Pink" },
                    { new Guid("c857e0ae-e38d-469d-85cf-bfbbad0887f4"), "Metallic Sunburst" },
                    { new Guid("7396c625-b2ac-4b9a-9fdc-d99af62b9faa"), "Metallic Seaweed" },
                    { new Guid("5b2eca53-ef77-4a35-ab13-1a965b650989"), "Melon" },
                    { new Guid("2f57ea8d-f920-44c8-8b39-4d789e53eda8"), "Mellow Yellow" },
                    { new Guid("d954854a-acac-47b2-b1d7-8c01c7651463"), "Mellow Apricot" },
                    { new Guid("0568ccbf-bf92-48fa-808f-128be820002a"), "Midnight" },
                    { new Guid("5a257bc9-e2e3-4e23-84f2-b161a4241a08"), "Red-Orange" },
                    { new Guid("31a118a9-c2ad-4a07-9cc2-35283deedccb"), "Misty Rose" },
                    { new Guid("34797b32-8456-41f8-9023-511b2c331298"), "Mode Beige" },
                    { new Guid("497a1371-c04b-4521-87b8-c4d8bc7609f9"), "Naples Yellow" },
                    { new Guid("a312d430-db09-4569-b444-ce7e91399e24"), "Napier Green" },
                    { new Guid("a1d763a5-0804-4ff7-b996-0d9ed5693390"), "Nadeshiko Pink" },
                    { new Guid("e14b66b3-a37c-4701-b3cb-b3eb5edbde66"), "Mystic Maroon" },
                    { new Guid("4c24c682-7a41-4367-82eb-4bbfa594fcbf"), "Mystic" },
                    { new Guid("fb9a87a7-ebf5-4ebf-b318-33b1a40e78b0"), "Myrtle Green" },
                    { new Guid("d9eecfa3-dfe6-4a57-8d81-e19b782a18f4"), "Mustard" },
                    { new Guid("c76a89c6-9e1c-48d1-b28f-ce461190a26d"), "Moccasin" },
                    { new Guid("b62d0767-cbcf-4f28-8380-55698cbcae0a"), "Mummy's Tomb" },
                    { new Guid("c8b6a527-e5c6-4bb5-91dd-99e484a70c62"), "Mughal Green" },
                    { new Guid("6a88709f-8be2-4de1-a120-506f29030184"), "MSU Green" },
                    { new Guid("73a4d075-889d-49eb-959e-7f2a9b7a046c"), "Mountbatten Pink" },
                    { new Guid("28e7dd78-b1bd-4e2e-82a6-3764d99bb0b6"), "Mountain Meadow" },
                    { new Guid("79c8e194-8c62-45ca-a609-9f197670a440"), "Moss Green" },
                    { new Guid("347ff49b-4710-47fe-8020-713eb48f04e2"), "Mordant Red 19" },
                    { new Guid("30f0dbf4-1989-4bfa-8180-137b613e031b"), "Moonstone Blue" },
                    { new Guid("606ebf5a-8c68-4630-8229-4b3a936454d9"), "Mulberry" },
                    { new Guid("f578497e-0095-4dc0-9483-4ee3552ce239"), "Light Sky Blue" },
                    { new Guid("380ba0a4-abcf-4cd6-8d45-dde5b98631e5"), "Red-Purple" },
                    { new Guid("060ad90a-7b4a-4a00-8384-70f2c8ecef5e"), "Red-Violet" },
                    { new Guid("c4f1a3fc-897e-4ec4-b979-0e00d45495bd"), "Ultra Pink" },
                    { new Guid("2818cd8f-7e2c-4a65-9973-d9b86cf5db49"), "Ultramarine Blue" },
                    { new Guid("0f12779a-7a12-4c60-9ee5-40621999a24b"), "Ultramarine" },
                    { new Guid("dcd5badb-8c60-4b42-a3d9-9181e8d55778"), "UFO Green" },
                    { new Guid("03e364aa-8e3b-4d39-b055-431503f7561a"), "UCLA Gold" },
                    { new Guid("8adb6776-d0db-4e12-9dc0-5a2067b3f477"), "UCLA Blue" },
                    { new Guid("5eb0a1be-a0d8-4dcd-9d36-dc82b06b8199"), "Ube" },
                    { new Guid("cd1d4c51-4966-4093-abf2-466bf145c5f9"), "UA Red" },
                    { new Guid("e9f58c1a-beda-45ff-ad6f-4a17dcbbac2e"), "UA Blue" },
                    { new Guid("5b364b6f-2bd2-4f3a-b008-cc085197bb86"), "Tyrian Purple" },
                    { new Guid("857f6b7b-af35-4ea6-afc0-5c4ee591d01b"), "Twilight Lavender" },
                    { new Guid("8c01dfe4-eeeb-427a-80ac-1f6220cf104d"), "Tuscany" },
                    { new Guid("f8b34603-2d5a-442a-bf0e-e7823a0be819"), "Tuscan Tan" },
                    { new Guid("e6fc2ce5-db58-43a2-bb28-c77826c13fa0"), "Tuscan Red" },
                    { new Guid("5f67d7a3-8466-475c-a043-14ece7e0b9d1"), "Tuscan Brown" },
                    { new Guid("498c70d4-5d01-424c-a9e4-79bf3ffaf9ec"), "Ultra Red" },
                    { new Guid("07e807df-c4a7-4ea9-8a3c-fea69e3ce09e"), "Umber" },
                    { new Guid("67250448-5b0d-4bf4-a453-d86386a5e581"), "Unbleached Silk" },
                    { new Guid("88a11131-99b7-497c-b577-084f6eded177"), "United Nations Blue" },
                    { new Guid("ace7e552-8e60-4b2e-bc51-d54c3482b96b"), "Venetian Red" },
                    { new Guid("8b4f9651-b887-4122-a1cd-9b2ef872b23e"), "Vegas Gold" },
                    { new Guid("ffce1df1-d4b9-4d0a-a25f-f5694555ca62"), "Vanilla Ice" },
                    { new Guid("8a82e959-1da3-425e-965d-1affb15b8c66"), "Vanilla" },
                    { new Guid("375e4c89-36e9-4724-ab09-c6d167964cd9"), "Van Dyke Brown" },
                    { new Guid("60558965-e88e-4349-8264-c65c572139d6"), "Utah Crimson" },
                    { new Guid("3b7fc3c3-aa68-4400-bed8-e4f9114a8b13"), "University Of Tennessee Orange" },
                    { new Guid("d11e4aaf-14c8-4b89-92b8-a3bcbc8220aa"), "Tuscan" },
                    { new Guid("ed19bff5-e81e-4e78-a916-2bd6b47d3d47"), "USC Gold" },
                    { new Guid("9379f727-cb3b-4e4b-a9d2-746e9eb5c40a"), "USAFA Blue" },
                    { new Guid("8da478e9-a7c5-4d4a-8979-e403b30a2eca"), "Urobilin" },
                    { new Guid("e936b0c7-ac87-4c07-b4e0-ef2001604aa3"), "Upsdell Red" },
                    { new Guid("54f403fe-a183-45de-8cdd-3bce9811e5f5"), "UP Maroon" },
                    { new Guid("7a36e77b-78f4-4271-8a49-d9e0b91ad250"), "UP Forest Green" },
                    { new Guid("9bafe624-da49-4724-99bb-a02be02be140"), "Unmellow Yellow" },
                    { new Guid("f0aaf072-438e-423c-a9c2-fcf76eb2558c"), "University Of California Gold" },
                    { new Guid("4033c3a0-6d90-41f6-94b6-1e67cd64ea6c"), "USC Cardinal" },
                    { new Guid("3e101de8-1ad6-4763-a665-234e1c5856d2"), "Verdigris" },
                    { new Guid("79af353c-fe56-431d-9314-74f8cea91af8"), "Turtle Green" },
                    { new Guid("3fa181aa-a741-40c4-858c-fbc26468f065"), "Turquoise Blue" },
                    { new Guid("c10c6c19-1e63-464a-949c-02335db7f4c7"), "Terra Cotta" },
                    { new Guid("7933dfc8-9892-4a66-91a3-2e9e0a52607c"), "Tenné" },
                    { new Guid("24002d71-538d-4ab7-9d82-0a9d70d539d5"), "Telemagenta" },
                    { new Guid("906005ca-3a16-49b0-b88d-738f3f49b813"), "Teal Green" },
                    { new Guid("762864a9-5c66-4c17-9383-b43fcbc131db"), "Teal Deer" },
                    { new Guid("1ca078b0-7554-4b73-aa7d-6df39961ffd3"), "Teal Blue" },
                    { new Guid("129da7ba-1ab8-4916-98fb-e340b75877ef"), "Teal" },
                    { new Guid("cc392f8f-7ee8-4890-ab55-e80779fb9f63"), "Tea Rose" },
                    { new Guid("3e54f3e0-8f6d-469a-9021-dad4f3b9a3da"), "Tea Green" },
                    { new Guid("67796ce6-bf8f-4a9e-90b1-8b74e726c5a7"), "Taupe Gray" },
                    { new Guid("19cad7f1-5c4f-483c-97f5-fa6939c62c62"), "Taupe" },
                    { new Guid("4737e6e1-09e0-40c5-9622-9d51823fa904"), "Tart Orange" },
                    { new Guid("6b771bd8-7581-4313-ae6b-942404b95620"), "Tango Pink" },
                    { new Guid("d7bbbb7a-e530-4906-af82-bbb1407208e4"), "Tangerine Yellow" },
                    { new Guid("654a7912-1430-4156-9a28-d21a2cc97c59"), "Tangerine" },
                    { new Guid("01ee7653-7660-4555-ba2f-b6b402b84e59"), "Thistle" },
                    { new Guid("5e3a73f8-cfea-4cb9-adf5-374e879b8658"), "Thulian Pink" },
                    { new Guid("6f537921-4013-4f90-8f08-0e5814dba819"), "Tickle Me Pink" },
                    { new Guid("5d782441-dd58-4a08-b97b-00a6e32f56ee"), "Tiffany Blue" },
                    { new Guid("1d09d177-39a5-4d98-b7b2-6d013c0e645a"), "Turquoise" },
                    { new Guid("8fd95a6d-9361-43e2-b4fe-02f4bf647863"), "Turkish Rose" },
                    { new Guid("b84a3970-32ce-43cd-9cb3-692a6acedc27"), "Tumbleweed" },
                    { new Guid("cc616d01-eee6-48d8-afd1-7e9c41c9f682"), "Tulip" },
                    { new Guid("fd17a306-54b8-48ed-9d02-a7dfaf4b2fb0"), "Tufts Blue" },
                    { new Guid("408b4506-120e-4c63-be4d-3f5c74d924c7"), "True Blue" },
                    { new Guid("4a39e66d-858b-4581-afde-82205937951d"), "Tropical Violet" },
                    { new Guid("0214c15f-bc83-4e2d-92dc-073f430dd142"), "Turquoise Green" },
                    { new Guid("cc4a0b1c-4b36-4953-a5d4-0ad5adc36e10"), "Tropical Rain Forest" },
                    { new Guid("a353f403-110b-4a3a-9424-c8d291adb0c9"), "Tractor Red" },
                    { new Guid("5b440d31-d2a7-4c74-916d-b834ff45e1a9"), "Topaz" },
                    { new Guid("64b08609-000e-4cb4-a696-d68f763b07c3"), "Toolbox" },
                    { new Guid("c9fb0f84-1262-461c-9cc5-5d09ef1966d8"), "Tomato" },
                    { new Guid("648beb23-b873-4137-b486-c5e79b5b2604"), "Titanium Yellow" },
                    { new Guid("1b3eef1e-8154-43b0-a73d-b36707296ce2"), "Timberwolf" },
                    { new Guid("2d0e0e2e-be72-47dd-ba6a-4548f02b7df0"), "Tiger's Eye" },
                    { new Guid("b528ad6f-9e7f-4097-9239-1e806cda4716"), "Trolley Grey" },
                    { new Guid("461bd59e-59a3-4f4e-80e5-486581fe23a4"), "Tangelo" },
                    { new Guid("5d2c03a8-2bc0-4d07-a47b-6df1ba74bbc5"), "Vermilion" },
                    { new Guid("c7c5b570-0d9b-43a1-bc98-b282d4e215bf"), "Very Light Azure" },
                    { new Guid("577f68a3-0454-4dfe-aa21-f7ea17bdf274"), "Winter Wizard" },
                    { new Guid("c5518b5d-9b90-41d8-aec6-b0957febde5d"), "Winter Sky" },
                    { new Guid("a720d758-6be8-4b80-a159-9b406d5b0609"), "Wine Dregs" },
                    { new Guid("72a820c9-8b9f-4d8d-9705-a8eed39fc0ab"), "Wine" },
                    { new Guid("6babc86e-f886-490d-887e-f4c37e85baa2"), "Windsor Tan" },
                    { new Guid("118bc320-155e-4a56-9e24-793e40177ff9"), "Willpower Orange" },
                    { new Guid("d01e8639-26a2-44f7-9789-a6604cb67bbc"), "Wild Watermelon" },
                    { new Guid("f59d031f-3997-46cf-96af-de9284349207"), "Wild Strawberry" },
                    { new Guid("39e80b71-5036-49be-958e-fd72edde035c"), "Wild Orchid" },
                    { new Guid("08b643d1-3b43-4d72-8236-42882f7acf31"), "Wild Blue Yonder" },
                    { new Guid("1ea8f867-f4af-4e0a-be3c-3b9a20e8cf97"), "White Smoke" },
                    { new Guid("f6cd50e3-14bc-413c-b545-4fd0a16fa447"), "White" },
                    { new Guid("127fa0c5-469a-40c0-9718-2683a0354448"), "Wheat" },
                    { new Guid("97314b14-12c2-4885-85f2-fad3e32918ae"), "Wenge" },
                    { new Guid("f178fb0b-a930-455b-80c2-96ad621ae136"), "Weldon Blue" },
                    { new Guid("895f84ab-d9ce-4b84-a65e-fa56e6defe65"), "Wintergreen Dream" },
                    { new Guid("3a757be3-774a-4675-b74b-a8a7bf1dd965"), "Wisteria" },
                    { new Guid("464475d7-aa17-4a50-989f-d7ed7e037338"), "Wood Brown" },
                    { new Guid("65e24122-cfab-4265-8462-143a44a1d9a1"), "Xanadu" },
                    { new Guid("7b5a17a2-022c-43f3-af82-eb12b1b8cf2b"), "Zomp" },
                    { new Guid("aa981105-a05a-4cc7-bac1-3137366a7e2e"), "Zinnwaldite Brown" },
                    { new Guid("8c9a3f38-3dae-4941-b5f6-2762527d4f7f"), "Zaffre" },
                    { new Guid("bc4157b4-61dd-488c-94b6-1955b2dca139"), "Yellow Sunshine" },
                    { new Guid("55bea4d9-c574-47da-bf88-56a391f3a5c5"), "Yellow Rose" },
                    { new Guid("02e5dec6-7e6d-414c-aac8-77c9b571fff3"), "Yellow Orange" },
                    { new Guid("a598266c-0cd5-4b28-83dc-a4696746ae32"), "Yellow-Green" },
                    { new Guid("a232f30d-3f69-4f73-9772-291a37e969a8"), "Waterspout" },
                    { new Guid("d13ffcd6-5d15-49f3-bf71-351d29a78279"), "Yellow (RYB)" },
                    { new Guid("889408ed-1648-407b-bd73-640fa8052e6d"), "Yellow (Pantone)" },
                    { new Guid("0d62ce07-e016-47cc-a438-ac8401594edb"), "Yellow (NCS)" },
                    { new Guid("038129fe-9fd8-4a77-8bb8-ccf3a59c6bb7"), "Yellow (Munsell)" },
                    { new Guid("4c2cfc99-8596-43be-958f-a78656427916"), "Yellow (Crayola)" },
                    { new Guid("d1daa356-5e05-43e1-a501-89bc0aaf43e4"), "Yellow" },
                    { new Guid("9df06244-88f5-467a-ac2a-2dd4fda20f8f"), "Yankees Blue" },
                    { new Guid("a06d924c-085e-4b46-93c0-be880462e182"), "Yale Blue" },
                    { new Guid("4410a43a-4619-434b-aeb7-39ea0820f011"), "Yellow (Process)" },
                    { new Guid("f63c3b82-05ea-41fb-824a-804f1dd19d86"), "Veronica" },
                    { new Guid("c2939fdd-b21f-42ec-8fd8-79f5232ab52a"), "Warm Black" },
                    { new Guid("abf3e32e-a36b-4914-a534-51cd10d3253d"), "Vivid Yellow" },
                    { new Guid("88ec627c-1151-45d2-9f0b-7454d49316cb"), "Vivid Amber" },
                    { new Guid("baa8778b-07e2-4612-ac5d-02481bf79911"), "Vista Blue" },
                    { new Guid("a8f4a5a0-8b38-4907-8bfe-1523329efe55"), "Viridian Green" },
                    { new Guid("65b54580-f9bd-405e-aeb2-b7488a38e864"), "Viridian" },
                    { new Guid("091df248-c8c8-40f4-814a-5e8c586889cb"), "Violet-Red" },
                    { new Guid("95b6d897-ceff-43f8-9cf0-be83de9afb2e"), "Violet-Blue" },
                    { new Guid("16102d59-52cf-4234-93c1-d0c069870753"), "Violet (Web)" },
                    { new Guid("2d112717-ef38-4e18-8350-731a9e6e9389"), "Violet (RYB)" },
                    { new Guid("6a7067c5-26fc-4213-9cc4-f6dffeafd003"), "Violet (Color Wheel)" },
                    { new Guid("166dc965-530f-42a0-82a9-b58708dd558b"), "Violet" },
                    { new Guid("4b435ca2-b5a2-42f5-a165-cdadf6b577f7"), "Very Pale Yellow" },
                    { new Guid("c2325471-2275-48af-8133-f4ae9770c3b5"), "Very Pale Orange" },
                    { new Guid("c69d54c1-fe8a-48fd-82c7-7525c8ff22f7"), "Very Light Tangelo" },
                    { new Guid("a3d3d9b3-b592-468f-a942-159de0e71b37"), "Very Light Malachite Green" },
                    { new Guid("0a2dadec-4949-491b-a18c-d12d96ec2e83"), "Very Light Blue" },
                    { new Guid("e0a4b3cf-4429-4784-8d82-21c38fe63189"), "Vivid Auburn" },
                    { new Guid("0bebad35-8cbd-4fe0-b00d-7bbc76a88a99"), "Vivid Burgundy" },
                    { new Guid("dff495fd-56ff-42d6-a1d6-8b50b633cd6d"), "Vivid Cerise" },
                    { new Guid("1d087dab-6704-4930-93b0-c298cd7afd66"), "Vivid Cerulean" },
                    { new Guid("d7ef0393-80ad-43ca-8648-b08b10cd2cee"), "Vivid Violet" },
                    { new Guid("b1f65257-c82b-401b-b564-2643389b0b5f"), "Vivid Vermilion" },
                    { new Guid("acbcf3e7-680a-40bc-b013-15706b76fbc9"), "Vivid Tangerine" },
                    { new Guid("2b6869c1-869d-4da3-a668-c69b6a98fd08"), "Vivid Tangelo" },
                    { new Guid("65510060-dfd8-4dcf-a52f-a590460045e1"), "Vivid Sky Blue" },
                    { new Guid("e3d136b4-995b-4a7e-b826-2ea801020e32"), "Vivid Red-Tangelo" },
                    { new Guid("37ec8a28-f87f-41a9-b640-36131f3c781b"), "Vivid Red" },
                    { new Guid("ba4fc481-b61e-498d-aba0-151890daa841"), "Volt" },
                    { new Guid("9bd508c5-e6c4-4e29-9e4e-c5a0ceffec58"), "Vivid Raspberry" },
                    { new Guid("32380990-55b1-4af9-b1b5-423526931beb"), "Vivid Orange Peel" },
                    { new Guid("d2e90660-cff7-438e-b70f-adbc522022e3"), "Vivid Orange" },
                    { new Guid("6d8d2e64-fe33-42bb-9db1-00086a21dc8b"), "Vivid Mulberry" },
                    { new Guid("23f26ffb-3f79-4e38-abdd-a30aa77a1b77"), "Vivid Malachite" },
                    { new Guid("bd785b92-0f2b-4128-824f-d537c3c82920"), "Vivid Lime Green" },
                    { new Guid("866e2eea-49b2-47de-aa5b-7867804847aa"), "Vivid Gamboge" },
                    { new Guid("43ed326e-db4a-4fdc-bcb2-99ac582ef887"), "Vivid Crimson" },
                    { new Guid("109a3a42-8511-4436-a771-99b3e14ba406"), "Vivid Orchid" },
                    { new Guid("9c8fe8d5-3b43-4d53-ad54-c0579d3351f9"), "Tan" },
                    { new Guid("c57503b0-854e-49c7-8de0-947b00f87f9a"), "Sweet Brown" },
                    { new Guid("f9f1aa67-3c51-462a-a55d-c47cb3beecbf"), "Super Pink" },
                    { new Guid("e2ce6671-339d-4201-a7fd-c53f57cce7a5"), "Safety Orange" },
                    { new Guid("7f548fd3-a4e4-43b3-b25a-62933bcf10cf"), "Saddle Brown" },
                    { new Guid("b0cea482-9290-4892-8661-bc6eaba56444"), "Sacramento State Green" },
                    { new Guid("8f67429a-cbea-4564-bc21-62f8d11920dc"), "Rusty Red" },
                    { new Guid("920dcb3a-a5b4-41a4-9dc0-72be377f631a"), "Rust" },
                    { new Guid("f33765bc-e1e4-4d69-84e7-d8df1f6c2c4c"), "Russian Violet" },
                    { new Guid("79a05193-58bf-4c91-8d2a-132e822ff92c"), "Russian Green" },
                    { new Guid("911623ab-aeb3-42f4-95ef-1687828d724f"), "Russet" },
                    { new Guid("4c2483ba-32ae-4c8a-9434-cc4c3f4b5003"), "Rufous" },
                    { new Guid("f70e3795-98be-43fa-a48f-732de5bc708b"), "Ruddy Pink" },
                    { new Guid("6ddb7d2f-119f-42f1-a7fc-6259f137f646"), "Ruddy Brown" },
                    { new Guid("b7d409d0-2757-488f-8fd2-0822f44e011f"), "Ruddy" },
                    { new Guid("c2c50d7f-03a0-4613-b66c-8d3260c480f2"), "Ruby Red" },
                    { new Guid("29221dd2-3c5d-4dfa-8347-c7ea1649a822"), "Ruby" },
                    { new Guid("5ef5f288-87ab-4fb4-ab76-4d7f67f46ef4"), "Rubine Red" },
                    { new Guid("cf310be2-60ae-42da-b78e-63518c143710"), "Safety Orange (Blaze Orange)" },
                    { new Guid("b9c45156-c5ae-4c9a-8a09-f4e57daf407b"), "Safety Yellow" },
                    { new Guid("0675caa0-b390-4d88-ab8a-a716f0fc129e"), "Saffron" },
                    { new Guid("e1b6924b-cddf-4852-907b-78b07c0609da"), "Sage" },
                    { new Guid("4f8f545d-0193-4222-8cff-e6c7e9424a60"), "Schauss Pink" },
                    { new Guid("a584635e-9a56-4912-a7fc-bda9f03800b7"), "Scarlet" },
                    { new Guid("babd034a-ab1a-4c2a-ab6b-14b14809428a"), "Satin Sheen Gold" },
                    { new Guid("048eca3a-157b-4c77-ad31-0bda5406d43a"), "Sasquatch Socks" },
                    { new Guid("a78ab357-1e12-4977-8440-9808e2a35d3b"), "Sapphire Blue" },
                    { new Guid("acb84ef7-744c-4fcd-b487-1f56d91b61c3"), "Sapphire" },
                    { new Guid("dd77f7f1-68c0-4e44-9959-28bab90e7e8d"), "Sap Green" },
                    { new Guid("ae1b7c19-519a-4424-9f8d-739c250a97cf"), "Ruber" },
                    { new Guid("2cbb0a23-2f96-481d-b1ce-48c51d94f4ee"), "Sangria" },
                    { new Guid("91befbfa-151e-4dbe-8aff-7b9da8706485"), "Sandy Brown" },
                    { new Guid("ff32d86a-f7a4-42a4-8ecb-348376611309"), "Sandstorm" },
                    { new Guid("c166bae8-1139-4bc0-85b3-d50de64ef35c"), "Sand Dune" },
                    { new Guid("b3446643-a8e3-48a5-8b6a-b11afade5f86"), "Sand" },
                    { new Guid("af968100-092a-4ab6-80c4-6973d1edd2b1"), "Salmon Pink" },
                    { new Guid("0b6bfcbd-b7da-4eef-89ea-3a697a3c4968"), "Salmon" },
                    { new Guid("b8f80c54-83c7-4613-aa38-274414f8db30"), "St. Patrick's Blue" },
                    { new Guid("644e6e9c-ccf1-497e-bfe1-5a5faec4cc2f"), "Sandy Taupe" },
                    { new Guid("7a041d53-f263-45a9-9b42-d2eb68b844a5"), "School Bus Yellow" },
                    { new Guid("5da99fd0-aca4-421e-a944-91c7f6375647"), "Royal Yellow" },
                    { new Guid("e1153457-0b98-4740-8567-4aea9fb78fdd"), "Royal Fuchsia" },
                    { new Guid("993d908a-cfd5-4b39-a68d-f9c79ab93061"), "Rifle Green" },
                    { new Guid("7836c78e-3297-4fa6-8853-5dccd48db947"), "Rich Maroon" },
                    { new Guid("a7e2abc0-6037-4c7b-a2e0-1b7677685470"), "Rich Lilac" },
                    { new Guid("501399ef-e3f5-4c3a-a18f-76048287b497"), "Rich Lavender" },
                    { new Guid("b194bddc-6b88-41ac-a2b6-0851a95c4193"), "Rich Electric Blue" },
                    { new Guid("ca40aa3e-6f05-4470-8531-3f971133c3bc"), "Rich Carmine" },
                    { new Guid("e9c4be90-8f62-4c6d-ae95-461c4a4190f0"), "Rich Brilliant Lavender" },
                    { new Guid("4d1629c1-0b8f-44a6-83fd-fd34b5a515be"), "Rich Black (FOGRA39)" },
                    { new Guid("a8023217-32ac-47f1-b161-8682ab07fc54"), "Rich Black (FOGRA29)" },
                    { new Guid("99c429c1-096b-4850-8f4c-845032eaaac2"), "Rich Black" },
                    { new Guid("a94266c5-5129-40db-919b-a400061d76ad"), "Rhythm" },
                    { new Guid("da72365e-8f59-40b6-aad0-a24528a9c742"), "Resolution Blue" },
                    { new Guid("9b05fae5-9bcb-424d-93c1-9f32cb1bb3dd"), "Registration Black" },
                    { new Guid("2978284c-53b2-42af-ba4b-955a82afe9c1"), "Regalia" },
                    { new Guid("9c178270-0ece-4c72-97a0-0f22fde828fb"), "Redwood" },
                    { new Guid("6843bfe3-f76e-47e3-bdf3-3f1988f5b8ac"), "Roast Coffee" },
                    { new Guid("a0537693-6f92-4c47-995a-280e378ccdc4"), "Robin Egg Blue" },
                    { new Guid("6629fde0-61dc-477c-af0f-110124437338"), "Rocket Metallic" },
                    { new Guid("00a444b0-1c83-4382-88cf-a898d0a392ad"), "Roman Silver" },
                    { new Guid("1acbf3e2-821e-4f10-ace9-4c3cd1203edb"), "Royal Blue" },
                    { new Guid("a2fea8f6-5218-462a-8c05-b491d56f81c7"), "Royal Azure" },
                    { new Guid("3adaa817-ae9f-4aa2-8765-bf6ceffe1ac9"), "Rosy Brown" },
                    { new Guid("0089a577-2fd8-40a4-be2a-a1f7d5abaaf8"), "Rosso Corsa" },
                    { new Guid("149b739e-3971-4e6f-add1-593b81c1e068"), "Rosewood" },
                    { new Guid("ce5caa2f-393d-40ab-b134-53fc814a34ae"), "Rose Vale" },
                    { new Guid("ac8d8e1f-f4fd-438a-9336-df3adb00becd"), "Rose Taupe" },
                    { new Guid("10b36702-9362-4b5e-9fb1-7bef00449a85"), "Royal Purple" },
                    { new Guid("1fbe3a0d-6589-4ebe-a44f-8e71f2f4ef4a"), "Rose Red" },
                    { new Guid("23a7f728-2485-4ac7-b099-72d2b758c9d5"), "Rose Pink" },
                    { new Guid("ce91b932-85c2-485e-adbb-4ff5b644c310"), "Rose Madder" },
                    { new Guid("6843e023-d129-4f98-912d-b0400329c562"), "Rose Gold" },
                    { new Guid("827901cf-dc2f-408d-aa3a-d99e942823fe"), "Rose Ebony" },
                    { new Guid("6bf0c406-96ac-4e5f-95be-fd63047468fc"), "Rose Dust" },
                    { new Guid("245b35de-1345-463c-89f6-d3a2f843447f"), "Rose Bonbon" },
                    { new Guid("85c7ea44-fcd9-4627-ab47-a1e428c6e197"), "Rose" },
                    { new Guid("3a44bacd-7e67-439e-9cbf-158ccbf957fe"), "Rose Quartz" },
                    { new Guid("5d883054-5163-4c7b-9cae-ad364c43d836"), "Screamin' Green" },
                    { new Guid("01f1c464-ef98-4b9d-8dbb-95ff55d81978"), "Sea Blue" },
                    { new Guid("344e7ed7-9710-4975-8859-b4a319d55295"), "Sea Green" },
                    { new Guid("78771dad-5872-41dc-82f6-3beee72380d6"), "Spicy Mix" },
                    { new Guid("e67f4987-0160-4f38-8cde-08b670447f80"), "Spanish Viridian" },
                    { new Guid("48e4184a-89d3-445e-841e-1b36b7d59f6b"), "Spanish Violet" },
                    { new Guid("5a92c84f-5de6-4c39-932d-3412a69e2cc8"), "Spanish Sky Blue" },
                    { new Guid("e966336a-f30e-489f-bf1e-02eba9dbc80b"), "Spanish Red" },
                    { new Guid("67ef3196-0877-411e-9466-8fc71f9f44ff"), "Spanish Pink" },
                    { new Guid("3cf978cd-0cc9-40cd-bd2c-cbad18a002a5"), "Spanish Orange" },
                    { new Guid("d9f48ffb-f5e3-4177-9dd0-40b6fa00b5d7"), "Spanish Green" },
                    { new Guid("2b65c990-701c-472d-a219-beaa21750b7d"), "Spanish Gray" },
                    { new Guid("b9e75a32-9bd6-4ee6-8f0d-a66ec097687d"), "Spanish Crimson" },
                    { new Guid("d1850dfb-5653-43e0-b915-a2a0ad195013"), "Spanish Carmine" },
                    { new Guid("9a9bfa15-95ce-4d6f-a299-0342b4ce18a2"), "Spanish Blue" },
                    { new Guid("91c55071-9a4d-4f0b-8521-55eb48894720"), "Spanish Bistre" },
                    { new Guid("edd803b8-bdbc-4b5e-a339-fb12bec5d8d1"), "Space Cadet" },
                    { new Guid("5ee35312-e96d-4209-9aa4-ac3500b699fe"), "Spartan Crimson" },
                    { new Guid("a86042a9-5e21-4846-aa0a-7efb25661b33"), "Spiro Disco Ball" },
                    { new Guid("b9b48310-8572-4d80-9659-f19bf3c717f8"), "Spring Bud" },
                    { new Guid("63f58f4b-4d1f-44ea-b3b6-b1030a9ed80c"), "Spring Frost" },
                    { new Guid("522106f4-f3d4-4a2d-8723-7e9cce2fd13d"), "Spring Green" },
                    { new Guid("90d67c9d-e76f-4dbc-9c36-3c6b133d1ab5"), "Sunset Orange" },
                    { new Guid("6f94d3eb-825e-4eb3-99f4-d0846bfa8170"), "Sunset" },
                    { new Guid("d69b8903-c6f0-415b-be38-3e2630f6e5b5"), "Sunray" },
                    { new Guid("952a4419-c2a3-47f9-850a-980ab5672624"), "Sunny" },
                    { new Guid("a3f3f73b-f708-48d1-871e-e5086ff3ac50"), "Sunglow" },
                    { new Guid("0cd1ee42-f6f8-47ed-a8bd-cfee9f0dfbcd"), "Sunburnt Cyclops" },
                    { new Guid("19189783-0c8e-4eaf-85af-dc97b2799126"), "Sugar Plum" },
                    { new Guid("e8692c82-cd2b-44fe-9ca6-8640b25b796d"), "Sonic Silver" },
                    { new Guid("eeed8c9e-a621-4446-bbd6-1bf1ce46ece0"), "Strawberry" },
                    { new Guid("4b4debe3-879b-419d-a8ac-ac8f266b04dd"), "Stormcloud" },
                    { new Guid("a95875ff-16e9-4baf-b83c-a309799fdb96"), "Stizza" },
                    { new Guid("bc56effe-cce3-442f-a91e-e866912c53f2"), "Stil De Grain Yellow" },
                    { new Guid("06cd0f5f-99ca-431e-82a1-38db96b44c95"), "Steel Teal" },
                    { new Guid("c9fe7589-0a7b-4530-a69b-a00aadd4bdac"), "Steel Pink" },
                    { new Guid("a56716d3-4685-4e72-912b-d26743d62ed1"), "Steel Blue" },
                    { new Guid("435146a2-cb13-4544-a038-059ec80aa73b"), "Star Command Blue" },
                    { new Guid("b347705a-25f5-4092-9534-f2a8f5d1b2c5"), "Straw" },
                    { new Guid("48407c1d-a400-455f-a371-943f2e63ffab"), "Solid Pink" },
                    { new Guid("9d73ce0a-1756-4ed2-99bf-1f3a800cf740"), "Soap" },
                    { new Guid("80c0cb34-7f7d-4a99-9d9a-b1075a9c76fd"), "Snow" },
                    { new Guid("9147935b-b088-4c4b-a9a2-dc980063f533"), "Silver" },
                    { new Guid("101481cc-b817-427e-b182-c093e45ec09a"), "Sienna" },
                    { new Guid("a81ec825-e437-451c-8d00-04da6f171586"), "Shocking Pink (Crayola)" },
                    { new Guid("042b248b-7874-4c6b-b378-57a816e13e7b"), "Shocking Pink" },
                    { new Guid("cc0f7187-22de-4d3c-aef1-9e14a046b41e"), "Shiny Shamrock" },
                    { new Guid("37da96dd-684b-4c1a-9b50-fcd42f8c01e4"), "Shimmering Blush" },
                    { new Guid("611e451a-55d2-4bf6-8dd5-6bfc4ff0d878"), "Sheen Green" },
                    { new Guid("1a83f3e7-9c55-4d50-93e8-5ae1929104fe"), "Silver Chalice" },
                    { new Guid("6cab0d64-f452-4616-9e54-9d3f030ed620"), "Shamrock Green" },
                    { new Guid("a2c378c7-9b73-47e7-86c3-bfe159f96d4d"), "Shadow Blue" },
                    { new Guid("fee5e2da-6d7d-4075-8f8e-4495e483b515"), "Shadow" },
                    { new Guid("de76ecae-2b98-4123-ab51-9dad86180ded"), "Sepia" },
                    { new Guid("dae71311-61f3-41cd-9115-1ddd94f99a5b"), "Selective Yellow" },
                    { new Guid("c9d31290-bc9e-4a05-9651-d0bcc5e4d84c"), "Seashell" },
                    { new Guid("e38d35f2-fdfa-4a89-815e-4f268fe0aa89"), "Seal Brown" },
                    { new Guid("81335000-9c1c-4e11-b726-31fa3f39cf4d"), "Sea Serpent" },
                    { new Guid("daa16966-9991-4aae-89d9-ed385f100b79"), "Shampoo" },
                    { new Guid("95712077-aa8c-49fb-bb96-d8ce97c8c422"), "Red Salsa" },
                    { new Guid("a1ddfc4e-6140-4e22-8601-01dffa013a5e"), "Silver Lake Blue" },
                    { new Guid("1198904d-2ec7-4745-b963-dcd014a80b82"), "Silver Sand" },
                    { new Guid("e5f5d141-c4a7-4b08-bf17-113b2a91b6a5"), "Smoky Topaz" },
                    { new Guid("0a660e30-1323-4884-9e26-5716b7b233dd"), "Smoky Black" },
                    { new Guid("d7cd8a55-3a66-46f6-bc3d-fc77ab27c7c1"), "Smokey Topaz" },
                    { new Guid("c1047c2d-7d58-4e9d-9072-e52d64c2b44c"), "Smoke" },
                    { new Guid("aca34e2d-e8a6-45c4-8037-71f7bfb7d4de"), "Smitten" },
                    { new Guid("36ca9d35-1f07-4ec9-adf3-504a6f2e88a0"), "Smashed Pumpkin" },
                    { new Guid("d9dfb227-5cf3-40a3-a55a-8f7899954094"), "Slimy Green" },
                    { new Guid("71bf47f7-44ad-4a39-9817-30739c09fbf3"), "Silver Pink" },
                    { new Guid("fdf0fdad-38da-40b6-a921-ad2c3274d05f"), "Smalt (Dark Powder Blue)" },
                    { new Guid("895dbaa1-15b4-45b4-8297-9c7dcc088af5"), "Slate Blue" },
                    { new Guid("489b0a25-96d9-4684-bcc7-8705dfabaa98"), "Sky Magenta" },
                    { new Guid("ad382c72-4f7c-4fcd-af05-de93f6d3951c"), "Sky Blue" },
                    { new Guid("c04db1c3-8fd6-431e-af7c-d3aba72c84e8"), "Skobeloff" },
                    { new Guid("f005f56f-77bb-4543-9de9-224e20e72988"), "Sizzling Sunrise" },
                    { new Guid("37bad57d-26d0-49f3-b69e-2e5cdf68a6f4"), "Sizzling Red" },
                    { new Guid("8278cf82-1a05-4b28-99f5-68ef5d6eda24"), "Sinopia" },
                    { new Guid("6fff370e-e833-40c2-91d7-1a67837fa302"), "Slate Gray" },
                    { new Guid("e9dfaa99-256a-41f8-b7b6-e412922a262e"), "Light Sea Green" },
                    { new Guid("352ebf24-5e0b-48c5-ac58-071a52076b05"), "Misty Moss" },
                    { new Guid("077c7d90-3ca0-4322-9c9b-f82105e7211a"), "Light Salmon" },
                    { new Guid("59cf038e-50b7-4c00-ae68-a1427d98de7c"), "Chestnut" },
                    { new Guid("ceaefdd4-0dbd-4635-8a9c-d3c4ce16a285"), "Cherry Blossom Pink" },
                    { new Guid("0b3c590a-a8fc-494b-b6b2-d3262cdb4cf2"), "Cherry" },
                    { new Guid("33c2f3e8-cb96-43b7-bbe3-dc5b707de698"), "Chartreuse (Web)" },
                    { new Guid("81415437-2858-4aea-9817-5b63b3f5b34b"), "Chartreuse (Traditional)" },
                    { new Guid("75d9ae79-04c5-4631-97b6-bf9382521f6e"), "Charm Pink" },
                    { new Guid("4816f171-542c-44dc-868f-f37068389a13"), "Charleston Green" },
                    { new Guid("491d8520-0ef8-4779-8243-95dff916a284"), "Charcoal" },
                    { new Guid("39af13fb-d7e4-4f44-aa5a-8d87b2f568fd"), "Champagne" },
                    { new Guid("9bef5229-1732-4a36-a1a2-989bcafdf44b"), "Chamoisee" },
                    { new Guid("13520240-4d27-416d-bd82-ea9075d62f0e"), "CG Red" },
                    { new Guid("8a1a6ee2-4531-44c5-9145-a1efabffd55f"), "CG Blue" },
                    { new Guid("90f095a9-4e95-44d8-97b2-eb0909a9ea36"), "Cerulean Frost" },
                    { new Guid("696413c6-1da1-4d31-aa23-08af0c0686c6"), "Cerulean Blue" },
                    { new Guid("85722ff6-29cb-4eab-b7ac-d9cfffb8e0f4"), "Cerulean" },
                    { new Guid("fa13c58c-0122-4c08-b4af-1d5067dd685e"), "China Pink" },
                    { new Guid("ab9fb4a4-7309-481d-a09f-1f4b3c6fd832"), "China Rose" },
                    { new Guid("21152881-ee9c-4d93-b0b0-91cd52dadf8d"), "Chinese Red" },
                    { new Guid("c42eb8c1-da39-49b9-b4e3-ef5f9997f495"), "Light Salmon Pink" },
                    { new Guid("97e17415-a818-4055-bc16-14d5d42ca510"), "Coffee" },
                    { new Guid("630bcbd2-020d-4d70-96f4-6532790207e1"), "Coconut" },
                    { new Guid("5b53a0c2-2af1-410c-865d-e56bcd4ec4a5"), "Cocoa Brown" },
                    { new Guid("93f54c38-bfdc-4833-bbb9-30ca3d88c36d"), "Cobalt Blue" },
                    { new Guid("c181d356-7b14-4354-8b82-745bd3dc3aa9"), "Classic Rose" },
                    { new Guid("b42166f2-5e75-4f2f-9bed-20259f2e5a3d"), "Claret" },
                    { new Guid("beb0eff6-e1d9-4eef-8048-af7b36c0c432"), "Citron" },
                    { new Guid("f4a3cf5b-d13d-4835-9ce9-7dfbfab5e6d1"), "Cerise Pink" },
                    { new Guid("9a5ac668-a0f8-4576-b89c-a6e15e80ffe3"), "Citrine" },
                    { new Guid("eedec6ec-37fd-4c3a-b862-96f8d8510165"), "Cinnamon[Citation Needed]" },
                    { new Guid("fa5d9d59-b941-496a-a17c-e193ceba6810"), "Cinnabar" },
                    { new Guid("f8a2918f-f53b-45be-819f-4dfbc45e19fc"), "Cinereous" },
                    { new Guid("0fa9f970-efe3-410a-9b00-a88e3973020e"), "Chrome Yellow" },
                    { new Guid("4a7f8d9d-a270-4ea4-b59b-d97440ce0b20"), "Chocolate (Web)" },
                    { new Guid("bec02d71-bb92-4169-b850-c6fc8ffb2730"), "Chocolate (Traditional)" },
                    { new Guid("a241c500-911a-486a-b858-53f86b2e59ec"), "Chlorophyll Green" },
                    { new Guid("6d5e97f6-c748-40af-928d-1a89e27240ba"), "Cinnamon Satin" },
                    { new Guid("2d29c398-6f68-40dd-a5d2-4134b79b809c"), "Columbia Blue" },
                    { new Guid("0ca579cf-fb81-427c-82e7-28a5f6e6f0f5"), "Cerise" },
                    { new Guid("d7b3158e-9aea-4314-84b3-f3268c873035"), "Celeste" },
                    { new Guid("ee31b0a5-f4e5-4815-8c50-959d0f04cc6f"), "Candy Pink" },
                    { new Guid("2f8f2629-f2de-4d06-b5fa-e33036fd9626"), "Candy Apple Red" },
                    { new Guid("db10515e-329f-4059-b0ff-5e95adc807d3"), "Canary Yellow" },
                    { new Guid("1d710a53-6d74-4345-86f1-e2e6cf3d4173"), "Camouflage Green" },
                    { new Guid("7b869729-fb72-404d-86df-038753ba87f7"), "Cameo Pink" },
                    { new Guid("89a2f885-9248-45c1-ba03-8f0a90a1bf65"), "Camel" },
                    { new Guid("5c474432-e5fb-4778-9315-e305f9835709"), "Cambridge Blue" },
                    { new Guid("6e873724-d1ab-4b0f-8dc9-2294afaa20ef"), "Cal Poly Green" },
                    { new Guid("ec58fe10-9a2a-4a38-a133-2466f1af5259"), "Café Noir" },
                    { new Guid("1be88d3f-d4b1-4893-a9f7-0ed655bc9536"), "Café Au Lait" },
                    { new Guid("fc2243d1-df52-4540-ba6d-c2d40a49b2d9"), "Cadmium Yellow" },
                    { new Guid("09a4d598-6a1b-4548-8261-4b0b1ad3b875"), "Cadmium Red" },
                    { new Guid("d52d09a5-fa10-4c74-aeb5-1b2ec96ac4da"), "Cadmium Orange" },
                    { new Guid("a38b392b-36a1-4b81-8b25-92302fc78f7f"), "Cadmium Green" },
                    { new Guid("8730b91a-2fb2-45d0-a055-3030f1ae7611"), "Cadet Grey" },
                    { new Guid("e9dcc39c-bac4-4709-9b42-17476d8ce8b6"), "Capri" },
                    { new Guid("e2166b46-72f7-42d5-978e-eb8b18ac11ec"), "Caput Mortuum" },
                    { new Guid("b3258c7a-1e36-43ce-92e8-6ba0965de3ac"), "Cardinal" },
                    { new Guid("269a64fe-9b0f-4041-809d-ac8a0d2b3893"), "Caribbean Green" },
                    { new Guid("c472493b-17a8-4325-ab40-b039480ab72c"), "Celadon Green" },
                    { new Guid("db5a9bd8-19d3-4714-9ed2-e62e26ccd82f"), "Celadon Blue" },
                    { new Guid("1ca2bfb2-51ad-469b-9700-72b3c02c2d39"), "Celadon" },
                    { new Guid("2a28c41e-aa44-40dc-a57b-6eca4634952e"), "Ceil" },
                    { new Guid("158583bc-6bfe-4559-9392-dd218fcd5f3d"), "Cedar Chest" },
                    { new Guid("2bff8cf1-fbc3-45c3-a6eb-cce20d9cc3cc"), "Catawba" },
                    { new Guid("ac5cb188-95c5-40a0-ad1a-8b4d32853403"), "Catalina Blue" },
                    { new Guid("fa5357d1-43d8-4c63-bd58-9dffb549c2ca"), "Celestial Blue" },
                    { new Guid("cb479794-e1ec-49da-aa51-f934c8193e01"), "Castleton Green" },
                    { new Guid("73ba8550-3c1c-4cea-962a-b1d3c8d75d12"), "Carolina Blue" },
                    { new Guid("843558cc-3dfe-4ecc-9ece-dbfb0af75db5"), "Carnelian" },
                    { new Guid("8e7d543b-9199-454b-9f94-c2138ed70ad9"), "Carnation Pink" },
                    { new Guid("c6b38e56-8b72-413e-9e21-daf5732521cf"), "Carmine Red" },
                    { new Guid("cbe70450-7d64-47b9-b6aa-4e4516a2dcc4"), "Carmine Pink" },
                    { new Guid("d9e9c058-2cfe-48b5-b8d4-abd1466ddbfa"), "Carmine (M&P)" },
                    { new Guid("28a166e7-d21e-4ef9-92c8-7db5802c1640"), "Carmine" },
                    { new Guid("cf8763f0-b422-4693-9850-68aead2bf5cd"), "Carrot Orange" },
                    { new Guid("bea0f947-709e-4915-a1ae-38223c16341e"), "Congo Pink" },
                    { new Guid("c147f549-f764-4402-8fa9-6f761c1223bc"), "Cool Black" },
                    { new Guid("95d2a2c6-0294-416c-8a2a-c86a71b4014f"), "Cool Grey" },
                    { new Guid("27458a33-6ef2-4c3b-9c85-d6143cd9a1d9"), "Dark Lavender" },
                    { new Guid("875a7f83-44fe-4b0f-8e02-7cbf7304a490"), "Dark Lava" },
                    { new Guid("e2a465aa-bf0b-4e53-84ae-6c9ddc69978f"), "Dark Khaki" },
                    { new Guid("f52f2e34-aedf-4fac-a54c-c411393e7dbd"), "Dark Jungle Green" },
                    { new Guid("d52cdace-10bc-410c-8a1a-3b32ca0d3398"), "Dark Imperial Blue" },
                    { new Guid("35c84c04-1adc-47d4-b757-8cbd315741cf"), "Dark Gunmetal" },
                    { new Guid("0fae3eca-d675-4842-936f-513df1b5b471"), "Dark Green (X11)" },
                    { new Guid("d57c8e91-81a2-4f8d-8305-1df3e6c40c7d"), "Dark Green" },
                    { new Guid("a528941d-3c47-4b63-90b2-a7fa96ae695d"), "Dark Gray (X11)" },
                    { new Guid("726e78a0-0494-4c0c-916e-52a5ea56ff30"), "Dark Goldenrod" },
                    { new Guid("bd653fd2-a337-4650-9864-7559dea0c2ca"), "Dark Electric Blue" },
                    { new Guid("2f1342fc-ea60-4f6b-be3b-60b6aa785e60"), "Dark Cyan" },
                    { new Guid("5441cc54-5f09-493d-9a1f-278af16503c4"), "Dark Coral" },
                    { new Guid("840b7e27-e66a-4ad7-a400-d777f7d201b5"), "Dark Chestnut" },
                    { new Guid("79e235cd-b6a1-4d99-afb1-e0c364f6ace0"), "Dark Cerulean" },
                    { new Guid("dfdec086-9aa8-4da6-b850-85a5928cfd48"), "Dark Liver" },
                    { new Guid("9be3bcd6-b456-4f50-a499-2855306f48c1"), "Dark Liver (Horses)" },
                    { new Guid("cd00ccd1-c2d3-4ab6-8400-a51d05209617"), "Dark Magenta" },
                    { new Guid("916df4ae-0204-4bed-b4dd-ddfc0a64200b"), "Dark Medium Gray" },
                    { new Guid("b45f223f-5314-4daa-a799-55a24ed18c7c"), "Dark Salmon" },
                    { new Guid("a0801dfe-8cb7-40ce-a969-9e86e630fd48"), "Dark Red" },
                    { new Guid("7735adc7-d570-4161-aa75-cf303acaa536"), "Dark Raspberry" },
                    { new Guid("33959993-6762-4ab1-879c-a097add75aed"), "Dark Purple" },
                    { new Guid("218fc36c-d563-4541-9d45-712a2f370e53"), "Dark Puce" },
                    { new Guid("4f9e2ba9-d6e0-4d54-9293-d82dd0f03dd3"), "Dark Powder Blue" },
                    { new Guid("08b9d893-fb2c-4d3d-b0bb-9f13709ac3cb"), "Dark Pink" },
                    { new Guid("492d81a5-9e49-40cd-b303-1d90e1da605e"), "Dark Candy Apple Red" },
                    { new Guid("7ad96545-fbd7-4c78-a44e-30f956d187df"), "Dark Pastel Red" },
                    { new Guid("c0c2f125-831b-488b-a768-86835097a7a1"), "Dark Pastel Green" },
                    { new Guid("598e13b3-3468-421f-81e4-8347108db919"), "Dark Pastel Blue" },
                    { new Guid("6cb15faa-7a73-46d9-b2b1-cce4855af8fa"), "Dark Orchid" },
                    { new Guid("2f3c13f2-ad1c-4f53-9e9d-0c535d627218"), "Dark Orange" },
                    { new Guid("dd7a4c88-5b06-4fd3-ab26-a24a21b0ec17"), "Dark Olive Green" },
                    { new Guid("888d87f3-9e4e-4fdb-a0bf-b2b4452d0ef2"), "Dark Moss Green" },
                    { new Guid("b60307e6-a09a-4ef4-8ad8-5c56b28919ee"), "Dark Midnight Blue" },
                    { new Guid("4619cf49-6197-4707-8917-7ce5b018a72b"), "Dark Pastel Purple" },
                    { new Guid("f451377d-9c18-4604-ab48-9a4e050c27fb"), "Dark Byzantium" },
                    { new Guid("400888f8-ec60-4521-8f11-ead1c90f3caa"), "Dark Brown-Tangelo" },
                    { new Guid("f9478a2a-ca09-49c5-b99f-34e8e9f197cf"), "Dark Brown" },
                    { new Guid("a7d17927-c73e-4b24-816f-860155df836d"), "Cosmic Latte" },
                    { new Guid("0e0af4d1-a348-44eb-bb31-85f12031173a"), "Cosmic Cobalt" },
                    { new Guid("43d2cd49-4904-4a9c-83fe-87ec76bd1341"), "Cornsilk" },
                    { new Guid("cefff5a0-e7ab-4bed-bd8c-41992c1495f1"), "Cornflower Blue" },
                    { new Guid("f7d386f3-50c2-478b-9558-0d82a4b4720b"), "Cornell Red" },
                    { new Guid("66885358-b7c7-4451-8290-b040547fa329"), "Corn" },
                    { new Guid("0fbf3a7f-2854-4007-95fb-c73623feded2"), "Cordovan" },
                    { new Guid("f8d65389-d16f-4cc3-b097-935df3e4cac6"), "Coyote Brown" },
                    { new Guid("c1d287dd-e21b-4e34-9833-b98f884bc416"), "Coral Red" },
                    { new Guid("866dd9c4-b479-4e9e-a301-3a4efdd53a5f"), "Coral" },
                    { new Guid("492e4aba-6fe5-4268-822a-aec6ca1dbddd"), "Coquelicot" },
                    { new Guid("b11f21cd-14a8-4586-9797-eaa448e6eacc"), "Copper Rose" },
                    { new Guid("5efc4cc3-def2-4564-8f5e-19089338e5c5"), "Copper Red" },
                    { new Guid("9c6c1163-6325-49e7-8fce-ab41a01f59f9"), "Copper Penny" },
                    { new Guid("b57b379b-7e7a-461d-8ec0-2b585b2d8ceb"), "Copper (Crayola)" },
                    { new Guid("31a0d3e1-99e8-4ce0-ba01-c5c5252485f9"), "Copper" },
                    { new Guid("0ca1dd4c-e943-4889-9895-5dd810306e5a"), "Coral Pink" },
                    { new Guid("c0f14799-058e-4f67-9bd5-2996ecfc6c9d"), "Cadet Blue" },
                    { new Guid("24c0651c-a444-447a-b10f-94609bffd94d"), "Cotton Candy" },
                    { new Guid("2025a143-14fa-4dd6-af95-a4c31412d145"), "Crimson" },
                    { new Guid("47ce24da-37f8-47c8-907b-47c0bb136616"), "Dark Blue-Gray" },
                    { new Guid("c2ea1b5e-dda8-45ee-965d-f328c338b622"), "Dark Blue" },
                    { new Guid("2fbadad5-745e-4249-8275-bbb6d091c10c"), "Dandelion" },
                    { new Guid("b940f56f-11e8-41f1-89f6-dd204873d847"), "Daffodil" },
                    { new Guid("099ea3eb-f625-44b4-8322-60d12869b69b"), "Cyclamen" },
                    { new Guid("e3a2af56-46dc-4348-bbf7-8737d4820a11"), "Cyber Yellow" },
                    { new Guid("313d6991-b6b7-42c0-8f11-4e63ed89d00f"), "Cyber Grape" },
                    { new Guid("16c1b735-54dd-4d3a-87eb-dc25bc4afda1"), "Cream" },
                    { new Guid("0b8cb92a-f023-45fb-9e2e-cd48b1e8a64c"), "Cyan (Process)" },
                    { new Guid("7002e778-3f24-4ef1-bc15-b19bd0f95d84"), "Cyan Cobalt Blue" },
                    { new Guid("e79af014-2c6b-4d79-8035-dd45fc41c726"), "Cyan-Blue Azure" },
                    { new Guid("d6c5e351-a8f5-4b36-acd8-b4ab35b3836e"), "Cyan Azure" },
                    { new Guid("823910ed-40e8-4a1c-b473-0a5936cf7a7d"), "Cyan" },
                    { new Guid("9b72df3a-c8c4-40c7-8869-b3e7aa118b9e"), "Cultured" },
                    { new Guid("a6c3f52a-8f52-42c4-a9bb-30a1808ceed3"), "Crimson Red" },
                    { new Guid("8ed5d736-1958-48e9-ba1b-b86d77a075b8"), "Crimson Glory" },
                    { new Guid("7fa9e587-6014-403f-be34-858f2eb3a268"), "Cyan Cornflower Blue" },
                    { new Guid("35e98fa5-5967-46f4-b1d8-52d639d82903"), "Dark Scarlet" },
                    { new Guid("d91a6de9-14a7-4426-a9ea-c46834e91b55"), "Cadet" },
                    { new Guid("c9bef0a2-7edf-476d-9d08-d10bd5335ab4"), "Byzantine" },
                    { new Guid("de36ce75-0821-43fb-bc10-6d61f72d8892"), "Baby Blue Eyes" },
                    { new Guid("727847a1-5cec-49e1-9e7a-036a8674616e"), "Baby Blue" },
                    { new Guid("be984b4f-e360-4e63-a5c3-5ba498b2cbc3"), "Azureish White" },
                    { new Guid("dcdbeca1-4501-4320-92c9-a16d0be1341a"), "Azure Mist" },
                    { new Guid("72b38557-4fb7-48f2-9530-6f0fa58c7027"), "Azure (Web Color)" },
                    { new Guid("7e230459-d319-4c90-b47d-c45e9af4b622"), "Azure" },
                    { new Guid("99eb66e7-6f6c-4fc1-b375-7abeaa777f9c"), "Aztec Gold" },
                    { new Guid("73b7cc59-5c5f-44e0-9704-cae97af04ef0"), "Avocado" },
                    { new Guid("5d0f0a5c-b1b2-48bb-a281-cb6080ae167d"), "AuroMetalSaurus" },
                    { new Guid("1bd0ba20-e76e-443d-814e-58c4135a625d"), "Aureolin" },
                    { new Guid("4b7db94b-e91e-4f80-9beb-a38314c93b86"), "Auburn" },
                    { new Guid("51d71a3b-586e-4639-9be0-337180da3391"), "Atomic Tangerine" },
                    { new Guid("3dd033fa-4190-47ae-8cd8-da75a800eef9"), "Asparagus" },
                    { new Guid("7aeca22b-a1b0-4b10-9ddc-d3e8fffadeb4"), "Ash Grey" },
                    { new Guid("89a79852-8afc-48d6-83a1-7d6b57ca73a1"), "Arylide Yellow" },
                    { new Guid("e2e61e90-35e7-4f95-b88b-069beb4fc1d0"), "Baby Pink" },
                    { new Guid("81d46194-7fba-4e0a-8cd6-ce227235d961"), "Baby Powder" },
                    { new Guid("820824e2-9a56-479d-92c7-7933e74d1c76"), "Baker-Miller Pink" },
                    { new Guid("0da2d02e-888c-49f6-8ebe-d47e7a25e14c"), "Ball Blue" },
                    { new Guid("43878c98-b100-49e7-8696-0d679b005b75"), "Bistre" },
                    { new Guid("f0920cda-1d3f-46e4-8817-af73d40369f1"), "Bisque" },
                    { new Guid("8a98bcce-ccfa-43ef-ac44-c48544b8e591"), "Big Foot Feet" },
                    { new Guid("ec12c03f-30c7-430e-bd65-66a6aab1b18f"), "Big Dip O’ruby" },
                    { new Guid("50f17e48-b35c-442b-b999-0c6138005c2d"), "B'dazzled Blue" },
                    { new Guid("1a968203-3975-4d57-9ef9-6741349fb29d"), "Belgion" },
                    { new Guid("99624705-83e2-4c27-b9d3-e2fc39c4a4d5"), "Beige" },
                    { new Guid("b07e6184-9aa2-4063-b03a-080da9eec4d4"), "Artichoke" },
                    { new Guid("62ca3b0a-3028-4f03-a19c-d55daeca7b20"), "Beaver" },
                    { new Guid("da9209cb-6f21-4003-973c-72a812392e18"), "Bazaar" },
                    { new Guid("676045c5-92fd-410a-94cc-b9b7d559d397"), "Battleship Grey" },
                    { new Guid("e78b9cea-e173-4041-abbf-ad393af3a16d"), "Barn Red" },
                    { new Guid("6b327b54-2ce2-44cb-9af5-2e19746cd4a3"), "Barbie Pink" },
                    { new Guid("c9bd11d3-47c6-4c0f-9d3a-68c894e1a44c"), "Bangladesh Green" },
                    { new Guid("a9692a01-121f-4a04-9208-e175bc4fd0e1"), "Banana Yellow" },
                    { new Guid("30d9a5a2-7686-416a-8c5d-cd6722ac6a22"), "Banana Mania" },
                    { new Guid("80b7af4c-76c6-4769-a8c4-3fecd78d39c9"), "Beau Blue" },
                    { new Guid("23690068-9eeb-4137-95cd-3afd6ec88bc5"), "Bistre Brown" },
                    { new Guid("0e884e15-ca42-468d-9acb-7ddad9cf71e2"), "Arsenic" },
                    { new Guid("6d6008f8-4022-41b9-9695-f52e257708d3"), "Arctic Lime" },
                    { new Guid("ea3abf9c-78a2-4ccd-bb03-4977833e32c9"), "Amaranth Deep Purple" },
                    { new Guid("bfa106a5-ce23-45ab-97ae-67f4179c6282"), "Amaranth" },
                    { new Guid("7e97dcda-21ba-4289-8d4b-f56485c3f299"), "Almond" },
                    { new Guid("812e8c5d-4e68-4e5d-89bc-172c2f2b103a"), "Alloy Orange" },
                    { new Guid("c8185dbd-5c51-4d9e-bd1f-b6c1abad1157"), "Alizarin Crimson" },
                    { new Guid("823e39cc-df51-4377-9180-aad19e40b862"), "Alien Armpit" },
                    { new Guid("fb02f57a-d9a0-460d-8cbc-11251a370167"), "Alice Blue" },
                    { new Guid("50567cb3-a1dc-48c1-b8dd-043736ac209e"), "Alabama Crimson" },
                    { new Guid("b09b64ce-71f1-4e46-81d7-a50c88adebf7"), "Air Superiority Blue" },
                    { new Guid("92cb934e-7284-435a-9767-a1498a25b7e5"), "Air Force Blue (USAF)" },
                    { new Guid("c5298ad0-44fc-4fc9-83f9-98b11939a2bc"), "Air Force Blue (RAF)" },
                    { new Guid("13863dd7-57f7-4f9f-a794-5c8c854a2aad"), "African Violet" },
                    { new Guid("bc8d1cd3-ee46-4cbc-bcb7-df5c9e7d6dfb"), "Aero Blue" },
                    { new Guid("69380b23-71ac-49cb-b4aa-10cea2d16711"), "Aero" },
                    { new Guid("05e9d00d-0068-4ad6-8b28-296d10e43e41"), "Acid Green" },
                    { new Guid("32e949ca-0fcd-477a-a082-a4418ed56273"), "Amaranth Pink" },
                    { new Guid("e65277b7-6183-4156-b4e0-6c9063631a5b"), "Amaranth Purple" },
                    { new Guid("c1673668-198d-4248-9bf8-2ed0eaeaa0d0"), "Amaranth Red" },
                    { new Guid("7c060cf4-2f04-40db-ab57-058abddf818b"), "Amazon" },
                    { new Guid("1026cfd1-a7ae-4856-b35e-8c895dac0b82"), "Aquamarine" },
                    { new Guid("b11ae8ed-3767-495a-9747-b6946c300161"), "Aqua" },
                    { new Guid("eb30db01-1657-4b33-a110-4c1eb349cef8"), "Apricot" },
                    { new Guid("e78c561e-5c21-4833-8ce8-d94ccbab7594"), "Apple Green" },
                    { new Guid("8076c877-24d3-47e7-a32a-4846942b1462"), "Ao (English)" },
                    { new Guid("54aad886-cb82-4985-90e8-5b821b2a38bd"), "Antique White" },
                    { new Guid("e7b1716a-3e2a-4259-a259-29f5b5d7d6b4"), "Antique Ruby" },
                    { new Guid("77b035dd-812f-4f60-bad5-7087761cf6b5"), "Army Green" },
                    { new Guid("88391e27-edaf-4eb5-9d78-7aceadae2bf7"), "Antique Fuchsia" },
                    { new Guid("8cc5a2b2-785f-482f-a1c7-0891b88594e0"), "Antique Brass" },
                    { new Guid("31d13f3a-68e2-48f7-baa4-705a023c3b1d"), "Anti-Flash White" },
                    { new Guid("91e04982-97b6-4d76-ad5e-183a0b30f0c1"), "Android Green" },
                    { new Guid("3211288d-f600-4fe5-93e9-822e8e5a62cb"), "Amethyst" },
                    { new Guid("630a8a6c-862f-41cd-8aeb-25609c596a46"), "American Rose" },
                    { new Guid("f80ea686-076a-46cf-aecb-e7899e21d77b"), "Amber (SAE/ECE)" },
                    { new Guid("5d20402b-0ad7-427f-847a-d693249cd78c"), "Amber" },
                    { new Guid("de641e04-cd8a-4822-85d1-355495999f92"), "Antique Bronze" },
                    { new Guid("a98a6e89-c059-4061-a4bd-e5fa7bb1662c"), "Bitter Lemon" },
                    { new Guid("b50ef2ea-3468-41e2-a776-39a81129610b"), "Bitter Lime" },
                    { new Guid("59260171-531a-4b67-b283-a2079ab19d10"), "Bittersweet" },
                    { new Guid("9148eebd-9a4f-455b-adae-9743e0b26312"), "Brink Pink" },
                    { new Guid("f1a2d2d3-e24e-4d03-8d32-f4a18bfcd61a"), "Brilliant Rose" },
                    { new Guid("dfcdf473-4f10-4999-8dba-f39fa146ee49"), "Brilliant Lavender" },
                    { new Guid("9a7dab3d-cd6f-45c0-8f4e-c675b6cc2276"), "Brilliant Azure" },
                    { new Guid("6da06e28-7234-466d-96ce-1e5c399ce45a"), "Bright Yellow (Crayola)" },
                    { new Guid("2cbf2f89-db5a-4507-b660-06e598c88f2f"), "Bright Ube" },
                    { new Guid("8cf82e1f-289c-4a6d-bc01-6a45e2ddda49"), "Bright Turquoise" },
                    { new Guid("920596e2-718c-42c7-80bc-74037cf539e6"), "Bright Pink" },
                    { new Guid("18b01ce7-223d-4e99-97db-eb4411b3c500"), "Bright Navy Blue" },
                    { new Guid("79708aa3-99f1-4d14-a085-4ea0f1010c9b"), "Bright Maroon" },
                    { new Guid("5c933bab-16ed-4fb0-a960-7c304604e682"), "Bright Lilac" },
                    { new Guid("adaa548c-f5a5-4d9f-a31d-7a6ce398cfd3"), "Bright Lavender" },
                    { new Guid("37d990b3-140b-45f3-baee-ce881b218f2f"), "Bright Green" },
                    { new Guid("bc28c2d6-1ada-4ee9-8b1c-8289400ba6d1"), "Bright Cerulean" },
                    { new Guid("17ed1a11-b8cd-4418-92e7-886fe76149a8"), "Brick Red" },
                    { new Guid("8206d3fd-89d9-4503-8fea-6799dccaef44"), "British Racing Green" },
                    { new Guid("56457fee-a539-4be0-85e5-3d52195dfcd2"), "Bronze" },
                    { new Guid("5986e2c1-7e1d-4748-a6a1-dad954a56245"), "Bronze Yellow" },
                    { new Guid("43b0089a-c30b-4241-b99c-dc3246a1a3a7"), "Brown (Traditional)" },
                    { new Guid("b804cb96-e9b4-44cb-95bc-2cbdf511b3dc"), "Burnt Umber" },
                    { new Guid("159e0766-d640-49e7-9908-4b39384358df"), "Burnt Sienna" },
                    { new Guid("fcf45632-b41a-4fc4-8d7d-46d5ee575ddc"), "Burnt Orange" },
                    { new Guid("8e53753c-ca29-48cb-bd22-7e83e76c6fe6"), "Burnished Brown" },
                    { new Guid("1d276b1a-27ce-4f27-94d6-9acb9eb117a3"), "Burlywood" },
                    { new Guid("c5913213-398d-4d5f-8e6d-539a4a6dd6a7"), "Burgundy" },
                    { new Guid("6c7db9b1-ca03-43d4-aa60-386c5b727609"), "Bulgarian Rose" },
                    { new Guid("bd207de7-ccd8-404c-b64f-e22c8e961420"), "Brass" },
                    { new Guid("67d1dc7b-9a1c-4159-96d8-41f1e6566bfc"), "Buff" },
                    { new Guid("73d078f5-1caf-4835-a175-6c86cf334d4a"), "Bubbles" },
                    { new Guid("53513678-0bd1-4b21-a1f8-6da6b98c58b5"), "Bubble Gum" },
                    { new Guid("ad3a15f4-3206-4b3f-83cb-5a295e9aad48"), "Brunswick Green" },
                    { new Guid("faccd3e8-b3cc-42a3-ba14-9ee3be862e5a"), "Brown Yellow" },
                    { new Guid("6d333bf0-b4d2-447e-8009-7d82cfd81435"), "Brown Sugar" },
                    { new Guid("68b3b501-05e5-4d2a-a548-f49f367518cb"), "Brown-Nose" },
                    { new Guid("c42624a1-1817-4500-af79-8bef245516e1"), "Brown (Web)" },
                    { new Guid("5e6907e7-1198-430f-aff2-6683a7278a10"), "Bud Green" },
                    { new Guid("40de7603-5c15-495e-9406-6f659f4917f1"), "Brandeis Blue" },
                    { new Guid("330bfd24-d8ab-486b-bbf1-2c0af9804c8b"), "Boysenberry" },
                    { new Guid("4fe24026-139f-4457-8e36-21629b8b857c"), "Bottle Green" },
                    { new Guid("8ffd1ae3-6da2-4a4d-bc6d-2591a11ce273"), "Blue (NCS)" },
                    { new Guid("098da8c5-d7f0-4925-95b7-1e4d190086b7"), "Blue (Munsell)" },
                    { new Guid("70b9f459-6c05-4d00-9122-35a972c3daab"), "Blue (Crayola)" },
                    { new Guid("58e8c150-12f9-4923-9384-d6f5f2ddc9b5"), "Blue" },
                    { new Guid("e6738e5b-c747-469b-9a37-ba12cc506659"), "Blond" },
                    { new Guid("006dbb59-d41e-456c-87eb-98e47112159f"), "Blizzard Blue" },
                    { new Guid("f3c1184d-03f8-4dc3-b9f5-c9ff2397d661"), "Bleu De France" },
                    { new Guid("f0252c79-3e1f-451f-a0fb-7452245c9b3b"), "Blue (Pantone)" },
                    { new Guid("1dc4e457-d285-4f87-aeb9-c203fdfe315a"), "Blast-Off Bronze" },
                    { new Guid("ff71c50f-3a91-4fc5-bdb4-855708e013fb"), "Black Shadows" },
                    { new Guid("10471b5e-2fc3-4ad7-b8fb-9f93e3d86136"), "Black Olive" },
                    { new Guid("95ab346c-b2a8-4532-830b-aa98acb085e6"), "Black Leather Jacket" },
                    { new Guid("538f728c-3102-4d63-9d1f-7ae91365713e"), "Black Coral" },
                    { new Guid("399a1312-e201-43cd-9aa2-85608c7d7b0c"), "Black Bean" },
                    { new Guid("39dc87f3-93b4-429c-a0cc-8cbfa3014766"), "Black" },
                    { new Guid("bf5d9a25-ef9f-4b34-9298-259f2ad451af"), "Bittersweet Shimmer" },
                    { new Guid("db5c915f-3d08-4867-b4fe-cddc1e30eb5b"), "Blanched Almond" },
                    { new Guid("71697a6a-ef2c-4804-a973-abc3541a144c"), "Byzantium" },
                    { new Guid("17d9eb00-a3c9-4d37-9ac8-1d184fbcf299"), "Blue (Pigment)" },
                    { new Guid("95bf88a3-d9f9-4dbb-95dc-db62e4f2212e"), "Blue Bell" },
                    { new Guid("940c198d-dd34-418e-bd97-028284b486ee"), "Boston University Red" },
                    { new Guid("929cebff-5bfb-47c0-bf47-fd8a32b77176"), "Booger Buster" },
                    { new Guid("3f1b71ac-e7d1-435d-bffb-4b3cdba67069"), "Bone" },
                    { new Guid("b985efc2-c148-40a2-b737-af69e5be909e"), "Bondi Blue" },
                    { new Guid("a885e2c8-1e7b-4360-8be7-8b04448a0107"), "Bole" },
                    { new Guid("70151498-a80d-42a6-bdb1-0d62f78b0b76"), "Blush" },
                    { new Guid("f2bbcc7c-5530-487d-8bae-024e6fc7f550"), "Bluebonnet" },
                    { new Guid("826db787-0bdf-4e6a-abb9-619ca59a492f"), "Blue (RYB)" },
                    { new Guid("3240c34c-314e-45ff-adf2-ceadeb4d632d"), "Blueberry" },
                    { new Guid("6cc29e35-3b2c-4dcb-adfb-40bbdeed4a50"), "Blue-Violet" },
                    { new Guid("399645cd-6082-4584-b68a-379037eeee33"), "Blue Sapphire" },
                    { new Guid("02cb9a15-004a-4184-9a25-70d7e9abe38d"), "Blue-Magenta Violet" },
                    { new Guid("fd0190ac-0c8f-426f-b406-f0a51ca430f3"), "Blue Lagoon" },
                    { new Guid("25699b20-59a0-4115-bd23-f8a83cc442ae"), "Blue Jeans" },
                    { new Guid("cc387135-23dc-45a1-a40e-40c8ec641504"), "Blue-Green" },
                    { new Guid("6799c73c-09a1-4662-88af-c3f6d584e420"), "Blue-Gray" },
                    { new Guid("b0eacda6-918a-4721-9a51-15d46cba3fa2"), "Blue Yonder" },
                    { new Guid("658734b0-b59c-4403-a2b5-132781337d05"), "Dark Sea Green" },
                    { new Guid("7e40d2ac-0857-4e37-a410-65518f42ec2f"), "Chinese Violet" },
                    { new Guid("5f657591-2f3e-4145-9c82-a82c35b37b7e"), "Dark Sky Blue" },
                    { new Guid("2275b812-29db-4294-9bf3-a1d426a5fe6e"), "Imperial" },
                    { new Guid("318d3f86-1cea-4dba-a7ac-514e3d48457a"), "Illuminating Emerald" },
                    { new Guid("95fd130b-52bb-4fe4-b842-34e3246672b7"), "Icterine" },
                    { new Guid("07c34cd1-6257-41e9-b1a3-3277240e4b40"), "Iceberg" },
                    { new Guid("b2b89975-f0ae-4858-9fb5-eb053ec96c99"), "Hunter Green" },
                    { new Guid("a6bad065-f271-49d2-a345-e29b654465e4"), "Hot Pink" },
                    { new Guid("f5a0c5a3-04f2-435d-9f47-5410e3119c0c"), "Hot Magenta" },
                    { new Guid("2e68975c-1bbd-44af-8513-762011bcde96"), "Hooker's Green" },
                    { new Guid("5e00f73c-509d-4aa9-906b-9842838606cd"), "Honolulu Blue" },
                    { new Guid("031a7cd4-f2cc-4936-ad41-c64237e325dd"), "Honeydew" },
                    { new Guid("14ec95a7-db62-4a90-bb8b-6c419917fc1e"), "Hollywood Cerise" },
                    { new Guid("5745d62c-cff5-4630-8c71-d244992b643f"), "Heliotrope Magenta" },
                    { new Guid("4ad80581-980c-4cca-a797-38f1d3290781"), "Heliotrope Gray" },
                    { new Guid("55c7a576-7637-4633-8fa2-f52551705e30"), "Heliotrope" },
                    { new Guid("a37b00f7-4866-4b12-aaf8-630060e36bda"), "Heat Wave" },
                    { new Guid("427e1ff2-a708-4740-8ef1-91721968a02a"), "Imperial Blue" },
                    { new Guid("93c3f6de-baf5-4786-8379-a6b00eb5f945"), "Imperial Purple" },
                    { new Guid("3c598558-6ee2-4cc3-8631-cf3f4d48b704"), "Imperial Red" },
                    { new Guid("a78c8a29-1d1c-408f-a7c1-dd246f165faf"), "Inchworm" },
                    { new Guid("e85b479f-9cdc-4d22-b7d3-fb744ced7d20"), "Italian Sky Blue" },
                    { new Guid("f4df0180-854e-447b-8054-faa89a2e9fa1"), "Islamic Green" },
                    { new Guid("a6ec6174-9b47-4427-9010-379eaf546055"), "Isabelline" },
                    { new Guid("cdb3e39b-187a-4717-964d-739515359965"), "Irresistible" },
                    { new Guid("5d307fb3-a8f1-4432-a009-4adeffad0163"), "Iris" },
                    { new Guid("503432e7-1736-4d69-a23d-a2a2f81a038c"), "International Orange (Golden Gate Bridge)" },
                    { new Guid("75babc69-e0cc-4add-b258-330e87896642"), "International Orange (Engineering)" },
                    { new Guid("b2deef23-c800-4c8a-b938-59d2bfd5fd35"), "Heart Gold" },
                    { new Guid("5f6669ff-9f08-4c39-9082-5dfabf45ddac"), "International Orange (Aerospace)" },
                    { new Guid("2eda46e4-427a-482f-a949-e6b7c6b4d10f"), "Indigo (Web)" },
                    { new Guid("b66e9354-7c8d-4071-9bf5-ec171dea8b6e"), "Indigo Dye" },
                    { new Guid("1e12833a-a8f0-41a1-ad75-0bf4435e66ba"), "Indigo" },
                    { new Guid("69dc9e0d-ea2c-4d5f-8cf9-1a40cb360c78"), "Indian Yellow" },
                    { new Guid("38284239-7937-4b4c-8298-bb6c0b96a4bf"), "Indian Red" },
                    { new Guid("2e9f2367-3afa-4f55-9049-b60de7aa3bb9"), "India Green" },
                    { new Guid("944ccfde-adc9-41d6-b7f8-12fea7faa918"), "Independence" },
                    { new Guid("1509111e-faf5-4074-887a-228f2f66e486"), "International Klein Blue" },
                    { new Guid("36344a36-1231-4176-ac29-333c6a40ea07"), "Ivory" },
                    { new Guid("4a1bd24d-878f-42b6-8821-60dd5135df9a"), "Harvest Gold" },
                    { new Guid("3f76a30e-0ca9-4146-bcbd-fddce274adb3"), "Harlequin Green" },
                    { new Guid("3df4975d-8954-480e-a513-ef5d3a63b8d5"), "Green (Crayola)" },
                    { new Guid("192fcaaa-8231-4211-aa3a-db2e0200e676"), "Green (Color Wheel) (X11 Green)" },
                    { new Guid("169ace8d-de3a-409e-80e3-e682db48c3c3"), "Gray-Blue" },
                    { new Guid("24b19c80-1f22-4a47-a7c3-9ed27a00b765"), "Gray-Asparagus" },
                    { new Guid("29b6a974-d93e-4219-96db-a78890783613"), "Gray (X11 Gray)" },
                    { new Guid("f9a5fd9c-0e25-4919-9a18-85bba01efef8"), "Gray (HTML/CSS Gray)" },
                    { new Guid("0f92f092-c640-40c9-8cc3-3a77026d9494"), "Gray" },
                    { new Guid("ca1701f2-598e-442c-88ef-f9c7d6527f4d"), "Grape" },
                    { new Guid("d05c8993-56fd-4021-8dc6-4b1810aca257"), "Granny Smith Apple" },
                    { new Guid("a6f412c3-18af-412c-92a5-ec6eaa0d7c7a"), "Granite Gray" },
                    { new Guid("095415b7-b561-4b0a-b342-9a95484eab7f"), "Goldenrod" },
                    { new Guid("0803b929-a9f6-47b5-a8cb-2e9c3f108f95"), "Golden Yellow" },
                    { new Guid("d4c28e3e-f108-41f8-9688-ca29f4b20f88"), "Golden Poppy" },
                    { new Guid("7c40fa2a-d465-4199-adc8-6f5b2255c2a0"), "Golden Brown" },
                    { new Guid("e34256aa-da19-445f-8f5c-a40e1d1406fd"), "Gold Fusion" },
                    { new Guid("1f020067-e4c3-4b48-a126-a0a23d2d9626"), "Green (HTML/CSS Color)" },
                    { new Guid("41304b34-a09f-4d5a-9e1b-61bfcabfee39"), "Green (Munsell)" },
                    { new Guid("add023a6-aba3-4c29-8124-4f2a715305d0"), "Green (NCS)" },
                    { new Guid("86dd5a26-5891-414a-a9b0-7e88dec1fbb5"), "Green (Pantone)" },
                    { new Guid("497b931b-11c9-4985-b26f-5857f6c01013"), "Harlequin" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a8bfdabb-87c8-440d-85ef-5006e80bc93b"), "Hansa Yellow" },
                    { new Guid("32823fdb-a375-4e0a-ab43-0d29954e0ec7"), "Han Purple" },
                    { new Guid("18a9bcb1-7ba9-43ba-892e-4236cd7aec65"), "Han Blue" },
                    { new Guid("3ded5888-fd0f-4e4b-a352-2a9238fdef6e"), "Halayà Úbe" },
                    { new Guid("9209d2b5-0183-482f-86c9-0cb89c317db6"), "Gunmetal" },
                    { new Guid("c9961fde-e582-44f0-a844-01517c01d410"), "Guppie Green" },
                    { new Guid("fd5d7093-d6cf-4f05-ad28-2204165b0b48"), "Harvard Crimson" },
                    { new Guid("faebfc5a-ecfe-47e3-8307-61c3f8096f1b"), "Grullo" },
                    { new Guid("9d6fed8a-1aa9-4ccc-9725-5a79471d8375"), "Green-Yellow" },
                    { new Guid("fa337fed-6cf5-495e-9c62-9eef15453104"), "Green Sheen" },
                    { new Guid("e56acb40-e113-4946-84c3-5c313fa30d7e"), "Green Lizard" },
                    { new Guid("096d051a-bb29-485b-aa0a-369ef920f76d"), "Green-Cyan" },
                    { new Guid("031ac03c-3bf4-4283-b6b1-acacb9006e32"), "Green-Blue" },
                    { new Guid("9954f047-6ab5-433a-8b85-2c1b54485eff"), "Green (RYB)" },
                    { new Guid("528a5f7a-3e53-4a7b-96bf-953eb2e71557"), "Green (Pigment)" },
                    { new Guid("0cf96cf5-fb90-4848-abef-30fdb58a26d0"), "Grizzly" },
                    { new Guid("7f93439e-8bca-4f97-9254-15217aeafea8"), "Gold (Web) (Golden)" },
                    { new Guid("94492484-3870-43a9-8bc8-e6bb198a9639"), "Jade" },
                    { new Guid("afca88d1-0f53-4233-a20f-3d85b60f46cf"), "Japanese Indigo" },
                    { new Guid("fd7d0354-7615-4277-a094-f6244fb7afa4"), "Light Carmine Pink" },
                    { new Guid("881b3c51-b4ae-4e76-8a6d-d7fb83ab3906"), "Light Brown" },
                    { new Guid("1af90c0f-09ef-41dc-85b3-a571c67b7e1e"), "Light Brilliant Red" },
                    { new Guid("1377ecf9-8085-4dd4-b938-5893a43f4494"), "Light Blue" },
                    { new Guid("988af716-12bc-46ce-ac80-f66a5e2268fe"), "Light Apricot" },
                    { new Guid("ed993e98-36fe-40ce-9ada-e5e6cf088ede"), "Liberty" },
                    { new Guid("c20293ca-5317-404f-89cc-76171fb6d63c"), "Licorice" },
                    { new Guid("8af0e113-801b-4857-b9c3-03ce5d995dfe"), "Lenurple" },
                    { new Guid("bf2d3a83-000d-4675-90dc-473c40d7836a"), "Lemon Yellow" },
                    { new Guid("1883e9eb-dc4b-4ed7-b4f6-c8b1c365a1a1"), "Lemon Meringue" },
                    { new Guid("3ecd49a2-e6c0-4593-bc68-4bf4d8305b14"), "Lemon Lime" },
                    { new Guid("d2ff4415-ca5e-427c-ad23-644b290a7bb4"), "Lemon Glacier" },
                    { new Guid("3f706e7e-67fc-4908-8674-2c8aad9c6008"), "Lemon Curry" },
                    { new Guid("fd940f85-b4a4-4443-a611-d0ddc9f2e3c0"), "Lemon Chiffon" },
                    { new Guid("b6296b6b-0bcd-40a3-82bd-51031a8a5964"), "Lemon" },
                    { new Guid("1a7f674c-0a55-49db-a59f-8e0a1ac40e1e"), "Light Cobalt Blue" },
                    { new Guid("18022831-ddfa-40c9-90e3-325c37c62802"), "Light Coral" },
                    { new Guid("8aa0ea2f-c3f1-47e3-ba7e-06ff5b1ac77e"), "Light Cornflower Blue" },
                    { new Guid("77b861e5-f0b9-4b59-a1db-f09ee1b53ea8"), "Light Crimson" },
                    { new Guid("07594dc9-19e7-4c0a-952b-372e68c8c09a"), "Light Red Ochre" },
                    { new Guid("eeb06701-e9ce-4e5b-8ea9-5562f031eebf"), "Light Pink" },
                    { new Guid("71e549dc-baa0-4099-82b5-2688867e3adf"), "Light Pastel Purple" },
                    { new Guid("ae872a17-c5f3-4cc1-905e-fa5f9d45ff70"), "Light Orchid" },
                    { new Guid("d4625777-3388-43a6-80eb-48efe3418851"), "Light Moss Green" },
                    { new Guid("3d5e668a-7cab-4174-b3da-c7dcbae13f2e"), "Light Medium Orchid" },
                    { new Guid("ba05cccf-5306-4324-ab41-e157348f6fda"), "Light Khaki" },
                    { new Guid("e84e8d5a-5cc8-4754-9a75-6562104b38b0"), "Lawn Green" },
                    { new Guid("90c901d0-c4d7-48c4-b604-522aefae7719"), "Light Hot Pink" },
                    { new Guid("67745053-1b47-462a-8a23-cf273ae4affb"), "Light Grayish Magenta" },
                    { new Guid("fd4809d4-08c2-478e-b070-af26a2fdcf35"), "Light Gray" },
                    { new Guid("b8469508-8171-4780-8efd-806aab87d10a"), "Light Goldenrod Yellow" },
                    { new Guid("a5dddf25-9e53-4667-aa85-77ef93306456"), "Light Fuchsia Pink" },
                    { new Guid("78e36272-90d8-4cc5-906f-ec4a23c85136"), "Light French Beige" },
                    { new Guid("59fcd100-c0ac-498e-b531-2f229c971608"), "Light Deep Pink" },
                    { new Guid("a4a1a8cf-1691-42cb-8c23-a875de594b84"), "Light Cyan" },
                    { new Guid("d58efaa3-5b64-426b-bc77-34a537de1f33"), "Light Green" },
                    { new Guid("5a2f5f80-bccc-46d0-a12a-d655c424ad66"), "Japanese Carmine" },
                    { new Guid("2ce14728-8008-47df-b2c4-7d2cb201b188"), "Lavender Rose" },
                    { new Guid("94164d69-3629-4a2e-8c38-e5f87b35f3b0"), "Lavender Pink" },
                    { new Guid("f5b4dd97-1eda-4f0f-b3c2-1923eb80aa4d"), "Khaki (HTML/CSS) (Khaki)" },
                    { new Guid("c67bf907-4737-4adf-a0af-c57f555d7e0b"), "Key Lime" },
                    { new Guid("a7df82de-4da0-4a93-b54c-57a6425763e5"), "Keppel" },
                    { new Guid("d0dd4f75-81cb-480c-a38d-dffeed27da44"), "Kenyan Copper" },
                    { new Guid("66f75af2-df4d-44b7-a6d2-1a21aa272ee3"), "Kelly Green" },
                    { new Guid("4b63cec2-e2a4-48e3-8279-860bbdaa59eb"), "Jungle Green" },
                    { new Guid("7c973301-9c3f-4c23-83ec-1f9e568c0650"), "June Bud" },
                    { new Guid("5a513da8-08e3-4d3b-9f7a-8b0ff32bb4fb"), "Jordy Blue" },
                    { new Guid("fc1379fe-cca9-4002-9481-8340e95c5acd"), "Jonquil" },
                    { new Guid("a05c40b6-0fd3-400d-8bbd-778474c5c3de"), "Jet" },
                    { new Guid("7cf524e5-5fb7-4fa0-9060-d5acb6bc4c86"), "Jelly Bean" },
                    { new Guid("c648e797-b425-4ae0-8551-77e2171fdada"), "Jazzberry Jam" },
                    { new Guid("472ea937-d8d1-4ab1-82c8-ecab34e32b82"), "Jasper" },
                    { new Guid("39c1bd1e-c05c-49f4-96b4-38f6a83d9da6"), "Jasmine" },
                    { new Guid("7d9385ed-9c85-43b2-860e-dba722ec1ac5"), "Japanese Violet" },
                    { new Guid("c0503396-5e4f-4a0f-a0e6-782d5ef4fc8d"), "Khaki (X11) (Light Khaki)" },
                    { new Guid("1dbb4dd6-2279-4f1f-a89f-09aece16836e"), "Dark Sienna" },
                    { new Guid("ec18c0af-f55e-4f83-9dab-031cb17a1470"), "Kobi" },
                    { new Guid("3dc6d222-d30a-4eab-84f2-46c325d3440b"), "Kobicha" },
                    { new Guid("6f187f50-c8fd-4aa1-8474-d5807182a5cc"), "Lavender Mist" },
                    { new Guid("164dc62c-60fb-4e74-87fd-55e27115c8d2"), "Lavender Magenta" },
                    { new Guid("62d22eea-50af-4995-ac05-d0c55bef2d31"), "Lavender Indigo" },
                    { new Guid("3d07cf0a-47f0-414c-81ed-d5b865480c4c"), "Lavender Gray" },
                    { new Guid("071ebcc5-f0df-4f5e-acb9-b4178fc514b3"), "Lavender Blush" },
                    { new Guid("a905f95d-387b-478b-87e2-b3c4ca4c15df"), "Lavender Blue" },
                    { new Guid("1773f9a1-265d-41f2-b5d3-94780d642f6e"), "Lavender (Web)" },
                    { new Guid("58ce3f98-42a1-45d5-8b89-c1f37220345a"), "Lavender Purple" },
                    { new Guid("b13c6dc5-c0f7-4cad-b089-b68cd7e76350"), "Lavender (Floral)" },
                    { new Guid("22bd82ba-6e18-47dd-ac63-d733b697c72f"), "Laurel Green" },
                    { new Guid("4c51f48e-4b8a-43c6-b69c-5512b7ff742f"), "Laser Lemon" },
                    { new Guid("cc4c8dd2-dbb3-4dae-8af1-3e4812d7963a"), "Lapis Lazuli" },
                    { new Guid("25323dd1-0c3a-4883-b150-2e21e9947c63"), "Languid Lavender" },
                    { new Guid("fe5373aa-ea84-4ff5-b910-f41cf37a90ed"), "La Salle Green" },
                    { new Guid("ba61f4df-f588-4b71-8b26-17d9a5a8ca8d"), "KU Crimson" },
                    { new Guid("bed34c87-62bc-4722-be39-9719f7122b69"), "Kombu Green" },
                    { new Guid("fe8bd7fa-c91e-4e52-b6ec-0dc4914d9efe"), "Lava" },
                    { new Guid("78cfc4c9-9747-40fc-9ddd-288f0487c65d"), "Gold (Metallic)" },
                    { new Guid("27401bac-c618-44b7-bbcc-9d1258b1496d"), "Kobe" },
                    { new Guid("bea81afb-ec0e-47da-b11f-e244f56adb72"), "Glossy Grape" },
                    { new Guid("238fa585-99d0-4924-b64c-da89ed170897"), "Dingy Dungeon" },
                    { new Guid("dcea6174-da1d-463d-b987-9c0ecf37ddea"), "Dim Gray" },
                    { new Guid("c0b0f387-f0d7-4a21-8a93-f69976077b6d"), "Diamond" },
                    { new Guid("3eb691d9-efe1-43da-a141-37e2680d1b10"), "Desire" },
                    { new Guid("192ccd7e-b8f4-4d5b-88e1-767d96b891fc"), "Desert Sand" },
                    { new Guid("6bf23aeb-5387-40b6-8cfe-c6b4618cd579"), "Desert" },
                    { new Guid("0d736f35-41c0-453f-9be4-30c8019bce6f"), "Desaturated Cyan" },
                    { new Guid("e73f4872-41e7-4ca0-81e8-e26c8e13bfca"), "Denim Blue" },
                    { new Guid("9e03ed75-5c73-41d7-90a0-1abc3039a029"), "Denim" },
                    { new Guid("d7d32ddd-9f02-474a-9131-8255234e5e30"), "Deer" },
                    { new Guid("dbe4f58d-62d5-4698-a149-468d292da7b7"), "Deep Violet" },
                    { new Guid("21da0127-5ae3-478f-98bb-e0a342208959"), "Deep Tuscan Red" },
                    { new Guid("816d682a-fbac-4680-b545-67824f396946"), "Deep Taupe" },
                    { new Guid("818befdb-cd77-4a95-bb2d-e1287e668afe"), "Deep Spring Bud" },
                    { new Guid("3b951f21-5f34-41b9-af5c-1606644f1da7"), "Deep Space Sparkle" },
                    { new Guid("e25844a0-089a-4b81-bb87-a3e33f949125"), "Dirt" },
                    { new Guid("2693cdb1-fb4a-4446-83c6-6c999fc7a85d"), "Dodger Blue" },
                    { new Guid("7933c002-0f09-4196-9666-c53e7a48c2e8"), "Dogwood Rose" },
                    { new Guid("0051d8ea-2eb0-43be-95fa-6251459ad585"), "Dollar Bill" },
                    { new Guid("2b718b38-c32c-419e-9c35-55eaa0195b8d"), "Electric Green" },
                    { new Guid("faf6aef5-8b5e-4f58-81fa-79a7b8608552"), "Electric Cyan" },
                    { new Guid("5a521d02-38af-4f66-8c0a-7a436530e503"), "Electric Crimson" },
                    { new Guid("75e75fed-095c-4835-884e-22f3e2673d5e"), "Electric Blue" },
                    { new Guid("89d626b8-5a72-451d-a6ad-a0c8da61593d"), "Egyptian Blue" },
                    { new Guid("9abfbe26-6225-4818-a071-09d7da92ef43"), "Eggshell" },
                    { new Guid("3717e627-59be-4b29-8334-b7cecd9e4e0f"), "Eggplant" },
                    { new Guid("80351d22-9e8e-4d5b-b1c3-c2b0c7870f42"), "Deep Sky Blue" },
                    { new Guid("a80eda6c-a35c-4678-b9fb-f7f99712c6ac"), "Eerie Black" },
                    { new Guid("39ec02ec-663b-4d25-85e6-274f15e7c20a"), "Ebony" },
                    { new Guid("43a38f5c-67c9-4af0-8fb0-8e896ea6c794"), "Earth Yellow" },
                    { new Guid("ec6c4272-e053-4768-8e25-d0ffe08ca14b"), "Dutch White" },
                    { new Guid("56f21334-1985-4592-a814-ce82c79d3363"), "Dust Storm" },
                    { new Guid("d19666c7-9757-4ccd-892c-07b32beab443"), "Duke Blue" },
                    { new Guid("790ced00-9c63-4f63-8cca-79b723bb6d9d"), "Drab" },
                    { new Guid("9758dd93-d5b7-431c-b030-e200ef530316"), "Donkey Brown" },
                    { new Guid("0a83a249-253e-4e18-b20c-2192e148493d"), "Ecru" },
                    { new Guid("afd37206-da81-4efd-9cce-949d9784562e"), "Deep Saffron" },
                    { new Guid("84c10525-7386-4961-96ea-d71caca6123a"), "Deep Ruby" },
                    { new Guid("a2c43806-6198-4ff2-b8e4-04cde2b03ab7"), "Deep Red" },
                    { new Guid("21232240-d008-4ccd-bf96-0dfa20309547"), "Deep Aquamarine" },
                    { new Guid("5310cac3-3ddf-44df-9522-504ac3b4bc66"), "Debian Red" },
                    { new Guid("0e277a47-01f6-4dfe-9c1a-e4a08d8b97a7"), "Davy's Grey" },
                    { new Guid("c88400d7-dba1-48b1-97c3-a212132cf640"), "Dartmouth Green" },
                    { new Guid("f6130503-7e24-46f9-ac1d-ded0275d4392"), "Dark Yellow" },
                    { new Guid("86c77759-febe-4443-bca9-5807c213cf37"), "Dark Violet" },
                    { new Guid("0354a53e-9cbc-4991-937f-c1567e6511df"), "Dark Vanilla" },
                    { new Guid("b07ac4ff-b567-4036-bfdf-a4a0426139b5"), "Deep Carmine" },
                    { new Guid("9ae16843-a22f-478d-a66e-64070c09336c"), "Dark Turquoise" },
                    { new Guid("6c8bd240-fde3-4785-a0dc-d58f8447b7e9"), "Dark Taupe" },
                    { new Guid("4588fcfb-791a-406b-98a2-ead621102613"), "Dark Tangerine" },
                    { new Guid("39db5215-fc0c-46c9-93eb-d4252e4faa8c"), "Dark Tan" },
                    { new Guid("89eaead0-2e23-4019-91c9-8dcfc4def70b"), "Dark Spring Green" },
                    { new Guid("f68bc3e9-806d-4bcb-8d87-17d81ec315fe"), "Dark Slate Gray" },
                    { new Guid("06dd57eb-8e64-4eb6-93c9-092615901cb8"), "Dark Slate Blue" },
                    { new Guid("59f1337b-d099-443a-b836-f186f6bf6c62"), "GO Green" },
                    { new Guid("737865ee-16ba-428c-880f-9bbbb6beec85"), "Dark Terra Cotta" },
                    { new Guid("4c1156c1-9b3f-495c-9ec9-f9a4c5bcc064"), "Electric Indigo" },
                    { new Guid("c445ce58-9301-44c6-8ceb-ed5f4586c162"), "Deep Carmine Pink" },
                    { new Guid("3b23041a-3cd9-40af-bc9c-910bbe73dc69"), "Deep Cerise" },
                    { new Guid("f0547ee7-8c6d-4d63-8819-d05ce982cbaa"), "Deep Puce" },
                    { new Guid("955bf350-7fb0-46d8-8277-f351fa0234f4"), "Deep Pink" },
                    { new Guid("a732f67a-b6da-4a0a-9780-e4303450612f"), "Deep Peach" },
                    { new Guid("32d272ad-4d36-4ca2-9560-a59edfa336bd"), "Deep Moss Green" },
                    { new Guid("df4afbfa-2f20-40eb-8ee0-dfd43bea6c58"), "Deep Mauve" },
                    { new Guid("d1fdc999-b4c9-4cf7-9e16-c7fc6dec3166"), "Deep Maroon" },
                    { new Guid("effbec7f-7481-4960-8803-b66f65f5c003"), "Deep Lilac" },
                    { new Guid("d6bc1f43-06eb-410a-952c-ab4c5ab8d030"), "Deep Carrot Orange" },
                    { new Guid("61c60e83-27cd-4f75-8627-2e46b99e60ac"), "Deep Lemon" },
                    { new Guid("0119ffca-5f0c-415e-b606-8fefec5a1705"), "Deep Jungle Green" },
                    { new Guid("dc33dd66-c66e-4ad5-8e26-25ef453dd2fb"), "Deep Green-Cyan Turquoise" },
                    { new Guid("f09053ec-e26e-49d1-b945-ecb0d4568560"), "Deep Green" },
                    { new Guid("7bfe6b95-cd51-43d4-954a-7b50b3b9bd73"), "Deep Fuchsia" },
                    { new Guid("8f1de441-899d-421f-a689-41e7fcaaf058"), "Deep Coffee" },
                    { new Guid("7f043698-0448-4334-a5c1-3404145eeccb"), "Deep Chestnut" },
                    { new Guid("514d39f4-e6ac-4524-a605-d5f9c9d50ec5"), "Deep Champagne" },
                    { new Guid("e23f658d-de1e-49b0-9244-92e1085f4e49"), "Deep Koamaru" },
                    { new Guid("8d56e96d-68de-4f76-b5ff-fa187ae79243"), "Electric Lavender" },
                    { new Guid("81fb06ff-898e-4e49-ba19-968af9ddde08"), "Deep Magenta" },
                    { new Guid("6155a2b5-b1e8-4e04-b72c-e13b15e19345"), "Electric Purple" },
                    { new Guid("878c60b3-abe7-49ad-8c39-c52d0f1d9d30"), "French Wine" },
                    { new Guid("6fae3f00-5678-49d4-9652-a6ee92771ecb"), "French Violet" },
                    { new Guid("24103333-cf5e-4efd-a817-fa1507fddbcb"), "French Sky Blue" },
                    { new Guid("21e258e3-7122-42ae-8c9b-29b412b7a986"), "French Rose" },
                    { new Guid("3a2e1794-c927-4dc0-ba43-80c8e51ba39b"), "French Raspberry" },
                    { new Guid("3c30f8c6-f57d-4146-9c2d-296dd5627b4c"), "French Puce" },
                    { new Guid("5b23348f-6d90-4b26-8425-6a8fc1cb0755"), "French Plum" },
                    { new Guid("52cb99b6-291e-4d01-b222-08282e9db9c3"), "French Pink" },
                    { new Guid("6e523711-aba2-4308-a212-c5ad39b1b23c"), "French Mauve" },
                    { new Guid("09786ee0-7419-4a8e-9a5c-54a17709fe0b"), "French Lime" },
                    { new Guid("b8cd0aea-e0a0-4215-9b87-bd2b655533e3"), "French Lilac" },
                    { new Guid("e3ea0c79-270d-462d-b94e-b295e4bd143c"), "French Fuchsia" },
                    { new Guid("cefc0a2a-ac61-412f-87e5-644e1ff759ba"), "French Blue" },
                    { new Guid("889a83b2-d35d-4590-8eba-b95bbb93bb5b"), "French Bistre" },
                    { new Guid("cda1da69-e4e0-409f-8a2e-e51fd88cf3c9"), "French Beige" },
                    { new Guid("395c1f97-df53-4a4e-89b9-08805285939c"), "Fresh Air" },
                    { new Guid("9bc2cff9-374c-41a9-8a5b-b55d28537b66"), "Frostbite" },
                    { new Guid("d774aef0-a2cb-4c85-805f-eeb2d3fa193c"), "Fuchsia" },
                    { new Guid("2b9a82d4-5650-4427-a398-6cf2f4d1cbfd"), "Fuchsia (Crayola)" },
                    { new Guid("225354df-2442-40ed-ae44-d8f5616d578e"), "Glitter" },
                    { new Guid("f271b56a-d7bd-45b9-afb5-a3ea794b4e2a"), "Electric Lime" },
                    { new Guid("44b3be00-eb15-45b2-a8db-da923b70bcbb"), "Glaucous" },
                    { new Guid("36ca62ce-3baf-49b1-b43f-9e1af2867839"), "Ginger" },
                    { new Guid("ea928f01-dc58-4dea-8353-a83983b657ce"), "Giants Orange" },
                    { new Guid("8f8d9d6d-4ed6-4bbf-85d3-151815cc5c56"), "Giant's Club" },
                    { new Guid("791882e9-8e68-4254-9d59-1a9bb1eaed5f"), "Ghost White" },
                    { new Guid("8dd68e1f-ce5b-47c5-90f3-6252dfd4cf89"), "Forest Green (Web)" },
                    { new Guid("66c965f1-f002-44f4-a12e-01c336d3a7e7"), "Generic Viridian" },
                    { new Guid("15add500-37b6-4863-ad10-1ff2c3fe9683"), "Gamboge Orange (Brown)" },
                    { new Guid("7df4f231-5ae8-4dd4-ba4c-323bb6c8dac4"), "Gamboge" },
                    { new Guid("fd58cb9b-e890-4685-926f-514fa58efe06"), "Gainsboro" },
                    { new Guid("467318f6-bc14-494a-94f6-c6babbf10b2e"), "Fuzzy Wuzzy" },
                    { new Guid("816ef9a2-cd14-4cb3-bd04-923c99b58b2e"), "Fulvous" },
                    { new Guid("5aa8e858-e367-4244-8629-4f5243e51356"), "Fuchsia Rose" },
                    { new Guid("f7fe80f6-f875-47b6-aefc-1fd483d95793"), "Fuchsia Purple" },
                    { new Guid("f0d3c721-16f4-4aa3-b2bc-bed26d3a2340"), "Gargoyle Gas" },
                    { new Guid("9a5d6f4b-7ef1-40b4-8eb7-d59bd4359927"), "Forest Green (Traditional)" },
                    { new Guid("6041e7c4-3bae-4a22-82b5-af125b8aa5f2"), "Fuchsia Pink" },
                    { new Guid("e581389e-0e59-4480-9a69-fb5a21a6d806"), "Fluorescent Yellow" },
                    { new Guid("05ed6441-f0da-4c5d-bd6a-d9542f33d935"), "Fandango Pink" },
                    { new Guid("bf269548-12e9-45f4-abcf-7d902c7c5439"), "Fandango" },
                    { new Guid("3560cf3f-5523-4bbc-a891-459e2a126986"), "Falu Red" },
                    { new Guid("cd9e681f-60cb-4951-a461-25fadb9725c2"), "Fallow" },
                    { new Guid("79805bd0-cd6f-4f36-920f-c13a3bd6cf45"), "Eucalyptus" },
                    { new Guid("b33d4781-4b88-4bfa-9b30-f6bc5b6f9ff6"), "Eton Blue" },
                    { new Guid("54ee38df-cc40-4e6b-a8ef-a163ce2f34dc"), "Electric Ultramarine" },
                    { new Guid("2c482fdd-1fe4-439b-8765-91d988efe5a9"), "Fashion Fuchsia" },
                    { new Guid("92207be4-6fbb-475b-89f4-7cfd7da26187"), "English Vermillion" },
                    { new Guid("f3fb524c-51f5-4223-96a7-ec9fb9804ed0"), "English Lavender" },
                    { new Guid("9928e6ae-f0ff-46e8-9cf0-7b801248ed38"), "English Green" },
                    { new Guid("6f919d4a-7f00-4109-8412-8880cc590901"), "Eminence" },
                    { new Guid("cb80d1ad-b4b6-475f-8f63-d6d4c63e0fe4"), "Emerald" },
                    { new Guid("41b8f6e8-ea07-4014-81f0-c7a4a22e5360"), "Electric Yellow" },
                    { new Guid("dcc836b0-a88b-4f1b-b2fe-f64e7e9194d7"), "Folly" },
                    { new Guid("7e5e9c6a-db6f-476d-ae3a-91319a2ad5f8"), "Electric Violet" },
                    { new Guid("7e3a1a6a-7d97-48f5-ae19-65e0371a7943"), "English Red" },
                    { new Guid("c07d180e-0547-4f74-a041-33ea455a9ccb"), "Fawn" },
                    { new Guid("e4572614-a0c1-449a-9a2b-a3f37eb531a3"), "English Violet" },
                    { new Guid("882df965-0b82-4b57-b1d0-fc1f9168aa9e"), "Flavescent" },
                    { new Guid("4de981cf-d9d3-4452-8e04-f645884ca066"), "Fluorescent Orange" },
                    { new Guid("57b86634-c043-438a-a023-76d088efd57a"), "Feldgrau" },
                    { new Guid("a2ef8322-df78-4b77-8b61-3534582d5f7f"), "Floral White" },
                    { new Guid("eac1e1f3-11c8-4081-8d68-a68dc3fa8c58"), "Flirt" },
                    { new Guid("cff8754b-05cb-4fd5-9aa9-ac95ef82f692"), "Flax" },
                    { new Guid("6156f3ef-2cdd-48f5-b674-e3de5e30aca2"), "Flattery" },
                    { new Guid("fba118d5-915c-477e-bb6d-2e08310a06bb"), "Flamingo Pink" },
                    { new Guid("5fbd0a16-e585-49ca-bc2d-b45bf57e0ed8"), "Flame" },
                    { new Guid("c9f415ad-9da4-4117-9b84-bddc793b0474"), "Fluorescent Pink" },
                    { new Guid("b3d70e3f-c78d-4239-9da1-53a4e83b510f"), "Firebrick" },
                    { new Guid("01cfe7bd-43ed-4550-85b8-9c67aaed6ded"), "Fiery Rose" },
                    { new Guid("f55fe5e8-53d0-40c6-81cb-67795eee7985"), "Field Drab" },
                    { new Guid("0313e157-1bae-44a8-a4a4-8364461c6c8a"), "Ferrari Red" },
                    { new Guid("68788f55-f63f-4638-a959-b36c5b271f1f"), "Fern Green" },
                    { new Guid("16c2986d-3d88-45e5-83df-83093a71df31"), "Fire Engine Red" },
                    { new Guid("74f61265-035d-46a2-989d-900f703e2511"), "Feldspar" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("532109b5-12c4-4616-9f58-e13570c37ec1"), "Norway" },
                    { new Guid("3a2f8331-06b6-4b5f-996b-e62507ff4a6b"), "Nigeria" },
                    { new Guid("70e7c919-5f6d-4d63-82fc-6dbb1062c67c"), "Niger" },
                    { new Guid("aac52447-c9e7-4a5d-a789-090165b863ff"), "New Zealand" },
                    { new Guid("4ae76072-626c-413b-864e-f6dc6f031547"), "Nauru" },
                    { new Guid("51120501-4708-43c4-9235-40f960c3d9f5"), "Netherlands" },
                    { new Guid("f23e0e1a-cd98-4b24-a325-3bc546d125c8"), "Oman" },
                    { new Guid("0e3262a9-1219-43ff-b7d2-afcd16d90c73"), "Nepal" },
                    { new Guid("043f6f9f-d2b2-468e-a0c9-8e905871be36"), "Nicaragua" },
                    { new Guid("e92b443a-d6a9-44ff-8539-1047dc52f527"), "Romania" },
                    { new Guid("eb1762cd-2ac1-4ed8-97f0-f08022252698"), "Philippines" },
                    { new Guid("1a553885-a630-4c49-be9d-777fe3cf570e"), "Palau" },
                    { new Guid("868363be-b51f-4221-a054-fcbde0ec7fb9"), "Panama" },
                    { new Guid("b804a898-52f5-4c42-bf08-165343d41806"), "Papua New Guinea" },
                    { new Guid("759f07d0-975f-4884-abda-96ac3616a395"), "Paraguay" },
                    { new Guid("f5ba9a6e-dee8-4086-9e98-ff0bd2c63a41"), "Peru" },
                    { new Guid("cdf311b7-b4e7-4fb0-b68c-c0e392ee5237"), "Poland" },
                    { new Guid("76fd2dc8-b110-4d25-809f-a569b5a2ed0a"), "Portugal" },
                    { new Guid("6a683061-d3f8-4efc-885c-adfac3056be9"), "Russian Federation" },
                    { new Guid("01dabc67-6416-4693-9c40-0eacc97cc0a0"), "Qatar" },
                    { new Guid("3d8e2588-46a8-4e50-b28f-ed48e63da967"), "Pakistan" },
                    { new Guid("39b870b3-c5bd-4e04-8ec2-f302532ba61d"), "Namibia" },
                    { new Guid("be277649-f863-4ec5-8858-37edb6d80f5a"), "Malawi" },
                    { new Guid("1a0a1e34-2e6f-4415-9744-155bb4c1024e"), "Mozambique" },
                    { new Guid("aa3a3aa4-c0ac-49d6-acae-c14d3d48914b"), "Liechtenstein" },
                    { new Guid("c2665174-9f9c-4f43-9004-34840129f35c"), "Libya" },
                    { new Guid("5181af2b-c814-45b0-8f51-73b29a6ee59f"), "Rwanda" },
                    { new Guid("a018d69a-89e9-42b8-b8f7-27501c0fc6b9"), "Lithuania" },
                    { new Guid("3e7c07d9-bb21-4eb3-8f9e-678d74fc3062"), "Luxembourg" },
                    { new Guid("7b65e755-9adb-48d7-9cf9-10d67fd5c8fd"), "Macedonia" },
                    { new Guid("46fd9092-16bd-430c-9f7b-007fdd6cb963"), "Madagascar" },
                    { new Guid("06bd7145-9bee-4e64-82e8-f2f453aa421a"), "Malaysia" },
                    { new Guid("8fb8908e-927c-4f8d-886d-c18557f8756b"), "Maldives" },
                    { new Guid("9d57b54e-4988-4f27-8a74-75f38cd4aeac"), "Mali" },
                    { new Guid("dc3202c3-fd85-4efa-8578-258ef90d8f86"), "Malta" },
                    { new Guid("012a178c-6dd2-4551-8c72-8c766062d8fd"), "Marshall Islands" },
                    { new Guid("c9c62ea8-6c4e-4c96-af6e-4547fa16133d"), "Mauritania" },
                    { new Guid("61ee3fd9-6974-4177-b84d-b81aaf91707e"), "Mauritius" },
                    { new Guid("d576cdea-7e04-41dd-a466-cf756d18d9c6"), "Mexico" },
                    { new Guid("5431a541-b40e-4269-a040-123315a03e5a"), "Micronesia" },
                    { new Guid("1dbc2f82-4904-4f1d-b305-add806a14665"), "Moldova" },
                    { new Guid("c8910eef-82be-42f3-bb7f-4b8e8847b818"), "Monaco" },
                    { new Guid("7ec946b2-356a-4e5e-9f36-ed1b90f41e0b"), "Mongolia" },
                    { new Guid("a5a5a626-179b-4a29-8de4-84a6dc398570"), "Montenegro" },
                    { new Guid("b5a43404-74ff-4d12-b3c7-fbea6b0b1a18"), "Morocco" },
                    { new Guid("11e6479b-effe-49dc-82c7-94e45949418c"), "Myanmar, {Burma}" },
                    { new Guid("5dce5035-362e-43fb-9814-28e7ce7c4813"), "St Kitts & Nevis" },
                    { new Guid("98da8e77-8523-4d5c-b4e6-e0d0b784e1da"), "Uganda" },
                    { new Guid("eb703028-6c7f-4d8b-9e92-306bc0920d21"), "Saint Vincent & the Grenadines" },
                    { new Guid("cf6d85aa-baff-4579-90b0-ae9779402038"), "Tanzania" },
                    { new Guid("d164f0ae-5cf7-433b-af2e-43308c22af2e"), "Thailand" },
                    { new Guid("68e64e6d-4399-4ac4-9f37-68ae93285711"), "Togo" },
                    { new Guid("9e57a0d8-ef6d-42d7-9804-c72d58643ec3"), "Tonga" },
                    { new Guid("ef565d35-c7b2-4aac-aa20-bdc90865fc47"), "Trinidad & Tobago" },
                    { new Guid("353bafd8-a36c-4aad-a2c1-0e71219553d8"), "Tunisia" },
                    { new Guid("8380517f-0317-4686-9839-3f06b6b51bcc"), "Turkey" },
                    { new Guid("491a6413-4fc3-4ee1-bc56-74f2b300b15e"), "Turkmenistan" },
                    { new Guid("e4582229-2f2f-452a-9317-3a4c425131e8"), "Tuvalu" },
                    { new Guid("244d6649-49a4-4737-ae4a-9b4d3a1d732c"), "Ukraine" },
                    { new Guid("52d460b9-c191-4a8a-9662-4e2242a2a620"), "United Arab Emirates" },
                    { new Guid("48e6a011-bbdf-45d1-bac4-ddba74568110"), "United Kingdom" },
                    { new Guid("5aa45a5c-1903-4633-88e4-11cd13fd6ba0"), "United States" },
                    { new Guid("8991902a-b072-4ec6-8828-40391f661443"), "Uruguay" },
                    { new Guid("fdb0e6c8-64c5-4a4b-9beb-053536ab2e38"), "Uzbekistan" },
                    { new Guid("42782d61-791e-4ac7-8c0f-9e8cfaffe1e5"), "Vanuatu" },
                    { new Guid("3d319e74-05ab-4ac3-bab5-00d387fa9c68"), "Vatican City" },
                    { new Guid("eb7125d5-3a49-4ce2-8003-e6931fc8e9ce"), "Venezuela" },
                    { new Guid("37a1a711-d146-4d64-8473-d0fd27b281db"), "Vietnam" },
                    { new Guid("6a5a2a58-7bf5-4f5c-9da7-9f1987d26946"), "Liberia" },
                    { new Guid("a614e1d4-b0ee-4101-8a66-bfd00f233a10"), "Yemen" },
                    { new Guid("a7ee28c5-c244-49fb-aa61-f62b9a7fc0c7"), "Tajikistan" },
                    { new Guid("094d9359-e4b4-4fe9-b621-0484c44a9c73"), "St Lucia" },
                    { new Guid("fe0e423a-0c01-4d53-9be3-bc4378129bf3"), "Taiwan" },
                    { new Guid("234d13c3-9e40-49ab-aefc-b730421b230f"), "Switzerland" },
                    { new Guid("050de1be-0db3-472a-9244-dd7ccf0a0257"), "Samoa" },
                    { new Guid("f881cb92-8b2b-42de-b814-633c5ab9fbea"), "San Marino" },
                    { new Guid("63f9a715-b50e-4dae-8134-70fc066e5c39"), "Sao Tome & Principe" },
                    { new Guid("d3e1160b-4acd-4c16-8aa4-2d237c1bf8e8"), "Saudi Arabia" },
                    { new Guid("2ece1a3d-b1b7-44e4-b44b-1aaaf788f3b2"), "Senegal" },
                    { new Guid("4a649a16-03e3-4951-b0f2-5427d8b3fe9c"), "Serbia" },
                    { new Guid("da0e21c6-0e79-4f72-a0ef-c6a3a680d09c"), "Seychelles" },
                    { new Guid("16ef187b-213d-4c2d-83a6-e07075a009ac"), "Sierra Leone" },
                    { new Guid("dc1ca296-5633-488f-ac55-8bf024b7172f"), "Singapore" },
                    { new Guid("ea90f918-7421-4a80-b1e1-532425e6766e"), "Slovakia" },
                    { new Guid("8946cb4b-40af-43a0-9055-d91f396b989b"), "Slovenia" },
                    { new Guid("71e3c0bd-85f5-4c99-a939-78a864c68aee"), "Solomon Islands" },
                    { new Guid("228ab87c-0b40-422b-a1c7-12ab317d124c"), "Somalia" },
                    { new Guid("a060324b-54f2-4a28-b574-f8d686360f3d"), "South Africa" },
                    { new Guid("ddbc0531-89b1-4f98-90a1-57d58af8d7ac"), "South Sudan" },
                    { new Guid("31458ed5-2fb1-4ee2-a28b-7c3166c5f13a"), "Spain" },
                    { new Guid("84e18865-baeb-4486-b8aa-ad1c7b621ef7"), "Sri Lanka" },
                    { new Guid("9b274197-83be-4d31-9e46-de5b31b532f6"), "Sudan" },
                    { new Guid("5c20b6dc-eee3-4146-b679-8c6c8b08fbc5"), "Suriname" },
                    { new Guid("563f0bf5-1009-48de-93f6-b1920caf7bf2"), "Swaziland" },
                    { new Guid("b265fa41-415b-43f7-b7cb-f6ccbe26391b"), "Sweden" },
                    { new Guid("b9e1c247-5919-48a5-8b38-8b2b3e36cba1"), "Syria" },
                    { new Guid("2611b55c-b895-4cb3-a275-86ad32408169"), "Lesotho" },
                    { new Guid("a89a0bc5-a861-4dc0-9fff-1465f3a30c57"), "Bolivia" },
                    { new Guid("609297e6-81bd-420d-a534-88f3a11badfb"), "Latvia" },
                    { new Guid("0f4b24ff-2256-4616-b059-36c69572a28a"), "Bulgaria" },
                    { new Guid("4ad4d024-49b7-478a-8105-96780bdef12a"), "Burkina" },
                    { new Guid("195e278e-9d49-47f1-8b33-d354dabc1556"), "Burundi" },
                    { new Guid("8d4e9021-01b6-4d74-a8a6-c329d295778f"), "Cambodia" },
                    { new Guid("3da66a4e-2f1b-4021-aac5-c600d298745a"), "Cameroon" },
                    { new Guid("c26d3cd6-a834-4a71-a884-2b33f94d2224"), "Canada" },
                    { new Guid("c7beaaca-9be2-48ea-a890-70a48cb88328"), "Cape Verde" },
                    { new Guid("77a80a00-451a-4a8e-b546-7294b29c7e62"), "Central African Rep" },
                    { new Guid("ee22c565-0fb2-4f93-ad69-24ceac898acc"), "Chad" },
                    { new Guid("991871ae-2087-41c0-891e-f15534329f59"), "Brunei" },
                    { new Guid("d37d32ae-8552-4866-a456-cfe34c2039c8"), "Chile" },
                    { new Guid("5b8765d2-3b2e-4593-ba24-2845ef2fb7cd"), "Colombia" },
                    { new Guid("50b4ec21-73f0-4b3f-adaf-f64ca5d4d174"), "Comoros" },
                    { new Guid("0b2bed53-4b73-4bfd-bfeb-9883d395c4ae"), "Congo" },
                    { new Guid("73a8850f-ee37-4f77-ad67-fb8de1ea9f44"), "Congo {Democratic Rep}" },
                    { new Guid("ed3a48ac-c00e-4bad-b00b-21e3fedc11b8"), "Costa Rica" },
                    { new Guid("2901cec0-b04c-4624-802c-e4a0409c514a"), "Croatia" },
                    { new Guid("4260b24f-9d84-4b4d-9ab5-deca7ddeb5ed"), "Cuba" },
                    { new Guid("44815169-bc08-4f98-b080-ab29ec0d9350"), "Cyprus" },
                    { new Guid("d4465912-3e3a-401c-8302-f534215ea5bd"), "Czech Republic" },
                    { new Guid("d7e91084-7456-44ea-b099-36bacc88e9a1"), "China" },
                    { new Guid("0a6f0391-0ae7-4f18-b5e1-559ed2bf3210"), "Brazil" },
                    { new Guid("9273d2eb-4c9d-4f33-ae1e-ee26ef51e862"), "Botswana" },
                    { new Guid("83a066ff-4a7f-4d65-97ac-ee5fbeb17108"), "Bosnia Herzegovina" },
                    { new Guid("9416424e-5280-4b09-9190-b7a65a79cc89"), "Zambia" },
                    { new Guid("756ec903-19e7-4d54-a027-2f542713bb43"), "Afghanistan" },
                    { new Guid("0d656599-6b9d-4bee-ad0a-213e41485521"), "Albania" },
                    { new Guid("725c8f8d-9b44-448d-83d9-6c5ed256a9d6"), "Algeria" },
                    { new Guid("ed7333d2-900e-4372-9286-96a3652b7211"), "Andorra" },
                    { new Guid("35291d19-b92a-4879-9795-a8aa317c56ca"), "Angola" },
                    { new Guid("9901ef79-51e3-4ca9-b328-9b09ebb4cbd3"), "Antigua & Deps" },
                    { new Guid("be76617c-eca7-495d-a8fe-f0959ded54c1"), "Argentina" },
                    { new Guid("2659ec2e-abde-4cc0-a6c1-5d6ff46948b1"), "Armenia" },
                    { new Guid("0b9284c4-6402-493a-9361-c497d6b86708"), "Australia" },
                    { new Guid("4c51bc99-5c1e-4010-9c6b-434864d74c9a"), "Austria" },
                    { new Guid("ce7b8ad7-adee-40d4-a5f0-582a7c44f7a9"), "Azerbaijan" },
                    { new Guid("8727a5d0-5794-400f-a4f8-2f05175caace"), "Bahamas" },
                    { new Guid("ca1e043d-3bb5-41b4-a0ee-527db6b3fa6b"), "Bahrain" },
                    { new Guid("8efe73ae-d4cd-4892-ac58-c39f100c09c6"), "Bangladesh" },
                    { new Guid("ea99a2b0-1e22-44b8-9fe3-f0fcae5a119c"), "Barbados" },
                    { new Guid("4578379f-cb7b-4feb-81eb-267b77b820b9"), "Belarus" },
                    { new Guid("c7b849d5-e5c4-4c8c-b7c6-7aa4a673fff1"), "Belgium" },
                    { new Guid("68d2d484-a12f-4b53-991a-56cf7b4ccfbe"), "Belize" },
                    { new Guid("712d9ade-b88a-458b-a672-af80ad30fb9f"), "Benin" },
                    { new Guid("30c6b8d8-aa51-401d-8d71-82a73190daef"), "Bhutan" },
                    { new Guid("f841e010-01b5-4fe4-ac5e-d3eb91a3ffbe"), "Denmark" },
                    { new Guid("6c104792-3f9c-4049-b3dc-358814ff5d51"), "Djibouti" },
                    { new Guid("8fb6e6ff-9caa-4795-993b-2cbd3216fe83"), "Dominica" },
                    { new Guid("68e471cd-c498-4d5b-a7b3-e1fdbd14a26a"), "Dominican Republic" },
                    { new Guid("78505b19-9e6d-4867-aa70-9cdac3f81592"), "Iceland" },
                    { new Guid("c946872a-1ace-4fa0-bcba-b77ba0fc66c8"), "India" },
                    { new Guid("20ca48ad-4646-46e2-850d-18fe33e4034e"), "Indonesia" },
                    { new Guid("393e415e-f462-4b63-bc99-389881145416"), "Iran" },
                    { new Guid("fec2d928-3e2c-496e-8f54-ef26b4e82c89"), "Iraq" },
                    { new Guid("1298aaf3-7245-444b-a401-d36f9966b9e6"), "Ireland {Republic}" },
                    { new Guid("d6040d41-460c-4383-b9f8-d7997a1c2e74"), "Israel" },
                    { new Guid("6191946d-0f56-482b-bfbd-10de0321fb42"), "Italy" },
                    { new Guid("4c3221b1-4344-4cdd-871b-53ddffe56775"), "Ivory Coast" },
                    { new Guid("491dfd3a-c3c6-4b4a-976a-e2188bf5bcc8"), "Jamaica" },
                    { new Guid("bc7fcdee-e539-447f-a381-9737b8471e7d"), "Japan" },
                    { new Guid("58711485-2515-45b3-9ac8-4f26902014e9"), "Jordan" },
                    { new Guid("74d8ae02-0f21-46b5-a275-3481e73ff257"), "Kazakhstan" },
                    { new Guid("4355e553-88a6-4d50-9bee-14f64c3edbfe"), "Kenya" },
                    { new Guid("c59b732a-4c78-4c12-9e78-7c0223f99785"), "Kiribati" },
                    { new Guid("08cfab7d-e2c7-49c3-b1bc-9d8ef2ae77b5"), "Korea North" },
                    { new Guid("d9ed18d5-7cd9-45c9-836e-4566d616c8cc"), "Korea South" },
                    { new Guid("ea4dad20-2551-4fc9-b1e6-f1b05ea18a20"), "Kosovo" },
                    { new Guid("787d931e-2d8d-4419-be63-1a77043ded9e"), "Kuwait" },
                    { new Guid("62eb477f-b6d3-4543-a99c-3f1e63f56f72"), "Kyrgyzstan" },
                    { new Guid("e096a929-dc3b-458e-a520-d1a6f1418431"), "Laos" },
                    { new Guid("04c33786-28f2-42ae-a58e-dbd28866d7fa"), "Hungary" },
                    { new Guid("e1e10a66-d45e-4c79-891c-cbee46ca0283"), "Lebanon" },
                    { new Guid("0e634bf1-1bf3-4801-af3e-5710e20edbcd"), "Honduras" },
                    { new Guid("b141335a-0ff7-4829-a0f4-200585755344"), "Guyana" },
                    { new Guid("4e7114ed-d335-4fa9-9245-250859dcb2a0"), "East Timor" },
                    { new Guid("162c2239-645e-4d78-b24f-8ade995d5fad"), "Ecuador" },
                    { new Guid("abf09f60-d9af-43ae-b4fe-429291cb1ce1"), "Egypt" },
                    { new Guid("2abe9cf2-8e1b-440f-8cdf-17570ee5c3a3"), "El Salvador" },
                    { new Guid("e126943d-770d-4374-81bc-9e2330641957"), "Equatorial Guinea" },
                    { new Guid("22ac06de-1907-4fb2-9fcb-30e933237b29"), "Eritrea" },
                    { new Guid("bb5d43b8-a74c-419f-a5b2-98c7eed4009a"), "Estonia" },
                    { new Guid("1944e176-81ce-46d8-8f37-7a53bc19e2bb"), "Ethiopia" },
                    { new Guid("20f14438-01d8-4f24-af78-758da76c6ecc"), "Fiji" },
                    { new Guid("34067cf6-eb8d-4a0b-8c0b-bf9dceca735e"), "Finland" },
                    { new Guid("84671d93-7fe6-48f6-8cd7-28aa5928e4eb"), "France" },
                    { new Guid("b7078d8b-2dc1-4659-b306-7be3bd2586eb"), "Gabon" },
                    { new Guid("165d5b9c-4f59-4c1b-b8e5-a45f795c1a08"), "Gambia" },
                    { new Guid("96d045a6-5820-4ac3-ad36-e433df3c7de8"), "Georgia" },
                    { new Guid("59c7bf65-9449-4288-b9d6-1035b1e5add5"), "Germany" },
                    { new Guid("f32b54a4-4ac9-482a-aa5d-5aa154ee5151"), "Ghana" },
                    { new Guid("9f011fe7-fb0f-4423-92d3-2e5843e65a15"), "Greece" },
                    { new Guid("6735bbd1-2d32-44d2-a533-279b90e87d0f"), "Grenada" },
                    { new Guid("1a1ab91b-8b29-4df0-9657-2d374bbd3e45"), "Guatemala" },
                    { new Guid("fd2ac447-4288-44e6-be42-97d41703fe1d"), "Guinea" },
                    { new Guid("bded9dc9-ff55-43cc-b15e-50df7bb3732a"), "Guinea-Bissau" },
                    { new Guid("6a23a535-b9cd-4260-8b4b-4500cfdbb49e"), "Haiti" },
                    { new Guid("f8318a84-7485-4aee-874b-bf5e47aa107e"), "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgeTypes_Title",
                table: "AgeTypes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BagItemUser_BagUsersId",
                table: "BagItemUser",
                column: "BagUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_LogoId",
                table: "Brands",
                column: "LogoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Title",
                table: "Brands",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Name",
                table: "Colors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteItemUser_FavoriteUsersId",
                table: "FavoriteItemUser",
                column: "FavoriteUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_FormatsImage_Format",
                table: "FormatsImage",
                column: "Format",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Title",
                table: "Genders",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageItem_ItemsId",
                table: "ImageItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageFormatId",
                table: "Images",
                column: "ImageFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AgeTypeId",
                table: "Items",
                column: "AgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ArticleNumber",
                table: "Items",
                column: "ArticleNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ColorId",
                table: "Items",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CountryId",
                table: "Items",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GenderId",
                table: "Items",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MainImageId",
                table: "Items",
                column: "MainImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ManufacturerId",
                table: "Items",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_SubItemTypeId",
                table: "ItemTypes",
                column: "SubItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_Title",
                table: "ItemTypes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logos_Path",
                table: "Logos",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Title",
                table: "Manufacturers",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubItemTypes_Title",
                table: "SubItemTypes",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BagItemUser");

            migrationBuilder.DropTable(
                name: "FavoriteItemUser");

            migrationBuilder.DropTable(
                name: "ImageItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "AgeTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "FormatsImage");

            migrationBuilder.DropTable(
                name: "SubItemTypes");
        }
    }
}
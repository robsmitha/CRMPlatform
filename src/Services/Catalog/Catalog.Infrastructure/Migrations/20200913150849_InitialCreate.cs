using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                schema: "catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypes",
                schema: "catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnitTypes",
                schema: "catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PerUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    DefaultTaxRates = table.Column<bool>(nullable: false),
                    IsRevenue = table.Column<bool>(nullable: false),
                    LookupCode = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: true),
                    MaxAllowed = table.Column<int>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    MerchantID = table.Column<int>(nullable: false),
                    ItemTypeID = table.Column<int>(nullable: false),
                    UnitTypeID = table.Column<int>(nullable: false),
                    PriceTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeID",
                        column: x => x.ItemTypeID,
                        principalSchema: "catalog",
                        principalTable: "ItemTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_PriceTypes_PriceTypeID",
                        column: x => x.PriceTypeID,
                        principalSchema: "catalog",
                        principalTable: "PriceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_UnitTypes_UnitTypeID",
                        column: x => x.UnitTypeID,
                        principalSchema: "catalog",
                        principalTable: "UnitTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                schema: "catalog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ItemID = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemImages_Items_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "catalog",
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemID",
                schema: "catalog",
                table: "ItemImages",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeID",
                schema: "catalog",
                table: "Items",
                column: "ItemTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceTypeID",
                schema: "catalog",
                table: "Items",
                column: "PriceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitTypeID",
                schema: "catalog",
                table: "Items",
                column: "UnitTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemImages",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "ItemTypes",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "PriceTypes",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "UnitTypes",
                schema: "catalog");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Merchants.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "merchants");

            migrationBuilder.CreateTable(
                name: "MerchantTypes",
                schema: "merchants",
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
                    table.PrimaryKey("PK_MerchantTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "merchants",
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
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                schema: "merchants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateAbbreviation = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CallToAction = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    OperatingHours = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    MerchantTypeID = table.Column<int>(nullable: false),
                    OrganizationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Merchants_MerchantTypes_MerchantTypeID",
                        column: x => x.MerchantTypeID,
                        principalSchema: "merchants",
                        principalTable: "MerchantTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Merchants_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalSchema: "merchants",
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchantImages",
                schema: "merchants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    MerchantID = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MerchantImages_Merchants_MerchantID",
                        column: x => x.MerchantID,
                        principalSchema: "merchants",
                        principalTable: "Merchants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantImages_MerchantID",
                schema: "merchants",
                table: "MerchantImages",
                column: "MerchantID");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_MerchantTypeID",
                schema: "merchants",
                table: "Merchants",
                column: "MerchantTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_OrganizationID",
                schema: "merchants",
                table: "Merchants",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantImages",
                schema: "merchants");

            migrationBuilder.DropTable(
                name: "Merchants",
                schema: "merchants");

            migrationBuilder.DropTable(
                name: "MerchantTypes",
                schema: "merchants");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "merchants");
        }
    }
}

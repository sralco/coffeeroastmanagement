using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoffeeRoastManagement.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    FavIcon = table.Column<byte[]>(type: "bytea", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cupping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GreenBeanInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Crop = table.Column<int>(type: "integer", nullable: false),
                    Processing = table.Column<string>(type: "text", nullable: true),
                    Variety = table.Column<string>(type: "text", nullable: true),
                    OverallCuppingScore = table.Column<double>(type: "double precision", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Farmer = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreenBeanInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortInfo = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Equipment = table.Column<string>(type: "text", nullable: true),
                    CuppingInfoId = table.Column<int>(type: "integer", nullable: true),
                    RoastProfile = table.Column<string>(type: "jsonb", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roast_Cupping_CuppingInfoId",
                        column: x => x.CuppingInfoId,
                        principalTable: "Cupping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GreenBeanInfoId = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    OverallPrice = table.Column<double>(type: "double precision", nullable: false),
                    SellerContactId = table.Column<int>(type: "integer", nullable: true),
                    GoodsReceived = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    BeansAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Contact_SellerContactId",
                        column: x => x.SellerContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stock_GreenBeanInfo_GreenBeanInfoId",
                        column: x => x.GreenBeanInfoId,
                        principalTable: "GreenBeanInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GreenBlend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StockItemId = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    RoastId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreenBlend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GreenBlend_Roast_RoastId",
                        column: x => x.RoastId,
                        principalTable: "Roast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GreenBlend_Stock_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GreenBlend_RoastId",
                table: "GreenBlend",
                column: "RoastId");

            migrationBuilder.CreateIndex(
                name: "IX_GreenBlend_StockItemId",
                table: "GreenBlend",
                column: "StockItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Roast_CuppingInfoId",
                table: "Roast",
                column: "CuppingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_GreenBeanInfoId",
                table: "Stock",
                column: "GreenBeanInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SellerContactId",
                table: "Stock",
                column: "SellerContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GreenBlend");

            migrationBuilder.DropTable(
                name: "Roast");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Cupping");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "GreenBeanInfo");
        }
    }
}

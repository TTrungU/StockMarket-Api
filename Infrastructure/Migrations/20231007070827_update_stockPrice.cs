using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_stockPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnomaly",
                table: "StockPrices",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Prediction",
                table: "StockPrices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "StockPrices",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnomaly",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "Prediction",
                table: "StockPrices");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "StockPrices");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BahareBar_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDateAndTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedServiceItemCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhysicalProductCost",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalEstimatedCost",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalEstimatedCost");

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedServiceItemCost",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PhysicalProductCost",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

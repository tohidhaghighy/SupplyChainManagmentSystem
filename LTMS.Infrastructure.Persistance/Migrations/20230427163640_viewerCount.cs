using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schm.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class viewerCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertedDate",
                table: "SupplierItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SupplierItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ViewerCount",
                table: "SupplierItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertedDate",
                table: "SupplierItem");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SupplierItem");

            migrationBuilder.DropColumn(
                name: "ViewerCount",
                table: "SupplierItem");
        }
    }
}

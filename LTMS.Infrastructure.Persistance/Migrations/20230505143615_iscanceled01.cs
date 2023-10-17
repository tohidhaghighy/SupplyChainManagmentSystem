using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schm.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class iscanceled01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SupplierUser_SupplierId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Supplier_SupplierId",
                table: "Orders",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Supplier_SupplierId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SupplierUser_SupplierId",
                table: "Orders",
                column: "SupplierId",
                principalTable: "SupplierUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

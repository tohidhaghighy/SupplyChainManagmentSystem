using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schm.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateusersupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "SupplierUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SupplierUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "SupplierUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SupplierUser");
        }
    }
}

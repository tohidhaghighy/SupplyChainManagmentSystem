using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schm.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addtokentosupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Supplier");
        }
    }
}

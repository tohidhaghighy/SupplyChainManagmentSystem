using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schm.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class test06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Items");
        }
    }
}

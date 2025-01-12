using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stationery.EF.Migrations
{
    /// <inheritdoc />
    public partial class updateProductUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quentity",
                table: "ProductUnits",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quentity",
                table: "ProductUnits");
        }
    }
}

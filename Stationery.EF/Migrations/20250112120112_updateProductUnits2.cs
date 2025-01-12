using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stationery.EF.Migrations
{
    /// <inheritdoc />
    public partial class updateProductUnits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetails_Units_UnitsID",
                table: "OrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrdersDetails_UnitsID",
                table: "OrdersDetails");

            migrationBuilder.DropColumn(
                name: "UnitsID",
                table: "OrdersDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_UnitId",
                table: "OrdersDetails",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetails_Units_UnitId",
                table: "OrdersDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetails_Units_UnitId",
                table: "OrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrdersDetails_UnitId",
                table: "OrdersDetails");

            migrationBuilder.AddColumn<int>(
                name: "UnitsID",
                table: "OrdersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_UnitsID",
                table: "OrdersDetails",
                column: "UnitsID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetails_Units_UnitsID",
                table: "OrdersDetails",
                column: "UnitsID",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointCollector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class points101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_Customers_CustomerId",
                table: "Point");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Point",
                table: "Point");

            migrationBuilder.RenameTable(
                name: "Point",
                newName: "Points");

            migrationBuilder.RenameIndex(
                name: "IX_Point_CustomerId",
                table: "Points",
                newName: "IX_Points_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Points",
                table: "Points",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Customers_CustomerId",
                table: "Points",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Customers_CustomerId",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Points",
                table: "Points");

            migrationBuilder.RenameTable(
                name: "Points",
                newName: "Point");

            migrationBuilder.RenameIndex(
                name: "IX_Points_CustomerId",
                table: "Point",
                newName: "IX_Point_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Point",
                table: "Point",
                column: "PointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Point_Customers_CustomerId",
                table: "Point",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

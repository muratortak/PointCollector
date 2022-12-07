using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointCollector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateWorkspaceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Workspace");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Workspace");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Workspace");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Workspace");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Workspace");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.WorkspaceId);
                    table.ForeignKey(
                        name: "FK_Address_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Workspace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Workspace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Workspace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Workspace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Workspace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

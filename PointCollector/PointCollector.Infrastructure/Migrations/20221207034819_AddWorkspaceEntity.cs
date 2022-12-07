using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointCollector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkspaceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "nvarchar(max)", nullable: false),
                    AddressCity = table.Column<string>(name: "Address_City", type: "nvarchar(max)", nullable: false),
                    AddressState = table.Column<string>(name: "Address_State", type: "nvarchar(max)", nullable: false),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "nvarchar(max)", nullable: false),
                    AddressZipCode = table.Column<string>(name: "Address_ZipCode", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspace", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workspace");
        }
    }
}

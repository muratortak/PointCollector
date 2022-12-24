using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointCollector.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MIGRATIONNAME : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Workspace_WorkspaceId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workspace",
                table: "Workspace");

            migrationBuilder.RenameTable(
                name: "Workspace",
                newName: "Workspaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Workspaces_WorkspaceId",
                table: "Address",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Workspaces_WorkspaceId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workspaces",
                table: "Workspaces");

            migrationBuilder.RenameTable(
                name: "Workspaces",
                newName: "Workspace");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workspace",
                table: "Workspace",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Workspace_WorkspaceId",
                table: "Address",
                column: "WorkspaceId",
                principalTable: "Workspace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

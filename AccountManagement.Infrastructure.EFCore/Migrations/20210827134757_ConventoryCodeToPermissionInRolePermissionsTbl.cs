using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class ConventoryCodeToPermissionInRolePermissionsTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "RolePermissions");

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "RolePermissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "RolePermissions");

            migrationBuilder.AddColumn<int>(
                name: "RolePermission",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

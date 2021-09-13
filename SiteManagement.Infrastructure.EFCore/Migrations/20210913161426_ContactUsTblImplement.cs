using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManagement.Infrastructure.EFCore.Migrations
{
    public partial class ContactUsTblImplement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsInfo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactUsInfo",
                columns: new[] { "Id", "CreationDate", "Description", "Location" },
                values: new object[] { 1L, new DateTime(2021, 9, 13, 20, 44, 26, 390, DateTimeKind.Local).AddTicks(3662), "description", "location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "ContactUsInfo");
        }
    }
}

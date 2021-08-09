using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogManagement.Infrastructure.EFCore.Migrations
{
    public partial class ArticleCategoriesTblImplemet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageAlt = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keyword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");
        }
    }
}

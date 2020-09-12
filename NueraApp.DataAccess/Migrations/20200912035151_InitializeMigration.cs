using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NueraApp.DataAccess.Migrations
{
    public partial class InitializeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentLimitCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLimitCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentLimitItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(12, 2)", nullable: false),
                    ContentLimitCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLimitItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentLimitItem_ContentLimitCategory_ContentLimitCategoryId",
                        column: x => x.ContentLimitCategoryId,
                        principalTable: "ContentLimitCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentLimitItem_ContentLimitCategoryId",
                table: "ContentLimitItem",
                column: "ContentLimitCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentLimitItem");

            migrationBuilder.DropTable(
                name: "ContentLimitCategory");
        }
    }
}

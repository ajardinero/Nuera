using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NueraApp.DataAccess.Migrations
{
    public partial class PopulateContentLimitCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContentLimitCategory",
                columns: new[] { "Id", "CreatedBy", "Created", "LastModifiedBy", "LastModified", "CategoryName" },

                values: new object[] { 1, "system", DateTime.Now, "system", DateTime.Now, "Clothing" });

            migrationBuilder.InsertData(
                table: "ContentLimitCategory",
                columns: new[] { "Id", "CreatedBy", "Created", "LastModifiedBy", "LastModified", "CategoryName" },
                values: new object[] { 2, "system", DateTime.Now, "system", DateTime.Now, "Electronics" });

            migrationBuilder.InsertData(
                table: "ContentLimitCategory",
                columns: new[] { "Id", "CreatedBy", "Created", "LastModifiedBy", "LastModified", "CategoryName" },
                values: new object[] { 3, "system", DateTime.Now, "system", DateTime.Now, "Kitchen" });

            migrationBuilder.InsertData(
                table: "ContentLimitCategory",
                columns: new[] { "Id", "CreatedBy", "Created", "LastModifiedBy", "LastModified", "CategoryName" },
                values: new object[] { 4, "system", DateTime.Now, "system", DateTime.Now, "Miscellaneous" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContentLimitCategory",
                keyColumn: "Id",
                keyValue: 1 );

            migrationBuilder.DeleteData(
                table: "ContentLimitCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContentLimitCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContentLimitCategory",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleBlog.Migrations
{
    /// <inheritdoc />
    public partial class initalDataBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AuthorName", "Content", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Abdullah Ali", "I Love Asp.Net", new DateTime(2024, 9, 11, 15, 9, 1, 146, DateTimeKind.Local).AddTicks(218), "ASP.Net" },
                    { 2, "Malak Mohamed", "I Love API Core", new DateTime(2024, 9, 11, 15, 9, 1, 146, DateTimeKind.Local).AddTicks(278), "API Core" },
                    { 3, "Omar Ali", "I Love MVC Core", new DateTime(2024, 9, 11, 15, 9, 1, 146, DateTimeKind.Local).AddTicks(286), "MVC Core" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

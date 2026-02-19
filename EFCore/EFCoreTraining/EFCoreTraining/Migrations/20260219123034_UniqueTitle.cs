using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTraining.Migrations
{
    /// <inheritdoc />
    public partial class UniqueTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 19));

            migrationBuilder.CreateIndex(
                name: "IX_courses_Title",
                table: "courses",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_courses_Title",
                table: "courses");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2026, 2, 18));
        }
    }
}

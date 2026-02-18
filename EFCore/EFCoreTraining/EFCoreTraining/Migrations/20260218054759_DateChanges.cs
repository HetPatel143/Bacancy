using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTraining.Migrations
{
    /// <inheritdoc />
    public partial class DateChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedDate",
                table: "students",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 18, 11, 14, 14, 119, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 18, 11, 14, 14, 120, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 2, 18, 11, 14, 14, 120, DateTimeKind.Local).AddTicks(5286));
        }
    }
}

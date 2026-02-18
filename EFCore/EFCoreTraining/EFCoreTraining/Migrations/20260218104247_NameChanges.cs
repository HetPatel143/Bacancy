using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTraining.Migrations
{
    /// <inheritdoc />
    public partial class NameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Name",
                value: "Het");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Name",
                value: "Niken");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Name",
                value: "Megh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "Name",
                value: "Het Patel");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Name",
                value: "Niken Patel");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "Name",
                value: "Megh Mewada");
        }
    }
}

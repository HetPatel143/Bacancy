using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTraining.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "trainers",
                newName: "TrainerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "courses",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "batches",
                newName: "BatchId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Student Courses",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student Courses", x => new { x.CoursesCourseId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_Student Courses_courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student Courses_students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "CourseId", "DurationInMonths", "Fees", "Title" },
                values: new object[,]
                {
                    { 101, 4, 5000m, ".NET" },
                    { 102, 2, 3000m, "C#" }
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StudentId", "CreatedDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 18, 11, 14, 14, 119, DateTimeKind.Local).AddTicks(7849), "het@gmail.com", "Het Patel" },
                    { 2, new DateTime(2026, 2, 18, 11, 14, 14, 120, DateTimeKind.Local).AddTicks(5274), "niken@gmail.com", "Niken Patel" },
                    { 3, new DateTime(2026, 2, 18, 11, 14, 14, 120, DateTimeKind.Local).AddTicks(5286), "megh@gmail.com", "Megh Mewada" }
                });

            migrationBuilder.InsertData(
                table: "trainers",
                columns: new[] { "TrainerId", "ExperienceYears", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Jaydip Mer" },
                    { 2, 5, "Vivek Vaghasiya" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_batches_CourseId",
                table: "batches",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_batches_TrainerId",
                table: "batches",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Student Courses_StudentsStudentId",
                table: "Student Courses",
                column: "StudentsStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_batches_courses_CourseId",
                table: "batches",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_batches_trainers_TrainerId",
                table: "batches",
                column: "TrainerId",
                principalTable: "trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_batches_courses_CourseId",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "FK_batches_trainers_TrainerId",
                table: "batches");

            migrationBuilder.DropTable(
                name: "Student Courses");

            migrationBuilder.DropIndex(
                name: "IX_batches_CourseId",
                table: "batches");

            migrationBuilder.DropIndex(
                name: "IX_batches_TrainerId",
                table: "batches");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "CourseId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "CourseId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "trainers",
                keyColumn: "TrainerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "trainers",
                keyColumn: "TrainerId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "trainers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "batches",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

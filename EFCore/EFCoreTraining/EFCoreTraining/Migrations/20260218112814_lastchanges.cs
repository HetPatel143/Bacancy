using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTraining.Migrations
{
    /// <inheritdoc />
    public partial class lastchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "courses",
                newName: "CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatedDate",
                table: "students",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fees",
                table: "courses",
                type: "Decimal(10,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateTable(
                name: "trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "batches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batches", x => x.BatchId);
                    table.ForeignKey(
                        name: "FK_batches_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_batches_trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "trainers",
                        principalColumn: "TrainerId",
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
                    { 1, new DateOnly(2026, 2, 18), "het@gmail.com", "Het" },
                    { 2, new DateOnly(2026, 2, 18), "niken@gmail.com", "Niken" },
                    { 3, new DateOnly(2026, 2, 18), "megh@gmail.com", "Megh" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "batches");

            migrationBuilder.DropTable(
                name: "Student Courses");

            migrationBuilder.DropTable(
                name: "trainers");

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

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "courses",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "Fees",
                table: "courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,2)");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class configureDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamResultId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "ExamResultId", "OptionId", "QuestionId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "1", 1, 1, 1, null },
                    { 2, null, "1", 1, 4, 2, null }
                });

            migrationBuilder.InsertData(
                table: "ExamResults",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "ExamId", "Mark", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "1", 1, 85.0, null },
                    { 2, null, "1", 2, 90.0, null }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Description", "Duration", "IsVisible", "Text", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "1", "---", null, true, "Programming 1", null },
                    { 2, null, "1", "---", null, false, "Calculase", null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "ExamId", "Grade", "Text", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "1", 1, 1.0, "What is the capital of France?", null },
                    { 2, null, "1", 1, 1.0, "What is the largest planet in our solar system?", null },
                    { 3, null, "1", 2, 1.0, "What is the derivative of x^2?", null },
                    { 4, null, "1", 2, 1.0, "What is the integral of 1/x?", null },
                    { 5, null, "1", 1, 1.0, "What is the capital of Germany?", null }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "IsTrue", "QuestionId", "Text", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "1", true, 1, "Paris", null },
                    { 2, null, "1", false, 1, "London", null },
                    { 3, null, "1", true, 2, "4", null },
                    { 4, null, "1", false, 2, "5", null },
                    { 5, null, "1", true, 3, "Blue", null },
                    { 6, null, "1", false, 3, "Red", null },
                    { 7, null, "1", true, 4, "Einstein", null },
                    { 8, null, "1", false, 4, "Newton", null },
                    { 9, null, "1", true, 5, "H2O", null },
                    { 10, null, "1", false, 5, "CO2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}

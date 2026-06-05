using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForEvaluations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_correct",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "total_questions",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "answered_at",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropColumn(
                name: "seconds_spent",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.AddColumn<double>(
                name: "average_assessment_score",
                table: "ncp_user_syllabus_unit_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "best_assessment_score",
                table: "ncp_user_syllabus_unit_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "total_assessment_attempts",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "average_assessment_score",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "best_assessment_score",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "total_assessment_attempts",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.AddColumn<int>(
                name: "total_correct",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_questions",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "answered_at",
                table: "ncp_assessment_attempt_question",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "seconds_spent",
                table: "ncp_assessment_attempt_question",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

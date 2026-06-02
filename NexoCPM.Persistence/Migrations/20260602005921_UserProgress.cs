using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_viewed",
                table: "ncp_user_sub_topic_view",
                newName: "is_completed");

            migrationBuilder.AddColumn<DateTime>(
                name: "completed_at",
                table: "ncp_user_syllabus_unit_progress",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "completed_sub_topics",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "content_progress_percentage",
                table: "ncp_user_syllabus_unit_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "overall_progress_percentage",
                table: "ncp_user_syllabus_unit_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "total_sub_topics",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "unit_exam_completed",
                table: "ncp_user_syllabus_unit_progress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "unit_exam_score",
                table: "ncp_user_syllabus_unit_progress",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "ncp_user_syllabus_unit_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "completed_at",
                table: "ncp_user_syllabus_progress",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "completed_units",
                table: "ncp_user_syllabus_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "content_progress_percentage",
                table: "ncp_user_syllabus_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "final_exam_completed",
                table: "ncp_user_syllabus_progress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "final_exam_score",
                table: "ncp_user_syllabus_progress",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_activity_at",
                table: "ncp_user_syllabus_progress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "overall_progress_percentage",
                table: "ncp_user_syllabus_progress",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "syllabus_id",
                table: "ncp_user_syllabus_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_units",
                table: "ncp_user_syllabus_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "ncp_user_syllabus_progress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "viewed_at",
                table: "ncp_user_sub_topic_view",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "completed_at",
                table: "ncp_user_sub_topic_view",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed_at",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "completed_sub_topics",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "content_progress_percentage",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "overall_progress_percentage",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "total_sub_topics",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "unit_exam_completed",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "unit_exam_score",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropColumn(
                name: "completed_at",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "completed_units",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "content_progress_percentage",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "final_exam_completed",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "final_exam_score",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "last_activity_at",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "overall_progress_percentage",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "syllabus_id",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "total_units",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropColumn(
                name: "completed_at",
                table: "ncp_user_sub_topic_view");

            migrationBuilder.RenameColumn(
                name: "is_completed",
                table: "ncp_user_sub_topic_view",
                newName: "is_viewed");

            migrationBuilder.AlterColumn<DateTime>(
                name: "viewed_at",
                table: "ncp_user_sub_topic_view",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}

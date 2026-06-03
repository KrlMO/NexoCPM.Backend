using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "option_display_order",
                table: "ncp_assessment_attempt_question",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "generation_mode_used",
                table: "ncp_assessment_attempt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "ncp_assessment_attempt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "generation_mode",
                table: "ncp_assessment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "shuffle_options",
                table: "ncp_assessment",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "shuffle_questions",
                table: "ncp_assessment",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "option_display_order",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropColumn(
                name: "generation_mode_used",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropColumn(
                name: "generation_mode",
                table: "ncp_assessment");

            migrationBuilder.DropColumn(
                name: "shuffle_options",
                table: "ncp_assessment");

            migrationBuilder.DropColumn(
                name: "shuffle_questions",
                table: "ncp_assessment");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CapturePendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionContentBlockId",
                table: "ncp_question_context",
                newName: "question_content_block_id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ncp_question_context",
                newName: "question_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_context_QuestionId_order_index",
                table: "ncp_question_context",
                newName: "IX_ncp_question_context_question_id_order_index");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_context_QuestionContentBlockId",
                table: "ncp_question_context",
                newName: "IX_ncp_question_context_question_content_block_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "question_content_block_id",
                table: "ncp_question_context",
                newName: "QuestionContentBlockId");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "ncp_question_context",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_context_question_id_order_index",
                table: "ncp_question_context",
                newName: "IX_ncp_question_context_QuestionId_order_index");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_context_question_content_block_id",
                table: "ncp_question_context",
                newName: "IX_ncp_question_context_QuestionContentBlockId");
        }
    }
}

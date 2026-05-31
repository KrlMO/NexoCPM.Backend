using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_question_content_block_question",
                table: "ncp_question_content_block");

            migrationBuilder.DropIndex(
                name: "IX_ncp_question_content_block_question_id",
                table: "ncp_question_content_block");

            migrationBuilder.DropColumn(
                name: "order_index",
                table: "ncp_question_content_block");

            migrationBuilder.DropColumn(
                name: "question_id",
                table: "ncp_question_content_block");

            migrationBuilder.AddColumn<string>(
                name: "statament",
                table: "ncp_question",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ncp_question_context",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionContentBlockId = table.Column<int>(type: "int", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_question_context", x => new { x.QuestionId, x.QuestionContentBlockId });
                    table.ForeignKey(
                        name: "fk_question_content_block_question_context",
                        column: x => x.QuestionContentBlockId,
                        principalTable: "ncp_question_content_block",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_context_question",
                        column: x => x.QuestionId,
                        principalTable: "ncp_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_context_QuestionContentBlockId",
                table: "ncp_question_context",
                column: "QuestionContentBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_context_QuestionId_order_index",
                table: "ncp_question_context",
                columns: new[] { "QuestionId", "order_index" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncp_question_context");

            migrationBuilder.DropColumn(
                name: "statament",
                table: "ncp_question");

            migrationBuilder.AddColumn<int>(
                name: "order_index",
                table: "ncp_question_content_block",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "question_id",
                table: "ncp_question_content_block",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_content_block_question_id",
                table: "ncp_question_content_block",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "fk_question_content_block_question",
                table: "ncp_question_content_block",
                column: "question_id",
                principalTable: "ncp_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

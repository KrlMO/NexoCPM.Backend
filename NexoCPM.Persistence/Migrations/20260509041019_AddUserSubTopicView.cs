using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSubTopicView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ncp_user_sub_topic_view",
                columns: table => new
                {
                    user_syllabus_unit_progress_id = table.Column<int>(type: "int", nullable: false),
                    sub_topic_id = table.Column<int>(type: "int", nullable: false),
                    is_viewed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    viewed_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_sub_topic_view", x => new { x.user_syllabus_unit_progress_id, x.sub_topic_id });
                    table.ForeignKey(
                        name: "fk_user_sub_topic_view_sub_topic",
                        column: x => x.sub_topic_id,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_sub_topic_view_unit_progress",
                        column: x => x.user_syllabus_unit_progress_id,
                        principalTable: "ncp_user_syllabus_unit_progress",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_sub_topic_view_sub_topic_id",
                table: "ncp_user_sub_topic_view",
                column: "sub_topic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncp_user_sub_topic_view");
        }
    }
}

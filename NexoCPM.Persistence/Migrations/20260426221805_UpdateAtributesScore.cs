using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAtributesScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "stars_earned",
                table: "ncp_assessment_attempt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ncp_user_leaderboard",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    total_stars = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    last_updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_leaderboard", x => x.user_id);
                    table.ForeignKey(
                        name: "fk_user_leaderboard_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncp_user_leaderboard");

            migrationBuilder.DropColumn(
                name: "stars_earned",
                table: "ncp_assessment_attempt");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ncp_assessment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    scope = table.Column<int>(type: "int", nullable: false),
                    target_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    time_limit_seconds = table.Column<int>(type: "int", nullable: true),
                    number_questions = table.Column<int>(type: "int", nullable: false),
                    max_attempts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assessment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_competence",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    effect_year = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_competence", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_modality",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_modality", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_specialization",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_specialization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    effect_year = table.Column<int>(type: "int", nullable: false),
                    min_competence_level = table.Column<int>(type: "int", nullable: false),
                    max_competence_level = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    linkedin_profile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    user_role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_verified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_ability",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    competence_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_ability", x => x.id);
                    table.ForeignKey(
                        name: "fk_ability_competence",
                        column: x => x.competence_id,
                        principalTable: "ncp_competence",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_competence_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competence_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    level_number = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_competence_level", x => x.id);
                    table.ForeignKey(
                        name: "fk_competence_level_competence",
                        column: x => x.competence_id,
                        principalTable: "ncp_competence",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_level",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    modality_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_level", x => x.id);
                    table.ForeignKey(
                        name: "fk_level_modality",
                        column: x => x.modality_id,
                        principalTable: "ncp_modality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus_unit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    syllabus_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    order_index = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus_unit", x => x.id);
                    table.ForeignKey(
                        name: "fk_syllabus_unit_syllabus",
                        column: x => x.syllabus_id,
                        principalTable: "ncp_syllabus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_email_verification_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    token_hash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    used_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_email_verification_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_email_verification_token_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_refresh_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    device_info = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    revoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    revoked_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_refresh_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_token_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ncp_user_learning_context",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    syllabus_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_learning_context", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_learning_context_syllabus",
                        column: x => x.syllabus_id,
                        principalTable: "ncp_syllabus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_learning_context_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_education_context",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level_id = table.Column<int>(type: "int", nullable: false),
                    specialization_id = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_education_context", x => x.id);
                    table.ForeignKey(
                        name: "fk_education_context_level",
                        column: x => x.level_id,
                        principalTable: "ncp_level",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_education_context_specialization",
                        column: x => x.specialization_id,
                        principalTable: "ncp_specialization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_topic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    syllabus_unit_id = table.Column<int>(type: "int", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_topic", x => x.id);
                    table.ForeignKey(
                        name: "fk_topic_syllabus_unit",
                        column: x => x.syllabus_unit_id,
                        principalTable: "ncp_syllabus_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_assessment_attempt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_id = table.Column<int>(type: "int", nullable: false),
                    user_learning_context_id = table.Column<int>(type: "int", nullable: false),
                    started_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finished_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    total_questions = table.Column<int>(type: "int", nullable: false),
                    correct_answers = table.Column<int>(type: "int", nullable: false),
                    stars_earned = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assessment_attempt", x => x.id);
                    table.ForeignKey(
                        name: "FK_ncp_assessment_attempt_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_assessment_attempt_assessment",
                        column: x => x.assessment_id,
                        principalTable: "ncp_assessment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assessment_attempt_user_learning_context",
                        column: x => x.user_learning_context_id,
                        principalTable: "ncp_user_learning_context",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_syllabus_progress",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_learning_context_id = table.Column<int>(type: "int", nullable: false),
                    last_access = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_syllabus_progress", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_syllabus_progress_user_learning_context",
                        column: x => x.user_learning_context_id,
                        principalTable: "ncp_user_learning_context",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus_context",
                columns: table => new
                {
                    syllabus_id = table.Column<int>(type: "int", nullable: false),
                    education_context_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus_context", x => new { x.syllabus_id, x.education_context_id });
                    table.ForeignKey(
                        name: "fk_syllabus_context_education_context",
                        column: x => x.education_context_id,
                        principalTable: "ncp_education_context",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_syllabus_context_syllabus",
                        column: x => x.syllabus_id,
                        principalTable: "ncp_syllabus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_sub_topic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topic_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_sub_topic", x => x.id);
                    table.ForeignKey(
                        name: "fk_sub_topic_competence",
                        column: x => x.CompetenceId,
                        principalTable: "ncp_competence",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sub_topic_topic",
                        column: x => x.topic_id,
                        principalTable: "ncp_topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_syllabus_unit_progress",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_syllabus_progress_id = table.Column<int>(type: "int", nullable: false),
                    syllabus_unit_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    total_questions = table.Column<int>(type: "int", nullable: false),
                    total_correct = table.Column<int>(type: "int", nullable: false),
                    attempts = table.Column<int>(type: "int", nullable: false),
                    last_attempt_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_syllabus_unit_progress", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_syllabus_unit_progress_syllabus_unit",
                        column: x => x.syllabus_unit_id,
                        principalTable: "ncp_syllabus_unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_syllabus_unit_progress_user_syllabus_progress",
                        column: x => x.user_syllabus_progress_id,
                        principalTable: "ncp_user_syllabus_progress",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_micro_topic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sub_topic_id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_micro_topic", x => x.id);
                    table.ForeignKey(
                        name: "fk_micro_topic_sub_topic",
                        column: x => x.sub_topic_id,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    total_attempts = table.Column<int>(type: "int", nullable: false),
                    total_correct = table.Column<int>(type: "int", nullable: false),
                    sub_topic_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    created_by = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_sub_topic",
                        column: x => x.sub_topic_id,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ncp_resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    public_score = table.Column<int>(type: "int", nullable: false),
                    sub_topic_id = table.Column<int>(type: "int", nullable: true),
                    views_count = table.Column<int>(type: "int", nullable: false),
                    likes_count = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_resource", x => x.id);
                    table.ForeignKey(
                        name: "fk_resource_sub_topic",
                        column: x => x.sub_topic_id,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ncp_option",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    label = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    is_correct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_option", x => x.id);
                    table.ForeignKey(
                        name: "fk_option_question",
                        column: x => x.question_id,
                        principalTable: "ncp_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_question_content_block",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_question_content_block", x => x.id);
                    table.ForeignKey(
                        name: "fk_question_content_block_question",
                        column: x => x.question_id,
                        principalTable: "ncp_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_resource_like",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    resource_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_resource_like", x => new { x.resource_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_resource_like_resource",
                        column: x => x.resource_id,
                        principalTable: "ncp_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_resource_like_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_resource_view",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    resource_id = table.Column<int>(type: "int", nullable: false),
                    viewed_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_resource_view", x => new { x.user_id, x.resource_id });
                    table.ForeignKey(
                        name: "fk_user_resource_view_resource",
                        column: x => x.resource_id,
                        principalTable: "ncp_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_resource_view_user",
                        column: x => x.user_id,
                        principalTable: "ncp_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_assessment_attempt_question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assessment_attempt_id = table.Column<int>(type: "int", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    selected_option_id = table.Column<int>(type: "int", nullable: true),
                    answered_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    seconds_spent = table.Column<int>(type: "int", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assessment_attempt_question", x => x.id);
                    table.ForeignKey(
                        name: "fk_assessment_attempt_question_assessment_attempt",
                        column: x => x.assessment_attempt_id,
                        principalTable: "ncp_assessment_attempt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assessment_attempt_question_question",
                        column: x => x.question_id,
                        principalTable: "ncp_question",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_assessment_attempt_question_selected_option",
                        column: x => x.selected_option_id,
                        principalTable: "ncp_option",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_option_block",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    option_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    order_index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_option_block", x => x.id);
                    table.ForeignKey(
                        name: "fk_option_block_option",
                        column: x => x.option_id,
                        principalTable: "ncp_option",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_ability_code",
                table: "ncp_ability",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_ability_competence_id",
                table: "ncp_ability",
                column: "competence_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_code",
                table: "ncp_assessment",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_scope_target_id",
                table: "ncp_assessment",
                columns: new[] { "scope", "target_id" });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_assessment_id",
                table: "ncp_assessment_attempt",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_user_learning_context_id",
                table: "ncp_assessment_attempt",
                column: "user_learning_context_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_UserId",
                table: "ncp_assessment_attempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_assessment_attempt_id_question_id",
                table: "ncp_assessment_attempt_question",
                columns: new[] { "assessment_attempt_id", "question_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_question_id",
                table: "ncp_assessment_attempt_question",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_selected_option_id",
                table: "ncp_assessment_attempt_question",
                column: "selected_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_competence_level_code",
                table: "ncp_competence_level",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_competence_level_competence_id",
                table: "ncp_competence_level",
                column: "competence_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_level_id_specialization_id",
                table: "ncp_education_context",
                columns: new[] { "level_id", "specialization_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_specialization_id",
                table: "ncp_education_context",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_email_verification_token_user_id",
                table: "ncp_email_verification_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_level_code",
                table: "ncp_level",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_level_modality_id",
                table: "ncp_level",
                column: "modality_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_level_slug",
                table: "ncp_level",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_micro_topic_code",
                table: "ncp_micro_topic",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_micro_topic_slug",
                table: "ncp_micro_topic",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_micro_topic_sub_topic_id",
                table: "ncp_micro_topic",
                column: "sub_topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_modality_code",
                table: "ncp_modality",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_modality_slug",
                table: "ncp_modality",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_option_question_id",
                table: "ncp_option",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_option_block_option_id",
                table: "ncp_option_block",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_code",
                table: "ncp_question",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_sub_topic_id",
                table: "ncp_question",
                column: "sub_topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_content_block_code",
                table: "ncp_question_content_block",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_content_block_question_id",
                table: "ncp_question_content_block",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_refresh_token_token",
                table: "ncp_refresh_token",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_refresh_token_user_id",
                table: "ncp_refresh_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_resource_sub_topic_id",
                table: "ncp_resource",
                column: "sub_topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_resource_like_user_id",
                table: "ncp_resource_like",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_specialization_code",
                table: "ncp_specialization",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_specialization_slug",
                table: "ncp_specialization",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_sub_topic_code",
                table: "ncp_sub_topic",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_sub_topic_CompetenceId",
                table: "ncp_sub_topic",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_sub_topic_slug",
                table: "ncp_sub_topic",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_sub_topic_topic_id",
                table: "ncp_sub_topic",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_code",
                table: "ncp_syllabus",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_slug",
                table: "ncp_syllabus",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_context_education_context_id",
                table: "ncp_syllabus_context",
                column: "education_context_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_unit_code",
                table: "ncp_syllabus_unit",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_unit_slug",
                table: "ncp_syllabus_unit",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_unit_syllabus_id",
                table: "ncp_syllabus_unit",
                column: "syllabus_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_topic_code",
                table: "ncp_topic",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_topic_slug",
                table: "ncp_topic",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_topic_syllabus_unit_id",
                table: "ncp_topic",
                column: "syllabus_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_code",
                table: "ncp_user",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_email",
                table: "ncp_user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_user_name",
                table: "ncp_user",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_learning_context_syllabus_id",
                table: "ncp_user_learning_context",
                column: "syllabus_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_learning_context_user_id",
                table: "ncp_user_learning_context",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_resource_view_resource_id",
                table: "ncp_user_resource_view",
                column: "resource_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_sub_topic_view_sub_topic_id",
                table: "ncp_user_sub_topic_view",
                column: "sub_topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_progress_user_learning_context_id",
                table: "ncp_user_syllabus_progress",
                column: "user_learning_context_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_unit_progress_syllabus_unit_id",
                table: "ncp_user_syllabus_unit_progress",
                column: "syllabus_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_unit_progress_user_syllabus_progress_id_syllabus_unit_id",
                table: "ncp_user_syllabus_unit_progress",
                columns: new[] { "user_syllabus_progress_id", "syllabus_unit_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncp_ability");

            migrationBuilder.DropTable(
                name: "ncp_assessment_attempt_question");

            migrationBuilder.DropTable(
                name: "ncp_competence_level");

            migrationBuilder.DropTable(
                name: "ncp_email_verification_token");

            migrationBuilder.DropTable(
                name: "ncp_micro_topic");

            migrationBuilder.DropTable(
                name: "ncp_option_block");

            migrationBuilder.DropTable(
                name: "ncp_question_content_block");

            migrationBuilder.DropTable(
                name: "ncp_refresh_token");

            migrationBuilder.DropTable(
                name: "ncp_resource_like");

            migrationBuilder.DropTable(
                name: "ncp_syllabus_context");

            migrationBuilder.DropTable(
                name: "ncp_user_leaderboard");

            migrationBuilder.DropTable(
                name: "ncp_user_resource_view");

            migrationBuilder.DropTable(
                name: "ncp_user_sub_topic_view");

            migrationBuilder.DropTable(
                name: "ncp_assessment_attempt");

            migrationBuilder.DropTable(
                name: "ncp_option");

            migrationBuilder.DropTable(
                name: "ncp_education_context");

            migrationBuilder.DropTable(
                name: "ncp_resource");

            migrationBuilder.DropTable(
                name: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropTable(
                name: "ncp_assessment");

            migrationBuilder.DropTable(
                name: "ncp_question");

            migrationBuilder.DropTable(
                name: "ncp_level");

            migrationBuilder.DropTable(
                name: "ncp_specialization");

            migrationBuilder.DropTable(
                name: "ncp_user_syllabus_progress");

            migrationBuilder.DropTable(
                name: "ncp_sub_topic");

            migrationBuilder.DropTable(
                name: "ncp_modality");

            migrationBuilder.DropTable(
                name: "ncp_user_learning_context");

            migrationBuilder.DropTable(
                name: "ncp_competence");

            migrationBuilder.DropTable(
                name: "ncp_topic");

            migrationBuilder.DropTable(
                name: "ncp_user");

            migrationBuilder.DropTable(
                name: "ncp_syllabus_unit");

            migrationBuilder.DropTable(
                name: "ncp_syllabus");
        }
    }
}

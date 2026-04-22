using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ncp_assessment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Scope = table.Column<int>(type: "int", nullable: false),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TimeLimitSeconds = table.Column<int>(type: "int", nullable: true),
                    NumberQuestions = table.Column<int>(type: "int", nullable: false),
                    MaxAttempts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_competence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EffectYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_competence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_modality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_modality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_specialization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EfectYear = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncp_competence_level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetenceId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_competence_level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_competence_level_ncp_competence_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "ncp_competence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_level_ncp_modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "ncp_modality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus_unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus_unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_syllabus_unit_ncp_syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "ncp_syllabus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_email_verification_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_email_verification_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_email_verification_token_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_refresh_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_refresh_token_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_learning_context",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_learning_context", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_user_learning_context_ncp_syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "ncp_syllabus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_user_learning_context_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_education_context",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_education_context", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_education_context_ncp_level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "ncp_level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_education_context_ncp_specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "ncp_specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_competence_level_unit",
                columns: table => new
                {
                    CompetenceLevelId = table.Column<int>(type: "int", nullable: false),
                    SyllabusUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_competence_level_unit", x => new { x.CompetenceLevelId, x.SyllabusUnitId });
                    table.ForeignKey(
                        name: "FK_ncp_competence_level_unit_ncp_competence_level_CompetenceLevelId",
                        column: x => x.CompetenceLevelId,
                        principalTable: "ncp_competence_level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_competence_level_unit_ncp_syllabus_unit_SyllabusUnitId",
                        column: x => x.SyllabusUnitId,
                        principalTable: "ncp_syllabus_unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SyllabusUnitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_topic_ncp_syllabus_unit_SyllabusUnitId",
                        column: x => x.SyllabusUnitId,
                        principalTable: "ncp_syllabus_unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_assesment_attempt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    UserLearningContextId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assesment_attempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_assesment_attempt_ncp_assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "ncp_assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_assesment_attempt_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ncp_assesment_attempt_ncp_user_learning_context_UserLearningContextId",
                        column: x => x.UserLearningContextId,
                        principalTable: "ncp_user_learning_context",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_syllabus_progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLearningContextId = table.Column<int>(type: "int", nullable: false),
                    LastAccess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_syllabus_progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_user_syllabus_progress_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ncp_user_syllabus_progress_ncp_user_learning_context_UserLearningContextId",
                        column: x => x.UserLearningContextId,
                        principalTable: "ncp_user_learning_context",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ncp_syllabus_context",
                columns: table => new
                {
                    SyllabusId = table.Column<int>(type: "int", nullable: false),
                    EducationContextId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_syllabus_context", x => new { x.SyllabusId, x.EducationContextId });
                    table.ForeignKey(
                        name: "FK_ncp_syllabus_context_ncp_education_context_EducationContextId",
                        column: x => x.EducationContextId,
                        principalTable: "ncp_education_context",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_syllabus_context_ncp_syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "ncp_syllabus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_sub_topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_sub_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_sub_topic_ncp_topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "ncp_topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_syllabus_unit_progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSyllabusProgressId = table.Column<int>(type: "int", nullable: false),
                    SyllabusUnitId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    LastAttemptAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_syllabus_unit_progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_user_syllabus_unit_progress_ncp_syllabus_unit_SyllabusUnitId",
                        column: x => x.SyllabusUnitId,
                        principalTable: "ncp_syllabus_unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_user_syllabus_unit_progress_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ncp_user_syllabus_unit_progress_ncp_user_syllabus_progress_UserSyllabusProgressId",
                        column: x => x.UserSyllabusProgressId,
                        principalTable: "ncp_user_syllabus_progress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_micro_topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTopicId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_micro_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_micro_topic_ncp_sub_topic_SubTopicId",
                        column: x => x.SubTopicId,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalAttempts = table.Column<int>(type: "int", nullable: false),
                    TotalCorrect = table.Column<int>(type: "int", nullable: false),
                    SubTopicId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_question_ncp_sub_topic_SubTopicId",
                        column: x => x.SubTopicId,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ncp_resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PublicScore = table.Column<int>(type: "int", nullable: false),
                    SubTopicId = table.Column<int>(type: "int", nullable: true),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_resource_ncp_sub_topic_SubTopicId",
                        column: x => x.SubTopicId,
                        principalTable: "ncp_sub_topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_option_ncp_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ncp_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_question_content_block",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_question_content_block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_question_content_block_ncp_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ncp_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_resource_like",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_resource_like", x => new { x.ResourceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ncp_resource_like_ncp_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "ncp_resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_resource_like_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_user_resource_view",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_user_resource_view", x => new { x.UserId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ncp_user_resource_view_ncp_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "ncp_resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_user_resource_view_ncp_user_UserId",
                        column: x => x.UserId,
                        principalTable: "ncp_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ncp_assessment_attempt_question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentAttemptId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    SelectedOptionId = table.Column<int>(type: "int", nullable: true),
                    AnsweredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondsSpent = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncp_assessment_attempt_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncp_assessment_attempt_question_ncp_assesment_attempt_AssessmentAttemptId",
                        column: x => x.AssessmentAttemptId,
                        principalTable: "ncp_assesment_attempt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_assessment_attempt_question_ncp_option_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "ncp_option",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncp_assessment_attempt_question_ncp_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ncp_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assesment_attempt_AssessmentId",
                table: "ncp_assesment_attempt",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assesment_attempt_UserId",
                table: "ncp_assesment_attempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assesment_attempt_UserLearningContextId",
                table: "ncp_assesment_attempt",
                column: "UserLearningContextId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_Code",
                table: "ncp_assessment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_Scope_TargetId",
                table: "ncp_assessment",
                columns: new[] { "Scope", "TargetId" });

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_AssessmentAttemptId_QuestionId",
                table: "ncp_assessment_attempt_question",
                columns: new[] { "AssessmentAttemptId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_QuestionId",
                table: "ncp_assessment_attempt_question",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_assessment_attempt_question_SelectedOptionId",
                table: "ncp_assessment_attempt_question",
                column: "SelectedOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_competence_level_CompetenceId",
                table: "ncp_competence_level",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_competence_level_unit_SyllabusUnitId",
                table: "ncp_competence_level_unit",
                column: "SyllabusUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_LevelId_SpecializationId",
                table: "ncp_education_context",
                columns: new[] { "LevelId", "SpecializationId" },
                unique: true,
                filter: "[SpecializationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_SpecializationId",
                table: "ncp_education_context",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_email_verification_token_UserId",
                table: "ncp_email_verification_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_level_ModalityId",
                table: "ncp_level",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_micro_topic_SubTopicId",
                table: "ncp_micro_topic",
                column: "SubTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_option_QuestionId",
                table: "ncp_option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_Code",
                table: "ncp_question",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_SubTopicId",
                table: "ncp_question",
                column: "SubTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_content_block_Code",
                table: "ncp_question_content_block",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_question_content_block_QuestionId",
                table: "ncp_question_content_block",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_refresh_token_UserId",
                table: "ncp_refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_resource_SubTopicId",
                table: "ncp_resource",
                column: "SubTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_resource_like_UserId",
                table: "ncp_resource_like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_sub_topic_TopicId",
                table: "ncp_sub_topic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_context_EducationContextId",
                table: "ncp_syllabus_context",
                column: "EducationContextId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_syllabus_unit_SyllabusId",
                table: "ncp_syllabus_unit",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_topic_SyllabusUnitId",
                table: "ncp_topic",
                column: "SyllabusUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_Code",
                table: "ncp_user",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_Email",
                table: "ncp_user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_UserName",
                table: "ncp_user",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_learning_context_SyllabusId",
                table: "ncp_user_learning_context",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_learning_context_UserId",
                table: "ncp_user_learning_context",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_resource_view_ResourceId",
                table: "ncp_user_resource_view",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_progress_UserId",
                table: "ncp_user_syllabus_progress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_progress_UserLearningContextId",
                table: "ncp_user_syllabus_progress",
                column: "UserLearningContextId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_unit_progress_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                column: "SyllabusUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_unit_progress_UserId",
                table: "ncp_user_syllabus_unit_progress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_user_syllabus_unit_progress_UserSyllabusProgressId_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                columns: new[] { "UserSyllabusProgressId", "SyllabusUnitId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncp_assessment_attempt_question");

            migrationBuilder.DropTable(
                name: "ncp_competence_level_unit");

            migrationBuilder.DropTable(
                name: "ncp_email_verification_token");

            migrationBuilder.DropTable(
                name: "ncp_micro_topic");

            migrationBuilder.DropTable(
                name: "ncp_question_content_block");

            migrationBuilder.DropTable(
                name: "ncp_refresh_token");

            migrationBuilder.DropTable(
                name: "ncp_resource_like");

            migrationBuilder.DropTable(
                name: "ncp_syllabus_context");

            migrationBuilder.DropTable(
                name: "ncp_user_resource_view");

            migrationBuilder.DropTable(
                name: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropTable(
                name: "ncp_assesment_attempt");

            migrationBuilder.DropTable(
                name: "ncp_option");

            migrationBuilder.DropTable(
                name: "ncp_competence_level");

            migrationBuilder.DropTable(
                name: "ncp_education_context");

            migrationBuilder.DropTable(
                name: "ncp_resource");

            migrationBuilder.DropTable(
                name: "ncp_user_syllabus_progress");

            migrationBuilder.DropTable(
                name: "ncp_assessment");

            migrationBuilder.DropTable(
                name: "ncp_question");

            migrationBuilder.DropTable(
                name: "ncp_competence");

            migrationBuilder.DropTable(
                name: "ncp_level");

            migrationBuilder.DropTable(
                name: "ncp_specialization");

            migrationBuilder.DropTable(
                name: "ncp_user_learning_context");

            migrationBuilder.DropTable(
                name: "ncp_sub_topic");

            migrationBuilder.DropTable(
                name: "ncp_modality");

            migrationBuilder.DropTable(
                name: "ncp_user");

            migrationBuilder.DropTable(
                name: "ncp_topic");

            migrationBuilder.DropTable(
                name: "ncp_syllabus_unit");

            migrationBuilder.DropTable(
                name: "ncp_syllabus");
        }
    }
}

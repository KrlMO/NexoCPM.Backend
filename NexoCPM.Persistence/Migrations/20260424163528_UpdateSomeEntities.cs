using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_assessment_AssessmentId",
                table: "ncp_assesment_attempt");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_user_UserId",
                table: "ncp_assesment_attempt");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_user_learning_context_UserLearningContextId",
                table: "ncp_assesment_attempt");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_assesment_attempt_AssessmentAttemptId",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_option_SelectedOptionId",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_question_QuestionId",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_competence_level_ncp_competence_CompetenceId",
                table: "ncp_competence_level");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_competence_level_unit_ncp_competence_level_CompetenceLevelId",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_competence_level_unit_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_education_context_ncp_level_LevelId",
                table: "ncp_education_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_education_context_ncp_specialization_SpecializationId",
                table: "ncp_education_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_email_verification_token_ncp_user_UserId",
                table: "ncp_email_verification_token");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_level_ncp_modality_ModalityId",
                table: "ncp_level");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_micro_topic_ncp_sub_topic_SubTopicId",
                table: "ncp_micro_topic");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_option_ncp_question_QuestionId",
                table: "ncp_option");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_question_ncp_sub_topic_SubTopicId",
                table: "ncp_question");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_question_content_block_ncp_question_QuestionId",
                table: "ncp_question_content_block");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_refresh_token_ncp_user_UserId",
                table: "ncp_refresh_token");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_resource_ncp_sub_topic_SubTopicId",
                table: "ncp_resource");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_resource_like_ncp_resource_ResourceId",
                table: "ncp_resource_like");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_resource_like_ncp_user_UserId",
                table: "ncp_resource_like");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_sub_topic_ncp_topic_TopicId",
                table: "ncp_sub_topic");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_syllabus_context_ncp_education_context_EducationContextId",
                table: "ncp_syllabus_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_syllabus_context_ncp_syllabus_SyllabusId",
                table: "ncp_syllabus_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_syllabus_unit_ncp_syllabus_SyllabusId",
                table: "ncp_syllabus_unit");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_topic_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_topic");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_learning_context_ncp_syllabus_SyllabusId",
                table: "ncp_user_learning_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_learning_context_ncp_user_UserId",
                table: "ncp_user_learning_context");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_resource_view_ncp_resource_ResourceId",
                table: "ncp_user_resource_view");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_resource_view_ncp_user_UserId",
                table: "ncp_user_resource_view");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_syllabus_progress_ncp_user_learning_context_UserLearningContextId",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_syllabus_unit_progress_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropForeignKey(
                name: "FK_ncp_user_syllabus_unit_progress_ncp_user_syllabus_progress_UserSyllabusProgressId",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropIndex(
                name: "IX_ncp_education_context_LevelId_SpecializationId",
                table: "ncp_education_context");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ncp_assesment_attempt",
                table: "ncp_assesment_attempt");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ncp_topic");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "ncp_email_verification_token");

            migrationBuilder.RenameTable(
                name: "ncp_assesment_attempt",
                newName: "ncp_assessment_attempt");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ncp_user_syllabus_unit_progress",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Attempts",
                table: "ncp_user_syllabus_unit_progress",
                newName: "attempts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserSyllabusProgressId",
                table: "ncp_user_syllabus_unit_progress",
                newName: "user_syllabus_progress_id");

            migrationBuilder.RenameColumn(
                name: "TotalQuestions",
                table: "ncp_user_syllabus_unit_progress",
                newName: "total_questions");

            migrationBuilder.RenameColumn(
                name: "TotalCorrect",
                table: "ncp_user_syllabus_unit_progress",
                newName: "total_correct");

            migrationBuilder.RenameColumn(
                name: "SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                newName: "syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "LastAttemptAt",
                table: "ncp_user_syllabus_unit_progress",
                newName: "last_attempt_at");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_unit_progress_UserSyllabusProgressId_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                newName: "IX_ncp_user_syllabus_unit_progress_user_syllabus_progress_id_syllabus_unit_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_unit_progress_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                newName: "IX_ncp_user_syllabus_unit_progress_syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ncp_user_syllabus_progress",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_user_syllabus_progress",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserLearningContextId",
                table: "ncp_user_syllabus_progress",
                newName: "user_learning_context_id");

            migrationBuilder.RenameColumn(
                name: "LastAccess",
                table: "ncp_user_syllabus_progress",
                newName: "last_access");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_progress_UserLearningContextId",
                table: "ncp_user_syllabus_progress",
                newName: "IX_ncp_user_syllabus_progress_user_learning_context_id");

            migrationBuilder.RenameColumn(
                name: "ViewedAt",
                table: "ncp_user_resource_view",
                newName: "viewed_at");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "ncp_user_resource_view",
                newName: "resource_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ncp_user_resource_view",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_resource_view_ResourceId",
                table: "ncp_user_resource_view",
                newName: "IX_ncp_user_resource_view_resource_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_user_learning_context",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ncp_user_learning_context",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "ncp_user_learning_context",
                newName: "syllabus_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_user_learning_context",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_user_learning_context",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_learning_context_UserId",
                table: "ncp_user_learning_context",
                newName: "IX_ncp_user_learning_context_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_learning_context_SyllabusId",
                table: "ncp_user_learning_context",
                newName: "IX_ncp_user_learning_context_syllabus_id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ncp_user",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ncp_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_user",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "ncp_user",
                newName: "bio");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "ncp_user",
                newName: "user_role");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ncp_user",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ncp_user",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "ncp_user",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "LinkedInProfile",
                table: "ncp_user",
                newName: "linkedin_profile");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ncp_user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "ncp_user",
                newName: "is_verified");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_user",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_user",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "ncp_user",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "ncp_user",
                newName: "date_of_birth");

            migrationBuilder.RenameColumn(
                name: "AvatarUrl",
                table: "ncp_user",
                newName: "avatar_url");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_Email",
                table: "ncp_user",
                newName: "IX_ncp_user_email");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_Code",
                table: "ncp_user",
                newName: "IX_ncp_user_code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_UserName",
                table: "ncp_user",
                newName: "IX_ncp_user_user_name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ncp_topic",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_topic",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_topic",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SyllabusUnitId",
                table: "ncp_topic",
                newName: "syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_topic",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_topic",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_topic",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_topic_SyllabusUnitId",
                table: "ncp_topic",
                newName: "IX_ncp_topic_syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_syllabus_unit",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_syllabus_unit",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_syllabus_unit",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "ncp_syllabus_unit",
                newName: "syllabus_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_syllabus_unit",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_syllabus_unit",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_syllabus_unit",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_syllabus_unit_SyllabusId",
                table: "ncp_syllabus_unit",
                newName: "IX_ncp_syllabus_unit_syllabus_id");

            migrationBuilder.RenameColumn(
                name: "EducationContextId",
                table: "ncp_syllabus_context",
                newName: "education_context_id");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "ncp_syllabus_context",
                newName: "syllabus_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_syllabus_context_EducationContextId",
                table: "ncp_syllabus_context",
                newName: "IX_ncp_syllabus_context_education_context_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_syllabus",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_syllabus",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_syllabus",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_syllabus",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_syllabus",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_sub_topic",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_sub_topic",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "ncp_sub_topic",
                newName: "topic_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_sub_topic",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_sub_topic",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_sub_topic_TopicId",
                table: "ncp_sub_topic",
                newName: "IX_ncp_sub_topic_topic_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_specialization",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_specialization",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_specialization",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_specialization",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_specialization",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ncp_resource_like",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "ncp_resource_like",
                newName: "resource_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_resource_like_UserId",
                table: "ncp_resource_like",
                newName: "IX_ncp_resource_like_user_id");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ncp_resource",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ncp_resource",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ncp_resource",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_resource",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ViewsCount",
                table: "ncp_resource",
                newName: "views_count");

            migrationBuilder.RenameColumn(
                name: "SubTopicId",
                table: "ncp_resource",
                newName: "sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "PublicScore",
                table: "ncp_resource",
                newName: "public_score");

            migrationBuilder.RenameColumn(
                name: "LikesCount",
                table: "ncp_resource",
                newName: "likes_count");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_resource",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_resource",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_resource_SubTopicId",
                table: "ncp_resource",
                newName: "IX_ncp_resource_sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "ncp_refresh_token",
                newName: "token");

            migrationBuilder.RenameColumn(
                name: "Revoked",
                table: "ncp_refresh_token",
                newName: "revoked");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_refresh_token",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ncp_refresh_token",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "RevokedAt",
                table: "ncp_refresh_token",
                newName: "revoked_at");

            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "ncp_refresh_token",
                newName: "ip_address");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "ncp_refresh_token",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "DeviceInfo",
                table: "ncp_refresh_token",
                newName: "device_info");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_refresh_token",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_refresh_token_UserId",
                table: "ncp_refresh_token",
                newName: "IX_ncp_refresh_token_user_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ncp_question_content_block",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ncp_question_content_block",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_question_content_block",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_question_content_block",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ncp_question_content_block",
                newName: "question_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_question_content_block",
                newName: "order_index");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_content_block_Code",
                table: "ncp_question_content_block",
                newName: "IX_ncp_question_content_block_code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_content_block_QuestionId",
                table: "ncp_question_content_block",
                newName: "IX_ncp_question_content_block_question_id");

            migrationBuilder.RenameColumn(
                name: "Explanation",
                table: "ncp_question",
                newName: "explanation");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_question",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_question",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TotalCorrect",
                table: "ncp_question",
                newName: "total_correct");

            migrationBuilder.RenameColumn(
                name: "TotalAttempts",
                table: "ncp_question",
                newName: "total_attempts");

            migrationBuilder.RenameColumn(
                name: "SubTopicId",
                table: "ncp_question",
                newName: "sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_question",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_question",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_Code",
                table: "ncp_question",
                newName: "IX_ncp_question_code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_SubTopicId",
                table: "ncp_question",
                newName: "IX_ncp_question_sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ncp_option",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_option",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ncp_option",
                newName: "question_id");

            migrationBuilder.RenameColumn(
                name: "IsCorrect",
                table: "ncp_option",
                newName: "is_correct");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_option_QuestionId",
                table: "ncp_option",
                newName: "IX_ncp_option_question_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_modality",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_modality",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_modality",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_modality",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_modality",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_micro_topic",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_micro_topic",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SubTopicId",
                table: "ncp_micro_topic",
                newName: "sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_micro_topic",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_micro_topic",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_micro_topic",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_micro_topic_SubTopicId",
                table: "ncp_micro_topic",
                newName: "IX_ncp_micro_topic_sub_topic_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_level",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_level",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_level",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModalityId",
                table: "ncp_level",
                newName: "modality_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_level",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_level",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_level_ModalityId",
                table: "ncp_level",
                newName: "IX_ncp_level_modality_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_email_verification_token",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ncp_email_verification_token",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UsedAt",
                table: "ncp_email_verification_token",
                newName: "used_at");

            migrationBuilder.RenameColumn(
                name: "TokenHash",
                table: "ncp_email_verification_token",
                newName: "token_hash");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "ncp_email_verification_token",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_email_verification_token",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_email_verification_token_UserId",
                table: "ncp_email_verification_token",
                newName: "IX_ncp_email_verification_token_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_education_context",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SpecializationId",
                table: "ncp_education_context",
                newName: "specialization_id");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "ncp_education_context",
                newName: "level_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ncp_education_context",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_education_context",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_education_context_SpecializationId",
                table: "ncp_education_context",
                newName: "IX_ncp_education_context_specialization_id");

            migrationBuilder.RenameColumn(
                name: "SyllabusUnitId",
                table: "ncp_competence_level_unit",
                newName: "syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "CompetenceLevelId",
                table: "ncp_competence_level_unit",
                newName: "competence_level_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_competence_level_unit_SyllabusUnitId",
                table: "ncp_competence_level_unit",
                newName: "IX_ncp_competence_level_unit_syllabus_unit_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ncp_competence_level",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_competence_level",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_competence_level",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LevelNumber",
                table: "ncp_competence_level",
                newName: "level_number");

            migrationBuilder.RenameColumn(
                name: "CompetenceId",
                table: "ncp_competence_level",
                newName: "competence_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_competence_level_CompetenceId",
                table: "ncp_competence_level",
                newName: "IX_ncp_competence_level_competence_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ncp_competence",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ncp_competence",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_competence",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_competence",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_competence",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "EffectYear",
                table: "ncp_competence",
                newName: "effect_year");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_assessment_attempt_question",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SelectedOptionId",
                table: "ncp_assessment_attempt_question",
                newName: "selected_option_id");

            migrationBuilder.RenameColumn(
                name: "SecondsSpent",
                table: "ncp_assessment_attempt_question",
                newName: "seconds_spent");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "ncp_assessment_attempt_question",
                newName: "question_id");

            migrationBuilder.RenameColumn(
                name: "OrderIndex",
                table: "ncp_assessment_attempt_question",
                newName: "order_index");

            migrationBuilder.RenameColumn(
                name: "AssessmentAttemptId",
                table: "ncp_assessment_attempt_question",
                newName: "assessment_attempt_id");

            migrationBuilder.RenameColumn(
                name: "AnsweredAt",
                table: "ncp_assessment_attempt_question",
                newName: "answered_at");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_SelectedOptionId",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_selected_option_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_QuestionId",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_AssessmentAttemptId_QuestionId",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_assessment_attempt_id_question_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ncp_assessment",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ncp_assessment",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Scope",
                table: "ncp_assessment",
                newName: "scope");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ncp_assessment",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_assessment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TimeLimitSeconds",
                table: "ncp_assessment",
                newName: "time_limit_seconds");

            migrationBuilder.RenameColumn(
                name: "TargetId",
                table: "ncp_assessment",
                newName: "target_id");

            migrationBuilder.RenameColumn(
                name: "NumberQuestions",
                table: "ncp_assessment",
                newName: "number_questions");

            migrationBuilder.RenameColumn(
                name: "MaxAttempts",
                table: "ncp_assessment",
                newName: "max_attempts");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ncp_assessment",
                newName: "is_active");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_Code",
                table: "ncp_assessment",
                newName: "IX_ncp_assessment_code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_Scope_TargetId",
                table: "ncp_assessment",
                newName: "IX_ncp_assessment_scope_target_id");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "ncp_assessment_attempt",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ncp_assessment_attempt",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserLearningContextId",
                table: "ncp_assessment_attempt",
                newName: "user_learning_context_id");

            migrationBuilder.RenameColumn(
                name: "TotalQuestions",
                table: "ncp_assessment_attempt",
                newName: "total_questions");

            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "ncp_assessment_attempt",
                newName: "started_at");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "ncp_assessment_attempt",
                newName: "finished_at");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswers",
                table: "ncp_assessment_attempt",
                newName: "correct_answers");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "ncp_assessment_attempt",
                newName: "assessment_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assesment_attempt_UserLearningContextId",
                table: "ncp_assessment_attempt",
                newName: "IX_ncp_assessment_attempt_user_learning_context_id");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assesment_attempt_UserId",
                table: "ncp_assessment_attempt",
                newName: "IX_ncp_assessment_attempt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assesment_attempt_AssessmentId",
                table: "ncp_assessment_attempt",
                newName: "IX_ncp_assessment_attempt_assessment_id");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_user_learning_context",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_user_learning_context",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_verified",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_topic",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_topic",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ncp_syllabus_unit",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_syllabus_unit",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_syllabus_unit",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_syllabus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_syllabus",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_sub_topic",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "ncp_sub_topic",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_specialization",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_specialization",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_resource",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_resource",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "ncp_refresh_token",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "revoked",
                table: "ncp_refresh_token",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "revoked_at",
                table: "ncp_refresh_token",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ip_address",
                table: "ncp_refresh_token",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "device_info",
                table: "ncp_refresh_token",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_question",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_question",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_modality",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_modality",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_micro_topic",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_micro_topic",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ncp_level",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_level",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_level",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "token_hash",
                table: "ncp_email_verification_token",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "is_used",
                table: "ncp_email_verification_token",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "specialization_id",
                table: "ncp_education_context",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "ncp_education_context",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_education_context",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_competence",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "ncp_assessment",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ncp_assessment_attempt",
                table: "ncp_assessment_attempt",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_refresh_token_token",
                table: "ncp_refresh_token",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_level_id_specialization_id",
                table: "ncp_education_context",
                columns: new[] { "level_id", "specialization_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assessment_attempt_ncp_user_UserId",
                table: "ncp_assessment_attempt",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_assessment_attempt_assessment",
                table: "ncp_assessment_attempt",
                column: "assessment_id",
                principalTable: "ncp_assessment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessment_attempt_user_learning_context",
                table: "ncp_assessment_attempt",
                column: "user_learning_context_id",
                principalTable: "ncp_user_learning_context",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessment_attempt_question_assessment_attempt",
                table: "ncp_assessment_attempt_question",
                column: "assessment_attempt_id",
                principalTable: "ncp_assessment_attempt",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessment_attempt_question_question",
                table: "ncp_assessment_attempt_question",
                column: "question_id",
                principalTable: "ncp_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessment_attempt_question_selected_option",
                table: "ncp_assessment_attempt_question",
                column: "selected_option_id",
                principalTable: "ncp_option",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_competence_level_competence",
                table: "ncp_competence_level",
                column: "competence_id",
                principalTable: "ncp_competence",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_competence_level_unit_competence_level",
                table: "ncp_competence_level_unit",
                column: "competence_level_id",
                principalTable: "ncp_competence_level",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_competence_level_unit_syllabus_unit",
                table: "ncp_competence_level_unit",
                column: "syllabus_unit_id",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_education_context_level",
                table: "ncp_education_context",
                column: "level_id",
                principalTable: "ncp_level",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_education_context_specialization",
                table: "ncp_education_context",
                column: "specialization_id",
                principalTable: "ncp_specialization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_email_verification_token_user",
                table: "ncp_email_verification_token",
                column: "user_id",
                principalTable: "ncp_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_level_modality",
                table: "ncp_level",
                column: "modality_id",
                principalTable: "ncp_modality",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_micro_topic_sub_topic",
                table: "ncp_micro_topic",
                column: "sub_topic_id",
                principalTable: "ncp_sub_topic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_option_question",
                table: "ncp_option",
                column: "question_id",
                principalTable: "ncp_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_question_sub_topic",
                table: "ncp_question",
                column: "sub_topic_id",
                principalTable: "ncp_sub_topic",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_question_content_block_question",
                table: "ncp_question_content_block",
                column: "question_id",
                principalTable: "ncp_question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_refresh_token_user",
                table: "ncp_refresh_token",
                column: "user_id",
                principalTable: "ncp_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resource_sub_topic",
                table: "ncp_resource",
                column: "sub_topic_id",
                principalTable: "ncp_sub_topic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resource_like_resource",
                table: "ncp_resource_like",
                column: "resource_id",
                principalTable: "ncp_resource",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resource_like_user",
                table: "ncp_resource_like",
                column: "user_id",
                principalTable: "ncp_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sub_topic_topic",
                table: "ncp_sub_topic",
                column: "topic_id",
                principalTable: "ncp_topic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_syllabus_context_education_context",
                table: "ncp_syllabus_context",
                column: "education_context_id",
                principalTable: "ncp_education_context",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_syllabus_context_syllabus",
                table: "ncp_syllabus_context",
                column: "syllabus_id",
                principalTable: "ncp_syllabus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_syllabus_unit_syllabus",
                table: "ncp_syllabus_unit",
                column: "syllabus_id",
                principalTable: "ncp_syllabus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_topic_syllabus_unit",
                table: "ncp_topic",
                column: "syllabus_unit_id",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_learning_context_syllabus",
                table: "ncp_user_learning_context",
                column: "syllabus_id",
                principalTable: "ncp_syllabus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_learning_context_user",
                table: "ncp_user_learning_context",
                column: "user_id",
                principalTable: "ncp_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_resource_view_resource",
                table: "ncp_user_resource_view",
                column: "resource_id",
                principalTable: "ncp_resource",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_resource_view_user",
                table: "ncp_user_resource_view",
                column: "user_id",
                principalTable: "ncp_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_syllabus_progress_user_learning_context",
                table: "ncp_user_syllabus_progress",
                column: "user_learning_context_id",
                principalTable: "ncp_user_learning_context",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_syllabus_unit_progress_syllabus_unit",
                table: "ncp_user_syllabus_unit_progress",
                column: "syllabus_unit_id",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_syllabus_unit_progress_user_syllabus_progress",
                table: "ncp_user_syllabus_unit_progress",
                column: "user_syllabus_progress_id",
                principalTable: "ncp_user_syllabus_progress",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ncp_assessment_attempt_ncp_user_UserId",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropForeignKey(
                name: "fk_assessment_attempt_assessment",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropForeignKey(
                name: "fk_assessment_attempt_user_learning_context",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropForeignKey(
                name: "fk_assessment_attempt_question_assessment_attempt",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "fk_assessment_attempt_question_question",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "fk_assessment_attempt_question_selected_option",
                table: "ncp_assessment_attempt_question");

            migrationBuilder.DropForeignKey(
                name: "fk_competence_level_competence",
                table: "ncp_competence_level");

            migrationBuilder.DropForeignKey(
                name: "fk_competence_level_unit_competence_level",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropForeignKey(
                name: "fk_competence_level_unit_syllabus_unit",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropForeignKey(
                name: "fk_education_context_level",
                table: "ncp_education_context");

            migrationBuilder.DropForeignKey(
                name: "fk_education_context_specialization",
                table: "ncp_education_context");

            migrationBuilder.DropForeignKey(
                name: "fk_email_verification_token_user",
                table: "ncp_email_verification_token");

            migrationBuilder.DropForeignKey(
                name: "fk_level_modality",
                table: "ncp_level");

            migrationBuilder.DropForeignKey(
                name: "fk_micro_topic_sub_topic",
                table: "ncp_micro_topic");

            migrationBuilder.DropForeignKey(
                name: "fk_option_question",
                table: "ncp_option");

            migrationBuilder.DropForeignKey(
                name: "fk_question_sub_topic",
                table: "ncp_question");

            migrationBuilder.DropForeignKey(
                name: "fk_question_content_block_question",
                table: "ncp_question_content_block");

            migrationBuilder.DropForeignKey(
                name: "fk_refresh_token_user",
                table: "ncp_refresh_token");

            migrationBuilder.DropForeignKey(
                name: "fk_resource_sub_topic",
                table: "ncp_resource");

            migrationBuilder.DropForeignKey(
                name: "fk_resource_like_resource",
                table: "ncp_resource_like");

            migrationBuilder.DropForeignKey(
                name: "fk_resource_like_user",
                table: "ncp_resource_like");

            migrationBuilder.DropForeignKey(
                name: "fk_sub_topic_topic",
                table: "ncp_sub_topic");

            migrationBuilder.DropForeignKey(
                name: "fk_syllabus_context_education_context",
                table: "ncp_syllabus_context");

            migrationBuilder.DropForeignKey(
                name: "fk_syllabus_context_syllabus",
                table: "ncp_syllabus_context");

            migrationBuilder.DropForeignKey(
                name: "fk_syllabus_unit_syllabus",
                table: "ncp_syllabus_unit");

            migrationBuilder.DropForeignKey(
                name: "fk_topic_syllabus_unit",
                table: "ncp_topic");

            migrationBuilder.DropForeignKey(
                name: "fk_user_learning_context_syllabus",
                table: "ncp_user_learning_context");

            migrationBuilder.DropForeignKey(
                name: "fk_user_learning_context_user",
                table: "ncp_user_learning_context");

            migrationBuilder.DropForeignKey(
                name: "fk_user_resource_view_resource",
                table: "ncp_user_resource_view");

            migrationBuilder.DropForeignKey(
                name: "fk_user_resource_view_user",
                table: "ncp_user_resource_view");

            migrationBuilder.DropForeignKey(
                name: "fk_user_syllabus_progress_user_learning_context",
                table: "ncp_user_syllabus_progress");

            migrationBuilder.DropForeignKey(
                name: "fk_user_syllabus_unit_progress_syllabus_unit",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropForeignKey(
                name: "fk_user_syllabus_unit_progress_user_syllabus_progress",
                table: "ncp_user_syllabus_unit_progress");

            migrationBuilder.DropIndex(
                name: "IX_ncp_refresh_token_token",
                table: "ncp_refresh_token");

            migrationBuilder.DropIndex(
                name: "IX_ncp_education_context_level_id_specialization_id",
                table: "ncp_education_context");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ncp_assessment_attempt",
                table: "ncp_assessment_attempt");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "ncp_sub_topic");

            migrationBuilder.DropColumn(
                name: "is_used",
                table: "ncp_email_verification_token");

            migrationBuilder.RenameTable(
                name: "ncp_assessment_attempt",
                newName: "ncp_assesment_attempt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ncp_user_syllabus_unit_progress",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "attempts",
                table: "ncp_user_syllabus_unit_progress",
                newName: "Attempts");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_syllabus_progress_id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "UserSyllabusProgressId");

            migrationBuilder.RenameColumn(
                name: "total_questions",
                table: "ncp_user_syllabus_unit_progress",
                newName: "TotalQuestions");

            migrationBuilder.RenameColumn(
                name: "total_correct",
                table: "ncp_user_syllabus_unit_progress",
                newName: "TotalCorrect");

            migrationBuilder.RenameColumn(
                name: "syllabus_unit_id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "last_attempt_at",
                table: "ncp_user_syllabus_unit_progress",
                newName: "LastAttemptAt");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_unit_progress_user_syllabus_progress_id_syllabus_unit_id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "IX_ncp_user_syllabus_unit_progress_UserSyllabusProgressId_SyllabusUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_unit_progress_syllabus_unit_id",
                table: "ncp_user_syllabus_unit_progress",
                newName: "IX_ncp_user_syllabus_unit_progress_SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ncp_user_syllabus_progress",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_user_syllabus_progress",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_learning_context_id",
                table: "ncp_user_syllabus_progress",
                newName: "UserLearningContextId");

            migrationBuilder.RenameColumn(
                name: "last_access",
                table: "ncp_user_syllabus_progress",
                newName: "LastAccess");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_syllabus_progress_user_learning_context_id",
                table: "ncp_user_syllabus_progress",
                newName: "IX_ncp_user_syllabus_progress_UserLearningContextId");

            migrationBuilder.RenameColumn(
                name: "viewed_at",
                table: "ncp_user_resource_view",
                newName: "ViewedAt");

            migrationBuilder.RenameColumn(
                name: "resource_id",
                table: "ncp_user_resource_view",
                newName: "ResourceId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ncp_user_resource_view",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_resource_view_resource_id",
                table: "ncp_user_resource_view",
                newName: "IX_ncp_user_resource_view_ResourceId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_user_learning_context",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ncp_user_learning_context",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "syllabus_id",
                table: "ncp_user_learning_context",
                newName: "SyllabusId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_user_learning_context",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_user_learning_context",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_learning_context_user_id",
                table: "ncp_user_learning_context",
                newName: "IX_ncp_user_learning_context_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_learning_context_syllabus_id",
                table: "ncp_user_learning_context",
                newName: "IX_ncp_user_learning_context_SyllabusId");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "ncp_user",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "ncp_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_user",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "bio",
                table: "ncp_user",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_role",
                table: "ncp_user",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "ncp_user",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "ncp_user",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "ncp_user",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "linkedin_profile",
                table: "ncp_user",
                newName: "LinkedInProfile");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "ncp_user",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_verified",
                table: "ncp_user",
                newName: "IsVerified");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_user",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_user",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "ncp_user",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "ncp_user",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "avatar_url",
                table: "ncp_user",
                newName: "AvatarUrl");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_email",
                table: "ncp_user",
                newName: "IX_ncp_user_Email");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_code",
                table: "ncp_user",
                newName: "IX_ncp_user_Code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_user_user_name",
                table: "ncp_user",
                newName: "IX_ncp_user_UserName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ncp_topic",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_topic",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_topic",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "syllabus_unit_id",
                table: "ncp_topic",
                newName: "SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_topic",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_topic",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_topic",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_topic_syllabus_unit_id",
                table: "ncp_topic",
                newName: "IX_ncp_topic_SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_syllabus_unit",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_syllabus_unit",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_syllabus_unit",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "syllabus_id",
                table: "ncp_syllabus_unit",
                newName: "SyllabusId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_syllabus_unit",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_syllabus_unit",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_syllabus_unit",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_syllabus_unit_syllabus_id",
                table: "ncp_syllabus_unit",
                newName: "IX_ncp_syllabus_unit_SyllabusId");

            migrationBuilder.RenameColumn(
                name: "education_context_id",
                table: "ncp_syllabus_context",
                newName: "EducationContextId");

            migrationBuilder.RenameColumn(
                name: "syllabus_id",
                table: "ncp_syllabus_context",
                newName: "SyllabusId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_syllabus_context_education_context_id",
                table: "ncp_syllabus_context",
                newName: "IX_ncp_syllabus_context_EducationContextId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_syllabus",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_syllabus",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_syllabus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_syllabus",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_syllabus",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_sub_topic",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_sub_topic",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "topic_id",
                table: "ncp_sub_topic",
                newName: "TopicId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_sub_topic",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_sub_topic",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_sub_topic_topic_id",
                table: "ncp_sub_topic",
                newName: "IX_ncp_sub_topic_TopicId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_specialization",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_specialization",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_specialization",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_specialization",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_specialization",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ncp_resource_like",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "resource_id",
                table: "ncp_resource_like",
                newName: "ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_resource_like_user_id",
                table: "ncp_resource_like",
                newName: "IX_ncp_resource_like_UserId");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "ncp_resource",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "ncp_resource",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ncp_resource",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_resource",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "views_count",
                table: "ncp_resource",
                newName: "ViewsCount");

            migrationBuilder.RenameColumn(
                name: "sub_topic_id",
                table: "ncp_resource",
                newName: "SubTopicId");

            migrationBuilder.RenameColumn(
                name: "public_score",
                table: "ncp_resource",
                newName: "PublicScore");

            migrationBuilder.RenameColumn(
                name: "likes_count",
                table: "ncp_resource",
                newName: "LikesCount");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_resource",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_resource",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_resource_sub_topic_id",
                table: "ncp_resource",
                newName: "IX_ncp_resource_SubTopicId");

            migrationBuilder.RenameColumn(
                name: "token",
                table: "ncp_refresh_token",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "revoked",
                table: "ncp_refresh_token",
                newName: "Revoked");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_refresh_token",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ncp_refresh_token",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "revoked_at",
                table: "ncp_refresh_token",
                newName: "RevokedAt");

            migrationBuilder.RenameColumn(
                name: "ip_address",
                table: "ncp_refresh_token",
                newName: "IpAddress");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                table: "ncp_refresh_token",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "device_info",
                table: "ncp_refresh_token",
                newName: "DeviceInfo");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_refresh_token",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_refresh_token_user_id",
                table: "ncp_refresh_token",
                newName: "IX_ncp_refresh_token_UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "ncp_question_content_block",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "ncp_question_content_block",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_question_content_block",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_question_content_block",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "ncp_question_content_block",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_question_content_block",
                newName: "OrderIndex");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_content_block_code",
                table: "ncp_question_content_block",
                newName: "IX_ncp_question_content_block_Code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_content_block_question_id",
                table: "ncp_question_content_block",
                newName: "IX_ncp_question_content_block_QuestionId");

            migrationBuilder.RenameColumn(
                name: "explanation",
                table: "ncp_question",
                newName: "Explanation");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_question",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "total_correct",
                table: "ncp_question",
                newName: "TotalCorrect");

            migrationBuilder.RenameColumn(
                name: "total_attempts",
                table: "ncp_question",
                newName: "TotalAttempts");

            migrationBuilder.RenameColumn(
                name: "sub_topic_id",
                table: "ncp_question",
                newName: "SubTopicId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_question",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_question",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_code",
                table: "ncp_question",
                newName: "IX_ncp_question_Code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_question_sub_topic_id",
                table: "ncp_question",
                newName: "IX_ncp_question_SubTopicId");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "ncp_option",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_option",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "ncp_option",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "is_correct",
                table: "ncp_option",
                newName: "IsCorrect");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_option_question_id",
                table: "ncp_option",
                newName: "IX_ncp_option_QuestionId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_modality",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_modality",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_modality",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_modality",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_modality",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_micro_topic",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_micro_topic",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sub_topic_id",
                table: "ncp_micro_topic",
                newName: "SubTopicId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_micro_topic",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_micro_topic",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_micro_topic",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_micro_topic_sub_topic_id",
                table: "ncp_micro_topic",
                newName: "IX_ncp_micro_topic_SubTopicId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_level",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_level",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_level",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modality_id",
                table: "ncp_level",
                newName: "ModalityId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_level",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_level",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_level_modality_id",
                table: "ncp_level",
                newName: "IX_ncp_level_ModalityId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_email_verification_token",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ncp_email_verification_token",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "used_at",
                table: "ncp_email_verification_token",
                newName: "UsedAt");

            migrationBuilder.RenameColumn(
                name: "token_hash",
                table: "ncp_email_verification_token",
                newName: "TokenHash");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                table: "ncp_email_verification_token",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_email_verification_token",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_email_verification_token_user_id",
                table: "ncp_email_verification_token",
                newName: "IX_ncp_email_verification_token_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_education_context",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "specialization_id",
                table: "ncp_education_context",
                newName: "SpecializationId");

            migrationBuilder.RenameColumn(
                name: "level_id",
                table: "ncp_education_context",
                newName: "LevelId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "ncp_education_context",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_education_context",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_education_context_specialization_id",
                table: "ncp_education_context",
                newName: "IX_ncp_education_context_SpecializationId");

            migrationBuilder.RenameColumn(
                name: "syllabus_unit_id",
                table: "ncp_competence_level_unit",
                newName: "SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "competence_level_id",
                table: "ncp_competence_level_unit",
                newName: "CompetenceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_competence_level_unit_syllabus_unit_id",
                table: "ncp_competence_level_unit",
                newName: "IX_ncp_competence_level_unit_SyllabusUnitId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ncp_competence_level",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_competence_level",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_competence_level",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "level_number",
                table: "ncp_competence_level",
                newName: "LevelNumber");

            migrationBuilder.RenameColumn(
                name: "competence_id",
                table: "ncp_competence_level",
                newName: "CompetenceId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_competence_level_competence_id",
                table: "ncp_competence_level",
                newName: "IX_ncp_competence_level_CompetenceId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ncp_competence",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ncp_competence",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_competence",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_competence",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_competence",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "effect_year",
                table: "ncp_competence",
                newName: "EffectYear");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_assessment_attempt_question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "selected_option_id",
                table: "ncp_assessment_attempt_question",
                newName: "SelectedOptionId");

            migrationBuilder.RenameColumn(
                name: "seconds_spent",
                table: "ncp_assessment_attempt_question",
                newName: "SecondsSpent");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "ncp_assessment_attempt_question",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "order_index",
                table: "ncp_assessment_attempt_question",
                newName: "OrderIndex");

            migrationBuilder.RenameColumn(
                name: "assessment_attempt_id",
                table: "ncp_assessment_attempt_question",
                newName: "AssessmentAttemptId");

            migrationBuilder.RenameColumn(
                name: "answered_at",
                table: "ncp_assessment_attempt_question",
                newName: "AnsweredAt");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_selected_option_id",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_SelectedOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_question_id",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_question_assessment_attempt_id_question_id",
                table: "ncp_assessment_attempt_question",
                newName: "IX_ncp_assessment_attempt_question_AssessmentAttemptId_QuestionId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "ncp_assessment",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "ncp_assessment",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "scope",
                table: "ncp_assessment",
                newName: "Scope");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "ncp_assessment",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_assessment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "time_limit_seconds",
                table: "ncp_assessment",
                newName: "TimeLimitSeconds");

            migrationBuilder.RenameColumn(
                name: "target_id",
                table: "ncp_assessment",
                newName: "TargetId");

            migrationBuilder.RenameColumn(
                name: "number_questions",
                table: "ncp_assessment",
                newName: "NumberQuestions");

            migrationBuilder.RenameColumn(
                name: "max_attempts",
                table: "ncp_assessment",
                newName: "MaxAttempts");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "ncp_assessment",
                newName: "IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_code",
                table: "ncp_assessment",
                newName: "IX_ncp_assessment_Code");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_scope_target_id",
                table: "ncp_assessment",
                newName: "IX_ncp_assessment_Scope_TargetId");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "ncp_assesment_attempt",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ncp_assesment_attempt",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_learning_context_id",
                table: "ncp_assesment_attempt",
                newName: "UserLearningContextId");

            migrationBuilder.RenameColumn(
                name: "total_questions",
                table: "ncp_assesment_attempt",
                newName: "TotalQuestions");

            migrationBuilder.RenameColumn(
                name: "started_at",
                table: "ncp_assesment_attempt",
                newName: "StartedAt");

            migrationBuilder.RenameColumn(
                name: "finished_at",
                table: "ncp_assesment_attempt",
                newName: "FinishedAt");

            migrationBuilder.RenameColumn(
                name: "correct_answers",
                table: "ncp_assesment_attempt",
                newName: "CorrectAnswers");

            migrationBuilder.RenameColumn(
                name: "assessment_id",
                table: "ncp_assesment_attempt",
                newName: "AssessmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_UserId",
                table: "ncp_assesment_attempt",
                newName: "IX_ncp_assesment_attempt_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_user_learning_context_id",
                table: "ncp_assesment_attempt",
                newName: "IX_ncp_assesment_attempt_UserLearningContextId");

            migrationBuilder.RenameIndex(
                name: "IX_ncp_assessment_attempt_assessment_id",
                table: "ncp_assesment_attempt",
                newName: "IX_ncp_assesment_attempt_AssessmentId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_user_learning_context",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_user_learning_context",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsVerified",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_user",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_topic",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_topic",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ncp_topic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ncp_syllabus_unit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_syllabus_unit",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_syllabus_unit",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_syllabus",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_syllabus",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_sub_topic",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_specialization",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_specialization",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_resource",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_resource",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "ncp_refresh_token",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<bool>(
                name: "Revoked",
                table: "ncp_refresh_token",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RevokedAt",
                table: "ncp_refresh_token",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "ncp_refresh_token",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "ncp_refresh_token",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_question",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_question",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_modality",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_modality",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_micro_topic",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_micro_topic",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ncp_level",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_level",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_level",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "TokenHash",
                table: "ncp_email_verification_token",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<bool>(
                name: "Used",
                table: "ncp_email_verification_token",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SpecializationId",
                table: "ncp_education_context",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ncp_education_context",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_education_context",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_competence",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ncp_assessment",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ncp_assesment_attempt",
                table: "ncp_assesment_attempt",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ncp_education_context_LevelId_SpecializationId",
                table: "ncp_education_context",
                columns: new[] { "LevelId", "SpecializationId" },
                unique: true,
                filter: "[SpecializationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_assessment_AssessmentId",
                table: "ncp_assesment_attempt",
                column: "AssessmentId",
                principalTable: "ncp_assessment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_user_UserId",
                table: "ncp_assesment_attempt",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assesment_attempt_ncp_user_learning_context_UserLearningContextId",
                table: "ncp_assesment_attempt",
                column: "UserLearningContextId",
                principalTable: "ncp_user_learning_context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_assesment_attempt_AssessmentAttemptId",
                table: "ncp_assessment_attempt_question",
                column: "AssessmentAttemptId",
                principalTable: "ncp_assesment_attempt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_option_SelectedOptionId",
                table: "ncp_assessment_attempt_question",
                column: "SelectedOptionId",
                principalTable: "ncp_option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_assessment_attempt_question_ncp_question_QuestionId",
                table: "ncp_assessment_attempt_question",
                column: "QuestionId",
                principalTable: "ncp_question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_competence_level_ncp_competence_CompetenceId",
                table: "ncp_competence_level",
                column: "CompetenceId",
                principalTable: "ncp_competence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_competence_level_unit_ncp_competence_level_CompetenceLevelId",
                table: "ncp_competence_level_unit",
                column: "CompetenceLevelId",
                principalTable: "ncp_competence_level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_competence_level_unit_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_competence_level_unit",
                column: "SyllabusUnitId",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_education_context_ncp_level_LevelId",
                table: "ncp_education_context",
                column: "LevelId",
                principalTable: "ncp_level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_education_context_ncp_specialization_SpecializationId",
                table: "ncp_education_context",
                column: "SpecializationId",
                principalTable: "ncp_specialization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_email_verification_token_ncp_user_UserId",
                table: "ncp_email_verification_token",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_level_ncp_modality_ModalityId",
                table: "ncp_level",
                column: "ModalityId",
                principalTable: "ncp_modality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_micro_topic_ncp_sub_topic_SubTopicId",
                table: "ncp_micro_topic",
                column: "SubTopicId",
                principalTable: "ncp_sub_topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_option_ncp_question_QuestionId",
                table: "ncp_option",
                column: "QuestionId",
                principalTable: "ncp_question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_question_ncp_sub_topic_SubTopicId",
                table: "ncp_question",
                column: "SubTopicId",
                principalTable: "ncp_sub_topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_question_content_block_ncp_question_QuestionId",
                table: "ncp_question_content_block",
                column: "QuestionId",
                principalTable: "ncp_question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_refresh_token_ncp_user_UserId",
                table: "ncp_refresh_token",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_resource_ncp_sub_topic_SubTopicId",
                table: "ncp_resource",
                column: "SubTopicId",
                principalTable: "ncp_sub_topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_resource_like_ncp_resource_ResourceId",
                table: "ncp_resource_like",
                column: "ResourceId",
                principalTable: "ncp_resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_resource_like_ncp_user_UserId",
                table: "ncp_resource_like",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_sub_topic_ncp_topic_TopicId",
                table: "ncp_sub_topic",
                column: "TopicId",
                principalTable: "ncp_topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_syllabus_context_ncp_education_context_EducationContextId",
                table: "ncp_syllabus_context",
                column: "EducationContextId",
                principalTable: "ncp_education_context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_syllabus_context_ncp_syllabus_SyllabusId",
                table: "ncp_syllabus_context",
                column: "SyllabusId",
                principalTable: "ncp_syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_syllabus_unit_ncp_syllabus_SyllabusId",
                table: "ncp_syllabus_unit",
                column: "SyllabusId",
                principalTable: "ncp_syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_topic_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_topic",
                column: "SyllabusUnitId",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_learning_context_ncp_syllabus_SyllabusId",
                table: "ncp_user_learning_context",
                column: "SyllabusId",
                principalTable: "ncp_syllabus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_learning_context_ncp_user_UserId",
                table: "ncp_user_learning_context",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_resource_view_ncp_resource_ResourceId",
                table: "ncp_user_resource_view",
                column: "ResourceId",
                principalTable: "ncp_resource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_resource_view_ncp_user_UserId",
                table: "ncp_user_resource_view",
                column: "UserId",
                principalTable: "ncp_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_syllabus_progress_ncp_user_learning_context_UserLearningContextId",
                table: "ncp_user_syllabus_progress",
                column: "UserLearningContextId",
                principalTable: "ncp_user_learning_context",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_syllabus_unit_progress_ncp_syllabus_unit_SyllabusUnitId",
                table: "ncp_user_syllabus_unit_progress",
                column: "SyllabusUnitId",
                principalTable: "ncp_syllabus_unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ncp_user_syllabus_unit_progress_ncp_user_syllabus_progress_UserSyllabusProgressId",
                table: "ncp_user_syllabus_unit_progress",
                column: "UserSyllabusProgressId",
                principalTable: "ncp_user_syllabus_progress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

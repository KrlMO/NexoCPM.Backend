using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexoCPM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuditableEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_user_syllabus_unit_progress",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_user_syllabus_unit_progress",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_user_syllabus_unit_progress",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_user_syllabus_unit_progress",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_user_syllabus_unit_progress",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_user_syllabus_unit_progress",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_user_syllabus_progress",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_user_syllabus_progress",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_user_syllabus_progress",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_user_syllabus_progress",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_user_syllabus_progress",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_user_syllabus_progress",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_user_learning_context",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_user_learning_context",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_user_learning_context",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_user_learning_context",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_user_learning_context",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_user_learning_context",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_user",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_user",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_user",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_user",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_user",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_user",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_topic",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_topic",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_topic",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_topic",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_topic",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_topic",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_syllabus_unit",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_syllabus_unit",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_syllabus_unit",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_syllabus_unit",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_syllabus_unit",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_syllabus_unit",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_syllabus_context",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_syllabus_context",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_syllabus_context",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_syllabus_context",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_syllabus_context",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_syllabus_context",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_syllabus",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_syllabus",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_syllabus",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_syllabus",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_syllabus",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_syllabus",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_sub_topic",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_sub_topic",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_sub_topic",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_sub_topic",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_sub_topic",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_sub_topic",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_specialization",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_specialization",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_specialization",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_specialization",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_specialization",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_specialization",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_question",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_question",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_question",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_question",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_question",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_question",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_modality",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_modality",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_modality",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_modality",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_modality",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_modality",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_micro_topic",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_micro_topic",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_micro_topic",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_micro_topic",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_micro_topic",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_micro_topic",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_level",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_level",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_level",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_level",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_level",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_level",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_education_context",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_education_context",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_education_context",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_education_context",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_education_context",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_education_context",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "ncp_competence",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ncp_competence",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ncp_competence",
                newName: "deleted_by");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ncp_competence",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ncp_competence",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ncp_competence",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_user_syllabus_unit_progress",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_user_syllabus_progress",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_user_learning_context",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_user",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_topic",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_syllabus_unit",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_syllabus_context",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_syllabus",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_sub_topic",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_specialization",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_question",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_modality",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_micro_topic",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "ncp_level",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_level",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_education_context",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "ncp_competence_level_unit",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "ncp_competence_level_unit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "ncp_competence_level_unit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "ncp_competence_level_unit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "ncp_competence_level_unit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "ncp_competence_level_unit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "ncp_competence_level",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "ncp_competence_level",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "ncp_competence_level",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "ncp_competence_level",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "ncp_competence_level",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "ncp_competence_level",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ncp_competence",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "ncp_competence_level_unit");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "ncp_competence_level");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "ncp_competence_level");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "ncp_competence_level");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "ncp_competence_level");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "ncp_competence_level");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "ncp_competence_level");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_user_syllabus_unit_progress",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_user_syllabus_unit_progress",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_user_syllabus_unit_progress",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_user_syllabus_unit_progress",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_user_syllabus_unit_progress",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_user_syllabus_unit_progress",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_user_syllabus_progress",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_user_syllabus_progress",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_user_syllabus_progress",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_user_syllabus_progress",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_user_syllabus_progress",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_user_syllabus_progress",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_user_learning_context",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_user_learning_context",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_user_learning_context",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_user_learning_context",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_user_learning_context",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_user_learning_context",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_user",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_user",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_user",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_user",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_user",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_user",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_topic",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_topic",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_topic",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_topic",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_topic",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_topic",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_syllabus_unit",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_syllabus_unit",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_syllabus_unit",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_syllabus_unit",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_syllabus_unit",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_syllabus_unit",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_syllabus_context",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_syllabus_context",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_syllabus_context",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_syllabus_context",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_syllabus_context",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_syllabus_context",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_syllabus",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_syllabus",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_syllabus",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_syllabus",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_syllabus",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_syllabus",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_sub_topic",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_sub_topic",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_sub_topic",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_sub_topic",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_sub_topic",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_sub_topic",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_specialization",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_specialization",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_specialization",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_specialization",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_specialization",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_specialization",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_question",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_question",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_question",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_question",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_question",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_question",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_modality",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_modality",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_modality",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_modality",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_modality",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_modality",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_micro_topic",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_micro_topic",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_micro_topic",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_micro_topic",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_micro_topic",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_micro_topic",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_level",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_level",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_level",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_level",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_level",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_level",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_education_context",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_education_context",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_education_context",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_education_context",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_education_context",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_education_context",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "ncp_competence",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "ncp_competence",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_by",
                table: "ncp_competence",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "ncp_competence",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "ncp_competence",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "ncp_competence",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_user_syllabus_unit_progress",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_user_syllabus_progress",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_user_learning_context",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_user",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_topic",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_syllabus_unit",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_syllabus_context",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_syllabus",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_sub_topic",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_specialization",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_question",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_modality",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_micro_topic",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ncp_level",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_level",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_education_context",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ncp_competence",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}

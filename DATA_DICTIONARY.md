# Diccionario de Datos — NexoCPM

## Convenciones Generales

- **Base de datos:** SQL Server (via EF Core)
- **Prefijo de tablas:** `ncp_`
- **Auditoría:** Casi todas las entidades heredan de `AuditableEntity` con columnas `created_at`, `created_by`, `updated_at`, `updated_by`, `deleted_at`, `deleted_by`
- **Soft delete:** Las tablas con `is_deleted` usan borrado lógico
- **Esquema de naming en BD:** snake_case (excepciones documentadas)
- **Versión de migración inicial:** `20260511125117_Init_Schema`

---

## Índice de Tablas

| # | Tabla | Descripción |
|---|-------|-------------|
| 1 | `ncp_user` | Usuarios del sistema |
| 2 | `ncp_refresh_token` | Tokens de refresco JWT |
| 3 | `ncp_email_verification_token` | Tokens de verificación de email |
| 4 | `ncp_modality` | Modalidades educativas |
| 5 | `ncp_level` | Niveles/grados educativos |
| 6 | `ncp_specialization` | Especializaciones |
| 7 | `ncp_education_context` | Contextos educativos (nivel + especialización) |
| 8 | `ncp_competence` | Competencias |
| 9 | `ncp_ability` | Habilidades/ capacidades |
| 10 | `ncp_competence_level` | Niveles de competencia |
| 11 | `ncp_syllabus` | Sílabos / planes de estudio |
| 12 | `ncp_syllabus_unit` | Unidades / módulos del sílabo |
| 13 | `ncp_topic` | Temas |
| 14 | `ncp_sub_topic` | Subtemas |
| 15 | `ncp_micro_topic` | Microtemas |
| 16 | `ncp_syllabus_context` | Asignación sílabo ↔ contexto educativo (M:N) |
| 17 | `ncp_assessment` | Evaluaciones |
| 18 | `ncp_assessment_attempt` | Intentos de evaluación |
| 19 | `ncp_assessment_attempt_question` | Preguntas respondidas en un intento |
| 20 | `ncp_question` | Preguntas |
| 21 | `ncp_question_content_block` | Bloques de contenido de pregunta |
| 22 | `ncp_option` | Opciones de respuesta |
| 23 | `ncp_option_block` | Bloques de contenido de opción |
| 24 | `ncp_resource` | Recursos educativos |
| 25 | `ncp_resource_like` | Likes a recursos (M:N) |
| 26 | `ncp_user_resource_view` | Vistas de recurso por usuario (M:N) |
| 27 | `ncp_user_learning_context` | Contexto de aprendizaje del usuario |
| 28 | `ncp_user_syllabus_progress` | Progreso del usuario en el sílabo |
| 29 | `ncp_user_syllabus_unit_progress` | Progreso del usuario en unidad |
| 30 | `ncp_user_sub_topic_view` | Vistas de subtema por usuario |
| 31 | `ncp_user_leaderboard` | Leaderboard / puntuación del usuario |

---

## 1. `ncp_user` — Usuarios

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_user_code` |
| `first_name` | FirstName | string | `nvarchar(100)` | No | — | |
| `last_name` | LastName | string | `nvarchar(100)` | No | — | |
| `user_name` | UserName | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_user_user_name` |
| `email` | Email | string | `nvarchar(200)` | No | — | **UQ** `IX_ncp_user_email` |
| `password_hash` | PasswordHash | string | `nvarchar(500)` | No | — | |
| `user_role` | UserRole | enum | `nvarchar(max)` | No | — | `USER \| ADMIN` (string) |
| `avatar_url` | AvatarUrl | string? | `nvarchar(500)` | Sí | — | |
| `bio` | Bio | string? | `nvarchar(500)` | Sí | — | |
| `date_of_birth` | DateOfBirth | DateTime? | `datetime2` | Sí | — | |
| `location` | Location | string? | `nvarchar(200)` | Sí | — | |
| `phone_number` | PhoneNumber | string? | `nvarchar(20)` | Sí | — | |
| `linkedin_profile` | LinkedInProfile | string? | `nvarchar(200)` | Sí | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_verified` | IsVerified | bool | `bit` | No | `false` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**Relaciones:**
- `UserResourceViews` → `ncp_user_resource_view` (1:N)
- `AssessmentAttempts` → `ncp_assessment_attempt` (1:N)
- `RefreshTokens` → `ncp_refresh_token` (1:N)
- `EmailVerificationTokens` → `ncp_email_verification_token` (1:N)
- `UserLearningContexts` → `ncp_user_learning_context` (1:N)
- `ResourceLikes` → `ncp_resource_like` (1:N)
- `UserLeaderboard` → `ncp_user_leaderboard` (1:1)

---

## 2. `ncp_refresh_token` — Tokens de Refresco

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `user_id` | UserId | int | `int` | No | — | FK → `ncp_user.id` |
| `token` | Token | string | `nvarchar(500)` | No | — | **UQ** `IX_ncp_refresh_token_token` |
| `device_info` | DeviceInfo | string | `nvarchar(500)` | No | — | |
| `ip_address` | IpAddress | string | `nvarchar(45)` | No | — | |
| `expires_at` | ExpiresAt | DateTime | `datetime2` | No | — | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | — | |
| `revoked` | Revoked | bool | `bit` | No | `false` | |
| `revoked_at` | RevokedAt | DateTime? | `datetime2` | Sí | — | |

**FK:** `fk_refresh_token_user` → `ncp_user(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_refresh_token_user_id`

---

## 3. `ncp_email_verification_token` — Tokens de Verificación de Email

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `user_id` | UserId | int | `int` | No | — | FK → `ncp_user.id` |
| `token_hash` | TokenHash | string | `nvarchar(500)` | No | — | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | — | |
| `expires_at` | ExpiresAt | DateTime | `datetime2` | No | — | |
| `is_used` | IsUsed | bool | `bit` | No | `false` | |
| `used_at` | UsedAt | DateTime? | `datetime2` | Sí | — | |

**FK:** `fk_email_verification_token_user` → `ncp_user(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_email_verification_token_user_id`

---

## 4. `ncp_modality` — Modalidades

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_modality_code` |
| `name` | Name | string | `nvarchar(max)` | No | — | |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_modality_slug` |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**Relaciones:** `Levels` → `ncp_level` (1:N)

---

## 5. `ncp_level` — Niveles / Grados

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_level_code` |
| `name` | Name | string | `nvarchar(100)` | No | — | |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_level_slug` |
| `modality_id` | ModalityId | int | `int` | No | — | FK → `ncp_modality.id` |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_level_modality` → `ncp_modality(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_level_modality_id`  
**Relaciones:** `Modality` (N:1), `EducationContexts` → `ncp_education_context` (1:N)

---

## 6. `ncp_specialization` — Especializaciones

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_specialization_code` |
| `name` | Name | string | `nvarchar(max)` | No | — | |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_specialization_slug` |
| `Description` | Description | string | `nvarchar(max)` | Sí | — | PascalCase en BD |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**Relaciones:** `EducationContexts` → `ncp_education_context` (1:N)

---

## 7. `ncp_education_context` — Contextos Educativos

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `level_id` | LevelId | int | `int` | No | — | FK → `ncp_level.id` |
| `specialization_id` | SpecializationId | int | `int` | No | — | FK → `ncp_specialization.id` |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:**
- `fk_education_context_level` → `ncp_level(id)` ON DELETE CASCADE
- `fk_education_context_specialization` → `ncp_specialization(id)` ON DELETE CASCADE

**Índices:**
- **UQ** `IX_ncp_education_context_level_id_specialization_id` en `(level_id, specialization_id)`
- `IX_ncp_education_context_specialization_id`

**Relaciones:** `Level` (N:1), `Specialization` (N:1), `SyllabusContexts` → `ncp_syllabus_context` (1:N)

---

## 8. `ncp_competence` — Competencias

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | |
| `name` | Name | string | `nvarchar(255)` | No | — | |
| `description` | Description | string | `nvarchar(max)` | No | — | |
| `effect_year` | EffectYear | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**Relaciones:**
- `CompetenceLevels` → `ncp_competence_level` (1:N)
- `Abilities` → `ncp_ability` (1:N)
- `SubTopics` → `ncp_sub_topic` (1:N)

---

## 9. `ncp_ability` — Habilidades

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_ability_code` |
| `name` | Name | string | `nvarchar(255)` | No | — | |
| `description` | Description | string? | `nvarchar(max)` | Sí | — | |
| `competence_id` | CompetenceId | int | `int` | No | — | FK → `ncp_competence.id` |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_ability_competence` → `ncp_competence(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_ability_competence_id`  
**Relaciones:** `Competence` (N:1)

---

## 10. `ncp_competence_level` — Niveles de Competencia

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `competence_id` | CompetenceId | int | `int` | No | — | FK → `ncp_competence.id` |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_competence_level_code` |
| `level_number` | LevelNumber | int | `int` | No | — | |
| `description` | Description | string? | `nvarchar(max)` | Sí | — | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_competence_level_competence` → `ncp_competence(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_competence_level_competence_id`  
**Relaciones:** `Competence` (N:1)

---

## 11. `ncp_syllabus` — Sílabos

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_syllabus_code` |
| `slug` | Slug | string | `nvarchar(30)` | No | — | **UQ** `IX_ncp_syllabus_slug` |
| `name` | Name | string | `nvarchar(max)` | No | — | |
| `Description` | Description | string | `nvarchar(max)` | No | — | PascalCase en BD |
| `effect_year` | EffectYear | int | `int` | No | — | |
| `min_competence_level` | MinCompetenceLevel | int | `int` | No | — | |
| `max_competence_level` | MaxCompetencLevel | int | `int` | No | — | Typo en propiedad |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**Relaciones:**
- `SyllabusContexts` → `ncp_syllabus_context` (1:N)
- `UserLearningContexts` → `ncp_user_learning_context` (1:N)
- `SyllabusUnits` → `ncp_syllabus_unit` (1:N)

---

## 12. `ncp_syllabus_unit` — Unidades / Módulos

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_syllabus_unit_code` |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_syllabus_unit_slug` |
| `syllabus_id` | SyllabusId | int | `int` | No | — | FK → `ncp_syllabus.id` |
| `name` | Name | string | `nvarchar(100)` | No | — | |
| `description` | Description | string? | `nvarchar(200)` | Sí | — | |
| `order_index` | OrderIndex | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_syllabus_unit_syllabus` → `ncp_syllabus(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_syllabus_unit_syllabus_id`  
**Relaciones:** `Syllabus` (N:1), `Topics` → `ncp_topic` (1:N), `UserSyllabusUnitProgresses` → `ncp_user_syllabus_unit_progress` (1:N)

---

## 13. `ncp_topic` — Temas

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_topic_code` |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_topic_slug` |
| `syllabus_unit_id` | SyllabusUnitId | int | `int` | No | — | FK → `ncp_syllabus_unit.id` |
| `description` | Description | string | `nvarchar(max)` | No | — | |
| `order_index` | OrderIndex | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_topic_syllabus_unit` → `ncp_syllabus_unit(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_topic_syllabus_unit_id`  
**Relaciones:** `SyllabusUnit` (N:1), `SubTopics` → `ncp_sub_topic` (1:N)

---

## 14. `ncp_sub_topic` — Subtemas

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `topic_id` | TopicId | int | `int` | No | — | FK → `ncp_topic.id` |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_sub_topic_code` |
| `slug` | Slug | string | `nvarchar(100)` | No | — | **UQ** `IX_ncp_sub_topic_slug` |
| `description` | Description | string | `nvarchar(max)` | No | — | |
| `order_index` | OrderIndex | int | `int` | No | — | |
| `CompetenceId` | CompetenceId | int? | `int` | Sí | — | FK → `ncp_competence.id` |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:**
- `fk_sub_topic_topic` → `ncp_topic(id)` ON DELETE CASCADE
- `fk_sub_topic_competence` → `ncp_competence(id)` ON DELETE NO ACTION

**Índices:** `IX_ncp_sub_topic_topic_id`, `IX_ncp_sub_topic_CompetenceId`  
**Relaciones:** `Topic` (N:1), `Competence` (N:1, nullable), `MicroTopics` → `ncp_micro_topic` (1:N), `Questions` → `ncp_question` (1:N), `Resources` → `ncp_resource` (1:N), `UserSubTopicViews` → `ncp_user_sub_topic_view` (1:N)

---

## 15. `ncp_micro_topic` — Microtemas

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `sub_topic_id` | SubTopicId | int | `int` | No | — | FK → `ncp_sub_topic.id` |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_micro_topic_code` |
| `slug` | Slug | string | `nvarchar(200)` | No | — | **UQ** `IX_ncp_micro_topic_slug` |
| `description` | Description | string | `nvarchar(max)` | No | — | |
| `order_index` | OrderIndex | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_micro_topic_sub_topic` → `ncp_sub_topic(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_micro_topic_sub_topic_id`  
**Relaciones:** `SubTopic` (N:1)

---

## 16. `ncp_syllabus_context` — Asignación Sílabo ↔ Contexto (M:N)

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `syllabus_id` | SyllabusId | int | `int` | No | — | PK compuesta, FK → `ncp_syllabus.id` |
| `education_context_id` | EducationContextId | int | `int` | No | — | PK compuesta, FK → `ncp_education_context.id` |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**PK:** `(syllabus_id, education_context_id)`  
**FK:**
- `fk_syllabus_context_syllabus` → `ncp_syllabus(id)` ON DELETE CASCADE
- `fk_syllabus_context_education_context` → `ncp_education_context(id)` ON DELETE CASCADE

**Índices:** `IX_ncp_syllabus_context_education_context_id`

---

## 17. `ncp_assessment` — Evaluaciones

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_assessment_code` |
| `title` | Title | string | `nvarchar(100)` | No | — | |
| `type` | Type | enum | `int` | No | — | 0=KNOLEDGE, 1=GENERAL_SKILLS |
| `scope` | Scope | enum | `int` | No | — | 0=UNIT, 1=SYLLABUS, 2=SIMULATION |
| `target_id` | TargetId | int? | `int` | Sí | — | FK polimórfica (SyllabusUnitId o SyllabusId) |
| `time_limit_seconds` | TimeLimitSeconds | int? | `int` | Sí | — | |
| `number_questions` | NumberQuestions | int | `int` | No | — | |
| `max_attempts` | MaxAttempts | int? | `int` | Sí | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |

**Índices:** `IX_ncp_assessment_scope_target_id` en `(scope, target_id)`  
**Relaciones:** `AssessmentAttempts` → `ncp_assessment_attempt` (1:N)

---

## 18. `ncp_assessment_attempt` — Intentos de Evaluación

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `assessment_id` | AssessmentId | int | `int` | No | — | FK → `ncp_assessment.id` |
| `user_learning_context_id` | UserLearningContextId | int | `int` | No | — | FK → `ncp_user_learning_context.id` |
| `started_at` | StartedAt | DateTime | `datetime2` | No | — | |
| `finished_at` | FinishedAt | DateTime | `datetime2` | No | — | |
| `score` | Score | int | `int` | No | — | |
| `total_questions` | TotalQuestions | int | `int` | No | — | |
| `correct_answers` | CorrectAnswers | int | `int` | No | — | |
| `stars_earned` | StarsEarned | int | `int` | No | `0` | |

**FK:**
- `fk_assessment_attempt_assessment` → `ncp_assessment(id)` ON DELETE CASCADE
- `fk_assessment_attempt_user_learning_context` → `ncp_user_learning_context(id)` ON DELETE CASCADE

**Índices:** `IX_ncp_assessment_attempt_assessment_id`, `IX_ncp_assessment_attempt_user_learning_context_id`  
**Relaciones:** `Assessment` (N:1), `UserLearningContext` (N:1), `AssessmentAttemptQuestions` → `ncp_assessment_attempt_question` (1:N)

---

## 19. `ncp_assessment_attempt_question` — Preguntas del Intento

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `assessment_attempt_id` | AssessmentAttemptId | int | `int` | No | — | FK → `ncp_assessment_attempt.id` |
| `question_id` | QuestionId | int | `int` | No | — | FK → `ncp_question.id` |
| `selected_option_id` | SelectedOptionId | int? | `int` | Sí | — | FK → `ncp_option.id` |
| `answered_at` | AnsweredAt | DateTime | `datetime2` | No | — | |
| `seconds_spent` | SecondsSpent | int | `int` | No | — | |
| `order_index` | OrderIndex | int | `int` | No | — | |

**FK:**
- `fk_assessment_attempt_question_assessment_attempt` → `ncp_assessment_attempt(id)` ON DELETE CASCADE
- `fk_assessment_attempt_question_question` → `ncp_question(id)` ON DELETE RESTRICT
- `fk_assessment_attempt_question_selected_option` → `ncp_option(id)` ON DELETE CASCADE

**Índices:**
- **UQ** `IX_ncp_assessment_attempt_question_assessment_attempt_id_question_id` en `(assessment_attempt_id, question_id)`
- `IX_ncp_assessment_attempt_question_question_id`
- `IX_ncp_assessment_attempt_question_selected_option_id`

**Relaciones:** `AssessmentAttempt` (N:1), `Question` (N:1), `SelectedOption` → `Option` (N:1)

---

## 20. `ncp_question` — Preguntas

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_question_code` |
| `explanation` | Explanation | string? | `nvarchar(max)` | Sí | — | |
| `sub_topic_id` | SubTopicId | int | `int` | No | — | FK → `ncp_sub_topic.id` |
| `total_attempts` | TotalAttempts | int | `int` | No | — | |
| `total_correct` | TotalCorrect | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_question_sub_topic` → `ncp_sub_topic(id)` ON DELETE RESTRICT  
**Índices:** `IX_ncp_question_sub_topic_id`  
**Relaciones:** `SubTopic` (N:1), `Options` → `ncp_option` (1:N), `QuestionContentBlocks` → `ncp_question_content_block` (1:N), `AssessmentAttemptQuestions` → `ncp_assessment_attempt_question` (1:N)

---

## 21. `ncp_question_content_block` — Bloques de Contenido de Pregunta

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `code` | Code | string | `nvarchar(50)` | No | — | **UQ** `IX_ncp_question_content_block_code` |
| `content` | Content | string | `nvarchar(max)` | No | — | |
| `question_id` | QuestionId | int | `int` | No | — | FK → `ncp_question.id` |
| `type` | Type | enum | `int` | No | — | 1=Text, 2=Context, 3=Image |
| `order_index` | OrderIndex | int | `int` | No | — | |

**FK:** `fk_question_content_block_question` → `ncp_question(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_question_content_block_question_id`  
**Relaciones:** `Question` (N:1)

---

## 22. `ncp_option` — Opciones de Respuesta

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `question_id` | QuestionId | int | `int` | No | — | FK → `ncp_question.id` |
| `label` | Label | string | `nvarchar(10)` | No | — | |
| `is_correct` | IsCorrect | bool | `bit` | No | — | |

**FK:** `fk_option_question` → `ncp_question(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_option_question_id`  
**Relaciones:** `Question` (N:1), `AssessmentAttemptQuestions` (1:N como SelectedOption), `OptionBlocks` → `ncp_option_block` (1:N)

---

## 23. `ncp_option_block` — Bloques de Contenido de Opción

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `option_id` | OptionId | int | `int` | No | — | FK → `ncp_option.id` |
| `content` | Content | string | `nvarchar(max)` | No | — | |
| `type` | Type | enum | `int` | No | — | 1=Text, 2=Context, 3=Image |
| `order_index` | OrderIndex | int | `int` | No | — | |

**FK:** `fk_option_block_option` → `ncp_option(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_option_block_option_id`  
**Relaciones:** `Option` (N:1)

---

## 24. `ncp_resource` — Recursos

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `title` | Title | string | `nvarchar(200)` | No | — | |
| `url` | Url | string | `nvarchar(max)` | No | — | |
| `description` | Description | string? | `nvarchar(1000)` | Sí | — | |
| `sub_topic_id` | SubTopicId | int? | `int` | Sí | — | FK → `ncp_sub_topic.id` |
| `public_score` | PublicScore | int | `int` | No | — | |
| `views_count` | ViewsCount | int | `int` | No | — | |
| `likes_count` | LikesCount | int | `int` | No | — | |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `CreatedAt` | CreatedAt | DateTime | `datetime2` | No | — | PascalCase en BD |
| `CreatedBy` | CreatedBy | int | `int` | No | — | |
| `UpdatedAt` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `UpdatedBy` | UpdatedBy | int? | `int` | Sí | — | |
| `DeletedAt` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `DeletedBy` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_resource_sub_topic` → `ncp_sub_topic(id)` ON DELETE CASCADE  
**Índices:** `IX_ncp_resource_sub_topic_id`  
**Relaciones:** `SubTopic` (N:1, nullable), `UserResourceViews` → `ncp_user_resource_view` (1:N), `ResourceLikes` → `ncp_resource_like` (1:N)

---

## 25. `ncp_resource_like` — Likes a Recursos (M:N)

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `resource_id` | ResourceId | int | `int` | No | — | PK compuesta, FK → `ncp_resource.id` |
| `user_id` | UserId | int | `int` | No | — | PK compuesta, FK → `ncp_user.id` |

**PK:** `(resource_id, user_id)`  
**FK:**
- `fk_resource_like_resource` → `ncp_resource(id)` ON DELETE CASCADE
- `fk_resource_like_user` → `ncp_user(id)` ON DELETE CASCADE

**Índices:** `IX_ncp_resource_like_user_id`

---

## 26. `ncp_user_resource_view` — Vistas de Recurso (M:N)

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `user_id` | UserId | int | `int` | No | — | PK compuesta, FK → `ncp_user.id` |
| `resource_id` | ResourceId | int | `int` | No | — | PK compuesta, FK → `ncp_resource.id` |
| `viewed_at` | ViewedAt | DateTime | `datetime2` | No | — | |

**PK:** `(user_id, resource_id)`  
**FK:**
- `fk_user_resource_view_user` → `ncp_user(id)` ON DELETE CASCADE
- `fk_user_resource_view_resource` → `ncp_resource(id)` ON DELETE CASCADE

**Índices:** `IX_ncp_user_resource_view_resource_id`

---

## 27. `ncp_user_learning_context` — Contexto de Aprendizaje del Usuario

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `user_id` | UserId | int | `int` | No | — | FK → `ncp_user.id` |
| `syllabus_id` | SyllabusId | int | `int` | No | — | FK → `ncp_syllabus.id` |
| `is_active` | IsActive | bool | `bit` | No | `true` | |
| `is_deleted` | IsDeleted | bool | `bit` | No | `false` | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:**
- `fk_user_learning_context_user` → `ncp_user(id)` ON DELETE CASCADE
- `fk_user_learning_context_syllabus` → `ncp_syllabus(id)` ON DELETE CASCADE

**Índices:** `IX_ncp_user_learning_context_user_id`, `IX_ncp_user_learning_context_syllabus_id`  
**Relaciones:** `User` (N:1), `Syllabus` (N:1), `UserSyllabusProgress` → `ncp_user_syllabus_progress` (1:1), `AssessmentAttempts` → `ncp_assessment_attempt` (1:N)

---

## 28. `ncp_user_syllabus_progress` — Progreso del Usuario en Sílabo

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `user_learning_context_id` | UserLearningContextId | int | `int` | No | — | **UQ**, FK → `ncp_user_learning_context.id` |
| `last_access` | LastAccess | DateTime | `datetime2` | No | — | |
| `status` | Status | enum | `int` | No | — | 1=IN_PROGRESS, 2=COMPLETED |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:** `fk_user_syllabus_progress_user_learning_context` → `ncp_user_learning_context(id)` ON DELETE NO ACTION  
**Índice:** **UQ** `IX_ncp_user_syllabus_progress_user_learning_context_id`  
**Relaciones:** `UserLearningContext` (1:1), `UserSyllabusUnitProgresses` → `ncp_user_syllabus_unit_progress` (1:N)

---

## 29. `ncp_user_syllabus_unit_progress` — Progreso del Usuario en Unidad

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `id` | Id | int | `int` | No | Identity(1,1) | PK |
| `user_syllabus_progress_id` | UserSyllabusProgressId | int | `int` | No | — | FK → `ncp_user_syllabus_progress.id` |
| `syllabus_unit_id` | SyllabusUnitId | int | `int` | No | — | FK → `ncp_syllabus_unit.id` |
| `status` | Status | enum | `int` | No | — | 1=LOCKED, 2=IN_PROGRESS, 3=APPROVED |
| `total_questions` | TotalQuestions | int | `int` | No | — | |
| `total_correct` | TotalCorrect | int | `int` | No | — | |
| `attempts` | Attempts | int | `int` | No | — | |
| `last_attempt_at` | LastAttemptAt | DateTime | `datetime2` | No | — | |
| `created_at` | CreatedAt | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |
| `created_by` | CreatedBy | int | `int` | No | `1` | |
| `updated_at` | UpdatedAt | DateTime? | `datetime2` | Sí | — | |
| `updated_by` | UpdatedBy | int? | `int` | Sí | — | |
| `deleted_at` | DeletedAt | DateTime? | `datetime2` | Sí | — | |
| `deleted_by` | DeletedBy | int? | `int` | Sí | — | |

**FK:**
- `fk_user_syllabus_unit_progress_user_syllabus_progress` → `ncp_user_syllabus_progress(id)` ON DELETE CASCADE
- `fk_user_syllabus_unit_progress_syllabus_unit` → `ncp_syllabus_unit(id)` ON DELETE CASCADE

**Índices:**
- **UQ** `IX_ncp_user_syllabus_unit_progress_user_syllabus_progress_id_syllabus_unit_id` en `(user_syllabus_progress_id, syllabus_unit_id)`
- `IX_ncp_user_syllabus_unit_progress_syllabus_unit_id`

**Relaciones:** `SyllabusUnit` (N:1), `UserSyllabusProgress` (N:1), `UserSubTopicViews` → `ncp_user_sub_topic_view` (1:N)

---

## 30. `ncp_user_sub_topic_view` — Vistas de Subtema por Usuario

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `user_syllabus_unit_progress_id` | UserSyllabusUnitProgressId | int | `int` | No | — | PK compuesta, FK → `ncp_user_syllabus_unit_progress.id` |
| `sub_topic_id` | SubTopicId | int | `int` | No | — | PK compuesta, FK → `ncp_sub_topic.id` |
| `is_viewed` | IsViewed | bool | `bit` | No | `false` | |
| `viewed_at` | ViewedAt | DateTime? | `datetime2` | Sí | — | |

**PK:** `(user_syllabus_unit_progress_id, sub_topic_id)`  
**FK:**
- `fk_user_sub_topic_view_unit_progress` → `ncp_user_syllabus_unit_progress(id)` ON DELETE CASCADE
- `fk_user_sub_topic_view_sub_topic` → `ncp_sub_topic(id)` ON DELETE NO ACTION

**Índices:** `IX_ncp_user_sub_topic_view_sub_topic_id`

---

## 31. `ncp_user_leaderboard` — Leaderboard del Usuario (1:1)

| Columna | Propiedad C# | Tipo C# | Tipo SQL | Nulo | Defecto | Restricciones |
|---------|-------------|---------|----------|------|---------|---------------|
| `user_id` | UserId | int | `int` | No | — | PK, FK → `ncp_user.id` (ValueGeneratedNever) |
| `total_stars` | TotalStars | int | `int` | No | `0` | |
| `last_updated` | LastUpdated | DateTime | `datetime2` | No | `CURRENT_TIMESTAMP` | |

**FK:** `fk_user_leaderboard_user` → `ncp_user(id)` ON DELETE CASCADE

---

## Resumen de Relaciones (Foreign Keys)

| # | Tabla FK | Columna FK | Tabla Ref. | Columna Ref. | Delete Rule |
|---|----------|-----------|------------|-------------|-------------|
| 1 | `ncp_refresh_token` | `user_id` | `ncp_user` | `id` | CASCADE |
| 2 | `ncp_email_verification_token` | `user_id` | `ncp_user` | `id` | CASCADE |
| 3 | `ncp_level` | `modality_id` | `ncp_modality` | `id` | CASCADE |
| 4 | `ncp_education_context` | `level_id` | `ncp_level` | `id` | CASCADE |
| 5 | `ncp_education_context` | `specialization_id` | `ncp_specialization` | `id` | CASCADE |
| 6 | `ncp_ability` | `competence_id` | `ncp_competence` | `id` | CASCADE |
| 7 | `ncp_competence_level` | `competence_id` | `ncp_competence` | `id` | CASCADE |
| 8 | `ncp_sub_topic` | `CompetenceId` | `ncp_competence` | `id` | NO ACTION |
| 9 | `ncp_sub_topic` | `topic_id` | `ncp_topic` | `id` | CASCADE |
| 10 | `ncp_syllabus_unit` | `syllabus_id` | `ncp_syllabus` | `id` | CASCADE |
| 11 | `ncp_topic` | `syllabus_unit_id` | `ncp_syllabus_unit` | `id` | CASCADE |
| 12 | `ncp_micro_topic` | `sub_topic_id` | `ncp_sub_topic` | `id` | CASCADE |
| 13 | `ncp_syllabus_context` | `syllabus_id` | `ncp_syllabus` | `id` | CASCADE |
| 14 | `ncp_syllabus_context` | `education_context_id` | `ncp_education_context` | `id` | CASCADE |
| 15 | `ncp_question` | `sub_topic_id` | `ncp_sub_topic` | `id` | RESTRICT |
| 16 | `ncp_question_content_block` | `question_id` | `ncp_question` | `id` | CASCADE |
| 17 | `ncp_option` | `question_id` | `ncp_question` | `id` | CASCADE |
| 18 | `ncp_option_block` | `option_id` | `ncp_option` | `id` | CASCADE |
| 19 | `ncp_resource` | `sub_topic_id` | `ncp_sub_topic` | `id` | CASCADE |
| 20 | `ncp_resource_like` | `resource_id` | `ncp_resource` | `id` | CASCADE |
| 21 | `ncp_resource_like` | `user_id` | `ncp_user` | `id` | CASCADE |
| 22 | `ncp_user_resource_view` | `user_id` | `ncp_user` | `id` | CASCADE |
| 23 | `ncp_user_resource_view` | `resource_id` | `ncp_resource` | `id` | CASCADE |
| 24 | `ncp_user_learning_context` | `user_id` | `ncp_user` | `id` | CASCADE |
| 25 | `ncp_user_learning_context` | `syllabus_id` | `ncp_syllabus` | `id` | CASCADE |
| 26 | `ncp_user_syllabus_progress` | `user_learning_context_id` | `ncp_user_learning_context` | `id` | NO ACTION |
| 27 | `ncp_user_syllabus_unit_progress` | `user_syllabus_progress_id` | `ncp_user_syllabus_progress` | `id` | CASCADE |
| 28 | `ncp_user_syllabus_unit_progress` | `syllabus_unit_id` | `ncp_syllabus_unit` | `id` | CASCADE |
| 29 | `ncp_user_sub_topic_view` | `user_syllabus_unit_progress_id` | `ncp_user_syllabus_unit_progress` | `id` | CASCADE |
| 30 | `ncp_user_sub_topic_view` | `sub_topic_id` | `ncp_sub_topic` | `id` | NO ACTION |
| 31 | `ncp_assessment_attempt` | `assessment_id` | `ncp_assessment` | `id` | CASCADE |
| 32 | `ncp_assessment_attempt` | `user_learning_context_id` | `ncp_user_learning_context` | `id` | CASCADE |
| 33 | `ncp_assessment_attempt_question` | `assessment_attempt_id` | `ncp_assessment_attempt` | `id` | CASCADE |
| 34 | `ncp_assessment_attempt_question` | `question_id` | `ncp_question` | `id` | RESTRICT |
| 35 | `ncp_assessment_attempt_question` | `selected_option_id` | `ncp_option` | `id` | CASCADE |
| 36 | `ncp_user_leaderboard` | `user_id` | `ncp_user` | `id` | CASCADE |

---

## Relaciones 1:1

1. **Usuario ↔ Leaderboard:** `ncp_user_leaderboard.user_id` = `ncp_user.id`
2. **UserLearningContext ↔ UserSyllabusProgress:** `ncp_user_syllabus_progress.user_learning_context_id` único

---

## Claves Primarias Compuestas

1. `ncp_syllabus_context` → `(syllabus_id, education_context_id)`
2. `ncp_resource_like` → `(resource_id, user_id)`
3. `ncp_user_resource_view` → `(user_id, resource_id)`
4. `ncp_user_sub_topic_view` → `(user_syllabus_unit_progress_id, sub_topic_id)`
5. `ncp_user_leaderboard` → `(user_id)` (sin auto-incremento)

---

## Referencia de Enums

| Enum | Valores | Almacenamiento |
|------|---------|----------------|
| `UserRole` | `USER`, `ADMIN` | `nvarchar(max)` (string) |
| `UserProgressStatus` | `IN_PROGRESS=1`, `COMPLETED=2` | `int` |
| `UserModuleProgressStatus` | `LOCKED=1`, `IN_PROGRESS=2`, `APPROVED=3` | `int` |
| `AssessmentType` | `KNOLEDGE=0`, `GENERAL_SKILLS=1` | `int` |
| `AssessmentScope` | `UNIT=0`, `SYLLABUS=1`, `SIMULATION=2` | `int` |
| `ContentBlockType` | `Text=1`, `Context=2`, `Image=3` | `int` |

---

## Notas / Hallazgos

1. **Typo en propiedad:** `Syllabus.MaxCompetencLevel` debería ser `MaxCompetenceLevel`
2. **Typo en enum:** `AssessmentType.KNOLEDGE` debería ser `KNOWLEDGE`
3. **Columna fantasma:** `ncp_assessment_attempt` tiene columna `UserId` en migración pero no existe en la entidad
4. **Inconsistencia delete:** Algunas configs dicen `Restrict` pero migración genera `CASCADE`
5. **PascalCase en BD:** `ncp_specialization.Description`, `ncp_syllabus.Description`, `ncp_resource.CreatedAt` usan PascalCase en lugar de snake_case
6. **Naming confuso en DbContext:** `Topics` y `SubTopics` ambos mapean a la entidad `SubTopic`

DECLARE @sysadminId INT = (SELECT id FROM ncp_user WHERE code = 'SYSA-676767');


UPDATE ncp_user
SET 
    [is_verified] = 1,
    [user_role] = 'ADMIN',
    [updated_at] = GETDATE(),
    [updated_by] = 1
WHERE [id] = @sysadminId;

-- Modalidades
IF NOT EXISTS (SELECT 1 FROM ncp_modality WHERE [code] = 'EBR')
BEGIN
    INSERT INTO ncp_modality([code], [name], [slug], [created_by])
    VALUES ('EBR', 'Educación Básica Regular', 'ebr', @sysadminId);
END;

IF NOT EXISTS (SELECT 1 FROM ncp_modality WHERE [code] = 'EBA')
BEGIN
    INSERT INTO ncp_modality([code], [name], [slug], [created_by])
    VALUES ('EBA', 'Educación Básica Alternativa', 'eba', @sysadminId);
END;

IF NOT EXISTS (SELECT 1 FROM ncp_modality WHERE [code] = 'EBE')
BEGIN
    INSERT INTO ncp_modality([code], [name], [slug], [created_by])
    VALUES ('EBE', 'Educación Básica Especial', 'ebe', @sysadminId);
END;

-- Levels
IF NOT EXISTS (SELECT 1 FROM ncp_level WHERE [code] = 'EBR-INIC')
BEGIN
    INSERT INTO ncp_level([code], [name], [modality_id], [slug], [created_by])
    VALUES ('EBR-INIC', 'Inicial', (SELECT id FROM ncp_modality WHERE [code] = 'EBR'), 'ebr-inicial', @sysadminId)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_level WHERE [code] = 'EBR-CUNA')
BEGIN
    INSERT INTO ncp_level([code], [name], [modality_id], [slug], [created_by])
    VALUES ('EBR-CUNA', 'Cuna', (SELECT id FROM ncp_modality WHERE [code] = 'EBR'), 'ebr-cuna', @sysadminId)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_level WHERE [code] = 'EBR-PRON')
BEGIN
    INSERT INTO ncp_level([code], [name], [modality_id], [slug], [created_by])
    VALUES ('EBR-PRON', 'PRONOEI', (SELECT id FROM ncp_modality WHERE [code] = 'EBR'), 'ebr-pronoei', @sysadminId)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_level WHERE [code] = 'EBR-PRIM')
BEGIN
    INSERT INTO ncp_level([code], [name], [modality_id], [slug], [created_by])
    VALUES ('EBR-PRIM', 'Primaria', (SELECT id FROM ncp_modality WHERE [code] = 'EBR'), 'ebr-primaria', @sysadminId)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_level WHERE [code] = 'EBR-SECU')
BEGIN
    INSERT INTO ncp_level([code], [name], [modality_id], [slug], [created_by])
    VALUES ('EBR-SECU', 'Secundaria', (SELECT id FROM ncp_modality WHERE [code] = 'EBR'), 'ebr-secundaria', @sysadminId)
END;

-- Specialization

IF NOT EXISTS (SELECT 1 FROM ncp_specialization WHERE [code] = 'GENEN')
BEGIN
    INSERT INTO ncp_specialization([code], [name], [slug], [created_by])
    VALUES ('GENEN', 'GENERAL','general', @sysadminId)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_specialization WHERE [code] = 'CYT')
BEGIN
    INSERT INTO ncp_specialization([code], [name], [slug], [created_by])
    VALUES ('CYT', 'Ciencia y Tecnología','ciencia-y-tecnologia', @sysadminId)
END;

-- Education Context

IF NOT EXISTS (SELECT 1 FROM ncp_education_context WHERE [level_id] = (SELECT id FROM ncp_level WHERE [code] = 'EBR-INIC') AND [specialization_id] = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'))
BEGIN
    INSERT INTO ncp_education_context([level_id], [specialization_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_level WHERE [code] = 'EBR-INIC'),
        (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_education_context WHERE [level_id] = (SELECT id FROM ncp_level WHERE [code] = 'EBR-CUNA') AND [specialization_id] = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'))
BEGIN
    INSERT INTO ncp_education_context([level_id], [specialization_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_level WHERE [code] = 'EBR-CUNA'),
        (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_education_context WHERE [level_id] = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRON') AND [specialization_id] = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'))
BEGIN
    INSERT INTO ncp_education_context([level_id], [specialization_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRON'),
        (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_education_context WHERE [level_id] = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRIM') AND [specialization_id] = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'))
BEGIN
    INSERT INTO ncp_education_context([level_id], [specialization_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRIM'),
        (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN'),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_education_context WHERE [level_id] = (SELECT id FROM ncp_level WHERE [code] = 'EBR-SECU') AND [specialization_id] = (SELECT id FROM ncp_specialization WHERE [code] = 'CYT'))
BEGIN
    INSERT INTO ncp_education_context([level_id], [specialization_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_level WHERE [code] = 'EBR-SECU'),
        (SELECT id FROM ncp_specialization WHERE [code] = 'CYT'),
        @sysadminId
    )
END;

-- Syllabi

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026')
BEGIN
    INSERT INTO ncp_syllabus([code], [slug], [name], [description], [effect_year], [created_by], [min_competence_level], [max_competence_level])
    VALUES ('SYB-EBR-ICP-2026', 'ebr-cuna-inicial-pronoei', 'EBR - Cuna/Inicial/PRONOEI', '', 2026, @sysadminId, 1, 2)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus WHERE [code] = 'SYB-EBR-PRIMA-2026')
BEGIN
    INSERT INTO ncp_syllabus([code], [slug], [name], [description], [effect_year], [created_by], [min_competence_level], [max_competence_level])
    VALUES ('SYB-EBR-PRIMA-2026', 'ebr-primaria', 'EBR - Primaria', '', 2026, @sysadminId, 3, 5)
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus WHERE [code] = 'SYB-EBR-SEC-CYT-2026')
BEGIN
    INSERT INTO ncp_syllabus([code], [slug], [name], [description], [effect_year], [created_by], [min_competence_level], [max_competence_level])
    VALUES ('SYB-EBR-SEC-CYT-2026', 'ebr-secundaria-cyt', 'EBR - Secundaria - Ciencia y Tecnología', '', 2026, @sysadminId, 6, 8)
END;

-- Syllabi - Education Context

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus_context WHERE [syllabus_id] = (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026') AND [education_context_id] = (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-INIC') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')))
BEGIN
    INSERT INTO ncp_syllabus_context([syllabus_id],[education_context_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026'),
        (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-INIC') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus_context WHERE [syllabus_id] = (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026') AND [education_context_id] = (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-CUNA') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')))
BEGIN
    INSERT INTO ncp_syllabus_context([syllabus_id],[education_context_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026'),
        (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-CUNA') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus_context WHERE [syllabus_id] = (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026') AND [education_context_id] = (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRON') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')))
BEGIN
    INSERT INTO ncp_syllabus_context([syllabus_id],[education_context_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-ICP-2026'),
        (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRON') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus_context WHERE [syllabus_id] = (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-PRIMA-2026') AND [education_context_id] = (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRIM') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')))
BEGIN
    INSERT INTO ncp_syllabus_context([syllabus_id],[education_context_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-PRIMA-2026'),
        (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-PRIM') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'GENEN')),
        @sysadminId
    )
END;

IF NOT EXISTS (SELECT 1 FROM ncp_syllabus_context WHERE [syllabus_id] = (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-SEC-CYT-2026') AND [education_context_id] = (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-SECU') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'CYT')))
BEGIN
    INSERT INTO ncp_syllabus_context([syllabus_id],[education_context_id], [created_by])
    VALUES (
        (SELECT id FROM ncp_syllabus WHERE [code] = 'SYB-EBR-SEC-CYT-2026'),
        (SELECT id FROM ncp_education_context WHERE level_id = (SELECT id FROM ncp_level WHERE [code] = 'EBR-SECU') AND specialization_id = (SELECT id FROM ncp_specialization WHERE [code] = 'CYT')),
        @sysadminId
    )
END;

-----------------------------------------------------------------------



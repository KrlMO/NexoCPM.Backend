DECLARE @SyllabusEBRCIPId BIGINT;
SELECT @SyllabusEBRCIPId = id
FROM ncp_syllabus
WHERE [code] = 'SYB-EBR-ICP-2026';

IF @SyllabusEBRCIPId IS NOT NULL
BEGIN
	INSERT INTO ncp_syllabus_unit ([code], [slug], [syllabus_id], [name], [order_index])
	VALUES
		('UNIT-EBRCIP-U1', 'conocimientos-de-especialidad', @SyllabusEBRCIPId, 'CONOCIMIENTOS DE LA ESPECIALIDAD', 1),
		('UNIT-EBRCIP-U2', 'ciclo-i', @SyllabusEBRCIPId, 'CICLO I', 2),
		('UNIT-EBRCIP-U3', 'ciclo-ii', @SyllabusEBRCIPId, 'CICLO II', 3);
END;


DECLARE @SyllabusEBRPId BIGINT;
SELECT @SyllabusEBRPId = id
FROM ncp_syllabus
WHERE [code] = 'SYB-EBR-PRIMA-2026';

IF @SyllabusEBRPId IS NOT NULL
BEGIN
	INSERT INTO ncp_syllabus_unit ([code], [slug], [syllabus_id], [name], [order_index])
	VALUES
		('UNIT-EBRPRIM-U1', 'ciencia-y-tecnologia', @SyllabusEBRPId, 'CIENCIA Y TECNOLOGÍA', 1),
		('UNIT-EBRPRIM-U2', 'comunicacion', @SyllabusEBRPId, 'COMUNICACIÓN', 2),
		('UNIT-EBRPRIM-U3', 'matematica', @SyllabusEBRPId, 'MATEMÁTICA', 3),
		('UNIT-EBRPRIM-U4', 'personal-social', @SyllabusEBRPId, 'PERSONAL SOCIAL', 4);
END;


DECLARE @SyllabusEBRSCYTId BIGINT;
SELECT @SyllabusEBRSCYTId = id
FROM ncp_syllabus
WHERE [code] = 'SYB-EBR-SEC-CYT-2026';

IF @SyllabusEBRSCYTId IS NOT NULL
BEGIN
	INSERT INTO ncp_syllabus_unit ([code], [slug], [syllabus_id], [name], [order_index])
	VALUES
		('UNIT-EBRSCYT-U1', 'conocimiento-didactico-indagacion', @SyllabusEBRSCYTId, 'Conocimiento Didáctico (Indagación)', 1),
		('UNIT-EBRSCYT-U2', 'conocimiento-didactico-explicacion', @SyllabusEBRSCYTId, 'Conocimiento Didáctico (Explicación)', 2),
		('UNIT-EBRSCYT-U3', 'conocimiento-didactico-diseño', @SyllabusEBRSCYTId, 'Conocimiento Didáctico (Diseño)', 3);
END;


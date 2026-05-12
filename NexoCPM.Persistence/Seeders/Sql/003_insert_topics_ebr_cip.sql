DECLARE @UnitEBRCIPU1Id BIGINT;
SELECT @UnitEBRCIPU1Id = id
FROM ncp_syllabus_unit
WHERE [code] = 'UNIT-EBRCIP-U1';

IF @UnitEBRCIPU1Id IS NOT NULL
BEGIN
	INSERT INTO ncp_topic ([code], [syllabus_unit_id], [slug], [description], [order_index])
	VALUES
		('TOP-EBRCIP-U1-T1',@UnitEBRCIPU1Id, 'principios', 'Principios', 1);
END;


DECLARE @UnitEBRCIPU2Id BIGINT;
SELECT @UnitEBRCIPU2Id = id
FROM ncp_syllabus_unit
WHERE [code] = 'UNIT-EBRCIP-U2';

IF @UnitEBRCIPU2Id IS NOT NULL
BEGIN
	INSERT INTO ncp_topic ([code], [syllabus_unit_id], [slug], [description], [order_index])
	VALUES
		('TOP-EBRCIP-U2-T1',@UnitEBRCIPU2Id, 'conocimientos-pedagogicos-niños-menores-3', 'Conocimientos pedagógicos y disciplinares para favorecer el desarrollo de competencias vinculadas a niños menores de tres años', 1);
END


DECLARE @UnitEBRCIPU3Id BIGINT;
SELECT @UnitEBRCIPU3Id = id
FROM ncp_syllabus_unit
WHERE [code] = 'UNIT-EBRCIP-U3';

IF @UnitEBRCIPU3Id IS NOT NULL
BEGIN
	INSERT INTO ncp_topic ([code], [syllabus_unit_id], [slug], [description], [order_index])
	VALUES
		('TOP-EBRCIP-U3-T1',@UnitEBRCIPU3Id, 'conocimientos-pedagogicos-personal-social', 'Conocimientos pedagógicos y disciplinares para favorecer el desarrollo de competencias vinculadas al área de Personal Social', 1),
		('TOP-EBRCIP-U3-T2',@UnitEBRCIPU3Id, 'conocimientos-pedagogicos-comunicacion', 'Conocimientos pedagógicos y disciplinares para favorecer el desarrollo de competencias vinculadas al área de Comunicación', 2),
		('TOP-EBRCIP-U3-T3',@UnitEBRCIPU3Id, 'conocimientos-pedagogicos-ciencia-y-tecnologia', 'Conocimientos pedagógicos y disciplinares para favorecer el desarrollo de competencias vinculadas al área de Ciencia y Tecnología', 3),
		('TOP-EBRCIP-U3-T4',@UnitEBRCIPU3Id, 'conocimientos-pedagogicos-matematica', 'Conocimientos pedagógicos y disciplinares para favorecer el desarrollo de competencias vinculadas al área de Matemática', 4);
END;
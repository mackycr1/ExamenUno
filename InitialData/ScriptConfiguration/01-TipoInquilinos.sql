 DROP TABLE IF EXISTS #TipoInquilinosTemp

SELECT   Id_TipoInquilino
		,Descripcion
		,Estado
INTO #TipoInquilinosTemp
FROM
(
	VALUES
	(1, 'Fisico', 1),
	(2, 'Juridico', 1)
) AS TEMP (Id_TipoInquilino, Descripcion, Estado)


/**************************************************
UPDATE : Actualiza cualquier informacion existente
***************************************************/

UPDATE TI
SET TI.Descripcion = TITEMP.Descripcion,
	TI.Estado = TITEMP.Estado
FROM [dbo].[TipoInquilino] AS TI
INNER JOIN #TipoInquilinosTemp AS TITEMP
ON TI.Id_TipoInquilino = TITEMP.Id_TipoInquilino

/**************************************************
INSERT : Inserta informacion que no existe en el tabla
***************************************************/

SET IDENTITY_INSERT [dbo].[TipoInquilino] ON

INSERT INTO [dbo].[TipoInquilino]
(
	 Id_TipoInquilino
	,Descripcion
	,Estado
)
SELECT   Id_TipoInquilino
		,Descripcion
		,Estado
FROM #TipoInquilinosTemp

/******************************************************************************
SELECT : Selecciona la informacion que fue insertada o actualizada de la tabla [dbo].[TipoInquilino]
******************************************************************************/

EXCEPT
SELECT   Id_TipoInquilino
		,Descripcion
		,Estado
FROM [dbo].[TipoInquilino]

SET IDENTITY_INSERT [dbo].[TipoInquilino] OFF
GO
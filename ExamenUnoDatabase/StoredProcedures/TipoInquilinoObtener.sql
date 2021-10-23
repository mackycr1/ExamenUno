CREATE PROCEDURE [dbo].[TipoInquilinoObtener]
	
	@IdTipoInquilino INT = NULL

AS BEGIN

	SET NOCOUNT ON

	SELECT   Id_TipoInquilino
			,Descripcion
			,Estado BIT 
	FROM [dbo].[TipoInquilino]
	WHERE 
	(@IdTipoInquilino IS NULL OR Id_TipoInquilino = @IdTipoInquilino)

END
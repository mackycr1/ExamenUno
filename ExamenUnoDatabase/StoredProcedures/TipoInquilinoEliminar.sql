﻿CREATE PROCEDURE [dbo].[TipoInquilinoEliminar]

	@IdTipoInquilino INT

AS BEGIN

	SET NOCOUNT ON

	BEGIN TRANSACTION TRANS
	
		BEGIN TRY 
			
			DELETE FROM [dbo].[TipoInquilino]
			WHERE Id_TipoInquilino = @IdTipoInquilino
			
			COMMIT TRANSACTION TRANS
			SELECT 0 AS CodeError, '' AS MsgError

		END TRY

		BEGIN CATCH
			
			SELECT   ERROR_NUMBER() AS CodeError
					,ERROR_MESSAGE() AS MsgError
		
			ROLLBACK TRANSACTION TRANS

		END CATCH
END
GO
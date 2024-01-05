-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Carlos Alberto>
-- Create date: <Create Date,,04/01/2024>
-- Description:	<Description,,Actualizar el inventario>
-- =============================================
CREATE PROCEDURE sp_acme_actualizar_inventario(
				 @id_inventario as INT,
				 @cantidad as INT
				 )
AS
BEGIN
    UPDATE tabla_inventario
    SET CantidadTotalDeProductosDisponibles = @Cantidad, 
		FechaActualizacion = GETDATE()
    WHERE Id = @id_inventario
END
GO

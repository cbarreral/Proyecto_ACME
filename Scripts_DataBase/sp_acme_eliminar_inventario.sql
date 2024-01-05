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
-- Description:	<Description,,Eliminar productos del inventario de una sucursal>
-- =============================================
CREATE PROCEDURE sp_acme_eliminar_inventario
				(
				@id_inventario as INT
				)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		tabla_inventario 
	WHERE id = @id_inventario
END
GO

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
-- Description:	<Description,,Agrega productos al inventario>
-- =============================================
CREATE PROCEDURE sp_acme_agregar_inventario
				(
				@id_sucursal as INT,
				@id_producto as INT,
				@cantidad as INT
				)
AS
BEGIN
    INSERT INTO tabla_inventario
		(
		 sucursal_id, 
		 producto_id, 
		 cantidadTotalDeProductosDisponibles, 
		 fechaActualizacion
		)
    VALUES (@id_sucursal, @id_producto, @Cantidad, GETDATE())
END
GO

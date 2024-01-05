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
-- Description:	<Description,,Obtener el inventario de cada sucursal>
-- =============================================
CREATE PROCEDURE sp_acme_obtener_inventario (@id_sucursal as int) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--exec sp_obtener_inventario 1
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		p.nombre AS 'Nombre de producto',
		p.codigoBarras as 'Código de barras',
		i.cantidadTotalDeProductosDisponibles as 'Disponibles',
		p.precio AS 'Precio Unitario' 
	FROM 
		tabla_inventario AS i
	JOIN 
		tabla_productos AS p ON i.producto_id = p.id
	WHERE 
		i.sucursal_id = @id_sucursal;  -- ID de Sucursal
END
GO

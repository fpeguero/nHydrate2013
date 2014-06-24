-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Master_NotificacionesPrioridadesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Master_NotificacionesPrioridadesCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master_Editar]
(
	@Notificacion_Descripcion  [VarChar]  (500),
	@Notificacion_Mensaje  [VarChar]  (8000),
	@Prioridad_Numero  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Notificacion_Numero  [Int] 

)

AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END
UPDATE 
	[dbo].[Notificaciones_Master] 
SET
	[Notificacion_Descripcion] = @Notificacion_Descripcion,
	[Notificacion_Mensaje] = @Notificacion_Mensaje,
	[Prioridad_Numero] = @Prioridad_Numero,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Notificaciones_Master].[Notificacion_Numero] = @Notificacion_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Notificaciones_Master]
(
	[Notificacion_Descripcion],
	[Notificacion_Mensaje],
	[Prioridad_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Notificacion_Descripcion,
	@Notificacion_Mensaje,
	@Prioridad_Numero,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Notificacion_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Notificacion_Numero AS 'Notificacion_Numero' 
        FROM [Notificaciones_Master]
        WHERE ([Notificaciones_Master].[Notificacion_Numero] = @Notificacion_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master_Borrar]
(
	@Notificacion_Numero  [Int] 

)

AS
SET NOCOUNT ON
DECLARE @error int, @rowcount int
DECLARE @tran bit; SELECT @tran = 0
IF @@TRANCOUNT = 0
BEGIN
 SELECT @tran = 1
 BEGIN TRANSACTION
END

    UPDATE [Personas_Notificaciones_Trans] SET
     [Personas_Notificaciones_Trans].[Notificacion_Numero] = NULL
    WHERE     ([Personas_Notificaciones_Trans].[Notificacion_Numero] = @Notificacion_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Notificaciones_Objetivo_Trans] SET
     [Notificaciones_Objetivo_Trans].[Notificacion_Numero] = NULL
    WHERE     ([Notificaciones_Objetivo_Trans].[Notificacion_Numero] = @Notificacion_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Notificaciones_Master]
    WHERE 
      ([Notificaciones_Master].[Notificacion_Numero] = @Notificacion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master]
(
	@Notificacion_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Notificaciones_Master].[Notificacion_Numero],
                [Notificaciones_Master].[Prioridad_Numero],
                [Notificaciones_Master].[Notificacion_Descripcion],
                [Notificaciones_Master].[Notificacion_Mensaje],
                [Notificaciones_Master].[Registro_Estado],
                [Notificaciones_Master].[Registro_Fecha],
                [Notificaciones_Master].[Registro_Usuario]
    FROM [Notificaciones_Master]
    WHERE 
     ( [Notificaciones_Master].[Notificacion_Numero] = @Notificacion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Notificaciones_Master].[Notificacion_Numero],
                [Notificaciones_Master].[Prioridad_Numero],
                [Notificaciones_Master].[Notificacion_Descripcion],
                [Notificaciones_Master].[Notificacion_Mensaje],
                [Notificaciones_Master].[Registro_Estado],
                [Notificaciones_Master].[Registro_Fecha],
                [Notificaciones_Master].[Registro_Usuario]
    FROM [Notificaciones_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master_NotificacionesPrioridadesCata]
(
	@Prioridad_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Master].[Notificacion_Numero],
                [Notificaciones_Master].[Prioridad_Numero],
                [Notificaciones_Master].[Notificacion_Descripcion],
                [Notificaciones_Master].[Notificacion_Mensaje],
                [Notificaciones_Master].[Registro_Estado],
                [Notificaciones_Master].[Registro_Fecha],
                [Notificaciones_Master].[Registro_Usuario]
    FROM [Notificaciones_Master]
      WHERE
        ([Notificaciones_Master].[Prioridad_Numero] = @Prioridad_Numero)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Notificaciones_Master_Paging]

	@PageIndex 		int,
	@PageSize  		int,
	@SearchString 	varchar (50) = NULL,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
AS

SET NOCOUNT ON;

DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
		SELECT  
				ROW_NUMBER() OVER ( ORDER BY 		                [nm].[Notificacion_Numero]
 ) AS [RowNumber],
				   nm.Notificacion_Numero , 
				   nm.Prioridad_Numero , 
				   nm.Notificacion_Descripcion , 
				   nm.Notificacion_Mensaje , 
				   nm.Registro_Estado , 
				   nm.Registro_Fecha , 
				   nm.Registro_Usuario
		FROM  [dbo].[Notificaciones_Master]	As nm	
			 Inner Join Notificaciones_Prioridades_Cata As npc
			   On  npc.Prioridad_Numero = nm.Prioridad_Numero

		   WHERE nm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(nm.Notificacion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(nm.Prioridad_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR nm.Notificacion_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR nm.Notificacion_Mensaje LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR nm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(nm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR nm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 0 THEN [Notificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 1 THEN [Notificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Numero]' AND @_orderByDirection0 = 0 THEN [Prioridad_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Numero]' AND @_orderByDirection0 = 1 THEN [Prioridad_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Descripcion]' AND @_orderByDirection0 = 0 THEN [Notificacion_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Descripcion]' AND @_orderByDirection0 = 1 THEN [Notificacion_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Mensaje]' AND @_orderByDirection0 = 0 THEN [Notificacion_Mensaje]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Mensaje]' AND @_orderByDirection0 = 1 THEN [Notificacion_Mensaje]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 0 THEN [Registro_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Estado]' AND @_orderByDirection0 = 1 THEN [Registro_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 0 THEN [Registro_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Fecha]' AND @_orderByDirection0 = 1 THEN [Registro_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 0 THEN [Registro_Usuario]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Registro_Usuario]' AND @_orderByDirection0 = 1 THEN [Registro_Usuario]
      END DESC
GO


-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Prioridades_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Prioridades_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Prioridades_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Prioridades_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Prioridades_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Editar]
(
	@Prioridad_Color  [VarChar]  (50),
	@Prioridad_Descripcion  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Prioridad_Numero  [Int] 

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
	[dbo].[Notificaciones_Prioridades_Cata] 
SET
	[Prioridad_Color] = @Prioridad_Color,
	[Prioridad_Descripcion] = @Prioridad_Descripcion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Notificaciones_Prioridades_Cata].[Prioridad_Numero] = @Prioridad_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Notificaciones_Prioridades_Cata]
(
	[Prioridad_Color],
	[Prioridad_Descripcion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Prioridad_Color,
	@Prioridad_Descripcion,
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
    SELECT DISTINCT @Prioridad_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Prioridad_Numero AS 'Prioridad_Numero' 
        FROM [Notificaciones_Prioridades_Cata]
        WHERE ([Notificaciones_Prioridades_Cata].[Prioridad_Numero] = @Prioridad_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Borrar]
(
	@Prioridad_Numero  [Int] 

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

    UPDATE [Notificaciones_Master] SET
     [Notificaciones_Master].[Prioridad_Numero] = NULL
    WHERE     ([Notificaciones_Master].[Prioridad_Numero] = @Prioridad_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Notificaciones_Prioridades_Cata]
    WHERE 
      ([Notificaciones_Prioridades_Cata].[Prioridad_Numero] = @Prioridad_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata]
(
	@Prioridad_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Notificaciones_Prioridades_Cata].[Prioridad_Numero],
                [Notificaciones_Prioridades_Cata].[Prioridad_Descripcion],
                [Notificaciones_Prioridades_Cata].[Prioridad_Color],
                [Notificaciones_Prioridades_Cata].[Registro_Estado],
                [Notificaciones_Prioridades_Cata].[Registro_Fecha],
                [Notificaciones_Prioridades_Cata].[Registro_Usuario]
    FROM [Notificaciones_Prioridades_Cata]
    WHERE 
     ( [Notificaciones_Prioridades_Cata].[Prioridad_Numero] = @Prioridad_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Notificaciones_Prioridades_Cata].[Prioridad_Numero],
                [Notificaciones_Prioridades_Cata].[Prioridad_Descripcion],
                [Notificaciones_Prioridades_Cata].[Prioridad_Color],
                [Notificaciones_Prioridades_Cata].[Registro_Estado],
                [Notificaciones_Prioridades_Cata].[Registro_Fecha],
                [Notificaciones_Prioridades_Cata].[Registro_Usuario]
    FROM [Notificaciones_Prioridades_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Notificaciones_Prioridades_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [npc].[Prioridad_Numero]
 ) AS [RowNumber],
				   npc.Prioridad_Numero , 
				   npc.Prioridad_Descripcion , 
				   npc.Prioridad_Color , 
				   npc.Registro_Estado , 
				   npc.Registro_Fecha , 
				   npc.Registro_Usuario
		FROM  [dbo].[Notificaciones_Prioridades_Cata]	As npc	

		   WHERE npc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(npc.Prioridad_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npc.Prioridad_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npc.Prioridad_Color LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(npc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Prioridad_Numero]' AND @_orderByDirection0 = 0 THEN [Prioridad_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Numero]' AND @_orderByDirection0 = 1 THEN [Prioridad_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Descripcion]' AND @_orderByDirection0 = 0 THEN [Prioridad_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Descripcion]' AND @_orderByDirection0 = 1 THEN [Prioridad_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Color]' AND @_orderByDirection0 = 0 THEN [Prioridad_Color]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Prioridad_Color]' AND @_orderByDirection0 = 1 THEN [Prioridad_Color]
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


-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Publicaciones_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Publicaciones_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Publicaciones_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Publicaciones_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Publicaciones_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Publicaciones_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Publicaciones_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Publicaciones_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Publicaciones_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Publicaciones_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Publicaciones_Cata_Editar]
(
	@Publicacion_Descripcion  [VarChar]  (150),
	@Publicacion_Orden  [Int] ,
	@Publicacion_Simbolo  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Publicacion_Numero  [Int] 

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
	[dbo].[Publicaciones_Cata] 
SET
	[Publicacion_Descripcion] = @Publicacion_Descripcion,
	[Publicacion_Orden] = @Publicacion_Orden,
	[Publicacion_Simbolo] = @Publicacion_Simbolo,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Publicaciones_Cata].[Publicacion_Numero] = @Publicacion_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Publicaciones_Cata]
(
	[Publicacion_Descripcion],
	[Publicacion_Orden],
	[Publicacion_Simbolo],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Publicacion_Descripcion,
	@Publicacion_Orden,
	@Publicacion_Simbolo,
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
    SELECT DISTINCT @Publicacion_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Publicacion_Numero AS 'Publicacion_Numero' 
        FROM [Publicaciones_Cata]
        WHERE ([Publicaciones_Cata].[Publicacion_Numero] = @Publicacion_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Publicaciones_Cata_Borrar]
(
	@Publicacion_Numero  [Int] 

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

    UPDATE [Horario_Turno_Informe_Trans] SET
     [Horario_Turno_Informe_Trans].[Publicacion_Numero] = NULL
    WHERE     ([Horario_Turno_Informe_Trans].[Publicacion_Numero] = @Publicacion_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Publicaciones_Cata]
    WHERE 
      ([Publicaciones_Cata].[Publicacion_Numero] = @Publicacion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Publicaciones_Cata]
(
	@Publicacion_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Publicaciones_Cata].[Publicacion_Numero],
                [Publicaciones_Cata].[Publicacion_Descripcion],
                [Publicaciones_Cata].[Publicacion_Simbolo],
                [Publicaciones_Cata].[Publicacion_Orden],
                [Publicaciones_Cata].[Registro_Estado],
                [Publicaciones_Cata].[Registro_Fecha],
                [Publicaciones_Cata].[Registro_Usuario]
    FROM [Publicaciones_Cata]
    WHERE 
     ( [Publicaciones_Cata].[Publicacion_Numero] = @Publicacion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Publicaciones_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Publicaciones_Cata].[Publicacion_Numero],
                [Publicaciones_Cata].[Publicacion_Descripcion],
                [Publicaciones_Cata].[Publicacion_Simbolo],
                [Publicaciones_Cata].[Publicacion_Orden],
                [Publicaciones_Cata].[Registro_Estado],
                [Publicaciones_Cata].[Registro_Fecha],
                [Publicaciones_Cata].[Registro_Usuario]
    FROM [Publicaciones_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Publicaciones_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pc].[Publicacion_Numero]
 ) AS [RowNumber],
				   pc.Publicacion_Numero , 
				   pc.Publicacion_Descripcion , 
				   pc.Publicacion_Simbolo , 
				   pc.Publicacion_Orden , 
				   pc.Registro_Estado , 
				   pc.Registro_Fecha , 
				   pc.Registro_Usuario
		FROM  [dbo].[Publicaciones_Cata]	As pc	

		   WHERE pc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pc.Publicacion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pc.Publicacion_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pc.Publicacion_Simbolo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pc.Publicacion_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Publicacion_Numero]' AND @_orderByDirection0 = 0 THEN [Publicacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Numero]' AND @_orderByDirection0 = 1 THEN [Publicacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Descripcion]' AND @_orderByDirection0 = 0 THEN [Publicacion_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Descripcion]' AND @_orderByDirection0 = 1 THEN [Publicacion_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Simbolo]' AND @_orderByDirection0 = 0 THEN [Publicacion_Simbolo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Simbolo]' AND @_orderByDirection0 = 1 THEN [Publicacion_Simbolo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Orden]' AND @_orderByDirection0 = 0 THEN [Publicacion_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Orden]' AND @_orderByDirection0 = 1 THEN [Publicacion_Orden]
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


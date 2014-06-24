-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Idiomas_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Idiomas_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Idiomas_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Idiomas_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Idiomas_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Idiomas_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Idiomas_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Idiomas_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Idiomas_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Idiomas_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Idiomas_Cata_Editar]
(
	@Idioma_Descripcion  [VarChar]  (50),
	@Idioma_Orden  [Int] ,
	@Idioma_Simbolo  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Idioma_Numero  [Int] 

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
	[dbo].[Idiomas_Cata] 
SET
	[Idioma_Descripcion] = @Idioma_Descripcion,
	[Idioma_Orden] = @Idioma_Orden,
	[Idioma_Simbolo] = @Idioma_Simbolo,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Idiomas_Cata].[Idioma_Numero] = @Idioma_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Idiomas_Cata]
(
	[Idioma_Descripcion],
	[Idioma_Orden],
	[Idioma_Simbolo],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Idioma_Descripcion,
	@Idioma_Orden,
	@Idioma_Simbolo,
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
    SELECT DISTINCT @Idioma_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Idioma_Numero AS 'Idioma_Numero' 
        FROM [Idiomas_Cata]
        WHERE ([Idiomas_Cata].[Idioma_Numero] = @Idioma_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Idiomas_Cata_Borrar]
(
	@Idioma_Numero  [Int] 

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
     [Horario_Turno_Informe_Trans].[Idioma_Numero] = NULL
    WHERE     ([Horario_Turno_Informe_Trans].[Idioma_Numero] = @Idioma_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Idiomas_Cata]
    WHERE 
      ([Idiomas_Cata].[Idioma_Numero] = @Idioma_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Idiomas_Cata]
(
	@Idioma_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Idiomas_Cata].[Idioma_Numero],
                [Idiomas_Cata].[Idioma_Descripcion],
                [Idiomas_Cata].[Idioma_Simbolo],
                [Idiomas_Cata].[Idioma_Orden],
                [Idiomas_Cata].[Registro_Estado],
                [Idiomas_Cata].[Registro_Fecha],
                [Idiomas_Cata].[Registro_Usuario]
    FROM [Idiomas_Cata]
    WHERE 
     ( [Idiomas_Cata].[Idioma_Numero] = @Idioma_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Idiomas_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Idiomas_Cata].[Idioma_Numero],
                [Idiomas_Cata].[Idioma_Descripcion],
                [Idiomas_Cata].[Idioma_Simbolo],
                [Idiomas_Cata].[Idioma_Orden],
                [Idiomas_Cata].[Registro_Estado],
                [Idiomas_Cata].[Registro_Fecha],
                [Idiomas_Cata].[Registro_Usuario]
    FROM [Idiomas_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Idiomas_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ic].[Idioma_Numero]
 ) AS [RowNumber],
				   ic.Idioma_Numero , 
				   ic.Idioma_Descripcion , 
				   ic.Idioma_Simbolo , 
				   ic.Idioma_Orden , 
				   ic.Registro_Estado , 
				   ic.Registro_Fecha , 
				   ic.Registro_Usuario
		FROM  [dbo].[Idiomas_Cata]	As ic	

		   WHERE ic.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ic.Idioma_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ic.Idioma_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ic.Idioma_Simbolo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ic.Idioma_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ic.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ic.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ic.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Idioma_Numero]' AND @_orderByDirection0 = 0 THEN [Idioma_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Numero]' AND @_orderByDirection0 = 1 THEN [Idioma_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Descripcion]' AND @_orderByDirection0 = 0 THEN [Idioma_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Descripcion]' AND @_orderByDirection0 = 1 THEN [Idioma_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Simbolo]' AND @_orderByDirection0 = 0 THEN [Idioma_Simbolo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Simbolo]' AND @_orderByDirection0 = 1 THEN [Idioma_Simbolo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Orden]' AND @_orderByDirection0 = 0 THEN [Idioma_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Orden]' AND @_orderByDirection0 = 1 THEN [Idioma_Orden]
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


-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Documentos_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Documentos_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Documentos_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Documentos_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Documentos_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Documentos_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Documentos_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Documentos_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Documentos_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Documentos_Master_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Documentos_Master_Editar]
(
	@Documento_Archivo_Nombre  [VarChar]  (250),
	@Documento_Descripcion  [VarChar]  (500),
	@Documento_Nombre  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Documento_Secuencia  [Int] 

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
	[dbo].[Documentos_Master] 
SET
	[Documento_Archivo_Nombre] = @Documento_Archivo_Nombre,
	[Documento_Descripcion] = @Documento_Descripcion,
	[Documento_Nombre] = @Documento_Nombre,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Documentos_Master].[Documento_Secuencia] = @Documento_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Documentos_Master]
(
	[Documento_Archivo_Nombre],
	[Documento_Descripcion],
	[Documento_Nombre],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Documento_Archivo_Nombre,
	@Documento_Descripcion,
	@Documento_Nombre,
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
    SELECT DISTINCT @Documento_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Documento_Secuencia AS 'Documento_Secuencia' 
        FROM [Documentos_Master]
        WHERE ([Documentos_Master].[Documento_Secuencia] = @Documento_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Documentos_Master_Borrar]
(
	@Documento_Secuencia  [Int] 

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

    UPDATE [Documentos_Objetivos_Trans] SET
     [Documentos_Objetivos_Trans].[Documento_Secuencia] = NULL
    WHERE     ([Documentos_Objetivos_Trans].[Documento_Secuencia] = @Documento_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Documentos_Master]
    WHERE 
      ([Documentos_Master].[Documento_Secuencia] = @Documento_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Documentos_Master]
(
	@Documento_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Documentos_Master].[Documento_Secuencia],
                [Documentos_Master].[Documento_Nombre],
                [Documentos_Master].[Documento_Descripcion],
                [Documentos_Master].[Documento_Archivo_Nombre],
                [Documentos_Master].[Registro_Estado],
                [Documentos_Master].[Registro_Fecha],
                [Documentos_Master].[Registro_Usuario]
    FROM [Documentos_Master]
    WHERE 
     ( [Documentos_Master].[Documento_Secuencia] = @Documento_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Documentos_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Documentos_Master].[Documento_Secuencia],
                [Documentos_Master].[Documento_Nombre],
                [Documentos_Master].[Documento_Descripcion],
                [Documentos_Master].[Documento_Archivo_Nombre],
                [Documentos_Master].[Registro_Estado],
                [Documentos_Master].[Registro_Fecha],
                [Documentos_Master].[Registro_Usuario]
    FROM [Documentos_Master]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Documentos_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [dm].[Documento_Secuencia]
 ) AS [RowNumber],
				   dm.Documento_Secuencia , 
				   dm.Documento_Nombre , 
				   dm.Documento_Descripcion , 
				   dm.Documento_Archivo_Nombre , 
				   dm.Registro_Estado , 
				   dm.Registro_Fecha , 
				   dm.Registro_Usuario
		FROM  [dbo].[Documentos_Master]	As dm	

		   WHERE dm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(dm.Documento_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dm.Documento_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dm.Documento_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dm.Documento_Archivo_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(dm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR dm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Documento_Secuencia]' AND @_orderByDirection0 = 0 THEN [Documento_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Documento_Secuencia]' AND @_orderByDirection0 = 1 THEN [Documento_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Documento_Nombre]' AND @_orderByDirection0 = 0 THEN [Documento_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Documento_Nombre]' AND @_orderByDirection0 = 1 THEN [Documento_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Documento_Descripcion]' AND @_orderByDirection0 = 0 THEN [Documento_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Documento_Descripcion]' AND @_orderByDirection0 = 1 THEN [Documento_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Documento_Archivo_Nombre]' AND @_orderByDirection0 = 0 THEN [Documento_Archivo_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Documento_Archivo_Nombre]' AND @_orderByDirection0 = 1 THEN [Documento_Archivo_Nombre]
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


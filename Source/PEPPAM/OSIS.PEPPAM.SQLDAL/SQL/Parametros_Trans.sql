-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Parametros_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Parametros_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Parametros_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Parametros_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Parametros_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Parametros_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Parametros_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Parametros_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Parametros_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Parametros_Trans_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Parametros_Trans_Editar]
(
	@Parametro_Descripcion  [VarChar]  (150),
	@Parametro_Explicacion  [VarChar]  (500),
	@Parametro_Valor  [VarChar]  (200),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Parametro_Codigo  [VarChar]  (50)

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
	[dbo].[Parametros_Trans] 
SET
	[Parametro_Descripcion] = @Parametro_Descripcion,
	[Parametro_Explicacion] = @Parametro_Explicacion,
	[Parametro_Valor] = @Parametro_Valor,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Parametros_Trans].[Parametro_Codigo] = @Parametro_Codigo



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Parametros_Trans]
(
	[Parametro_Codigo],
	[Parametro_Descripcion],
	[Parametro_Explicacion],
	[Parametro_Valor],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Parametro_Codigo,
	@Parametro_Descripcion,
	@Parametro_Explicacion,
	@Parametro_Valor,
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
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Parametros_Trans_Borrar]
(
	@Parametro_Codigo  [VarChar]  (50)

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


  DELETE FROM [Parametros_Trans]
    WHERE 
      ([Parametros_Trans].[Parametro_Codigo] = @Parametro_Codigo)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Parametros_Trans]
(
	@Parametro_Codigo  [VarChar]  (50)

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Parametros_Trans].[Parametro_Codigo],
                [Parametros_Trans].[Parametro_Descripcion],
                [Parametros_Trans].[Parametro_Explicacion],
                [Parametros_Trans].[Parametro_Valor],
                [Parametros_Trans].[Registro_Estado],
                [Parametros_Trans].[Registro_Fecha],
                [Parametros_Trans].[Registro_Usuario]
    FROM [Parametros_Trans]
    WHERE 
     ( [Parametros_Trans].[Parametro_Codigo] = @Parametro_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Parametros_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Parametros_Trans].[Parametro_Codigo],
                [Parametros_Trans].[Parametro_Descripcion],
                [Parametros_Trans].[Parametro_Explicacion],
                [Parametros_Trans].[Parametro_Valor],
                [Parametros_Trans].[Registro_Estado],
                [Parametros_Trans].[Registro_Fecha],
                [Parametros_Trans].[Registro_Usuario]
    FROM [Parametros_Trans]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Parametros_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pt].[Parametro_Codigo]
 ) AS [RowNumber],
				   pt.Parametro_Codigo , 
				   pt.Parametro_Descripcion , 
				   pt.Parametro_Explicacion , 
				   pt.Parametro_Valor , 
				   pt.Registro_Estado , 
				   pt.Registro_Fecha , 
				   pt.Registro_Usuario
		FROM  [dbo].[Parametros_Trans]	As pt	

		   WHERE pt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR pt.Parametro_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pt.Parametro_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pt.Parametro_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pt.Parametro_Valor LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Parametro_Codigo]' AND @_orderByDirection0 = 0 THEN [Parametro_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Codigo]' AND @_orderByDirection0 = 1 THEN [Parametro_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Descripcion]' AND @_orderByDirection0 = 0 THEN [Parametro_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Descripcion]' AND @_orderByDirection0 = 1 THEN [Parametro_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Explicacion]' AND @_orderByDirection0 = 0 THEN [Parametro_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Explicacion]' AND @_orderByDirection0 = 1 THEN [Parametro_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Valor]' AND @_orderByDirection0 = 0 THEN [Parametro_Valor]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Parametro_Valor]' AND @_orderByDirection0 = 1 THEN [Parametro_Valor]
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


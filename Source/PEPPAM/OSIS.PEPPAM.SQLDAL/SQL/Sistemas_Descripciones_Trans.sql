-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Descripciones_Trans_ObjectoCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_ObjectoCodigo]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Editar]
(
	@Objeto_Sub_Datagrid_Mostrar  [Char]  (1) = 'S',
	@Objeto_Sub_Datagrid_Orden  [Int] ,
	@Objeto_Sub_Descripcion  [VarChar]  (250),
	@Objeto_Sub_Detalle_Mostrar  [Char]  (1) = 'S',
	@Objeto_Sub_Detalle_Orden  [Int] ,
	@Objeto_Sub_Editar_Mostrar  [Char]  (1) = 'S',
	@Objeto_Sub_Editar_Orden  [Int] ,
	@Objeto_Sub_Explicacion  [VarChar]  (5000),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Objeto_Codigo  [VarChar]  (150),
	@Objeto_Sub_Codigo  [VarChar]  (150)

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
	[dbo].[Sistemas_Descripciones_Trans] 
SET
	[Objeto_Sub_Datagrid_Mostrar] = @Objeto_Sub_Datagrid_Mostrar,
	[Objeto_Sub_Datagrid_Orden] = @Objeto_Sub_Datagrid_Orden,
	[Objeto_Sub_Descripcion] = @Objeto_Sub_Descripcion,
	[Objeto_Sub_Detalle_Mostrar] = @Objeto_Sub_Detalle_Mostrar,
	[Objeto_Sub_Detalle_Orden] = @Objeto_Sub_Detalle_Orden,
	[Objeto_Sub_Editar_Mostrar] = @Objeto_Sub_Editar_Mostrar,
	[Objeto_Sub_Editar_Orden] = @Objeto_Sub_Editar_Orden,
	[Objeto_Sub_Explicacion] = @Objeto_Sub_Explicacion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Descripciones_Trans].[Objeto_Codigo] = @Objeto_Codigo AND
	[dbo].[Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo] = @Objeto_Sub_Codigo



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Descripciones_Trans]
(
	[Objeto_Codigo],
	[Objeto_Sub_Codigo],
	[Objeto_Sub_Datagrid_Mostrar],
	[Objeto_Sub_Datagrid_Orden],
	[Objeto_Sub_Descripcion],
	[Objeto_Sub_Detalle_Mostrar],
	[Objeto_Sub_Detalle_Orden],
	[Objeto_Sub_Editar_Mostrar],
	[Objeto_Sub_Editar_Orden],
	[Objeto_Sub_Explicacion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Objeto_Codigo,
	@Objeto_Sub_Codigo,
	@Objeto_Sub_Datagrid_Mostrar,
	@Objeto_Sub_Datagrid_Orden,
	@Objeto_Sub_Descripcion,
	@Objeto_Sub_Detalle_Mostrar,
	@Objeto_Sub_Detalle_Orden,
	@Objeto_Sub_Editar_Mostrar,
	@Objeto_Sub_Editar_Orden,
	@Objeto_Sub_Explicacion,
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
CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Borrar]
(
	@Objeto_Codigo  [VarChar]  (150),
	@Objeto_Sub_Codigo  [VarChar]  (150)

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


  DELETE FROM [Sistemas_Descripciones_Trans]
    WHERE 
      ([Sistemas_Descripciones_Trans].[Objeto_Codigo] = @Objeto_Codigo)
     AND       ([Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo] = @Objeto_Sub_Codigo)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans]
(
	@Objeto_Codigo  [VarChar]  (150),
	@Objeto_Sub_Codigo  [VarChar]  (150)

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Descripciones_Trans].[Objeto_Codigo],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Descripcion],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Explicacion],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Mostrar],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Mostrar],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Mostrar],
                [Sistemas_Descripciones_Trans].[Registro_Estado],
                [Sistemas_Descripciones_Trans].[Registro_Fecha],
                [Sistemas_Descripciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Descripciones_Trans]
    WHERE 
     ( [Sistemas_Descripciones_Trans].[Objeto_Codigo] = @Objeto_Codigo)
     AND      ( [Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo] = @Objeto_Sub_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Descripciones_Trans].[Objeto_Codigo],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Descripcion],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Explicacion],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Mostrar],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Mostrar],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Orden],
                [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Mostrar],
                [Sistemas_Descripciones_Trans].[Registro_Estado],
                [Sistemas_Descripciones_Trans].[Registro_Fecha],
                [Sistemas_Descripciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Descripciones_Trans]

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_ObjectoCodigo]
(
    @ObjectoCodigo [nvarchar]  (256),
		@PageIndex 		int = 1,
		@PageSize  		int = 1000000,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Sistemas_Descripciones_Trans].[Objeto_Codigo],
		                [Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo]
 ) AS [RowNumber],

          [Sistemas_Descripciones_Trans].[Objeto_Codigo],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Codigo],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Descripcion],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Explicacion],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Orden],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Datagrid_Mostrar],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Orden],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Editar_Mostrar],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Orden],
          [Sistemas_Descripciones_Trans].[Objeto_Sub_Detalle_Mostrar],
          [Sistemas_Descripciones_Trans].[Registro_Estado],
          [Sistemas_Descripciones_Trans].[Registro_Fecha],
          [Sistemas_Descripciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Descripciones_Trans]
      WHERE Sistemas_Descripciones_Trans.Registro_Estado = 'A'
      AND 
         [Sistemas_Descripciones_Trans].[Objeto_Codigo] = @objectocodigo
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Descripciones_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [sdt].[Objeto_Codigo],
		                [sdt].[Objeto_Sub_Codigo]
 ) AS [RowNumber],
				   sdt.Objeto_Codigo , 
				   sdt.Objeto_Sub_Codigo , 
				   sdt.Objeto_Sub_Descripcion , 
				   sdt.Objeto_Sub_Explicacion , 
				   sdt.Objeto_Sub_Datagrid_Orden , 
				   sdt.Objeto_Sub_Datagrid_Mostrar , 
				   sdt.Objeto_Sub_Editar_Orden , 
				   sdt.Objeto_Sub_Editar_Mostrar , 
				   sdt.Objeto_Sub_Detalle_Orden , 
				   sdt.Objeto_Sub_Detalle_Mostrar , 
				   sdt.Registro_Estado , 
				   sdt.Registro_Fecha , 
				   sdt.Registro_Usuario
		FROM  [dbo].[Sistemas_Descripciones_Trans]	As sdt	

		   WHERE sdt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR sdt.Objeto_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sdt.Objeto_Sub_Datagrid_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Datagrid_Mostrar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sdt.Objeto_Sub_Editar_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Editar_Mostrar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sdt.Objeto_Sub_Detalle_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Objeto_Sub_Detalle_Mostrar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sdt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sdt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Objeto_Codigo]' AND @_orderByDirection0 = 0 THEN [Objeto_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Codigo]' AND @_orderByDirection0 = 1 THEN [Objeto_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Codigo]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Codigo]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Descripcion]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Descripcion]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Explicacion]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Explicacion]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Datagrid_Orden]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Datagrid_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Datagrid_Orden]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Datagrid_Orden]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Datagrid_Mostrar]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Datagrid_Mostrar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Datagrid_Mostrar]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Datagrid_Mostrar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Editar_Orden]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Editar_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Editar_Orden]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Editar_Orden]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Editar_Mostrar]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Editar_Mostrar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Editar_Mostrar]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Editar_Mostrar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Detalle_Orden]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Detalle_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Detalle_Orden]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Detalle_Orden]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Detalle_Mostrar]' AND @_orderByDirection0 = 0 THEN [Objeto_Sub_Detalle_Mostrar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Objeto_Sub_Detalle_Mostrar]' AND @_orderByDirection0 = 1 THEN [Objeto_Sub_Detalle_Mostrar]
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


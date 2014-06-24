-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_SistemasModulosMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_SistemasModulosMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_ModuloNumero]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_ModuloNumero]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_FuncionalidadCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_FuncionalidadCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Master_Loadbymodulo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Loadbymodulo]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Editar]
(
	@Funcionalidad_Codigo  [VarChar]  (150),
	@Funcionalidad_Descripcion  [VarChar]  (500),
	@Funcionalidad_Explicacion  [VarChar]  (8000),
	@Funcionalidad_Nombre  [VarChar]  (150),
	@Funcionalidad_Orden  [Int]  = 0,
	@Funcionalidad_Permiso_Descripcion  [VarChar]  (50) = null,
	@Funcionalidad_Url  [VarChar]  (150),
	@Modulo_Numero  [Int] ,
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Funcionalidad_Numero  [Int] 

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
	[dbo].[Sistemas_Funcionalidades_Master] 
SET
	[Funcionalidad_Codigo] = @Funcionalidad_Codigo,
	[Funcionalidad_Descripcion] = @Funcionalidad_Descripcion,
	[Funcionalidad_Explicacion] = @Funcionalidad_Explicacion,
	[Funcionalidad_Nombre] = @Funcionalidad_Nombre,
	[Funcionalidad_Orden] = @Funcionalidad_Orden,
	[Funcionalidad_Permiso_Descripcion] = @Funcionalidad_Permiso_Descripcion,
	[Funcionalidad_Url] = @Funcionalidad_Url,
	[Modulo_Numero] = @Modulo_Numero,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] = @Funcionalidad_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Funcionalidades_Master]
(
	[Funcionalidad_Codigo],
	[Funcionalidad_Descripcion],
	[Funcionalidad_Explicacion],
	[Funcionalidad_Nombre],
	[Funcionalidad_Orden],
	[Funcionalidad_Permiso_Descripcion],
	[Funcionalidad_Url],
	[Modulo_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Funcionalidad_Codigo,
	@Funcionalidad_Descripcion,
	@Funcionalidad_Explicacion,
	@Funcionalidad_Nombre,
	@Funcionalidad_Orden,
	@Funcionalidad_Permiso_Descripcion,
	@Funcionalidad_Url,
	@Modulo_Numero,
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
    SELECT DISTINCT @Funcionalidad_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Funcionalidad_Numero AS 'Funcionalidad_Numero' 
        FROM [Sistemas_Funcionalidades_Master]
        WHERE ([Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] = @Funcionalidad_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Borrar]
(
	@Funcionalidad_Numero  [Int] 

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

    UPDATE [Sistemas_Funcionalidades_Acciones_Trans] SET
     [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = NULL
    WHERE     ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Sistemas_Funcionalidades_Master]
    WHERE 
      ([Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] = @Funcionalidad_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master]
(
	@Funcionalidad_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Master].[Modulo_Numero],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
                [Sistemas_Funcionalidades_Master].[Registro_Estado],
                [Sistemas_Funcionalidades_Master].[Registro_Fecha],
                [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]
    WHERE 
     ( [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] = @Funcionalidad_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Master].[Modulo_Numero],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
                [Sistemas_Funcionalidades_Master].[Registro_Estado],
                [Sistemas_Funcionalidades_Master].[Registro_Fecha],
                [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_SistemasModulosMaster]
(
	@Modulo_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Master].[Modulo_Numero],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
                [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
                [Sistemas_Funcionalidades_Master].[Registro_Estado],
                [Sistemas_Funcionalidades_Master].[Registro_Fecha],
                [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]
      WHERE
        ([Sistemas_Funcionalidades_Master].[Modulo_Numero] = @Modulo_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_ModuloNumero]
(
	@Modulo_Numero  [Int] 
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
          [Sistemas_Funcionalidades_Master].[Modulo_Numero],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
          [Sistemas_Funcionalidades_Master].[Registro_Estado],
          [Sistemas_Funcionalidades_Master].[Registro_Fecha],
          [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]
      WHERE
        ([Sistemas_Funcionalidades_Master].[Modulo_Numero] = @Modulo_Numero)

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_FuncionalidadCodigo]
(
	@Funcionalidad_Codigo  [VarChar]  (150)
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
          [Sistemas_Funcionalidades_Master].[Modulo_Numero],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
          [Sistemas_Funcionalidades_Master].[Registro_Estado],
          [Sistemas_Funcionalidades_Master].[Registro_Fecha],
          [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]
      WHERE
        ([Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo] = @Funcionalidad_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Loadbymodulo]
(
    @Modulo_Numero [Int] ,
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
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero]
 ) AS [RowNumber],

          [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero],
          [Sistemas_Funcionalidades_Master].[Modulo_Numero],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Codigo],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Nombre],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Explicacion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Url],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Permiso_Descripcion],
          [Sistemas_Funcionalidades_Master].[Funcionalidad_Orden],
          [Sistemas_Funcionalidades_Master].[Registro_Estado],
          [Sistemas_Funcionalidades_Master].[Registro_Fecha],
          [Sistemas_Funcionalidades_Master].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Master]
      WHERE Sistemas_Funcionalidades_Master.Registro_Estado = 'A'
      AND 
         [Sistemas_Funcionalidades_Master].[Modulo_Numero] = @modulo_numero
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [sfm].[Funcionalidad_Numero]
 ) AS [RowNumber],
				   sfm.Funcionalidad_Numero , 
				   sfm.Modulo_Numero , 
				   sfm.Funcionalidad_Codigo , 
				   sfm.Funcionalidad_Nombre , 
				   sfm.Funcionalidad_Descripcion , 
				   sfm.Funcionalidad_Explicacion , 
				   sfm.Funcionalidad_Url , 
				   sfm.Funcionalidad_Permiso_Descripcion , 
				   sfm.Funcionalidad_Orden , 
				   sfm.Registro_Estado , 
				   sfm.Registro_Fecha , 
				   sfm.Registro_Usuario
		FROM  [dbo].[Sistemas_Funcionalidades_Master]	As sfm	
			 Inner Join Sistemas_Modulos_Master As smm
			   On  smm.Modulo_Numero = sfm.Modulo_Numero

		   WHERE sfm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(sfm.Funcionalidad_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfm.Modulo_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Url LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Funcionalidad_Permiso_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfm.Funcionalidad_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Numero]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Numero]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Numero]' AND @_orderByDirection0 = 0 THEN [Modulo_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Numero]' AND @_orderByDirection0 = 1 THEN [Modulo_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Codigo]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Codigo]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Nombre]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Nombre]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Descripcion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Descripcion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Explicacion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Explicacion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Url]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Url]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Url]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Url]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Permiso_Descripcion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Permiso_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Permiso_Descripcion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Permiso_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Orden]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Orden]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Orden]
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


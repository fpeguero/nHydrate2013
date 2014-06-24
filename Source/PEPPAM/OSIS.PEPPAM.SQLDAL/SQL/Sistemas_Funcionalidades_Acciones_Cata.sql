-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_FuncionalidadAccionCodigo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_FuncionalidadAccionCodigo]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadFuncionalidad]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadFuncionalidad]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Editar]
(
	@Funcionalidad_Accion_Codigo  [VarChar]  (50),
	@Funcionalidad_Accion_Css  [VarChar]  (100),
	@Funcionalidad_Accion_Descripcion  [VarChar]  (150),
	@Funcionalidad_Accion_Explicacion  [VarChar]  (500),
	@Funcionalidad_Accion_Icono_Large  [VarChar]  (50) = null,
	@Funcionalidad_Accion_Icono_Small  [VarChar]  (50) = null,
	@Funcionalidad_Accion_Menu  [Char]  (1) = 'S',
	@Funcionalidad_Accion_Permiso_Descripcion  [VarChar]  (50) = null,
	@Funcionalidad_Accion_Permiso_Necesita  [Char]  (1) = ' ',
	@Funcionalidad_Accion_Tipo_Secuencia  [Int]  = null,
	@Funcionalidad_Accion_Toolbar  [Char]  (1) = 'S',
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Funcionalidad_Accion_Numero  [Int] 

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
	[dbo].[Sistemas_Funcionalidades_Acciones_Cata] 
SET
	[Funcionalidad_Accion_Codigo] = @Funcionalidad_Accion_Codigo,
	[Funcionalidad_Accion_Css] = @Funcionalidad_Accion_Css,
	[Funcionalidad_Accion_Descripcion] = @Funcionalidad_Accion_Descripcion,
	[Funcionalidad_Accion_Explicacion] = @Funcionalidad_Accion_Explicacion,
	[Funcionalidad_Accion_Icono_Large] = @Funcionalidad_Accion_Icono_Large,
	[Funcionalidad_Accion_Icono_Small] = @Funcionalidad_Accion_Icono_Small,
	[Funcionalidad_Accion_Menu] = @Funcionalidad_Accion_Menu,
	[Funcionalidad_Accion_Permiso_Descripcion] = @Funcionalidad_Accion_Permiso_Descripcion,
	[Funcionalidad_Accion_Permiso_Necesita] = @Funcionalidad_Accion_Permiso_Necesita,
	[Funcionalidad_Accion_Tipo_Secuencia] = @Funcionalidad_Accion_Tipo_Secuencia,
	[Funcionalidad_Accion_Toolbar] = @Funcionalidad_Accion_Toolbar,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Funcionalidades_Acciones_Cata]
(
	[Funcionalidad_Accion_Codigo],
	[Funcionalidad_Accion_Css],
	[Funcionalidad_Accion_Descripcion],
	[Funcionalidad_Accion_Explicacion],
	[Funcionalidad_Accion_Icono_Large],
	[Funcionalidad_Accion_Icono_Small],
	[Funcionalidad_Accion_Menu],
	[Funcionalidad_Accion_Permiso_Descripcion],
	[Funcionalidad_Accion_Permiso_Necesita],
	[Funcionalidad_Accion_Tipo_Secuencia],
	[Funcionalidad_Accion_Toolbar],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Funcionalidad_Accion_Codigo,
	@Funcionalidad_Accion_Css,
	@Funcionalidad_Accion_Descripcion,
	@Funcionalidad_Accion_Explicacion,
	@Funcionalidad_Accion_Icono_Large,
	@Funcionalidad_Accion_Icono_Small,
	@Funcionalidad_Accion_Menu,
	@Funcionalidad_Accion_Permiso_Descripcion,
	@Funcionalidad_Accion_Permiso_Necesita,
	@Funcionalidad_Accion_Tipo_Secuencia,
	@Funcionalidad_Accion_Toolbar,
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
    SELECT DISTINCT @Funcionalidad_Accion_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Funcionalidad_Accion_Numero AS 'Funcionalidad_Accion_Numero' 
        FROM [Sistemas_Funcionalidades_Acciones_Cata]
        WHERE ([Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Borrar]
(
	@Funcionalidad_Accion_Numero  [Int] 

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
     [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = NULL
    WHERE     ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Sistemas_Funcionalidades_Acciones_Cata]
    WHERE 
      ([Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata]
(
	@Funcionalidad_Accion_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Codigo],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Explicacion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Small],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Large],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Css],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Toolbar],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Menu],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Necesita],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Cata]
    WHERE 
     ( [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Codigo],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Explicacion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Small],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Large],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Css],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Toolbar],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Menu],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Descripcion],
                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Necesita],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Cata]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_FuncionalidadAccionCodigo]
(
	@Funcionalidad_Accion_Codigo  [VarChar]  (50)
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Codigo],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Descripcion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Explicacion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Small],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Large],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Css],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Toolbar],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Menu],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Descripcion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Necesita],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Estado],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Fecha],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Cata]
      WHERE
        ([Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Codigo] = @Funcionalidad_Accion_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_LoadFuncionalidad]
(
    @funcionalidadNumero [int] ,
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
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero]
 ) AS [RowNumber],

          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Tipo_Secuencia],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Codigo],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Descripcion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Explicacion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Small],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Icono_Large],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Css],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Toolbar],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Menu],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Descripcion],
          [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Permiso_Necesita],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Estado],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Fecha],
          [Sistemas_Funcionalidades_Acciones_Cata].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Cata]
		LEFT OUTER JOIN [Sistemas_Funcionalidades_Acciones_Trans]
			On              [Sistemas_Funcionalidades_Acciones_Cata].[Funcionalidad_Accion_Numero] =  [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero]
		LEFT OUTER JOIN [Sistemas_Funcionalidades_Master]
			On              [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] =  [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero]
      WHERE Sistemas_Funcionalidades_Acciones_Cata.Registro_Estado = 'A'
      AND 
         [Sistemas_Funcionalidades_Master].[Funcionalidad_Numero] = @funcionalidadnumero
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [sfac].[Funcionalidad_Accion_Numero]
 ) AS [RowNumber],
				   sfac.Funcionalidad_Accion_Numero , 
				   sfac.Funcionalidad_Accion_Tipo_Secuencia , 
				   sfac.Funcionalidad_Accion_Codigo , 
				   sfac.Funcionalidad_Accion_Descripcion , 
				   sfac.Funcionalidad_Accion_Explicacion , 
				   sfac.Funcionalidad_Accion_Icono_Small , 
				   sfac.Funcionalidad_Accion_Icono_Large , 
				   sfac.Funcionalidad_Accion_Css , 
				   sfac.Funcionalidad_Accion_Toolbar , 
				   sfac.Funcionalidad_Accion_Menu , 
				   sfac.Funcionalidad_Accion_Permiso_Descripcion , 
				   sfac.Funcionalidad_Accion_Permiso_Necesita , 
				   sfac.Registro_Estado , 
				   sfac.Registro_Fecha , 
				   sfac.Registro_Usuario
		FROM  [dbo].[Sistemas_Funcionalidades_Acciones_Cata]	As sfac	

		   WHERE sfac.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(sfac.Funcionalidad_Accion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfac.Funcionalidad_Accion_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Codigo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Icono_Small LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Icono_Large LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Css LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Toolbar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Menu LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Permiso_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Funcionalidad_Accion_Permiso_Necesita LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfac.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfac.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Numero]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Numero]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Tipo_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Codigo]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Codigo]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Descripcion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Descripcion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Explicacion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Explicacion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Icono_Small]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Icono_Small]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Icono_Small]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Icono_Small]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Icono_Large]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Icono_Large]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Icono_Large]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Icono_Large]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Css]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Css]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Css]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Css]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Toolbar]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Toolbar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Toolbar]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Toolbar]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Menu]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Menu]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Menu]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Menu]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Permiso_Descripcion]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Permiso_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Permiso_Descripcion]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Permiso_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Permiso_Necesita]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Permiso_Necesita]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Permiso_Necesita]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Permiso_Necesita]
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


-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Modulos_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Modulos_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Modulos_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Modulos_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Modulos_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Editar]
(
	@Modulo_Descripcion  [VarChar]  (500),
	@Modulo_Explicacion  [VarChar]  (8000),
	@Modulo_Icon  [VarChar]  (150) = null,
	@Modulo_Nombre  [VarChar]  (150),
	@Modulo_Orden  [Int]  = 0,
	@Modulo_Permiso_Descripcion  [VarChar]  (50) = null,
	@Modulo_Url  [VarChar]  (150),
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Modulo_Numero  [Int] 

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
	[dbo].[Sistemas_Modulos_Master] 
SET
	[Modulo_Descripcion] = @Modulo_Descripcion,
	[Modulo_Explicacion] = @Modulo_Explicacion,
	[Modulo_Icon] = @Modulo_Icon,
	[Modulo_Nombre] = @Modulo_Nombre,
	[Modulo_Orden] = @Modulo_Orden,
	[Modulo_Permiso_Descripcion] = @Modulo_Permiso_Descripcion,
	[Modulo_Url] = @Modulo_Url,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Modulos_Master].[Modulo_Numero] = @Modulo_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Modulos_Master]
(
	[Modulo_Descripcion],
	[Modulo_Explicacion],
	[Modulo_Icon],
	[Modulo_Nombre],
	[Modulo_Orden],
	[Modulo_Permiso_Descripcion],
	[Modulo_Url],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Modulo_Descripcion,
	@Modulo_Explicacion,
	@Modulo_Icon,
	@Modulo_Nombre,
	@Modulo_Orden,
	@Modulo_Permiso_Descripcion,
	@Modulo_Url,
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
    SELECT DISTINCT @Modulo_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Modulo_Numero AS 'Modulo_Numero' 
        FROM [Sistemas_Modulos_Master]
        WHERE ([Sistemas_Modulos_Master].[Modulo_Numero] = @Modulo_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Borrar]
(
	@Modulo_Numero  [Int] 

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

    UPDATE [Sistemas_Funcionalidades_Master] SET
     [Sistemas_Funcionalidades_Master].[Modulo_Numero] = NULL
    WHERE     ([Sistemas_Funcionalidades_Master].[Modulo_Numero] = @Modulo_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Sistemas_Modulos_Master]
    WHERE 
      ([Sistemas_Modulos_Master].[Modulo_Numero] = @Modulo_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master]
(
	@Modulo_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Modulos_Master].[Modulo_Numero],
                [Sistemas_Modulos_Master].[Modulo_Nombre],
                [Sistemas_Modulos_Master].[Modulo_Descripcion],
                [Sistemas_Modulos_Master].[Modulo_Explicacion],
                [Sistemas_Modulos_Master].[Modulo_Url],
                [Sistemas_Modulos_Master].[Modulo_Icon],
                [Sistemas_Modulos_Master].[Modulo_Permiso_Descripcion],
                [Sistemas_Modulos_Master].[Modulo_Orden],
                [Sistemas_Modulos_Master].[Registro_Estado],
                [Sistemas_Modulos_Master].[Registro_Fecha],
                [Sistemas_Modulos_Master].[Registro_Usuario]
    FROM [Sistemas_Modulos_Master]
    WHERE 
     ( [Sistemas_Modulos_Master].[Modulo_Numero] = @Modulo_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Modulos_Master].[Modulo_Numero],
                [Sistemas_Modulos_Master].[Modulo_Nombre],
                [Sistemas_Modulos_Master].[Modulo_Descripcion],
                [Sistemas_Modulos_Master].[Modulo_Explicacion],
                [Sistemas_Modulos_Master].[Modulo_Url],
                [Sistemas_Modulos_Master].[Modulo_Icon],
                [Sistemas_Modulos_Master].[Modulo_Permiso_Descripcion],
                [Sistemas_Modulos_Master].[Modulo_Orden],
                [Sistemas_Modulos_Master].[Registro_Estado],
                [Sistemas_Modulos_Master].[Registro_Fecha],
                [Sistemas_Modulos_Master].[Registro_Usuario]
    FROM [Sistemas_Modulos_Master]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Sistemas_Modulos_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [smm].[Modulo_Numero]
 ) AS [RowNumber],
				   smm.Modulo_Numero , 
				   smm.Modulo_Nombre , 
				   smm.Modulo_Descripcion , 
				   smm.Modulo_Explicacion , 
				   smm.Modulo_Url , 
				   smm.Modulo_Icon , 
				   smm.Modulo_Permiso_Descripcion , 
				   smm.Modulo_Orden , 
				   smm.Registro_Estado , 
				   smm.Registro_Fecha , 
				   smm.Registro_Usuario
		FROM  [dbo].[Sistemas_Modulos_Master]	As smm	

		   WHERE smm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(smm.Modulo_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Url LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Icon LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Modulo_Permiso_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(smm.Modulo_Orden) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(smm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR smm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Modulo_Numero]' AND @_orderByDirection0 = 0 THEN [Modulo_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Numero]' AND @_orderByDirection0 = 1 THEN [Modulo_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Nombre]' AND @_orderByDirection0 = 0 THEN [Modulo_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Nombre]' AND @_orderByDirection0 = 1 THEN [Modulo_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Descripcion]' AND @_orderByDirection0 = 0 THEN [Modulo_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Descripcion]' AND @_orderByDirection0 = 1 THEN [Modulo_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Explicacion]' AND @_orderByDirection0 = 0 THEN [Modulo_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Explicacion]' AND @_orderByDirection0 = 1 THEN [Modulo_Explicacion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Url]' AND @_orderByDirection0 = 0 THEN [Modulo_Url]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Url]' AND @_orderByDirection0 = 1 THEN [Modulo_Url]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Icon]' AND @_orderByDirection0 = 0 THEN [Modulo_Icon]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Icon]' AND @_orderByDirection0 = 1 THEN [Modulo_Icon]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Permiso_Descripcion]' AND @_orderByDirection0 = 0 THEN [Modulo_Permiso_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Permiso_Descripcion]' AND @_orderByDirection0 = 1 THEN [Modulo_Permiso_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Orden]' AND @_orderByDirection0 = 0 THEN [Modulo_Orden]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Modulo_Orden]' AND @_orderByDirection0 = 1 THEN [Modulo_Orden]
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


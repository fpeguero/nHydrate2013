-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_SistemasFuncionalidadesAccionesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_SistemasFuncionalidadesAccionesCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Funcionalidad]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Funcionalidad]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Editar]
(
	@Funcionalidad_Numero_Url  [Int]  = null,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Funcionalidad_Accion_Numero  [Int] ,
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
	[dbo].[Sistemas_Funcionalidades_Acciones_Trans] 
SET
	[Funcionalidad_Numero_Url] = @Funcionalidad_Numero_Url,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero AND
	[dbo].[Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Sistemas_Funcionalidades_Acciones_Trans]
(
	[Funcionalidad_Accion_Numero],
	[Funcionalidad_Numero],
	[Funcionalidad_Numero_Url],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Funcionalidad_Accion_Numero,
	@Funcionalidad_Numero,
	@Funcionalidad_Numero_Url,
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
CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Borrar]
(
	@Funcionalidad_Accion_Numero  [Int] ,
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

    UPDATE [Roles_Funcionalidad_Acciones_Trans] SET
     [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = NULL,
     [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = NULL
    WHERE     ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)  And
    ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Sistemas_Funcionalidades_Acciones_Trans]
    WHERE 
      ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)
     AND       ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans]
(
	@Funcionalidad_Accion_Numero  [Int] ,
	@Funcionalidad_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero_Url],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Trans]
    WHERE 
     ( [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)
     AND      ( [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero_Url],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_SistemasFuncionalidadesAccionesCata]
(
	@Funcionalidad_Accion_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero_Url],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Trans]
      WHERE
        ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Funcionalidad]
(
	@Funcionalidad_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero_Url],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Estado],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Fecha],
                [Sistemas_Funcionalidades_Acciones_Trans].[Registro_Usuario]
    FROM [Sistemas_Funcionalidades_Acciones_Trans]
      WHERE
        ([Sistemas_Funcionalidades_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Sistemas_Funcionalidades_Acciones_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [sfat].[Funcionalidad_Numero],
		                [sfat].[Funcionalidad_Accion_Numero]
 ) AS [RowNumber],
				   sfat.Funcionalidad_Numero , 
				   sfat.Funcionalidad_Accion_Numero , 
				   sfat.Funcionalidad_Numero_Url , 
				   sfat.Registro_Estado , 
				   sfat.Registro_Fecha , 
				   sfat.Registro_Usuario
		FROM  [dbo].[Sistemas_Funcionalidades_Acciones_Trans]	As sfat	
			 Inner Join Sistemas_Funcionalidades_Acciones_Cata As sfac
			   On  sfac.Funcionalidad_Accion_Numero = sfat.Funcionalidad_Accion_Numero
			 Inner Join Sistemas_Funcionalidades_Master As sfm
			   On  sfm.Funcionalidad_Numero = sfat.Funcionalidad_Numero

		   WHERE sfat.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(sfat.Funcionalidad_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfat.Funcionalidad_Accion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfat.Funcionalidad_Numero_Url) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfat.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(sfat.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR sfat.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Numero]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Accion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Accion_Numero]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Accion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Numero_Url]' AND @_orderByDirection0 = 0 THEN [Funcionalidad_Numero_Url]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Funcionalidad_Numero_Url]' AND @_orderByDirection0 = 1 THEN [Funcionalidad_Numero_Url]
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


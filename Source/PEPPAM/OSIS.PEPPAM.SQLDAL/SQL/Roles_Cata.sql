-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Cata_RolesNivelesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Cata_RolesNivelesCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Roles_Cata_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Role_Descripcion  [VarChar]  (1500),
	@Role_Nivel_Numero  [Int]  = null,
	@Role_Nombre  [VarChar]  (50),
	@Role_Numero  [Int] 

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
	[dbo].[Roles_Cata] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Role_Descripcion] = @Role_Descripcion,
	[Role_Nivel_Numero] = @Role_Nivel_Numero,
	[Role_Nombre] = @Role_Nombre

WHERE
	[dbo].[Roles_Cata].[Role_Numero] = @Role_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Roles_Cata]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Role_Descripcion],
	[Role_Nivel_Numero],
	[Role_Nombre],
	[Role_Numero]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Role_Descripcion,
	@Role_Nivel_Numero,
	@Role_Nombre,
	@Role_Numero
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
CREATE PROCEDURE [dbo].[Proc_Roles_Cata_Borrar]
(
	@Role_Numero  [Int] 

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

    UPDATE [Persona_Roles_Trans] SET
     [Persona_Roles_Trans].[Role_Numero] = NULL
    WHERE     ([Persona_Roles_Trans].[Role_Numero] = @Role_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Roles_Funcionalidad_Acciones_Trans] SET
     [Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = NULL
    WHERE     ([Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @Role_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Documentos_Objetivos_Trans] SET
     [Documentos_Objetivos_Trans].[Role_Numero] = NULL
    WHERE     ([Documentos_Objetivos_Trans].[Role_Numero] = @Role_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Notificaciones_Objetivo_Trans] SET
     [Notificaciones_Objetivo_Trans].[Role_Numero] = NULL
    WHERE     ([Notificaciones_Objetivo_Trans].[Role_Numero] = @Role_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Roles_Cata]
    WHERE 
      ([Roles_Cata].[Role_Numero] = @Role_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Cata]
(
	@Role_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Roles_Cata].[Role_Numero],
                [Roles_Cata].[Role_Nivel_Numero],
                [Roles_Cata].[Role_Nombre],
                [Roles_Cata].[Role_Descripcion],
                [Roles_Cata].[Registro_Estado],
                [Roles_Cata].[Registro_Fecha],
                [Roles_Cata].[Registro_Usuario]
    FROM [Roles_Cata]
    WHERE 
     ( [Roles_Cata].[Role_Numero] = @Role_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Roles_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Roles_Cata].[Role_Numero],
                [Roles_Cata].[Role_Nivel_Numero],
                [Roles_Cata].[Role_Nombre],
                [Roles_Cata].[Role_Descripcion],
                [Roles_Cata].[Registro_Estado],
                [Roles_Cata].[Registro_Fecha],
                [Roles_Cata].[Registro_Usuario]
    FROM [Roles_Cata]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Cata_RolesNivelesCata]
(
	@Role_Nivel_Numero  [Int]  = null,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Roles_Cata].[Role_Numero],
                [Roles_Cata].[Role_Nivel_Numero],
                [Roles_Cata].[Role_Nombre],
                [Roles_Cata].[Role_Descripcion],
                [Roles_Cata].[Registro_Estado],
                [Roles_Cata].[Registro_Fecha],
                [Roles_Cata].[Registro_Usuario]
    FROM [Roles_Cata]
      WHERE
        ([Roles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Roles_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rc].[Role_Numero]
 ) AS [RowNumber],
				   rc.Role_Numero , 
				   rc.Role_Nivel_Numero , 
				   rc.Role_Nombre , 
				   rc.Role_Descripcion , 
				   rc.Registro_Estado , 
				   rc.Registro_Fecha , 
				   rc.Registro_Usuario
		FROM  [dbo].[Roles_Cata]	As rc	
			 Inner Join Roles_Niveles_Cata As rnc
			   On  rnc.Role_Nivel_Numero = rc.Role_Nivel_Numero

		   WHERE rc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rc.Role_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rc.Role_Nivel_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rc.Role_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rc.Role_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Role_Numero]' AND @_orderByDirection0 = 0 THEN [Role_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Numero]' AND @_orderByDirection0 = 1 THEN [Role_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Numero]' AND @_orderByDirection0 = 0 THEN [Role_Nivel_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Numero]' AND @_orderByDirection0 = 1 THEN [Role_Nivel_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Nombre]' AND @_orderByDirection0 = 0 THEN [Role_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nombre]' AND @_orderByDirection0 = 1 THEN [Role_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Descripcion]' AND @_orderByDirection0 = 0 THEN [Role_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Descripcion]' AND @_orderByDirection0 = 1 THEN [Role_Descripcion]
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


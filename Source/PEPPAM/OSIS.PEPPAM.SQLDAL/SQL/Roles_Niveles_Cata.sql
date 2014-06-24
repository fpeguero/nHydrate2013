-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Niveles_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Niveles_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Niveles_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Niveles_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Niveles_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Niveles_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Editar]
(
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50) = '(suser_sname())',
	@Role_Nivel  [Int]  = 0,
	@Role_Nivel_Descripcion  [VarChar]  (500),
	@Role_Nivel_Nombre  [VarChar]  (50),
	@Role_Nivel_Numero  [Int] 

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
	[dbo].[Roles_Niveles_Cata] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Role_Nivel] = @Role_Nivel,
	[Role_Nivel_Descripcion] = @Role_Nivel_Descripcion,
	[Role_Nivel_Nombre] = @Role_Nivel_Nombre

WHERE
	[dbo].[Roles_Niveles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Roles_Niveles_Cata]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Role_Nivel],
	[Role_Nivel_Descripcion],
	[Role_Nivel_Nombre]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Role_Nivel,
	@Role_Nivel_Descripcion,
	@Role_Nivel_Nombre
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Role_Nivel_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Role_Nivel_Numero AS 'Role_Nivel_Numero' 
        FROM [Roles_Niveles_Cata]
        WHERE ([Roles_Niveles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Borrar]
(
	@Role_Nivel_Numero  [Int] 

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

    UPDATE [Roles_Cata] SET
     [Roles_Cata].[Role_Nivel_Numero] = NULL
    WHERE     ([Roles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Roles_Niveles_Cata]
    WHERE 
      ([Roles_Niveles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Niveles_Cata]
(
	@Role_Nivel_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Roles_Niveles_Cata].[Role_Nivel_Numero],
                [Roles_Niveles_Cata].[Role_Nivel],
                [Roles_Niveles_Cata].[Role_Nivel_Nombre],
                [Roles_Niveles_Cata].[Role_Nivel_Descripcion],
                [Roles_Niveles_Cata].[Registro_Estado],
                [Roles_Niveles_Cata].[Registro_Fecha],
                [Roles_Niveles_Cata].[Registro_Usuario]
    FROM [Roles_Niveles_Cata]
    WHERE 
     ( [Roles_Niveles_Cata].[Role_Nivel_Numero] = @Role_Nivel_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Roles_Niveles_Cata].[Role_Nivel_Numero],
                [Roles_Niveles_Cata].[Role_Nivel],
                [Roles_Niveles_Cata].[Role_Nivel_Nombre],
                [Roles_Niveles_Cata].[Role_Nivel_Descripcion],
                [Roles_Niveles_Cata].[Registro_Estado],
                [Roles_Niveles_Cata].[Registro_Fecha],
                [Roles_Niveles_Cata].[Registro_Usuario]
    FROM [Roles_Niveles_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Roles_Niveles_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rnc].[Role_Nivel_Numero]
 ) AS [RowNumber],
				   rnc.Role_Nivel_Numero , 
				   rnc.Role_Nivel , 
				   rnc.Role_Nivel_Nombre , 
				   rnc.Role_Nivel_Descripcion , 
				   rnc.Registro_Estado , 
				   rnc.Registro_Fecha , 
				   rnc.Registro_Usuario
		FROM  [dbo].[Roles_Niveles_Cata]	As rnc	

		   WHERE rnc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rnc.Role_Nivel_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rnc.Role_Nivel) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rnc.Role_Nivel_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rnc.Role_Nivel_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rnc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rnc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rnc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Numero]' AND @_orderByDirection0 = 0 THEN [Role_Nivel_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Numero]' AND @_orderByDirection0 = 1 THEN [Role_Nivel_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel]' AND @_orderByDirection0 = 0 THEN [Role_Nivel]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel]' AND @_orderByDirection0 = 1 THEN [Role_Nivel]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Nombre]' AND @_orderByDirection0 = 0 THEN [Role_Nivel_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Nombre]' AND @_orderByDirection0 = 1 THEN [Role_Nivel_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Descripcion]' AND @_orderByDirection0 = 0 THEN [Role_Nivel_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Nivel_Descripcion]' AND @_orderByDirection0 = 1 THEN [Role_Nivel_Descripcion]
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


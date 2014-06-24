-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_PersonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Roles_Trans_RolesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Roles_Trans_RolesCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Secuencia  [Int] ,
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
	[dbo].[Persona_Roles_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Persona_Roles_Trans].[Persona_Secuencia] = @Persona_Secuencia AND
	[dbo].[Persona_Roles_Trans].[Role_Numero] = @Role_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Persona_Roles_Trans]
(
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Role_Numero]
)
VALUES
(
	@Persona_Secuencia,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
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
CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Borrar]
(
	@Persona_Secuencia  [Int] ,
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


  DELETE FROM [Persona_Roles_Trans]
    WHERE 
      ([Persona_Roles_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Persona_Roles_Trans].[Role_Numero] = @Role_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans]
(
	@Persona_Secuencia  [Int] ,
	@Role_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Persona_Roles_Trans].[Persona_Secuencia],
                [Persona_Roles_Trans].[Role_Numero],
                [Persona_Roles_Trans].[Registro_Estado],
                [Persona_Roles_Trans].[Registro_Fecha],
                [Persona_Roles_Trans].[Registro_Usuario]
    FROM [Persona_Roles_Trans]
    WHERE 
     ( [Persona_Roles_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Persona_Roles_Trans].[Role_Numero] = @Role_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Persona_Roles_Trans].[Persona_Secuencia],
                [Persona_Roles_Trans].[Role_Numero],
                [Persona_Roles_Trans].[Registro_Estado],
                [Persona_Roles_Trans].[Registro_Fecha],
                [Persona_Roles_Trans].[Registro_Usuario]
    FROM [Persona_Roles_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_PersonasMaster]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Persona_Roles_Trans].[Persona_Secuencia],
                [Persona_Roles_Trans].[Role_Numero],
                [Persona_Roles_Trans].[Registro_Estado],
                [Persona_Roles_Trans].[Registro_Fecha],
                [Persona_Roles_Trans].[Registro_Usuario]
    FROM [Persona_Roles_Trans]
      WHERE
        ([Persona_Roles_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_RolesCata]
(
	@Role_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Persona_Roles_Trans].[Persona_Secuencia],
                [Persona_Roles_Trans].[Role_Numero],
                [Persona_Roles_Trans].[Registro_Estado],
                [Persona_Roles_Trans].[Registro_Fecha],
                [Persona_Roles_Trans].[Registro_Usuario]
    FROM [Persona_Roles_Trans]
      WHERE
        ([Persona_Roles_Trans].[Role_Numero] = @Role_Numero)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Persona_Roles_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [prt].[Persona_Secuencia],
		                [prt].[Role_Numero]
 ) AS [RowNumber],
				   prt.Persona_Secuencia , 
				   prt.Role_Numero , 
				   prt.Registro_Estado , 
				   prt.Registro_Fecha , 
				   prt.Registro_Usuario
		FROM  [dbo].[Persona_Roles_Trans]	As prt	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = prt.Persona_Secuencia
			 Inner Join Roles_Cata As rc
			   On  rc.Role_Numero = prt.Role_Numero

		   WHERE prt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(prt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(prt.Role_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR prt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(prt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR prt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Role_Numero]' AND @_orderByDirection0 = 0 THEN [Role_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Role_Numero]' AND @_orderByDirection0 = 1 THEN [Role_Numero]
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


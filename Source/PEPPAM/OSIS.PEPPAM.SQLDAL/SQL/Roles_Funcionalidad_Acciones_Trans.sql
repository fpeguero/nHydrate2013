-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_RolesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_RolesCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_SistemasFuncionalidadesAccionesTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_SistemasFuncionalidadesAccionesTrans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_DeleteByRole]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_DeleteByRole]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Funcionalidad_Accion_Numero  [Int] ,
	@Funcionalidad_Numero  [Int] ,
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
	[dbo].[Roles_Funcionalidad_Acciones_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero AND
	[dbo].[Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero AND
	[dbo].[Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @Role_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Roles_Funcionalidad_Acciones_Trans]
(
	[Funcionalidad_Accion_Numero],
	[Funcionalidad_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Role_Numero]
)
VALUES
(
	@Funcionalidad_Accion_Numero,
	@Funcionalidad_Numero,
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
CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Borrar]
(
	@Funcionalidad_Accion_Numero  [Int] ,
	@Funcionalidad_Numero  [Int] ,
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


  DELETE FROM [Roles_Funcionalidad_Acciones_Trans]
    WHERE 
      ([Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @Role_Numero)
     AND       ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)
     AND       ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans]
(
	@Funcionalidad_Accion_Numero  [Int] ,
	@Funcionalidad_Numero  [Int] ,
	@Role_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Roles_Funcionalidad_Acciones_Trans].[Role_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Estado],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Fecha],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Usuario]
    FROM [Roles_Funcionalidad_Acciones_Trans]
    WHERE 
     ( [Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @Role_Numero)
     AND      ( [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)
     AND      ( [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Roles_Funcionalidad_Acciones_Trans].[Role_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Estado],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Fecha],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Usuario]
    FROM [Roles_Funcionalidad_Acciones_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_RolesCata]
(
	@Role_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Roles_Funcionalidad_Acciones_Trans].[Role_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Estado],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Fecha],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Usuario]
    FROM [Roles_Funcionalidad_Acciones_Trans]
      WHERE
        ([Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @Role_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_SistemasFuncionalidadesAccionesTrans]
(
	@Funcionalidad_Accion_Numero  [Int] ,
	@Funcionalidad_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Roles_Funcionalidad_Acciones_Trans].[Role_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Estado],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Fecha],
                [Roles_Funcionalidad_Acciones_Trans].[Registro_Usuario]
    FROM [Roles_Funcionalidad_Acciones_Trans]
      WHERE
        ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Numero] = @Funcionalidad_Numero)
 And 
        ([Roles_Funcionalidad_Acciones_Trans].[Funcionalidad_Accion_Numero] = @Funcionalidad_Accion_Numero)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_DeleteByRole]
(
    @Role_Numero [Int] 
)
AS

SET NOCOUNT ON
DELETE
    FROM [Roles_Funcionalidad_Acciones_Trans]
      WHERE Roles_Funcionalidad_Acciones_Trans.Registro_Estado = 'A'
      AND 
         [Roles_Funcionalidad_Acciones_Trans].[Role_Numero] = @role_numero

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Roles_Funcionalidad_Acciones_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [rfat].[Role_Numero],
		                [rfat].[Funcionalidad_Numero],
		                [rfat].[Funcionalidad_Accion_Numero]
 ) AS [RowNumber],
				   rfat.Role_Numero , 
				   rfat.Funcionalidad_Numero , 
				   rfat.Funcionalidad_Accion_Numero , 
				   rfat.Registro_Estado , 
				   rfat.Registro_Fecha , 
				   rfat.Registro_Usuario
		FROM  [dbo].[Roles_Funcionalidad_Acciones_Trans]	As rfat	
			 Inner Join Roles_Cata As rc
			   On  rc.Role_Numero = rfat.Role_Numero
			 Inner Join Sistemas_Funcionalidades_Acciones_Trans As sfat
			   On  sfat.Funcionalidad_Numero = rfat.Funcionalidad_Numero
			      And  sfat.Funcionalidad_Accion_Numero = rfat.Funcionalidad_Accion_Numero

		   WHERE rfat.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(rfat.Role_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rfat.Funcionalidad_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rfat.Funcionalidad_Accion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rfat.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(rfat.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR rfat.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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


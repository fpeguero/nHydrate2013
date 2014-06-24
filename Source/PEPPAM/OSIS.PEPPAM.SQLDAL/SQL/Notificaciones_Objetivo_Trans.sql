-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_NotificacionesMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_NotificacionesMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_RolesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_RolesCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_RutasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_RutasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Objetivo_Trans_ZonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_ZonasMaster]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Notificacion_Numero  [Int] ,
	@Role_Numero  [Int] ,
	@Ruta_Secuencia  [Int] ,
	@Zona_Secuencia  [Int] 

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
	[dbo].[Notificaciones_Objetivo_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Notificaciones_Objetivo_Trans].[Notificacion_Numero] = @Notificacion_Numero AND
	[dbo].[Notificaciones_Objetivo_Trans].[Role_Numero] = @Role_Numero AND
	[dbo].[Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = @Ruta_Secuencia AND
	[dbo].[Notificaciones_Objetivo_Trans].[Zona_Secuencia] = @Zona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Notificaciones_Objetivo_Trans]
(
	[Notificacion_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Role_Numero],
	[Ruta_Secuencia],
	[Zona_Secuencia]
)
VALUES
(
	@Notificacion_Numero,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Role_Numero,
	@Ruta_Secuencia,
	@Zona_Secuencia
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
CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Borrar]
(
	@Notificacion_Numero  [Int] ,
	@Role_Numero  [Int] ,
	@Ruta_Secuencia  [Int] ,
	@Zona_Secuencia  [Int] 

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


  DELETE FROM [Notificaciones_Objetivo_Trans]
    WHERE 
      ([Notificaciones_Objetivo_Trans].[Notificacion_Numero] = @Notificacion_Numero)
     AND       ([Notificaciones_Objetivo_Trans].[Zona_Secuencia] = @Zona_Secuencia)
     AND       ([Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)
     AND       ([Notificaciones_Objetivo_Trans].[Role_Numero] = @Role_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans]
(
	@Notificacion_Numero  [Int] ,
	@Role_Numero  [Int] ,
	@Ruta_Secuencia  [Int] ,
	@Zona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]
    WHERE 
     ( [Notificaciones_Objetivo_Trans].[Notificacion_Numero] = @Notificacion_Numero)
     AND      ( [Notificaciones_Objetivo_Trans].[Zona_Secuencia] = @Zona_Secuencia)
     AND      ( [Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)
     AND      ( [Notificaciones_Objetivo_Trans].[Role_Numero] = @Role_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_NotificacionesMaster]
(
	@Notificacion_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]
      WHERE
        ([Notificaciones_Objetivo_Trans].[Notificacion_Numero] = @Notificacion_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_RolesCata]
(
	@Role_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]
      WHERE
        ([Notificaciones_Objetivo_Trans].[Role_Numero] = @Role_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_RutasMaster]
(
	@Ruta_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]
      WHERE
        ([Notificaciones_Objetivo_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_ZonasMaster]
(
	@Zona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Objetivo_Trans].[Notificacion_Numero],
                [Notificaciones_Objetivo_Trans].[Zona_Secuencia],
                [Notificaciones_Objetivo_Trans].[Ruta_Secuencia],
                [Notificaciones_Objetivo_Trans].[Role_Numero],
                [Notificaciones_Objetivo_Trans].[Registro_Estado],
                [Notificaciones_Objetivo_Trans].[Registro_Fecha],
                [Notificaciones_Objetivo_Trans].[Registro_Usuario]
    FROM [Notificaciones_Objetivo_Trans]
      WHERE
        ([Notificaciones_Objetivo_Trans].[Zona_Secuencia] = @Zona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Notificaciones_Objetivo_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [not].[Notificacion_Numero],
		                [not].[Zona_Secuencia],
		                [not].[Ruta_Secuencia],
		                [not].[Role_Numero]
 ) AS [RowNumber],
				   not.Notificacion_Numero , 
				   not.Zona_Secuencia , 
				   not.Ruta_Secuencia , 
				   not.Role_Numero , 
				   not.Registro_Estado , 
				   not.Registro_Fecha , 
				   not.Registro_Usuario
		FROM  [dbo].[Notificaciones_Objetivo_Trans]	As not	
			 Inner Join Notificaciones_Master As nm
			   On  nm.Notificacion_Numero = not.Notificacion_Numero
			 Inner Join Roles_Cata As rc
			   On  rc.Role_Numero = not.Role_Numero
			 Inner Join Rutas_Master As rm
			   On  rm.Ruta_Secuencia = not.Ruta_Secuencia
			 Inner Join Zonas_Master As zm
			   On  zm.Zona_Secuencia = not.Zona_Secuencia

		   WHERE not.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(not.Notificacion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(not.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(not.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(not.Role_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR not.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(not.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR not.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 0 THEN [Notificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 1 THEN [Notificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Zona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Zona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
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


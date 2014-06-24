-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Notificaciones_Personas_Trans_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_PersonasMaster]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Editar]
(
	@Notificacion_Persona_Vista  [Char]  (1) = 'N',
	@Notificacion_Persona_Vista_Fecha  [DateTime] ,
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (150),
	@Notifcacion_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

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
	[dbo].[Notificaciones_Personas_Trans] 
SET
	[Notificacion_Persona_Vista] = @Notificacion_Persona_Vista,
	[Notificacion_Persona_Vista_Fecha] = @Notificacion_Persona_Vista_Fecha,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Notificaciones_Personas_Trans].[Notifcacion_Secuencia] = @Notifcacion_Secuencia AND
	[dbo].[Notificaciones_Personas_Trans].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Notificaciones_Personas_Trans]
(
	[Notifcacion_Secuencia],
	[Notificacion_Persona_Vista],
	[Notificacion_Persona_Vista_Fecha],
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Notifcacion_Secuencia,
	@Notificacion_Persona_Vista,
	@Notificacion_Persona_Vista_Fecha,
	@Persona_Secuencia,
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
CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Borrar]
(
	@Notifcacion_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

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


  DELETE FROM [Notificaciones_Personas_Trans]
    WHERE 
      ([Notificaciones_Personas_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Notificaciones_Personas_Trans].[Notifcacion_Secuencia] = @Notifcacion_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans]
(
	@Notifcacion_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Notificaciones_Personas_Trans].[Persona_Secuencia],
                [Notificaciones_Personas_Trans].[Notifcacion_Secuencia],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Estado],
                [Notificaciones_Personas_Trans].[Registro_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Usuario]
    FROM [Notificaciones_Personas_Trans]
    WHERE 
     ( [Notificaciones_Personas_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Notificaciones_Personas_Trans].[Notifcacion_Secuencia] = @Notifcacion_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Notificaciones_Personas_Trans].[Persona_Secuencia],
                [Notificaciones_Personas_Trans].[Notifcacion_Secuencia],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Estado],
                [Notificaciones_Personas_Trans].[Registro_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Usuario]
    FROM [Notificaciones_Personas_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_PersonasMaster]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Notificaciones_Personas_Trans].[Persona_Secuencia],
                [Notificaciones_Personas_Trans].[Notifcacion_Secuencia],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista],
                [Notificaciones_Personas_Trans].[Notificacion_Persona_Vista_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Estado],
                [Notificaciones_Personas_Trans].[Registro_Fecha],
                [Notificaciones_Personas_Trans].[Registro_Usuario]
    FROM [Notificaciones_Personas_Trans]
      WHERE
        ([Notificaciones_Personas_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Notificaciones_Personas_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [npt].[Persona_Secuencia],
		                [npt].[Notifcacion_Secuencia]
 ) AS [RowNumber],
				   npt.Persona_Secuencia , 
				   npt.Notifcacion_Secuencia , 
				   npt.Notificacion_Persona_Vista , 
				   npt.Notificacion_Persona_Vista_Fecha , 
				   npt.Registro_Estado , 
				   npt.Registro_Fecha , 
				   npt.Registro_Usuario
		FROM  [dbo].[Notificaciones_Personas_Trans]	As npt	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = npt.Persona_Secuencia

		   WHERE npt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(npt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(npt.Notifcacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npt.Notificacion_Persona_Vista LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(npt.Notificacion_Persona_Vista_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(npt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR npt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Notifcacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Notifcacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notifcacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Notifcacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Persona_Vista]' AND @_orderByDirection0 = 0 THEN [Notificacion_Persona_Vista]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Persona_Vista]' AND @_orderByDirection0 = 1 THEN [Notificacion_Persona_Vista]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Persona_Vista_Fecha]' AND @_orderByDirection0 = 0 THEN [Notificacion_Persona_Vista_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Persona_Vista_Fecha]' AND @_orderByDirection0 = 1 THEN [Notificacion_Persona_Vista_Fecha]
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


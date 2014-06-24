-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_Notificaciones]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Notificaciones]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Notificaciones_Trans_Personas]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Personas]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Editar]
(
	@Notificacion_Vista  [Char]  (1) = ' ',
	@Notificacion_Vista_Fecha  [DateTime] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Notificacion_Numero  [Int] ,
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
	[dbo].[Personas_Notificaciones_Trans] 
SET
	[Notificacion_Vista] = @Notificacion_Vista,
	[Notificacion_Vista_Fecha] = @Notificacion_Vista_Fecha,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Notificaciones_Trans].[Notificacion_Numero] = @Notificacion_Numero AND
	[dbo].[Personas_Notificaciones_Trans].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Notificaciones_Trans]
(
	[Notificacion_Numero],
	[Notificacion_Vista],
	[Notificacion_Vista_Fecha],
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Notificacion_Numero,
	@Notificacion_Vista,
	@Notificacion_Vista_Fecha,
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
CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Borrar]
(
	@Notificacion_Numero  [Int] ,
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


  DELETE FROM [Personas_Notificaciones_Trans]
    WHERE 
      ([Personas_Notificaciones_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Personas_Notificaciones_Trans].[Notificacion_Numero] = @Notificacion_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans]
(
	@Notificacion_Numero  [Int] ,
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Notificaciones_Trans].[Persona_Secuencia],
                [Personas_Notificaciones_Trans].[Notificacion_Numero],
                [Personas_Notificaciones_Trans].[Notificacion_Vista],
                [Personas_Notificaciones_Trans].[Notificacion_Vista_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Estado],
                [Personas_Notificaciones_Trans].[Registro_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Usuario]
    FROM [Personas_Notificaciones_Trans]
    WHERE 
     ( [Personas_Notificaciones_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Personas_Notificaciones_Trans].[Notificacion_Numero] = @Notificacion_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Notificaciones_Trans].[Persona_Secuencia],
                [Personas_Notificaciones_Trans].[Notificacion_Numero],
                [Personas_Notificaciones_Trans].[Notificacion_Vista],
                [Personas_Notificaciones_Trans].[Notificacion_Vista_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Estado],
                [Personas_Notificaciones_Trans].[Registro_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Usuario]
    FROM [Personas_Notificaciones_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Notificaciones]
(
	@Notificacion_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Notificaciones_Trans].[Persona_Secuencia],
                [Personas_Notificaciones_Trans].[Notificacion_Numero],
                [Personas_Notificaciones_Trans].[Notificacion_Vista],
                [Personas_Notificaciones_Trans].[Notificacion_Vista_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Estado],
                [Personas_Notificaciones_Trans].[Registro_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Usuario]
    FROM [Personas_Notificaciones_Trans]
      WHERE
        ([Personas_Notificaciones_Trans].[Notificacion_Numero] = @Notificacion_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Personas]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Notificaciones_Trans].[Persona_Secuencia],
                [Personas_Notificaciones_Trans].[Notificacion_Numero],
                [Personas_Notificaciones_Trans].[Notificacion_Vista],
                [Personas_Notificaciones_Trans].[Notificacion_Vista_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Estado],
                [Personas_Notificaciones_Trans].[Registro_Fecha],
                [Personas_Notificaciones_Trans].[Registro_Usuario]
    FROM [Personas_Notificaciones_Trans]
      WHERE
        ([Personas_Notificaciones_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Personas_Notificaciones_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pnt].[Persona_Secuencia],
		                [pnt].[Notificacion_Numero]
 ) AS [RowNumber],
				   pnt.Persona_Secuencia , 
				   pnt.Notificacion_Numero , 
				   pnt.Notificacion_Vista , 
				   pnt.Notificacion_Vista_Fecha , 
				   pnt.Registro_Estado , 
				   pnt.Registro_Fecha , 
				   pnt.Registro_Usuario
		FROM  [dbo].[Personas_Notificaciones_Trans]	As pnt	
			 Inner Join Notificaciones_Master As nm
			   On  nm.Notificacion_Numero = pnt.Notificacion_Numero
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = pnt.Persona_Secuencia

		   WHERE pnt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pnt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pnt.Notificacion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pnt.Notificacion_Vista LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pnt.Notificacion_Vista_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pnt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pnt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pnt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 0 THEN [Notificacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Numero]' AND @_orderByDirection0 = 1 THEN [Notificacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Vista]' AND @_orderByDirection0 = 0 THEN [Notificacion_Vista]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Vista]' AND @_orderByDirection0 = 1 THEN [Notificacion_Vista]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Vista_Fecha]' AND @_orderByDirection0 = 0 THEN [Notificacion_Vista_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Notificacion_Vista_Fecha]' AND @_orderByDirection0 = 1 THEN [Notificacion_Vista_Fecha]
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


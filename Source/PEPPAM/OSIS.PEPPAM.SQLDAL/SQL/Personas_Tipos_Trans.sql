-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_PersonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Tipos_Trans_PersonasTipoCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_PersonasTipoCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Secuencia  [Int] ,
	@Persona_Tipo_Secuencia  [Int] 

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
	[dbo].[Personas_Tipos_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Tipos_Trans].[Persona_Secuencia] = @Persona_Secuencia AND
	[dbo].[Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Tipos_Trans]
(
	[Persona_Secuencia],
	[Persona_Tipo_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Persona_Secuencia,
	@Persona_Tipo_Secuencia,
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
CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Borrar]
(
	@Persona_Secuencia  [Int] ,
	@Persona_Tipo_Secuencia  [Int] 

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


  DELETE FROM [Personas_Tipos_Trans]
    WHERE 
      ([Personas_Tipos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans]
(
	@Persona_Secuencia  [Int] ,
	@Persona_Tipo_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Tipos_Trans].[Persona_Secuencia],
                [Personas_Tipos_Trans].[Persona_Tipo_Secuencia],
                [Personas_Tipos_Trans].[Registro_Estado],
                [Personas_Tipos_Trans].[Registro_Fecha],
                [Personas_Tipos_Trans].[Registro_Usuario]
    FROM [Personas_Tipos_Trans]
    WHERE 
     ( [Personas_Tipos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Tipos_Trans].[Persona_Secuencia],
                [Personas_Tipos_Trans].[Persona_Tipo_Secuencia],
                [Personas_Tipos_Trans].[Registro_Estado],
                [Personas_Tipos_Trans].[Registro_Fecha],
                [Personas_Tipos_Trans].[Registro_Usuario]
    FROM [Personas_Tipos_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_PersonasMaster]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Tipos_Trans].[Persona_Secuencia],
                [Personas_Tipos_Trans].[Persona_Tipo_Secuencia],
                [Personas_Tipos_Trans].[Registro_Estado],
                [Personas_Tipos_Trans].[Registro_Fecha],
                [Personas_Tipos_Trans].[Registro_Usuario]
    FROM [Personas_Tipos_Trans]
      WHERE
        ([Personas_Tipos_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_PersonasTipoCata]
(
	@Persona_Tipo_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Tipos_Trans].[Persona_Secuencia],
                [Personas_Tipos_Trans].[Persona_Tipo_Secuencia],
                [Personas_Tipos_Trans].[Registro_Estado],
                [Personas_Tipos_Trans].[Registro_Fecha],
                [Personas_Tipos_Trans].[Registro_Usuario]
    FROM [Personas_Tipos_Trans]
      WHERE
        ([Personas_Tipos_Trans].[Persona_Tipo_Secuencia] = @Persona_Tipo_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Personas_Tipos_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ptt].[Persona_Secuencia],
		                [ptt].[Persona_Tipo_Secuencia]
 ) AS [RowNumber],
				   ptt.Persona_Secuencia , 
				   ptt.Persona_Tipo_Secuencia , 
				   ptt.Registro_Estado , 
				   ptt.Registro_Fecha , 
				   ptt.Registro_Usuario
		FROM  [dbo].[Personas_Tipos_Trans]	As ptt	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = ptt.Persona_Secuencia
			 Inner Join Personas_Tipo_Cata As ptc
			   On  ptc.Persona_Tipo_Secuencia = ptt.Persona_Tipo_Secuencia

		   WHERE ptt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ptt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Persona_Tipo_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Tipo_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Tipo_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Tipo_Secuencia]
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


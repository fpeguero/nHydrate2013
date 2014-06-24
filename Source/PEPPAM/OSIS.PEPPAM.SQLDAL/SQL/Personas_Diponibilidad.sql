-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_DiasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_DiasCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_HorasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_HorasCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_PersonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_PersonaSecuencia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_PersonaSecuencia]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_LoadPersona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_LoadPersona]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Diponibilidad_DeletePersona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Diponibilidad_DeletePersona]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Dia_Secuencia  [Int] ,
	@Hora_Secuencia  [Int] ,
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
	[dbo].[Personas_Diponibilidad] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Diponibilidad].[Dia_Secuencia] = @Dia_Secuencia AND
	[dbo].[Personas_Diponibilidad].[Hora_Secuencia] = @Hora_Secuencia AND
	[dbo].[Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Diponibilidad]
(
	[Dia_Secuencia],
	[Hora_Secuencia],
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Dia_Secuencia,
	@Hora_Secuencia,
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
CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Borrar]
(
	@Dia_Secuencia  [Int] ,
	@Hora_Secuencia  [Int] ,
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


  DELETE FROM [Personas_Diponibilidad]
    WHERE 
      ([Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Personas_Diponibilidad].[Dia_Secuencia] = @Dia_Secuencia)
     AND       ([Personas_Diponibilidad].[Hora_Secuencia] = @Hora_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad]
(
	@Dia_Secuencia  [Int] ,
	@Hora_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Diponibilidad].[Persona_Secuencia],
                [Personas_Diponibilidad].[Dia_Secuencia],
                [Personas_Diponibilidad].[Hora_Secuencia],
                [Personas_Diponibilidad].[Registro_Estado],
                [Personas_Diponibilidad].[Registro_Fecha],
                [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
    WHERE 
     ( [Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Personas_Diponibilidad].[Dia_Secuencia] = @Dia_Secuencia)
     AND      ( [Personas_Diponibilidad].[Hora_Secuencia] = @Hora_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Diponibilidad].[Persona_Secuencia],
                [Personas_Diponibilidad].[Dia_Secuencia],
                [Personas_Diponibilidad].[Hora_Secuencia],
                [Personas_Diponibilidad].[Registro_Estado],
                [Personas_Diponibilidad].[Registro_Fecha],
                [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_DiasCata]
(
	@Dia_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Diponibilidad].[Persona_Secuencia],
                [Personas_Diponibilidad].[Dia_Secuencia],
                [Personas_Diponibilidad].[Hora_Secuencia],
                [Personas_Diponibilidad].[Registro_Estado],
                [Personas_Diponibilidad].[Registro_Fecha],
                [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
      WHERE
        ([Personas_Diponibilidad].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_HorasCata]
(
	@Hora_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Diponibilidad].[Persona_Secuencia],
                [Personas_Diponibilidad].[Dia_Secuencia],
                [Personas_Diponibilidad].[Hora_Secuencia],
                [Personas_Diponibilidad].[Registro_Estado],
                [Personas_Diponibilidad].[Registro_Fecha],
                [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
      WHERE
        ([Personas_Diponibilidad].[Hora_Secuencia] = @Hora_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_PersonasMaster]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Diponibilidad].[Persona_Secuencia],
                [Personas_Diponibilidad].[Dia_Secuencia],
                [Personas_Diponibilidad].[Hora_Secuencia],
                [Personas_Diponibilidad].[Registro_Estado],
                [Personas_Diponibilidad].[Registro_Fecha],
                [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
      WHERE
        ([Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_PersonaSecuencia]
(
	@Persona_Secuencia  [Int] 
,
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
          [Personas_Diponibilidad].[Persona_Secuencia],
          [Personas_Diponibilidad].[Dia_Secuencia],
          [Personas_Diponibilidad].[Hora_Secuencia],
          [Personas_Diponibilidad].[Registro_Estado],
          [Personas_Diponibilidad].[Registro_Fecha],
          [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
      WHERE
        ([Personas_Diponibilidad].[Persona_Secuencia] = @Persona_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_LoadPersona]
(
    @Persona_Secuencia [Int] ,
		@PageIndex 		int = 1,
		@PageSize  		int = 1000000,
    @_orderBy0 [nvarchar] (120) = NULL,
    @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
DECLARE @StartIndex INT, @EndIndex INT

SET   @PageIndex = @PageIndex - 1
SET   @StartIndex = (@PageIndex * @PageSize) + 1
SET   @EndIndex = @StartIndex + @PageSize - 1



;WITH PagingTable AS
(
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Personas_Diponibilidad].[Persona_Secuencia],
		                [Personas_Diponibilidad].[Dia_Secuencia],
		                [Personas_Diponibilidad].[Hora_Secuencia]
 ) AS [RowNumber],

          [Personas_Diponibilidad].[Persona_Secuencia],
          [Personas_Diponibilidad].[Dia_Secuencia],
          [Personas_Diponibilidad].[Hora_Secuencia],
          [Personas_Diponibilidad].[Registro_Estado],
          [Personas_Diponibilidad].[Registro_Fecha],
          [Personas_Diponibilidad].[Registro_Usuario]
    FROM [Personas_Diponibilidad]
      WHERE Personas_Diponibilidad.Registro_Estado = 'A'
      AND 
         [Personas_Diponibilidad].[Persona_Secuencia] = @persona_secuencia
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_DeletePersona]
(
    @Persona_Secuencia [Int] 
)
AS

SET NOCOUNT ON
DELETE
    FROM [Personas_Diponibilidad]
      WHERE Personas_Diponibilidad.Registro_Estado = 'A'
      AND 
         [Personas_Diponibilidad].[Persona_Secuencia] = @persona_secuencia

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Diponibilidad_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pd].[Persona_Secuencia],
		                [pd].[Dia_Secuencia],
		                [pd].[Hora_Secuencia]
 ) AS [RowNumber],
				   pd.Persona_Secuencia , 
				   pd.Dia_Secuencia , 
				   pd.Hora_Secuencia , 
				   pd.Registro_Estado , 
				   pd.Registro_Fecha , 
				   pd.Registro_Usuario
		FROM  [dbo].[Personas_Diponibilidad]	As pd	
			 Inner Join Dias_Cata As dc
			   On  dc.Dia_Secuencia = pd.Dia_Secuencia
			 Inner Join Horas_Cata As hc
			   On  hc.Hora_Secuencia = pd.Hora_Secuencia
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = pd.Persona_Secuencia

		   WHERE pd.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pd.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pd.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pd.Hora_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pd.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pd.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pd.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Dia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Dia_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Hora_Secuencia]' AND @_orderByDirection0 = 0 THEN [Hora_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Hora_Secuencia]' AND @_orderByDirection0 = 1 THEN [Hora_Secuencia]
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


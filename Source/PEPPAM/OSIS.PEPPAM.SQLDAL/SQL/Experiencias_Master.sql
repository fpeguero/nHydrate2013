-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Experiencias_Master_PersonasTurnosTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Experiencias_Master_PersonasTurnosTrans]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Experiencias_Master_Editar]
(
	@Dia_Secuencia  [Int] ,
	@Experiencia_Contenido  [VarChar]  (8000),
	@Experiencia_Nota  [VarChar]  (8000),
	@Horario_Turno_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Experiencia_Secuencia  [Int] 

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
	[dbo].[Experiencias_Master] 
SET
	[Dia_Secuencia] = @Dia_Secuencia,
	[Experiencia_Contenido] = @Experiencia_Contenido,
	[Experiencia_Nota] = @Experiencia_Nota,
	[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia,
	[Persona_Secuencia] = @Persona_Secuencia,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Experiencias_Master].[Experiencia_Secuencia] = @Experiencia_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Experiencias_Master]
(
	[Dia_Secuencia],
	[Experiencia_Contenido],
	[Experiencia_Nota],
	[Horario_Turno_Secuencia],
	[Persona_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Dia_Secuencia,
	@Experiencia_Contenido,
	@Experiencia_Nota,
	@Horario_Turno_Secuencia,
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
    SELECT DISTINCT @Experiencia_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Experiencia_Secuencia AS 'Experiencia_Secuencia' 
        FROM [Experiencias_Master]
        WHERE ([Experiencias_Master].[Experiencia_Secuencia] = @Experiencia_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Experiencias_Master_Borrar]
(
	@Experiencia_Secuencia  [Int] 

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


  DELETE FROM [Experiencias_Master]
    WHERE 
      ([Experiencias_Master].[Experiencia_Secuencia] = @Experiencia_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Experiencias_Master]
(
	@Experiencia_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Experiencias_Master].[Experiencia_Secuencia],
                [Experiencias_Master].[Persona_Secuencia],
                [Experiencias_Master].[Horario_Turno_Secuencia],
                [Experiencias_Master].[Dia_Secuencia],
                [Experiencias_Master].[Experiencia_Contenido],
                [Experiencias_Master].[Experiencia_Nota],
                [Experiencias_Master].[Registro_Estado],
                [Experiencias_Master].[Registro_Fecha],
                [Experiencias_Master].[Registro_Usuario]
    FROM [Experiencias_Master]
    WHERE 
     ( [Experiencias_Master].[Experiencia_Secuencia] = @Experiencia_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Experiencias_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Experiencias_Master].[Experiencia_Secuencia],
                [Experiencias_Master].[Persona_Secuencia],
                [Experiencias_Master].[Horario_Turno_Secuencia],
                [Experiencias_Master].[Dia_Secuencia],
                [Experiencias_Master].[Experiencia_Contenido],
                [Experiencias_Master].[Experiencia_Nota],
                [Experiencias_Master].[Registro_Estado],
                [Experiencias_Master].[Registro_Fecha],
                [Experiencias_Master].[Registro_Usuario]
    FROM [Experiencias_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Experiencias_Master_PersonasTurnosTrans]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Experiencias_Master].[Experiencia_Secuencia],
                [Experiencias_Master].[Persona_Secuencia],
                [Experiencias_Master].[Horario_Turno_Secuencia],
                [Experiencias_Master].[Dia_Secuencia],
                [Experiencias_Master].[Experiencia_Contenido],
                [Experiencias_Master].[Experiencia_Nota],
                [Experiencias_Master].[Registro_Estado],
                [Experiencias_Master].[Registro_Fecha],
                [Experiencias_Master].[Registro_Usuario]
    FROM [Experiencias_Master]
      WHERE
        ([Experiencias_Master].[Persona_Secuencia] = @Persona_Secuencia)
 And 
        ([Experiencias_Master].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
 And 
        ([Experiencias_Master].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Experiencias_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [em].[Experiencia_Secuencia]
 ) AS [RowNumber],
				   em.Experiencia_Secuencia , 
				   em.Persona_Secuencia , 
				   em.Horario_Turno_Secuencia , 
				   em.Dia_Secuencia , 
				   em.Experiencia_Contenido , 
				   em.Experiencia_Nota , 
				   em.Registro_Estado , 
				   em.Registro_Fecha , 
				   em.Registro_Usuario
		FROM  [dbo].[Experiencias_Master]	As em	
			 Inner Join Personas_Turnos_Trans As ptt
			   On  ptt.Persona_Secuencia = em.Persona_Secuencia
			      And  ptt.Horario_Turno_Secuencia = em.Horario_Turno_Secuencia
			      And  ptt.Dia_Secuencia = em.Dia_Secuencia

		   WHERE em.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(em.Experiencia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(em.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(em.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(em.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR em.Experiencia_Contenido LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR em.Experiencia_Nota LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR em.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(em.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR em.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Experiencia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Experiencia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Experiencia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Experiencia_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turno_Secuencia]' AND @_orderByDirection0 = 0 THEN [Horario_Turno_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turno_Secuencia]' AND @_orderByDirection0 = 1 THEN [Horario_Turno_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Dia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Dia_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Experiencia_Contenido]' AND @_orderByDirection0 = 0 THEN [Experiencia_Contenido]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Experiencia_Contenido]' AND @_orderByDirection0 = 1 THEN [Experiencia_Contenido]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Experiencia_Nota]' AND @_orderByDirection0 = 0 THEN [Experiencia_Nota]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Experiencia_Nota]' AND @_orderByDirection0 = 1 THEN [Experiencia_Nota]
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


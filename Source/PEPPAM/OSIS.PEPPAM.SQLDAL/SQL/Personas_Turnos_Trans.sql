-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_Persona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Persona]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_HorarioTurnoDiasTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_HorarioTurnoDiasTrans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Personas_Turnos_Trans_LoadHorarioDia]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_LoadHorarioDia]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Editar]
(
	@Persona_Turno_HC  [Char]  (1) = 'N',
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,
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
	[dbo].[Personas_Turnos_Trans] 
SET
	[Persona_Turno_HC] = @Persona_Turno_HC,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Personas_Turnos_Trans].[Dia_Secuencia] = @Dia_Secuencia AND
	[dbo].[Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia AND
	[dbo].[Personas_Turnos_Trans].[Persona_Secuencia] = @Persona_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Personas_Turnos_Trans]
(
	[Dia_Secuencia],
	[Horario_Turno_Secuencia],
	[Persona_Secuencia],
	[Persona_Turno_HC],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Dia_Secuencia,
	@Horario_Turno_Secuencia,
	@Persona_Secuencia,
	@Persona_Turno_HC,
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
CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Borrar]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,
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

    UPDATE [Experiencias_Master] SET
     [Experiencias_Master].[Persona_Secuencia] = NULL,
     [Experiencias_Master].[Horario_Turno_Secuencia] = NULL,
     [Experiencias_Master].[Dia_Secuencia] = NULL
    WHERE     ([Experiencias_Master].[Persona_Secuencia] = @Persona_Secuencia)  And
    ([Experiencias_Master].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)  And
    ([Experiencias_Master].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Personas_Turnos_Trans]
    WHERE 
      ([Personas_Turnos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND       ([Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND       ([Personas_Turnos_Trans].[Dia_Secuencia] = @Dia_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,
	@Persona_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Personas_Turnos_Trans].[Persona_Secuencia],
                [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
                [Personas_Turnos_Trans].[Dia_Secuencia],
                [Personas_Turnos_Trans].[Persona_Turno_HC],
                [Personas_Turnos_Trans].[Registro_Estado],
                [Personas_Turnos_Trans].[Registro_Fecha],
                [Personas_Turnos_Trans].[Registro_Usuario]
    FROM [Personas_Turnos_Trans]
    WHERE 
     ( [Personas_Turnos_Trans].[Persona_Secuencia] = @Persona_Secuencia)
     AND      ( [Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND      ( [Personas_Turnos_Trans].[Dia_Secuencia] = @Dia_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Personas_Turnos_Trans].[Persona_Secuencia],
                [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
                [Personas_Turnos_Trans].[Dia_Secuencia],
                [Personas_Turnos_Trans].[Persona_Turno_HC],
                [Personas_Turnos_Trans].[Registro_Estado],
                [Personas_Turnos_Trans].[Registro_Fecha],
                [Personas_Turnos_Trans].[Registro_Usuario]
    FROM [Personas_Turnos_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Persona]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Turnos_Trans].[Persona_Secuencia],
                [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
                [Personas_Turnos_Trans].[Dia_Secuencia],
                [Personas_Turnos_Trans].[Persona_Turno_HC],
                [Personas_Turnos_Trans].[Registro_Estado],
                [Personas_Turnos_Trans].[Registro_Fecha],
                [Personas_Turnos_Trans].[Registro_Usuario]
    FROM [Personas_Turnos_Trans]
      WHERE
        ([Personas_Turnos_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_HorarioTurnoDiasTrans]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Personas_Turnos_Trans].[Persona_Secuencia],
                [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
                [Personas_Turnos_Trans].[Dia_Secuencia],
                [Personas_Turnos_Trans].[Persona_Turno_HC],
                [Personas_Turnos_Trans].[Registro_Estado],
                [Personas_Turnos_Trans].[Registro_Fecha],
                [Personas_Turnos_Trans].[Registro_Usuario]
    FROM [Personas_Turnos_Trans]
      WHERE
        ([Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
 And 
        ([Personas_Turnos_Trans].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_LoadHorarioDia]
(
    @Horario_Turno_Secuencia [Int] ,
    @Dia_Secuencia [Int] ,
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
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Personas_Turnos_Trans].[Persona_Secuencia],
		                [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
		                [Personas_Turnos_Trans].[Dia_Secuencia]
 ) AS [RowNumber],

          [Personas_Turnos_Trans].[Persona_Secuencia],
          [Personas_Turnos_Trans].[Horario_Turno_Secuencia],
          [Personas_Turnos_Trans].[Dia_Secuencia],
          [Personas_Turnos_Trans].[Persona_Turno_HC],
          [Personas_Turnos_Trans].[Registro_Estado],
          [Personas_Turnos_Trans].[Registro_Fecha],
          [Personas_Turnos_Trans].[Registro_Usuario]
    FROM [Personas_Turnos_Trans]
      WHERE Personas_Turnos_Trans.Registro_Estado = 'A'
      AND 
         [Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @horario_turno_secuencia
 AND  [Personas_Turnos_Trans].[Dia_Secuencia] = @dia_secuencia 
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Personas_Turnos_Trans_Paging]

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
		                [ptt].[Horario_Turno_Secuencia],
		                [ptt].[Dia_Secuencia]
 ) AS [RowNumber],
				   ptt.Persona_Secuencia , 
				   ptt.Horario_Turno_Secuencia , 
				   ptt.Dia_Secuencia , 
				   ptt.Persona_Turno_HC , 
				   ptt.Registro_Estado , 
				   ptt.Registro_Fecha , 
				   ptt.Registro_Usuario
		FROM  [dbo].[Personas_Turnos_Trans]	As ptt	
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = ptt.Persona_Secuencia
			 Inner Join Horario_Turno_Dias_Trans As htdt
			   On  htdt.Horario_Turno_Secuencia = ptt.Horario_Turno_Secuencia
			      And  htdt.Dia_Secuencia = ptt.Dia_Secuencia

		   WHERE ptt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ptt.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ptt.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ptt.Persona_Turno_HC LIKE '%' + @SearchString + '%') OR 
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
          WHEN @_orderBy0 = '[Persona_Turno_HC]' AND @_orderByDirection0 = 0 THEN [Persona_Turno_HC]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Turno_HC]' AND @_orderByDirection0 = 1 THEN [Persona_Turno_HC]
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


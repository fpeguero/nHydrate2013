-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_DiasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_DiasCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_HorarioTurnoTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_HorarioTurnoTrans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_DeleteHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_DeleteHorario]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Dias_Trans_LoadPuestoHorario]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_LoadPuestoHorario]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Turno_Estado  [Char]  (1) = ' ',
	@Turno_Estudios_Iniciado_Cantidad  [Int]  = 0,
	@Turno_Fecha  [DateTime] ,
	@Turno_Razon_Inactivo  [VarChar]  (500),
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] 

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
	[dbo].[Horario_Turno_Dias_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Turno_Estado] = @Turno_Estado,
	[Turno_Estudios_Iniciado_Cantidad] = @Turno_Estudios_Iniciado_Cantidad,
	[Turno_Fecha] = @Turno_Fecha,
	[Turno_Razon_Inactivo] = @Turno_Razon_Inactivo

WHERE
	[dbo].[Horario_Turno_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia AND
	[dbo].[Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horario_Turno_Dias_Trans]
(
	[Dia_Secuencia],
	[Horario_Turno_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Turno_Estado],
	[Turno_Estudios_Iniciado_Cantidad],
	[Turno_Fecha],
	[Turno_Razon_Inactivo]
)
VALUES
(
	@Dia_Secuencia,
	@Horario_Turno_Secuencia,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Turno_Estado,
	@Turno_Estudios_Iniciado_Cantidad,
	@Turno_Fecha,
	@Turno_Razon_Inactivo
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
CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Borrar]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] 

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

    UPDATE [Personas_Turnos_Trans] SET
     [Personas_Turnos_Trans].[Horario_Turno_Secuencia] = NULL,
     [Personas_Turnos_Trans].[Dia_Secuencia] = NULL
    WHERE     ([Personas_Turnos_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)  And
    ([Personas_Turnos_Trans].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Horario_Turno_Informe_Trans] SET
     [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = NULL,
     [Horario_Turno_Informe_Trans].[Dia_Secuencia] = NULL
    WHERE     ([Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)  And
    ([Horario_Turno_Informe_Trans].[Dia_Secuencia] = @Dia_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horario_Turno_Dias_Trans]
    WHERE 
      ([Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND       ([Horario_Turno_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans]
(
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Dias_Trans].[Dia_Secuencia],
                [Horario_Turno_Dias_Trans].[Turno_Fecha],
                [Horario_Turno_Dias_Trans].[Turno_Estado],
                [Horario_Turno_Dias_Trans].[Turno_Razon_Inactivo],
                [Horario_Turno_Dias_Trans].[Turno_Estudios_Iniciado_Cantidad],
                [Horario_Turno_Dias_Trans].[Registro_Estado],
                [Horario_Turno_Dias_Trans].[Registro_Fecha],
                [Horario_Turno_Dias_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Dias_Trans]
    WHERE 
     ( [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND      ( [Horario_Turno_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Dias_Trans].[Dia_Secuencia],
                [Horario_Turno_Dias_Trans].[Turno_Fecha],
                [Horario_Turno_Dias_Trans].[Turno_Estado],
                [Horario_Turno_Dias_Trans].[Turno_Razon_Inactivo],
                [Horario_Turno_Dias_Trans].[Turno_Estudios_Iniciado_Cantidad],
                [Horario_Turno_Dias_Trans].[Registro_Estado],
                [Horario_Turno_Dias_Trans].[Registro_Fecha],
                [Horario_Turno_Dias_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Dias_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_DiasCata]
(
	@Dia_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Dias_Trans].[Dia_Secuencia],
                [Horario_Turno_Dias_Trans].[Turno_Fecha],
                [Horario_Turno_Dias_Trans].[Turno_Estado],
                [Horario_Turno_Dias_Trans].[Turno_Razon_Inactivo],
                [Horario_Turno_Dias_Trans].[Turno_Estudios_Iniciado_Cantidad],
                [Horario_Turno_Dias_Trans].[Registro_Estado],
                [Horario_Turno_Dias_Trans].[Registro_Fecha],
                [Horario_Turno_Dias_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Dias_Trans]
      WHERE
        ([Horario_Turno_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_HorarioTurnoTrans]
(
	@Horario_Turno_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Dias_Trans].[Dia_Secuencia],
                [Horario_Turno_Dias_Trans].[Turno_Fecha],
                [Horario_Turno_Dias_Trans].[Turno_Estado],
                [Horario_Turno_Dias_Trans].[Turno_Razon_Inactivo],
                [Horario_Turno_Dias_Trans].[Turno_Estudios_Iniciado_Cantidad],
                [Horario_Turno_Dias_Trans].[Registro_Estado],
                [Horario_Turno_Dias_Trans].[Registro_Fecha],
                [Horario_Turno_Dias_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Dias_Trans]
      WHERE
        ([Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_DeleteHorario]
(
    @Horario_Turno_Secuencia [Int] 
)
AS

SET NOCOUNT ON
DELETE
    FROM [Horario_Turno_Dias_Trans]
      WHERE Horario_Turno_Dias_Trans.Registro_Estado = 'A'
      AND 
         [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @horario_turno_secuencia

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_LoadPuestoHorario]
(
    @Puesto_Numero [int] ,
    @Horario_Secuencia [int] ,
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
SELECT 				ROW_NUMBER() OVER ( ORDER BY 		                [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
		                [Horario_Turno_Dias_Trans].[Dia_Secuencia]
 ) AS [RowNumber],

          [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia],
          [Horario_Turno_Dias_Trans].[Dia_Secuencia],
          [Horario_Turno_Dias_Trans].[Turno_Fecha],
          [Horario_Turno_Dias_Trans].[Turno_Estado],
          [Horario_Turno_Dias_Trans].[Turno_Razon_Inactivo],
          [Horario_Turno_Dias_Trans].[Turno_Estudios_Iniciado_Cantidad],
          [Horario_Turno_Dias_Trans].[Registro_Estado],
          [Horario_Turno_Dias_Trans].[Registro_Fecha],
          [Horario_Turno_Dias_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Dias_Trans]
		LEFT OUTER JOIN [Horario_Turno_Trans]
			On              [Horario_Turno_Trans].[Horario_Turno_Secuencia] =  [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia]
		LEFT OUTER JOIN [Horario_Trans]
			On              [Horario_Trans].[Horario_Secuencia] =  [Horario_Turno_Trans].[Horario_Secuencia]
		LEFT OUTER JOIN [Horario_Turno_Trans]
			On              [Horario_Turno_Trans].[Horario_Turno_Secuencia] =  [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia]
		LEFT OUTER JOIN [Horario_Trans]
			On              [Horario_Trans].[Horario_Secuencia] =  [Horario_Turno_Trans].[Horario_Secuencia]
      WHERE Horario_Turno_Dias_Trans.Registro_Estado = 'A'
      AND 
         [Horario_Trans].[Horario_Secuencia] = @horario_secuencia
 AND  [Horario_Trans].[Ruta_Secuencia] = @puesto_numero
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Dias_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [htdt].[Horario_Turno_Secuencia],
		                [htdt].[Dia_Secuencia]
 ) AS [RowNumber],
				   htdt.Horario_Turno_Secuencia , 
				   htdt.Dia_Secuencia , 
				   htdt.Turno_Fecha , 
				   htdt.Turno_Estado , 
				   htdt.Turno_Razon_Inactivo , 
				   htdt.Turno_Estudios_Iniciado_Cantidad , 
				   htdt.Registro_Estado , 
				   htdt.Registro_Fecha , 
				   htdt.Registro_Usuario
		FROM  [dbo].[Horario_Turno_Dias_Trans]	As htdt	
			 Inner Join Dias_Cata As dc
			   On  dc.Dia_Secuencia = htdt.Dia_Secuencia
			 Inner Join Horario_Turno_Trans As htt
			   On  htt.Horario_Turno_Secuencia = htdt.Horario_Turno_Secuencia

		   WHERE htdt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(htdt.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htdt.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htdt.Turno_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Turno_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Turno_Razon_Inactivo LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htdt.Turno_Estudios_Iniciado_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htdt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htdt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
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
          WHEN @_orderBy0 = '[Turno_Fecha]' AND @_orderByDirection0 = 0 THEN [Turno_Fecha]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Fecha]' AND @_orderByDirection0 = 1 THEN [Turno_Fecha]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estado]' AND @_orderByDirection0 = 0 THEN [Turno_Estado]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estado]' AND @_orderByDirection0 = 1 THEN [Turno_Estado]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Razon_Inactivo]' AND @_orderByDirection0 = 0 THEN [Turno_Razon_Inactivo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Razon_Inactivo]' AND @_orderByDirection0 = 1 THEN [Turno_Razon_Inactivo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estudios_Iniciado_Cantidad]' AND @_orderByDirection0 = 0 THEN [Turno_Estudios_Iniciado_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Estudios_Iniciado_Cantidad]' AND @_orderByDirection0 = 1 THEN [Turno_Estudios_Iniciado_Cantidad]
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


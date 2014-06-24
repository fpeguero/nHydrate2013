-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_DiasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_DiasCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_TurnosMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_TurnosMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Dias_Trans_DeleteTurnos]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_DeleteTurnos]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Editar]
(
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Dia_Secuencia  [Int] ,
	@Turno_Numero  [Int] 

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
	[dbo].[Turnos_Dias_Trans] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Turnos_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia AND
	[dbo].[Turnos_Dias_Trans].[Turno_Numero] = @Turno_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Turnos_Dias_Trans]
(
	[Dia_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Turno_Numero]
)
VALUES
(
	@Dia_Secuencia,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Turno_Numero
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
CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Borrar]
(
	@Dia_Secuencia  [Int] ,
	@Turno_Numero  [Int] 

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


  DELETE FROM [Turnos_Dias_Trans]
    WHERE 
      ([Turnos_Dias_Trans].[Turno_Numero] = @Turno_Numero)
     AND       ([Turnos_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans]
(
	@Dia_Secuencia  [Int] ,
	@Turno_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Turnos_Dias_Trans].[Turno_Numero],
                [Turnos_Dias_Trans].[Dia_Secuencia],
                [Turnos_Dias_Trans].[Registro_Estado],
                [Turnos_Dias_Trans].[Registro_Fecha],
                [Turnos_Dias_Trans].[Registro_Usuario]
    FROM [Turnos_Dias_Trans]
    WHERE 
     ( [Turnos_Dias_Trans].[Turno_Numero] = @Turno_Numero)
     AND      ( [Turnos_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Turnos_Dias_Trans].[Turno_Numero],
                [Turnos_Dias_Trans].[Dia_Secuencia],
                [Turnos_Dias_Trans].[Registro_Estado],
                [Turnos_Dias_Trans].[Registro_Fecha],
                [Turnos_Dias_Trans].[Registro_Usuario]
    FROM [Turnos_Dias_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_DiasCata]
(
	@Dia_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Turnos_Dias_Trans].[Turno_Numero],
                [Turnos_Dias_Trans].[Dia_Secuencia],
                [Turnos_Dias_Trans].[Registro_Estado],
                [Turnos_Dias_Trans].[Registro_Fecha],
                [Turnos_Dias_Trans].[Registro_Usuario]
    FROM [Turnos_Dias_Trans]
      WHERE
        ([Turnos_Dias_Trans].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_TurnosMaster]
(
	@Turno_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Turnos_Dias_Trans].[Turno_Numero],
                [Turnos_Dias_Trans].[Dia_Secuencia],
                [Turnos_Dias_Trans].[Registro_Estado],
                [Turnos_Dias_Trans].[Registro_Fecha],
                [Turnos_Dias_Trans].[Registro_Usuario]
    FROM [Turnos_Dias_Trans]
      WHERE
        ([Turnos_Dias_Trans].[Turno_Numero] = @Turno_Numero)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_DeleteTurnos]
(
    @Turno_Numero [Int] 
)
AS

SET NOCOUNT ON
DELETE
    FROM [Turnos_Dias_Trans]
      WHERE Turnos_Dias_Trans.Registro_Estado = 'A'
      AND 
         [Turnos_Dias_Trans].[Turno_Numero] = @turno_numero

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Turnos_Dias_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [tdt].[Turno_Numero],
		                [tdt].[Dia_Secuencia]
 ) AS [RowNumber],
				   tdt.Turno_Numero , 
				   tdt.Dia_Secuencia , 
				   tdt.Registro_Estado , 
				   tdt.Registro_Fecha , 
				   tdt.Registro_Usuario
		FROM  [dbo].[Turnos_Dias_Trans]	As tdt	
			 Inner Join Dias_Cata As dc
			   On  dc.Dia_Secuencia = tdt.Dia_Secuencia
			 Inner Join Turnos_Master As tm
			   On  tm.Turno_Numero = tdt.Turno_Numero

		   WHERE tdt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(tdt.Turno_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tdt.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tdt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tdt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tdt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Turno_Numero]' AND @_orderByDirection0 = 0 THEN [Turno_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Numero]' AND @_orderByDirection0 = 1 THEN [Turno_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 0 THEN [Dia_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Dia_Secuencia]' AND @_orderByDirection0 = 1 THEN [Dia_Secuencia]
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


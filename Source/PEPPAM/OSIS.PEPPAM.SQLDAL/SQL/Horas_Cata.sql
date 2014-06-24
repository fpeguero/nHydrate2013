-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horas_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horas_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horas_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horas_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horas_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horas_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horas_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horas_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horas_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horas_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horas_Cata_Editar]
(
	@Hora_Desde  [VarChar]  (50),
	@Hora_Hasta  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Hora_Secuencia  [Int] 

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
	[dbo].[Horas_Cata] 
SET
	[Hora_Desde] = @Hora_Desde,
	[Hora_Hasta] = @Hora_Hasta,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Horas_Cata].[Hora_Secuencia] = @Hora_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horas_Cata]
(
	[Hora_Desde],
	[Hora_Hasta],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Hora_Desde,
	@Hora_Hasta,
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
    SELECT DISTINCT @Hora_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Hora_Secuencia AS 'Hora_Secuencia' 
        FROM [Horas_Cata]
        WHERE ([Horas_Cata].[Hora_Secuencia] = @Hora_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Horas_Cata_Borrar]
(
	@Hora_Secuencia  [Int] 

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

    UPDATE [Personas_Diponibilidad] SET
     [Personas_Diponibilidad].[Hora_Secuencia] = NULL
    WHERE     ([Personas_Diponibilidad].[Hora_Secuencia] = @Hora_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horas_Cata]
    WHERE 
      ([Horas_Cata].[Hora_Secuencia] = @Hora_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horas_Cata]
(
	@Hora_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horas_Cata].[Hora_Secuencia],
                [Horas_Cata].[Hora_Desde],
                [Horas_Cata].[Hora_Hasta],
                [Horas_Cata].[Registro_Estado],
                [Horas_Cata].[Registro_Fecha],
                [Horas_Cata].[Registro_Usuario]
    FROM [Horas_Cata]
    WHERE 
     ( [Horas_Cata].[Hora_Secuencia] = @Hora_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horas_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horas_Cata].[Hora_Secuencia],
                [Horas_Cata].[Hora_Desde],
                [Horas_Cata].[Hora_Hasta],
                [Horas_Cata].[Registro_Estado],
                [Horas_Cata].[Registro_Fecha],
                [Horas_Cata].[Registro_Usuario]
    FROM [Horas_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Horas_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [hc].[Hora_Secuencia]
 ) AS [RowNumber],
				   hc.Hora_Secuencia , 
				   hc.Hora_Desde , 
				   hc.Hora_Hasta , 
				   hc.Registro_Estado , 
				   hc.Registro_Fecha , 
				   hc.Registro_Usuario
		FROM  [dbo].[Horas_Cata]	As hc	

		   WHERE hc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(hc.Hora_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hc.Hora_Desde LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hc.Hora_Hasta LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Hora_Secuencia]' AND @_orderByDirection0 = 0 THEN [Hora_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Hora_Secuencia]' AND @_orderByDirection0 = 1 THEN [Hora_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Hora_Desde]' AND @_orderByDirection0 = 0 THEN [Hora_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Hora_Desde]' AND @_orderByDirection0 = 1 THEN [Hora_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Hora_Hasta]' AND @_orderByDirection0 = 0 THEN [Hora_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Hora_Hasta]' AND @_orderByDirection0 = 1 THEN [Hora_Hasta]
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


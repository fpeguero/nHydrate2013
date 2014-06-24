-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Semanas_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Semanas_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Semanas_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Semanas_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Semanas_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Semanas_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Editar]
(
	@Registro_Estado  [Char]  (1) = 'A',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50) = '(suser_sname())',
	@Semana_Desde  [DateTime] ,
	@Semana_Hasta  [DateTime] ,
	@Semana_Codigo  [Int] 

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
	[dbo].[Horario_Semanas_Cata] 
SET
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Semana_Desde] = @Semana_Desde,
	[Semana_Hasta] = @Semana_Hasta

WHERE
	[dbo].[Horario_Semanas_Cata].[Semana_Codigo] = @Semana_Codigo



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horario_Semanas_Cata]
(
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Semana_Codigo],
	[Semana_Desde],
	[Semana_Hasta]
)
VALUES
(
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Semana_Codigo,
	@Semana_Desde,
	@Semana_Hasta
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
CREATE PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Borrar]
(
	@Semana_Codigo  [Int] 

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

    UPDATE [Horario_Trans] SET
     [Horario_Trans].[Semana_Codigo] = NULL
    WHERE     ([Horario_Trans].[Semana_Codigo] = @Semana_Codigo)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horario_Semanas_Cata]
    WHERE 
      ([Horario_Semanas_Cata].[Semana_Codigo] = @Semana_Codigo)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Semanas_Cata]
(
	@Semana_Codigo  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horario_Semanas_Cata].[Semana_Codigo],
                [Horario_Semanas_Cata].[Semana_Desde],
                [Horario_Semanas_Cata].[Semana_Hasta],
                [Horario_Semanas_Cata].[Registro_Estado],
                [Horario_Semanas_Cata].[Registro_Fecha],
                [Horario_Semanas_Cata].[Registro_Usuario]
    FROM [Horario_Semanas_Cata]
    WHERE 
     ( [Horario_Semanas_Cata].[Semana_Codigo] = @Semana_Codigo)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horario_Semanas_Cata].[Semana_Codigo],
                [Horario_Semanas_Cata].[Semana_Desde],
                [Horario_Semanas_Cata].[Semana_Hasta],
                [Horario_Semanas_Cata].[Registro_Estado],
                [Horario_Semanas_Cata].[Registro_Fecha],
                [Horario_Semanas_Cata].[Registro_Usuario]
    FROM [Horario_Semanas_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Horario_Semanas_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [hsc].[Semana_Codigo]
 ) AS [RowNumber],
				   hsc.Semana_Codigo , 
				   hsc.Semana_Desde , 
				   hsc.Semana_Hasta , 
				   hsc.Registro_Estado , 
				   hsc.Registro_Fecha , 
				   hsc.Registro_Usuario
		FROM  [dbo].[Horario_Semanas_Cata]	As hsc	

		   WHERE hsc.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(hsc.Semana_Codigo) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hsc.Semana_Desde) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hsc.Semana_Hasta) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hsc.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hsc.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hsc.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 0 THEN [Semana_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 1 THEN [Semana_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Semana_Desde]' AND @_orderByDirection0 = 0 THEN [Semana_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Semana_Desde]' AND @_orderByDirection0 = 1 THEN [Semana_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Semana_Hasta]' AND @_orderByDirection0 = 0 THEN [Semana_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Semana_Hasta]' AND @_orderByDirection0 = 1 THEN [Semana_Hasta]
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


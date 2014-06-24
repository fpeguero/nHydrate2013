-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Trans_HorarioTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Trans_HorarioTrans]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Editar]
(
	@Horario_Secuencia  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Turno_Cantidad_Publicadores  [Int]  = 0,
	@Turno_Descripcion  [VarChar]  (50),
	@Turno_Hora_Desde  [VarChar]  (50),
	@Turno_Hora_Hasta  [VarChar]  (50),
	@Turno_Minutos_Cantidad  [Int] ,
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
	[dbo].[Horario_Turno_Trans] 
SET
	[Horario_Secuencia] = @Horario_Secuencia,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Turno_Cantidad_Publicadores] = @Turno_Cantidad_Publicadores,
	[Turno_Descripcion] = @Turno_Descripcion,
	[Turno_Hora_Desde] = @Turno_Hora_Desde,
	[Turno_Hora_Hasta] = @Turno_Hora_Hasta,
	[Turno_Minutos_Cantidad] = @Turno_Minutos_Cantidad

WHERE
	[dbo].[Horario_Turno_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horario_Turno_Trans]
(
	[Horario_Secuencia],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Turno_Cantidad_Publicadores],
	[Turno_Descripcion],
	[Turno_Hora_Desde],
	[Turno_Hora_Hasta],
	[Turno_Minutos_Cantidad]
)
VALUES
(
	@Horario_Secuencia,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Turno_Cantidad_Publicadores,
	@Turno_Descripcion,
	@Turno_Hora_Desde,
	@Turno_Hora_Hasta,
	@Turno_Minutos_Cantidad
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Horario_Turno_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Horario_Turno_Secuencia AS 'Horario_Turno_Secuencia' 
        FROM [Horario_Turno_Trans]
        WHERE ([Horario_Turno_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Borrar]
(
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

    UPDATE [Horario_Turno_Dias_Trans] SET
     [Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = NULL
    WHERE     ([Horario_Turno_Dias_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horario_Turno_Trans]
    WHERE 
      ([Horario_Turno_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans]
(
	@Horario_Turno_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horario_Turno_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Trans].[Horario_Secuencia],
                [Horario_Turno_Trans].[Turno_Descripcion],
                [Horario_Turno_Trans].[Turno_Hora_Desde],
                [Horario_Turno_Trans].[Turno_Hora_Hasta],
                [Horario_Turno_Trans].[Turno_Minutos_Cantidad],
                [Horario_Turno_Trans].[Turno_Cantidad_Publicadores],
                [Horario_Turno_Trans].[Registro_Estado],
                [Horario_Turno_Trans].[Registro_Fecha],
                [Horario_Turno_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Trans]
    WHERE 
     ( [Horario_Turno_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horario_Turno_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Trans].[Horario_Secuencia],
                [Horario_Turno_Trans].[Turno_Descripcion],
                [Horario_Turno_Trans].[Turno_Hora_Desde],
                [Horario_Turno_Trans].[Turno_Hora_Hasta],
                [Horario_Turno_Trans].[Turno_Minutos_Cantidad],
                [Horario_Turno_Trans].[Turno_Cantidad_Publicadores],
                [Horario_Turno_Trans].[Registro_Estado],
                [Horario_Turno_Trans].[Registro_Fecha],
                [Horario_Turno_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans_HorarioTrans]
(
	@Horario_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Trans].[Horario_Secuencia],
                [Horario_Turno_Trans].[Turno_Descripcion],
                [Horario_Turno_Trans].[Turno_Hora_Desde],
                [Horario_Turno_Trans].[Turno_Hora_Hasta],
                [Horario_Turno_Trans].[Turno_Minutos_Cantidad],
                [Horario_Turno_Trans].[Turno_Cantidad_Publicadores],
                [Horario_Turno_Trans].[Registro_Estado],
                [Horario_Turno_Trans].[Registro_Fecha],
                [Horario_Turno_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Trans]
      WHERE
        ([Horario_Turno_Trans].[Horario_Secuencia] = @Horario_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [htt].[Horario_Turno_Secuencia]
 ) AS [RowNumber],
				   htt.Horario_Turno_Secuencia , 
				   htt.Horario_Secuencia , 
				   htt.Turno_Descripcion , 
				   htt.Turno_Hora_Desde , 
				   htt.Turno_Hora_Hasta , 
				   htt.Turno_Minutos_Cantidad , 
				   htt.Turno_Cantidad_Publicadores , 
				   htt.Registro_Estado , 
				   htt.Registro_Fecha , 
				   htt.Registro_Usuario
		FROM  [dbo].[Horario_Turno_Trans]	As htt	
			 Inner Join Horario_Trans As ht
			   On  ht.Horario_Secuencia = htt.Horario_Secuencia

		   WHERE htt.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(htt.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htt.Horario_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Hora_Desde LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Turno_Hora_Hasta LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htt.Turno_Minutos_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htt.Turno_Cantidad_Publicadores) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htt.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htt.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 0 THEN [Horario_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 1 THEN [Horario_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Descripcion]' AND @_orderByDirection0 = 0 THEN [Turno_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Descripcion]' AND @_orderByDirection0 = 1 THEN [Turno_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Desde]' AND @_orderByDirection0 = 0 THEN [Turno_Hora_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Desde]' AND @_orderByDirection0 = 1 THEN [Turno_Hora_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Hasta]' AND @_orderByDirection0 = 0 THEN [Turno_Hora_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Hora_Hasta]' AND @_orderByDirection0 = 1 THEN [Turno_Hora_Hasta]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Minutos_Cantidad]' AND @_orderByDirection0 = 0 THEN [Turno_Minutos_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Minutos_Cantidad]' AND @_orderByDirection0 = 1 THEN [Turno_Minutos_Cantidad]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Turno_Cantidad_Publicadores]' AND @_orderByDirection0 = 0 THEN [Turno_Cantidad_Publicadores]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Turno_Cantidad_Publicadores]' AND @_orderByDirection0 = 1 THEN [Turno_Cantidad_Publicadores]
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


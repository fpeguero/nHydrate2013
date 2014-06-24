-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Turnos_Master_HorariosMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Turnos_Master_HorariosMaster]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Turnos_Master_Editar]
(
	@Horario_Numero  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Turno_Cantidad_Publicadores  [Int]  = 0,
	@Turno_Descripcion  [VarChar]  (50),
	@Turno_Hora_Desde  [VarChar]  (50),
	@Turno_Hora_Hasta  [VarChar]  (50),
	@Turno_Minutos_Cantidad  [Int] ,
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
	[dbo].[Turnos_Master] 
SET
	[Horario_Numero] = @Horario_Numero,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Turno_Cantidad_Publicadores] = @Turno_Cantidad_Publicadores,
	[Turno_Descripcion] = @Turno_Descripcion,
	[Turno_Hora_Desde] = @Turno_Hora_Desde,
	[Turno_Hora_Hasta] = @Turno_Hora_Hasta,
	[Turno_Minutos_Cantidad] = @Turno_Minutos_Cantidad

WHERE
	[dbo].[Turnos_Master].[Turno_Numero] = @Turno_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Turnos_Master]
(
	[Horario_Numero],
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
	@Horario_Numero,
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
    SELECT DISTINCT @Turno_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Turno_Numero AS 'Turno_Numero' 
        FROM [Turnos_Master]
        WHERE ([Turnos_Master].[Turno_Numero] = @Turno_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Turnos_Master_Borrar]
(
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

    UPDATE [Turnos_Dias_Trans] SET
     [Turnos_Dias_Trans].[Turno_Numero] = NULL
    WHERE     ([Turnos_Dias_Trans].[Turno_Numero] = @Turno_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Turnos_Master]
    WHERE 
      ([Turnos_Master].[Turno_Numero] = @Turno_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Turnos_Master]
(
	@Turno_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Turnos_Master].[Turno_Numero],
                [Turnos_Master].[Horario_Numero],
                [Turnos_Master].[Turno_Descripcion],
                [Turnos_Master].[Turno_Hora_Desde],
                [Turnos_Master].[Turno_Hora_Hasta],
                [Turnos_Master].[Turno_Minutos_Cantidad],
                [Turnos_Master].[Turno_Cantidad_Publicadores],
                [Turnos_Master].[Registro_Estado],
                [Turnos_Master].[Registro_Fecha],
                [Turnos_Master].[Registro_Usuario]
    FROM [Turnos_Master]
    WHERE 
     ( [Turnos_Master].[Turno_Numero] = @Turno_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Turnos_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Turnos_Master].[Turno_Numero],
                [Turnos_Master].[Horario_Numero],
                [Turnos_Master].[Turno_Descripcion],
                [Turnos_Master].[Turno_Hora_Desde],
                [Turnos_Master].[Turno_Hora_Hasta],
                [Turnos_Master].[Turno_Minutos_Cantidad],
                [Turnos_Master].[Turno_Cantidad_Publicadores],
                [Turnos_Master].[Registro_Estado],
                [Turnos_Master].[Registro_Fecha],
                [Turnos_Master].[Registro_Usuario]
    FROM [Turnos_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Turnos_Master_HorariosMaster]
(
	@Horario_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Turnos_Master].[Turno_Numero],
                [Turnos_Master].[Horario_Numero],
                [Turnos_Master].[Turno_Descripcion],
                [Turnos_Master].[Turno_Hora_Desde],
                [Turnos_Master].[Turno_Hora_Hasta],
                [Turnos_Master].[Turno_Minutos_Cantidad],
                [Turnos_Master].[Turno_Cantidad_Publicadores],
                [Turnos_Master].[Registro_Estado],
                [Turnos_Master].[Registro_Fecha],
                [Turnos_Master].[Registro_Usuario]
    FROM [Turnos_Master]
      WHERE
        ([Turnos_Master].[Horario_Numero] = @Horario_Numero)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Turnos_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [tm].[Turno_Numero]
 ) AS [RowNumber],
				   tm.Turno_Numero , 
				   tm.Horario_Numero , 
				   tm.Turno_Descripcion , 
				   tm.Turno_Hora_Desde , 
				   tm.Turno_Hora_Hasta , 
				   tm.Turno_Minutos_Cantidad , 
				   tm.Turno_Cantidad_Publicadores , 
				   tm.Registro_Estado , 
				   tm.Registro_Fecha , 
				   tm.Registro_Usuario
		FROM  [dbo].[Turnos_Master]	As tm	
			 Inner Join Horarios_Master As hm
			   On  hm.Horario_Numero = tm.Horario_Numero

		   WHERE tm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(tm.Turno_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tm.Horario_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tm.Turno_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tm.Turno_Hora_Desde LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tm.Turno_Hora_Hasta LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tm.Turno_Minutos_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tm.Turno_Cantidad_Publicadores) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(tm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR tm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 0 THEN [Horario_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 1 THEN [Horario_Numero]
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


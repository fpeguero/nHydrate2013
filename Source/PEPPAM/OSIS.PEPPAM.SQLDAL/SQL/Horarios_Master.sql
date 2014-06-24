-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horarios_Master_RutasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horarios_Master_RutasMaster]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horarios_Master_Editar]
(
	@Horario_Cantidad_Dias  [Int] ,
	@Horario_Descripcion  [VarChar]  (50),
	@Horario_Turnos_Cantidad  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Ruta_Secuencia  [Int] ,
	@Horario_Numero  [Int] 

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
	[dbo].[Horarios_Master] 
SET
	[Horario_Cantidad_Dias] = @Horario_Cantidad_Dias,
	[Horario_Descripcion] = @Horario_Descripcion,
	[Horario_Turnos_Cantidad] = @Horario_Turnos_Cantidad,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Ruta_Secuencia] = @Ruta_Secuencia

WHERE
	[dbo].[Horarios_Master].[Horario_Numero] = @Horario_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horarios_Master]
(
	[Horario_Cantidad_Dias],
	[Horario_Descripcion],
	[Horario_Turnos_Cantidad],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Ruta_Secuencia]
)
VALUES
(
	@Horario_Cantidad_Dias,
	@Horario_Descripcion,
	@Horario_Turnos_Cantidad,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Ruta_Secuencia
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Horario_Numero = SCOPE_IDENTITY() 
    SELECT DISTINCT @Horario_Numero AS 'Horario_Numero' 
        FROM [Horarios_Master]
        WHERE ([Horarios_Master].[Horario_Numero] = @Horario_Numero)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Horarios_Master_Borrar]
(
	@Horario_Numero  [Int] 

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
     [Horario_Trans].[Horario_Numero] = NULL
    WHERE     ([Horario_Trans].[Horario_Numero] = @Horario_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END

    UPDATE [Turnos_Master] SET
     [Turnos_Master].[Horario_Numero] = NULL
    WHERE     ([Turnos_Master].[Horario_Numero] = @Horario_Numero)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horarios_Master]
    WHERE 
      ([Horarios_Master].[Horario_Numero] = @Horario_Numero)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horarios_Master]
(
	@Horario_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horarios_Master].[Horario_Numero],
                [Horarios_Master].[Ruta_Secuencia],
                [Horarios_Master].[Horario_Descripcion],
                [Horarios_Master].[Horario_Cantidad_Dias],
                [Horarios_Master].[Horario_Turnos_Cantidad],
                [Horarios_Master].[Registro_Estado],
                [Horarios_Master].[Registro_Fecha],
                [Horarios_Master].[Registro_Usuario]
    FROM [Horarios_Master]
    WHERE 
     ( [Horarios_Master].[Horario_Numero] = @Horario_Numero)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horarios_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horarios_Master].[Horario_Numero],
                [Horarios_Master].[Ruta_Secuencia],
                [Horarios_Master].[Horario_Descripcion],
                [Horarios_Master].[Horario_Cantidad_Dias],
                [Horarios_Master].[Horario_Turnos_Cantidad],
                [Horarios_Master].[Registro_Estado],
                [Horarios_Master].[Registro_Fecha],
                [Horarios_Master].[Registro_Usuario]
    FROM [Horarios_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horarios_Master_RutasMaster]
(
	@Ruta_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horarios_Master].[Horario_Numero],
                [Horarios_Master].[Ruta_Secuencia],
                [Horarios_Master].[Horario_Descripcion],
                [Horarios_Master].[Horario_Cantidad_Dias],
                [Horarios_Master].[Horario_Turnos_Cantidad],
                [Horarios_Master].[Registro_Estado],
                [Horarios_Master].[Registro_Fecha],
                [Horarios_Master].[Registro_Usuario]
    FROM [Horarios_Master]
      WHERE
        ([Horarios_Master].[Ruta_Secuencia] = @Ruta_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Horarios_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [hm].[Horario_Numero]
 ) AS [RowNumber],
				   hm.Horario_Numero , 
				   hm.Ruta_Secuencia , 
				   hm.Horario_Descripcion , 
				   hm.Horario_Cantidad_Dias , 
				   hm.Horario_Turnos_Cantidad , 
				   hm.Registro_Estado , 
				   hm.Registro_Fecha , 
				   hm.Registro_Usuario
		FROM  [dbo].[Horarios_Master]	As hm	
			 Inner Join Rutas_Master As rm
			   On  rm.Ruta_Secuencia = hm.Ruta_Secuencia

		   WHERE hm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(hm.Horario_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hm.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hm.Horario_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hm.Horario_Cantidad_Dias) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hm.Horario_Turnos_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(hm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR hm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 0 THEN [Horario_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 1 THEN [Horario_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Descripcion]' AND @_orderByDirection0 = 0 THEN [Horario_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Descripcion]' AND @_orderByDirection0 = 1 THEN [Horario_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Cantidad_Dias]' AND @_orderByDirection0 = 0 THEN [Horario_Cantidad_Dias]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Cantidad_Dias]' AND @_orderByDirection0 = 1 THEN [Horario_Cantidad_Dias]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turnos_Cantidad]' AND @_orderByDirection0 = 0 THEN [Horario_Turnos_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Turnos_Cantidad]' AND @_orderByDirection0 = 1 THEN [Horario_Turnos_Cantidad]
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


-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_HorariosMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_HorariosMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_RutasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_RutasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Trans_HorarioSemanasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Trans_HorarioSemanasCata]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horario_Trans_Editar]
(
	@Horario_Fecha_Desde  [DateTime] ,
	@Horario_Fecha_Hasta  [DateTime] ,
	@Horario_Numero  [Int]  = null,
	@Horario_Publicar  [Char]  (1) = 'S',
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Ruta_Secuencia  [Int] ,
	@Semana_Codigo  [Int] ,
	@Horario_Secuencia  [Int] 

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
	[dbo].[Horario_Trans] 
SET
	[Horario_Fecha_Desde] = @Horario_Fecha_Desde,
	[Horario_Fecha_Hasta] = @Horario_Fecha_Hasta,
	[Horario_Numero] = @Horario_Numero,
	[Horario_Publicar] = @Horario_Publicar,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Ruta_Secuencia] = @Ruta_Secuencia,
	[Semana_Codigo] = @Semana_Codigo

WHERE
	[dbo].[Horario_Trans].[Horario_Secuencia] = @Horario_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horario_Trans]
(
	[Horario_Fecha_Desde],
	[Horario_Fecha_Hasta],
	[Horario_Numero],
	[Horario_Publicar],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Ruta_Secuencia],
	[Semana_Codigo]
)
VALUES
(
	@Horario_Fecha_Desde,
	@Horario_Fecha_Hasta,
	@Horario_Numero,
	@Horario_Publicar,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Ruta_Secuencia,
	@Semana_Codigo
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Horario_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Horario_Secuencia AS 'Horario_Secuencia' 
        FROM [Horario_Trans]
        WHERE ([Horario_Trans].[Horario_Secuencia] = @Horario_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Horario_Trans_Borrar]
(
	@Horario_Secuencia  [Int] 

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

    UPDATE [Horario_Turno_Trans] SET
     [Horario_Turno_Trans].[Horario_Secuencia] = NULL
    WHERE     ([Horario_Turno_Trans].[Horario_Secuencia] = @Horario_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Horario_Trans]
    WHERE 
      ([Horario_Trans].[Horario_Secuencia] = @Horario_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Trans]
(
	@Horario_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horario_Trans].[Horario_Secuencia],
                [Horario_Trans].[Ruta_Secuencia],
                [Horario_Trans].[Horario_Numero],
                [Horario_Trans].[Semana_Codigo],
                [Horario_Trans].[Horario_Fecha_Desde],
                [Horario_Trans].[Horario_Fecha_Hasta],
                [Horario_Trans].[Horario_Publicar],
                [Horario_Trans].[Registro_Estado],
                [Horario_Trans].[Registro_Fecha],
                [Horario_Trans].[Registro_Usuario]
    FROM [Horario_Trans]
    WHERE 
     ( [Horario_Trans].[Horario_Secuencia] = @Horario_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horario_Trans].[Horario_Secuencia],
                [Horario_Trans].[Ruta_Secuencia],
                [Horario_Trans].[Horario_Numero],
                [Horario_Trans].[Semana_Codigo],
                [Horario_Trans].[Horario_Fecha_Desde],
                [Horario_Trans].[Horario_Fecha_Hasta],
                [Horario_Trans].[Horario_Publicar],
                [Horario_Trans].[Registro_Estado],
                [Horario_Trans].[Registro_Fecha],
                [Horario_Trans].[Registro_Usuario]
    FROM [Horario_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Trans_HorariosMaster]
(
	@Horario_Numero  [Int]  = null,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Trans].[Horario_Secuencia],
                [Horario_Trans].[Ruta_Secuencia],
                [Horario_Trans].[Horario_Numero],
                [Horario_Trans].[Semana_Codigo],
                [Horario_Trans].[Horario_Fecha_Desde],
                [Horario_Trans].[Horario_Fecha_Hasta],
                [Horario_Trans].[Horario_Publicar],
                [Horario_Trans].[Registro_Estado],
                [Horario_Trans].[Registro_Fecha],
                [Horario_Trans].[Registro_Usuario]
    FROM [Horario_Trans]
      WHERE
        ([Horario_Trans].[Horario_Numero] = @Horario_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Trans_RutasMaster]
(
	@Ruta_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Trans].[Horario_Secuencia],
                [Horario_Trans].[Ruta_Secuencia],
                [Horario_Trans].[Horario_Numero],
                [Horario_Trans].[Semana_Codigo],
                [Horario_Trans].[Horario_Fecha_Desde],
                [Horario_Trans].[Horario_Fecha_Hasta],
                [Horario_Trans].[Horario_Publicar],
                [Horario_Trans].[Registro_Estado],
                [Horario_Trans].[Registro_Fecha],
                [Horario_Trans].[Registro_Usuario]
    FROM [Horario_Trans]
      WHERE
        ([Horario_Trans].[Ruta_Secuencia] = @Ruta_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Trans_HorarioSemanasCata]
(
	@Semana_Codigo  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Trans].[Horario_Secuencia],
                [Horario_Trans].[Ruta_Secuencia],
                [Horario_Trans].[Horario_Numero],
                [Horario_Trans].[Semana_Codigo],
                [Horario_Trans].[Horario_Fecha_Desde],
                [Horario_Trans].[Horario_Fecha_Hasta],
                [Horario_Trans].[Horario_Publicar],
                [Horario_Trans].[Registro_Estado],
                [Horario_Trans].[Registro_Fecha],
                [Horario_Trans].[Registro_Usuario]
    FROM [Horario_Trans]
      WHERE
        ([Horario_Trans].[Semana_Codigo] = @Semana_Codigo)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Horario_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [ht].[Horario_Secuencia]
 ) AS [RowNumber],
				   ht.Horario_Secuencia , 
				   ht.Ruta_Secuencia , 
				   ht.Horario_Numero , 
				   ht.Semana_Codigo , 
				   ht.Horario_Fecha_Desde , 
				   ht.Horario_Fecha_Hasta , 
				   ht.Horario_Publicar , 
				   ht.Registro_Estado , 
				   ht.Registro_Fecha , 
				   ht.Registro_Usuario
		FROM  [dbo].[Horario_Trans]	As ht	
			 Inner Join Horarios_Master As hm
			   On  hm.Horario_Numero = ht.Horario_Numero
			 Inner Join Rutas_Master As rm
			   On  rm.Ruta_Secuencia = ht.Ruta_Secuencia
			 Inner Join Horario_Semanas_Cata As hsc
			   On  hsc.Semana_Codigo = ht.Semana_Codigo

		   WHERE ht.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(ht.Horario_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Ruta_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Semana_Codigo) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Fecha_Desde) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Horario_Fecha_Hasta) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ht.Horario_Publicar LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ht.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(ht.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR ht.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 0 THEN [Horario_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Secuencia]' AND @_orderByDirection0 = 1 THEN [Horario_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 0 THEN [Ruta_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Ruta_Secuencia]' AND @_orderByDirection0 = 1 THEN [Ruta_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 0 THEN [Horario_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Numero]' AND @_orderByDirection0 = 1 THEN [Horario_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 0 THEN [Semana_Codigo]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Semana_Codigo]' AND @_orderByDirection0 = 1 THEN [Semana_Codigo]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Desde]' AND @_orderByDirection0 = 0 THEN [Horario_Fecha_Desde]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Desde]' AND @_orderByDirection0 = 1 THEN [Horario_Fecha_Desde]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Hasta]' AND @_orderByDirection0 = 0 THEN [Horario_Fecha_Hasta]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Fecha_Hasta]' AND @_orderByDirection0 = 1 THEN [Horario_Fecha_Hasta]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Horario_Publicar]' AND @_orderByDirection0 = 0 THEN [Horario_Publicar]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Horario_Publicar]' AND @_orderByDirection0 = 1 THEN [Horario_Publicar]
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


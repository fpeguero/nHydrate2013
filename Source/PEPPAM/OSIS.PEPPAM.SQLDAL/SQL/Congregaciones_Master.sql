-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_Circuito]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_Circuito]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Congregaciones_Master_Zona]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Congregaciones_Master_Zona]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_Editar]
(
	@Circuito_Numero  [Int] ,
	@Congregacion_Direccion  [VarChar]  (150),
	@Congregacion_Nombre  [VarChar]  (50),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Zona_Secuencia  [Int] ,
	@Congregacion_Secuencia  [Int] 

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
	[dbo].[Congregaciones_Master] 
SET
	[Circuito_Numero] = @Circuito_Numero,
	[Congregacion_Direccion] = @Congregacion_Direccion,
	[Congregacion_Nombre] = @Congregacion_Nombre,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario,
	[Zona_Secuencia] = @Zona_Secuencia

WHERE
	[dbo].[Congregaciones_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Congregaciones_Master]
(
	[Circuito_Numero],
	[Congregacion_Direccion],
	[Congregacion_Nombre],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario],
	[Zona_Secuencia]
)
VALUES
(
	@Circuito_Numero,
	@Congregacion_Direccion,
	@Congregacion_Nombre,
	@Registro_Estado,
	@Registro_Fecha,
	@Registro_Usuario,
	@Zona_Secuencia
);




    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
    IF(@error != 0)
    BEGIN
        IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
    END
    SELECT DISTINCT @Congregacion_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Congregacion_Secuencia AS 'Congregacion_Secuencia' 
        FROM [Congregaciones_Master]
        WHERE ([Congregaciones_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_Borrar]
(
	@Congregacion_Secuencia  [Int] 

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

    UPDATE [Personas_Master] SET
     [Personas_Master].[Congregacion_Secuencia] = NULL
    WHERE     ([Personas_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Congregaciones_Master]
    WHERE 
      ([Congregaciones_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master]
(
	@Congregacion_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Congregaciones_Master].[Congregacion_Secuencia],
                [Congregaciones_Master].[Circuito_Numero],
                [Congregaciones_Master].[Zona_Secuencia],
                [Congregaciones_Master].[Congregacion_Nombre],
                [Congregaciones_Master].[Congregacion_Direccion],
                [Congregaciones_Master].[Registro_Estado],
                [Congregaciones_Master].[Registro_Fecha],
                [Congregaciones_Master].[Registro_Usuario]
    FROM [Congregaciones_Master]
    WHERE 
     ( [Congregaciones_Master].[Congregacion_Secuencia] = @Congregacion_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Congregaciones_Master].[Congregacion_Secuencia],
                [Congregaciones_Master].[Circuito_Numero],
                [Congregaciones_Master].[Zona_Secuencia],
                [Congregaciones_Master].[Congregacion_Nombre],
                [Congregaciones_Master].[Congregacion_Direccion],
                [Congregaciones_Master].[Registro_Estado],
                [Congregaciones_Master].[Registro_Fecha],
                [Congregaciones_Master].[Registro_Usuario]
    FROM [Congregaciones_Master]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_Circuito]
(
	@Circuito_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Congregaciones_Master].[Congregacion_Secuencia],
                [Congregaciones_Master].[Circuito_Numero],
                [Congregaciones_Master].[Zona_Secuencia],
                [Congregaciones_Master].[Congregacion_Nombre],
                [Congregaciones_Master].[Congregacion_Direccion],
                [Congregaciones_Master].[Registro_Estado],
                [Congregaciones_Master].[Registro_Fecha],
                [Congregaciones_Master].[Registro_Usuario]
    FROM [Congregaciones_Master]
      WHERE
        ([Congregaciones_Master].[Circuito_Numero] = @Circuito_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_Zona]
(
	@Zona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Congregaciones_Master].[Congregacion_Secuencia],
                [Congregaciones_Master].[Circuito_Numero],
                [Congregaciones_Master].[Zona_Secuencia],
                [Congregaciones_Master].[Congregacion_Nombre],
                [Congregaciones_Master].[Congregacion_Direccion],
                [Congregaciones_Master].[Registro_Estado],
                [Congregaciones_Master].[Registro_Fecha],
                [Congregaciones_Master].[Registro_Usuario]
    FROM [Congregaciones_Master]
      WHERE
        ([Congregaciones_Master].[Zona_Secuencia] = @Zona_Secuencia)


RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Congregaciones_Master_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [cm].[Congregacion_Secuencia]
 ) AS [RowNumber],
				   cm.Congregacion_Secuencia , 
				   cm.Circuito_Numero , 
				   cm.Zona_Secuencia , 
				   cm.Congregacion_Nombre , 
				   cm.Congregacion_Direccion , 
				   cm.Registro_Estado , 
				   cm.Registro_Fecha , 
				   cm.Registro_Usuario
		FROM  [dbo].[Congregaciones_Master]	As cm	
			 Inner Join Circuitos_Cata As cc
			   On  cc.Circuito_Numero = cm.Circuito_Numero
			 Inner Join Zonas_Master As zm
			   On  zm.Zona_Secuencia = cm.Zona_Secuencia

		   WHERE cm.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(cm.Congregacion_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(cm.Circuito_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(cm.Zona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm.Congregacion_Nombre LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm.Congregacion_Direccion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(cm.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR cm.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 0 THEN [Congregacion_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Secuencia]' AND @_orderByDirection0 = 1 THEN [Congregacion_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Circuito_Numero]' AND @_orderByDirection0 = 0 THEN [Circuito_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Circuito_Numero]' AND @_orderByDirection0 = 1 THEN [Circuito_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Zona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Zona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Zona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 0 THEN [Congregacion_Nombre]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Nombre]' AND @_orderByDirection0 = 1 THEN [Congregacion_Nombre]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Direccion]' AND @_orderByDirection0 = 0 THEN [Congregacion_Direccion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Congregacion_Direccion]' AND @_orderByDirection0 = 1 THEN [Congregacion_Direccion]
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


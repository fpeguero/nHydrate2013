-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Estado_Cata_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Estado_Cata_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Estado_Cata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Estado_Cata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Estado_Cata_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Estado_Cata_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Persona_Estado_Cata_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Paging]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Editar]
(
	@Persona_Estado_Descripcion  [VarChar]  (50),
	@Persona_Estado_Explicacion  [VarChar]  (500),
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Persona_Estado_Secuencia  [Int] 

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
	[dbo].[Persona_Estado_Cata] 
SET
	[Persona_Estado_Descripcion] = @Persona_Estado_Descripcion,
	[Persona_Estado_Explicacion] = @Persona_Estado_Explicacion,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Persona_Estado_Cata].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Persona_Estado_Cata]
(
	[Persona_Estado_Descripcion],
	[Persona_Estado_Explicacion],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Persona_Estado_Descripcion,
	@Persona_Estado_Explicacion,
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
    SELECT DISTINCT @Persona_Estado_Secuencia = SCOPE_IDENTITY() 
    SELECT DISTINCT @Persona_Estado_Secuencia AS 'Persona_Estado_Secuencia' 
        FROM [Persona_Estado_Cata]
        WHERE ([Persona_Estado_Cata].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia)
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Borrar]
(
	@Persona_Estado_Secuencia  [Int] 

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
     [Personas_Master].[Persona_Estado_Secuencia] = NULL
    WHERE     ([Personas_Master].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia)

    SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT

    IF(@error != 0)
      BEGIN
       IF @tran = 1 ROLLBACK TRANSACTION
        RETURN
      END


  DELETE FROM [Persona_Estado_Cata]
    WHERE 
      ([Persona_Estado_Cata].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Persona_Estado_Cata]
(
	@Persona_Estado_Secuencia  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Persona_Estado_Cata].[Persona_Estado_Secuencia],
                [Persona_Estado_Cata].[Persona_Estado_Descripcion],
                [Persona_Estado_Cata].[Persona_Estado_Explicacion],
                [Persona_Estado_Cata].[Registro_Estado],
                [Persona_Estado_Cata].[Registro_Fecha],
                [Persona_Estado_Cata].[Registro_Usuario]
    FROM [Persona_Estado_Cata]
    WHERE 
     ( [Persona_Estado_Cata].[Persona_Estado_Secuencia] = @Persona_Estado_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Persona_Estado_Cata_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Persona_Estado_Cata].[Persona_Estado_Secuencia],
                [Persona_Estado_Cata].[Persona_Estado_Descripcion],
                [Persona_Estado_Cata].[Persona_Estado_Explicacion],
                [Persona_Estado_Cata].[Registro_Estado],
                [Persona_Estado_Cata].[Registro_Fecha],
                [Persona_Estado_Cata].[Registro_Usuario]
    FROM [Persona_Estado_Cata]

RETURN
GO



CREATE PROCEDURE [dbo].[Proc_Persona_Estado_Cata_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [pec].[Persona_Estado_Secuencia]
 ) AS [RowNumber],
				   pec.Persona_Estado_Secuencia , 
				   pec.Persona_Estado_Descripcion , 
				   pec.Persona_Estado_Explicacion , 
				   pec.Registro_Estado , 
				   pec.Registro_Fecha , 
				   pec.Registro_Usuario
		FROM  [dbo].[Persona_Estado_Cata]	As pec	

		   WHERE pec.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(pec.Persona_Estado_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec.Persona_Estado_Descripcion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec.Persona_Estado_Explicacion LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(pec.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR pec.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
)


, TotalRow AS
(
    SELECT COUNT(*) TotalRowCount FROM PagingTable
)



SELECT * FROM TotalRow, PagingTable
	WHERE RowNumber Between @StartIndex AND @EndIndex
    ORDER BY      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Descripcion]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Descripcion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Descripcion]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Descripcion]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Explicacion]' AND @_orderByDirection0 = 0 THEN [Persona_Estado_Explicacion]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Estado_Explicacion]' AND @_orderByDirection0 = 1 THEN [Persona_Estado_Explicacion]
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


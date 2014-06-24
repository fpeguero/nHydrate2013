-- DELETE PROCEDURE

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_Borrar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Borrar]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_Editar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Editar]
GO


IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_LoadAll]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_LoadAll]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Paging]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_IdiomasCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_IdiomasCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_PublicacionesCata]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_PublicacionesCata]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_HorarioTurnoDiasTrans]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_HorarioTurnoDiasTrans]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_PersonasMaster]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_PersonasMaster]
GO

IF EXISTS (SELECT * FROM [dbo].[sysobjects] WHERE id = object_id(N'[dbo].[Proc_Horario_Turno_Informe_Trans_DeleteInforme]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_DeleteInforme]
GO

-- EDIT PROCEDURE

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Editar]
(
	@Publicacion_Cantidad  [Int] ,
	@Registro_Estado  [Char]  (1) = ' ',
	@Registro_Fecha  [DateTime] ,
	@Registro_Usuario  [VarChar]  (50),
	@Dia_Secuencia  [Int] ,
	@Horario_Turno_Secuencia  [Int] ,
	@Idioma_Numero  [Int] ,
	@Persona_Secuencia  [Int] ,
	@Publicacion_Numero  [Int] 

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
	[dbo].[Horario_Turno_Informe_Trans] 
SET
	[Publicacion_Cantidad] = @Publicacion_Cantidad,
	[Registro_Estado] = @Registro_Estado,
	[Registro_Fecha] = @Registro_Fecha,
	[Registro_Usuario] = @Registro_Usuario

WHERE
	[dbo].[Horario_Turno_Informe_Trans].[Dia_Secuencia] = @Dia_Secuencia AND
	[dbo].[Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia AND
	[dbo].[Horario_Turno_Informe_Trans].[Idioma_Numero] = @Idioma_Numero AND
	[dbo].[Horario_Turno_Informe_Trans].[Persona_Secuencia] = @Persona_Secuencia AND
	[dbo].[Horario_Turno_Informe_Trans].[Publicacion_Numero] = @Publicacion_Numero



SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF(@error != 0)
BEGIN
    IF @tran = 1 ROLLBACK TRANSACTION
    RETURN
END
IF(@rowcount = 0)
BEGIN
INSERT INTO [dbo].[Horario_Turno_Informe_Trans]
(
	[Dia_Secuencia],
	[Horario_Turno_Secuencia],
	[Idioma_Numero],
	[Persona_Secuencia],
	[Publicacion_Cantidad],
	[Publicacion_Numero],
	[Registro_Estado],
	[Registro_Fecha],
	[Registro_Usuario]
)
VALUES
(
	@Dia_Secuencia,
	@Horario_Turno_Secuencia,
	@Idioma_Numero,
	@Persona_Secuencia,
	@Publicacion_Cantidad,
	@Publicacion_Numero,
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
END
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO
/********EN COMENTARIO POR QUE NUNCA SE DEBE BORRAR DATOS***************/
CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Borrar]
(
	@Dia_Secuencia  [Int]  = 1,
	@Horario_Turno_Secuencia  [Int] ,
	@Idioma_Numero  [Int] ,
	@Persona_Secuencia  [Int] ,
	@Publicacion_Numero  [Int] 

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


  DELETE FROM [Horario_Turno_Informe_Trans]
    WHERE 
      ([Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND       ([Horario_Turno_Informe_Trans].[Dia_Secuencia] = @Dia_Secuencia)
     AND       ([Horario_Turno_Informe_Trans].[Publicacion_Numero] = @Publicacion_Numero)
     AND       ([Horario_Turno_Informe_Trans].[Idioma_Numero] = @Idioma_Numero)
     AND       ([Horario_Turno_Informe_Trans].[Persona_Secuencia] = @Persona_Secuencia)
SELECT @error = @@ERROR, @rowcount = @@ROWCOUNT
IF @tran = 1 COMMIT TRANSACTION

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans]
(
	@Dia_Secuencia  [Int]  = 1,
	@Horario_Turno_Secuencia  [Int] ,
	@Idioma_Numero  [Int] ,
	@Persona_Secuencia  [Int] ,
	@Publicacion_Numero  [Int] 

)
AS
SET NOCOUNT ON
SELECT DISTINCT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]
    WHERE 
     ( [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
     AND      ( [Horario_Turno_Informe_Trans].[Dia_Secuencia] = @Dia_Secuencia)
     AND      ( [Horario_Turno_Informe_Trans].[Publicacion_Numero] = @Publicacion_Numero)
     AND      ( [Horario_Turno_Informe_Trans].[Idioma_Numero] = @Idioma_Numero)
     AND      ( [Horario_Turno_Informe_Trans].[Persona_Secuencia] = @Persona_Secuencia)

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_LoadAll]
(
 @_orderBy0 [nvarchar] (64) = NULL,
 @_orderByDirection0 [bit] = 0
)
AS
SET NOCOUNT ON
SELECT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]

RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_IdiomasCata]
(
	@Idioma_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]
      WHERE
        ([Horario_Turno_Informe_Trans].[Idioma_Numero] = @Idioma_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_PublicacionesCata]
(
	@Publicacion_Numero  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]
      WHERE
        ([Horario_Turno_Informe_Trans].[Publicacion_Numero] = @Publicacion_Numero)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_HorarioTurnoDiasTrans]
(
	@Dia_Secuencia  [Int]  = 1,
	@Horario_Turno_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]
      WHERE
        ([Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @Horario_Turno_Secuencia)
 And 
        ([Horario_Turno_Informe_Trans].[Dia_Secuencia] = @Dia_Secuencia)


RETURN
GO

CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_PersonasMaster]
(
	@Persona_Secuencia  [Int] ,

   @_orderBy0 [nvarchar] (64) = NULL,
   @_orderByDirection0 [bit] = 0
)
AS

SET NOCOUNT ON
SELECT 
                [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia],
                [Horario_Turno_Informe_Trans].[Dia_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Numero],
                [Horario_Turno_Informe_Trans].[Idioma_Numero],
                [Horario_Turno_Informe_Trans].[Persona_Secuencia],
                [Horario_Turno_Informe_Trans].[Publicacion_Cantidad],
                [Horario_Turno_Informe_Trans].[Registro_Estado],
                [Horario_Turno_Informe_Trans].[Registro_Fecha],
                [Horario_Turno_Informe_Trans].[Registro_Usuario]
    FROM [Horario_Turno_Informe_Trans]
      WHERE
        ([Horario_Turno_Informe_Trans].[Persona_Secuencia] = @Persona_Secuencia)


RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_DeleteInforme]
(
    @Horario_Turno_Secuencia [Int] ,
    @Dia_Secuencia [Int]  = 1
)
AS

SET NOCOUNT ON
DELETE
    FROM [Horario_Turno_Informe_Trans]
      WHERE Horario_Turno_Informe_Trans.Registro_Estado = 'A'
      AND 
         [Horario_Turno_Informe_Trans].[Horario_Turno_Secuencia] = @horario_turno_secuencia
 AND  [Horario_Turno_Informe_Trans].[Dia_Secuencia] = @dia_secuencia

RETURN
GO


CREATE PROCEDURE [dbo].[Proc_Horario_Turno_Informe_Trans_Paging]

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
				ROW_NUMBER() OVER ( ORDER BY 		                [htit].[Horario_Turno_Secuencia],
		                [htit].[Dia_Secuencia],
		                [htit].[Publicacion_Numero],
		                [htit].[Idioma_Numero],
		                [htit].[Persona_Secuencia]
 ) AS [RowNumber],
				   htit.Horario_Turno_Secuencia , 
				   htit.Dia_Secuencia , 
				   htit.Publicacion_Numero , 
				   htit.Idioma_Numero , 
				   htit.Persona_Secuencia , 
				   htit.Publicacion_Cantidad , 
				   htit.Registro_Estado , 
				   htit.Registro_Fecha , 
				   htit.Registro_Usuario
		FROM  [dbo].[Horario_Turno_Informe_Trans]	As htit	
			 Inner Join Idiomas_Cata As ic
			   On  ic.Idioma_Numero = htit.Idioma_Numero
			 Inner Join Publicaciones_Cata As pc
			   On  pc.Publicacion_Numero = htit.Publicacion_Numero
			 Inner Join Horario_Turno_Dias_Trans As htdt
			   On  htdt.Horario_Turno_Secuencia = htit.Horario_Turno_Secuencia
			      And  htdt.Dia_Secuencia = htit.Dia_Secuencia
			 Inner Join Personas_Master As pm
			   On  pm.Persona_Secuencia = htit.Persona_Secuencia

		   WHERE htit.Registro_Estado = 'A' And (
				   (@SearchString Is Null OR LTRIM(htit.Horario_Turno_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Dia_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Publicacion_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Idioma_Numero) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Persona_Secuencia) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Publicacion_Cantidad) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htit.Registro_Estado LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR LTRIM(htit.Registro_Fecha) LIKE '%' + @SearchString + '%') OR 
				   (@SearchString Is Null OR htit.Registro_Usuario LIKE '%' + @SearchString + '%'))
		
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
          WHEN @_orderBy0 = '[Publicacion_Numero]' AND @_orderByDirection0 = 0 THEN [Publicacion_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Numero]' AND @_orderByDirection0 = 1 THEN [Publicacion_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Numero]' AND @_orderByDirection0 = 0 THEN [Idioma_Numero]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Idioma_Numero]' AND @_orderByDirection0 = 1 THEN [Idioma_Numero]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 0 THEN [Persona_Secuencia]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Persona_Secuencia]' AND @_orderByDirection0 = 1 THEN [Persona_Secuencia]
      END DESC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Cantidad]' AND @_orderByDirection0 = 0 THEN [Publicacion_Cantidad]
      END ASC,
      CASE
          WHEN @_orderBy0 = '[Publicacion_Cantidad]' AND @_orderByDirection0 = 1 THEN [Publicacion_Cantidad]
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


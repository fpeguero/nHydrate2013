--DO NOT MODIFY THIS FILE. IT IS ALWAYS OVERWRITTEN ON GENERATION.
--Static Data For Version 0.0.0.0

if (SERVERPROPERTY('EngineEdition') <> 5) --NOT AZURE
exec sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'

if (SERVERPROPERTY('EngineEdition') <> 5) --NOT AZURE
exec sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL'

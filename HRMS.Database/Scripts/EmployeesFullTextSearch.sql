IF EXISTS (SELECT * FROM sys.fulltext_indexes WHERE [object_id] = OBJECT_ID(N'[dbo].[Employees]'))
BEGIN
	ALTER FULLTEXT INDEX ON [dbo].[Employees] DISABLE
	DROP FULLTEXT INDEX ON [dbo].[Employees]
END
GO

IF EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE [name] = '[FTCEmployees]')
	DROP FULLTEXT CATALOG [FTCEmployees]
GO

CREATE FULLTEXT CATALOG [FTCEmployees] AS DEFAULT;
GO

CREATE FULLTEXT INDEX ON [dbo].[Employees](
	[FirstName],
	[LastName],
	[MaidenName],
	[ParentName],
	[RegistrationNumber],
	[WorkerCode],
	[Address]) KEY INDEX PK_Employees ON [FTCEmployees] WITH STOPLIST = OFF, CHANGE_TRACKING AUTO;
GO
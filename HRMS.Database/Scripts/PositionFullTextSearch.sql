IF EXISTS (SELECT * FROM sys.fulltext_indexes WHERE [object_id] = OBJECT_ID(N'[dbo].[Positions]'))
BEGIN
	ALTER FULLTEXT INDEX ON [dbo].[Positions] DISABLE
	DROP FULLTEXT INDEX ON [dbo].[Positions]
END
GO

IF EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE [name] = 'FTCPositions')
	DROP FULLTEXT CATALOG [FTCPositions]
GO

CREATE FULLTEXT CATALOG [FTCPositions] AS DEFAULT;
GO

CREATE FULLTEXT INDEX ON [dbo].[Positions]([Name]) KEY INDEX PK_Positions ON [FTCPositions] WITH STOPLIST = OFF, CHANGE_TRACKING AUTO;
GO
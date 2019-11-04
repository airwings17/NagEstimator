CREATE TABLE [dbo].[EstimateVersions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectID] INT NOT NULL, 
    [EstimationType] NVARCHAR(50) NULL DEFAULT 'Featured', 
    [VersionSummary] NVARCHAR(MAX) NULL, 
    [Estimates] DECIMAL NULL, 
    [Cost] MONEY NULL, 
    [CustomerSharedEstimates] DECIMAL NULL, 
    [CustomerSharedCost] MONEY NULL, 
    [EstimationDate] DATETIME NULL, 
    [PMEfforts] DECIMAL NULL, 
    [IsApproved] BIT NULL DEFAULT 0, 
    [EstimatedBy] NVARCHAR(100) NULL, 
    [ReviewedBy] NVARCHAR(100) NULL,
	[Created] DATETIME NULL, 
    [Modified] DATETIME NULL, 
    [CreatedBy] NVARCHAR(100) NULL, 
    [ModifiedBy] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_EstimateVersions_Project] FOREIGN KEY ([ProjectID]) REFERENCES [Projects]([ID])
   
)


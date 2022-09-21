CREATE TABLE [dbo].[ReportAccess] (
    [ReportAccessId] INT IDENTITY (1, 1) NOT NULL,
    [ReportId]       INT NOT NULL,
    [UserId]         INT NOT NULL,
    [IsActive]       BIT CONSTRAINT [DF_ReportAccess_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ReportAccess] PRIMARY KEY CLUSTERED ([ReportAccessId] ASC)
);


CREATE TABLE [dbo].[ROIReport] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [ReportName]   VARCHAR (50)   NULL,
    [TenantID]     NVARCHAR (250) NULL,
    [ClientID]     NVARCHAR (250) NULL,
    [ClientSecret] NVARCHAR (250) NULL,
    [workspaceId]  NVARCHAR (250) NULL,
    [reportId]     NVARCHAR (250) NULL,
    CONSTRAINT [PK_ROIReport] PRIMARY KEY CLUSTERED ([Id] ASC)
);


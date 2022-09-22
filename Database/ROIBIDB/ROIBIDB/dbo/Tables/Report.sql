CREATE TABLE [dbo].[Report] (
    [ReportId]    INT           IDENTITY (1, 1) NOT NULL,
    [TenantId]    INT           NULL,
    [ReportName]  VARCHAR (50)  NULL,
    [ReportGuid]  NVARCHAR (50) NULL,
    [IsDashboard] BIT           CONSTRAINT [DF_Report_IsDashboard] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([ReportId] ASC),
    CONSTRAINT [FK_Report_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId])
);




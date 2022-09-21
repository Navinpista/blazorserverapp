CREATE TABLE [dbo].[ReportAudit] (
    [ReportAudit]    INT            IDENTITY (1, 1) NOT NULL,
    [LoginSessionId] NVARCHAR (100) NULL,
    [ReportId]       NVARCHAR (50)  NULL,
    [AuditTime]      DATETIME       NULL,
    [LoginSource]    VARCHAR (10)   NULL,
    CONSTRAINT [PK_ReportAudit] PRIMARY KEY CLUSTERED ([ReportAudit] ASC)
);


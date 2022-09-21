CREATE TABLE [dbo].[MenuReport] (
    [MenuReportId] INT IDENTITY (1, 1) NOT NULL,
    [MenuId]       INT NOT NULL,
    [ReportId]     INT NOT NULL,
    CONSTRAINT [PK_MenuReport1] PRIMARY KEY CLUSTERED ([MenuReportId] ASC),
    CONSTRAINT [FK_MenuReport1_Menu] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menu] ([MenuId]),
    CONSTRAINT [FK_MenuReport1_Report] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[Report] ([ReportId])
);


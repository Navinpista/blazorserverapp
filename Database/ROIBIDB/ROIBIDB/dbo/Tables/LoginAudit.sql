CREATE TABLE [dbo].[LoginAudit] (
    [LoginAuditId]   INT            IDENTITY (1, 1) NOT NULL,
    [UserId]         INT            NULL,
    [LoginTime]      DATETIME       NULL,
    [LogoutTime]     DATETIME       NULL,
    [LoginStatus]    BIT            NULL,
    [LoginMessage]   NVARCHAR (200) NULL,
    [LoginSessionId] NVARCHAR (100) NULL,
    CONSTRAINT [PK_LoginAudit] PRIMARY KEY CLUSTERED ([LoginAuditId] ASC),
    CONSTRAINT [FK_LoginAudit_UserLogin] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserLogin] ([UserId])
);


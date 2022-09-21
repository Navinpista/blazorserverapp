CREATE TABLE [dbo].[Tenant] (
    [TenantId]      INT          IDENTITY (1, 1) NOT NULL,
    [TenantGuid]    VARCHAR (50) NULL,
    [ClientGuid]    VARCHAR (50) NULL,
    [ClientSecret]  VARCHAR (50) NULL,
    [WorkspaceGuid] VARCHAR (50) NULL,
    CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED ([TenantId] ASC)
);


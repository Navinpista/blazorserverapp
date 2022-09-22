CREATE TABLE [dbo].[Menu] (
    [MenuId]       INT           IDENTITY (1, 1) NOT NULL,
    [ParentMenuId] INT           NULL,
    [MenuName]     VARCHAR (50)  NULL,
    [Description]  VARCHAR (100) NULL,
    [IsGroup]      BIT           NULL,
    [Status]       BIT           NULL,
    [Icon]         VARCHAR (50)  NULL,
    [sortorder]    SMALLINT      NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([MenuId] ASC)
);




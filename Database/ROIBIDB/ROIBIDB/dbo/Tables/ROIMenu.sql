CREATE TABLE [dbo].[ROIMenu] (
    [MenuId]       INT           IDENTITY (1, 1) NOT NULL,
    [ParentMenuId] INT           CONSTRAINT [DF_ROIMenu_ParentMenuId] DEFAULT ((0)) NOT NULL,
    [MenuName]     VARCHAR (50)  NULL,
    [Description]  VARCHAR (100) NULL,
    [NavigateUrl]  VARCHAR (100) NULL,
    [Status]       INT           NULL,
    [IconName]     VARCHAR (50)  NULL,
    [IsGroup]      BIT           CONSTRAINT [DF_ROIMenu_IsGroup] DEFAULT ((0)) NOT NULL,
    [GroupName]    VARCHAR (50)  NULL,
    CONSTRAINT [PK_ROIMenu] PRIMARY KEY CLUSTERED ([MenuId] ASC)
);


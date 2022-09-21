CREATE TABLE [dbo].[UserLogin] (
    [UserId]    INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50) NULL,
    [LastName]  VARCHAR (50) NULL,
    [UserName]  VARCHAR (50) NULL,
    [Password]  VARCHAR (50) NULL,
    [IsActive]  BIT          CONSTRAINT [DF_UserLogin_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


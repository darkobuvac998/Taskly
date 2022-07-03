CREATE TABLE [dbo].[Priority] (
    [PriorityId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Color]      VARCHAR (50) NULL,
    CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED ([PriorityId] ASC)
);


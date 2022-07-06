CREATE TABLE [dbo].[Board] (
    [BoardId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (200) NULL,
    [TaskNumber]  INT           NOT NULL,
    [Visible] BIT NOT NULL DEFAULT 1, 
    [Pinned] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED ([BoardId] ASC)
);


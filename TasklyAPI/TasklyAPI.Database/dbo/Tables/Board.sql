﻿CREATE TABLE [dbo].[Board] (
    [BoardId]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (200) NULL,
    [TaskNumber]  INT           NOT NULL,
    CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED ([BoardId] ASC)
);

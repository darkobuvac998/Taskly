CREATE TABLE [dbo].[Task] (
    [TaskId]         INT             IDENTITY (1, 1) NOT NULL,
    [StatusId]       INT             NOT NULL ,
    [PriorityId]     INT             NOT NULL,
    [BoardId]        INT             NOT NULL,
    [Name]           VARCHAR (100)   NOT NULL,
    [Description]    VARCHAR (200)   NULL,
    [StartDateTime]  DATETIME        NULL,
    [DueDate]        DATETIME        NULL,
    [EndDate]        DATETIME        NULL,
    [Note]           VARCHAR (100)   NULL,
    [AttachmentLink] VARCHAR (2048)  NULL,
    [TimeAmount]     DECIMAL (10, 2) NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskId] ASC),
    CONSTRAINT [FK_Task_Board] FOREIGN KEY ([BoardId]) REFERENCES [dbo].[Board] ([BoardId]),
    CONSTRAINT [FK_Task_Priority] FOREIGN KEY ([PriorityId]) REFERENCES [dbo].[Priority] ([PriorityId]),
    CONSTRAINT [FK_Task_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([StatusId])
);


CREATE TABLE [dbo].[TaskChecklist] (
    [TaskChecklistId] INT          IDENTITY (1, 1) NOT NULL,
    [TaskId]          INT          NOT NULL,
    [Name]            VARCHAR (50) NOT NULL,
    [Checked]         BIT          CONSTRAINT [DF__TaskCheck__Check__20C1E124] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TaskChecklist] PRIMARY KEY CLUSTERED ([TaskChecklistId] ASC),
    CONSTRAINT [FK_TaskChecklist_Task] FOREIGN KEY ([TaskId]) REFERENCES [dbo].[Task] ([TaskId])
);


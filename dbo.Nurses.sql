CREATE TABLE [dbo].[Nurses] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Rooms]    NVARCHAR (MAX) NULL,
    [Phone] NVARCHAR (MAX) NULL,
    CONSTRAINT [********] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Room] (
    [RoomId]      INT             IDENTITY (1, 1) NOT NULL,
    [RoomType]    NVARCHAR (255)  NOT NULL,
    [Price]       DECIMAL (10, 2) NOT NULL,
    [Status]      TINYINT   NULL,
    [RoomNumber]  INT             NULL,
    [Description] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK__Room__3286393987E90EA7] PRIMARY KEY CLUSTERED ([RoomId] ASC)
);


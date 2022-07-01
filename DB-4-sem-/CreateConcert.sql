use master;
go

CREATE DATABASE Concert;
go

use Concert;
go

CREATE TABLE [dbo].[Concerts](
	[ConcertId] [int] IDENTITY(1,1) NOT NULL,
	[Group] [nvarchar](max) NOT NULL,
	[Count] [int] NOT NULL,
	[Zone] [nvarchar](max) NOT NULL,
	[When] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Concerts] PRIMARY KEY CLUSTERED 
(
	[ConcertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
go

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
go

CREATE TABLE [dbo].[UserConcerts](
	[UserContextId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ConcertId] [int] NOT NULL,
 CONSTRAINT [PK_UserConcerts] PRIMARY KEY CLUSTERED 
(
	[UserContextId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

ALTER TABLE [dbo].[UserConcerts]  WITH CHECK ADD  CONSTRAINT [FK_UserConcerts_Concerts_ConcertId] FOREIGN KEY([ConcertId])
REFERENCES [dbo].[Concerts] ([ConcertId])
ON DELETE CASCADE
go

ALTER TABLE [dbo].[UserConcerts] CHECK CONSTRAINT [FK_UserConcerts_Concerts_ConcertId]
go

ALTER TABLE [dbo].[UserConcerts]  WITH CHECK ADD  CONSTRAINT [FK_UserConcerts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
go

ALTER TABLE [dbo].[UserConcerts] CHECK CONSTRAINT [FK_UserConcerts_Users_UserId]
go

INSERT INTO [dbo].[Concerts]
           ([Group]
           ,[Count]
           ,[Zone]
           ,[When])
     VALUES
           ('Rasputniki', 20, 'D', '2020-06-06 19:00:00'),
		   ('Nizkiz', 19, 'B', '2020-07-07 20:00:00')
go
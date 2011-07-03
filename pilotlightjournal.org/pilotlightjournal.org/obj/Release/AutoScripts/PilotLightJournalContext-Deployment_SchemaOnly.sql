CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)

GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [PK__Accounts__000000000000000A] PRIMARY KEY 
(
	[AccountId]
)
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(2,1) NOT NULL,
	[ModelHash] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[EdmMetadata] ADD  CONSTRAINT [PK__EdmMetadata__000000000000003A] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Issues](
	[IssueId] [int] IDENTITY(1,1) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[Completed] [bit] NOT NULL,
	[ImagePath] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Issues] ADD  CONSTRAINT [PK__Issues__0000000000000018] PRIMARY KEY 
(
	[IssueId]
)
GO
CREATE TABLE [dbo].[Works](
	[WorkId] [int] IDENTITY(1,1) NOT NULL,
	[author_AuthorId] [int] NOT NULL,
	[author_FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[author_LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[author_Bio] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[author_ImagePath] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Title] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Order] [int] NOT NULL,
	[Issue_IssueId] [int] NULL
)

GO
ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [PK__Works__0000000000000030] PRIMARY KEY 
(
	[WorkId]
)
GO
ALTER TABLE [dbo].[Works]  ADD  CONSTRAINT [Issue_Works] FOREIGN KEY([Issue_IssueId])
REFERENCES [Issues] ([IssueId])
GO

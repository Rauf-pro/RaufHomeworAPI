USE [StudentDB]
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Surname], [Age], [Email]) VALUES (1, N'Qasim', N'Abbasov', 18, N'qasim@gmail.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO

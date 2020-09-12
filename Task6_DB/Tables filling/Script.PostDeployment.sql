INSERT [dbo].[Group] ([ID], [Name]) 
VALUES (1, N'IP-22'),
       (2, N'IP-21')

INSERT [dbo].[Session] ([ID], [GroupID], [SemesterNumber]) 
VALUES (1, 1, 1),
       (2, 1, 2),
       (3, 2, 1),
       (4, 2, 2)

INSERT [dbo].[Student] ([ID], [FullName], [Gender], [Birthdate], [GroupID]) 
VALUES (1, N'Famov Maxim Gennadievich', N'Male', CAST(N'2000-06-06' AS Date), 1),
       (2, N'Herons Viktor Vladimirovich', N'Male', CAST(N'2001-05-19' AS Date), 1),
       (3, N'Dfsdf dfdfa Eleseevna', N'Woman', CAST(N'2000-06-06' AS Date), 1),
       (4, N'Popova Maria Sergeevna', N'Woman', CAST(N'2000-10-12' AS Date), 2),
       (5, N'Sharov Anton Dmitrievich', N'Male', CAST(N'2000-12-15' AS Date), 2),
       (6, N'Vasilieva Anastasia Stepanovna', N'Woman', CAST(N'2001-03-16' AS Date), 2)

INSERT [dbo].[Discipline] ([ID], [Name]) 
VALUES (1, N'Math'),
       (2, N'OOP'),
       (3, N'MMA'),
       (4, N'History'),
       (5, N'OAIP')

INSERT INTO [dbo].[Credit] ([ID], [SessionID], [DisciplineID], [Date]) 
VALUES (1, 1, 4, CAST(N'2019-05-22' AS Date)),
	   (2, 1, 5, CAST(N'2019-05-25' AS Date)),
	   (3, 2, 3, CAST(N'2019-05-24' AS Date)),
	   (4, 2, 5, CAST(N'2019-05-27' AS Date)),
       (5, 3, 1, CAST(N'2019-05-19' AS Date)),
       (6, 3, 5, CAST(N'2019-05-21' AS Date)),
       (7, 4, 2, CAST(N'2019-05-18' AS Date)),
       (8, 4, 4, CAST(N'2019-05-28' AS Date))

INSERT [dbo].[Exam] ([ID], [SessionID], [DisciplineID], [Date]) 
VALUES (1, 1, 2, CAST(N'2019-06-14' AS Date)),
       (2, 1, 1, CAST(N'2019-06-18' AS Date)),
       (3, 1, 3, CAST(N'2019-06-22' AS Date)),
       (4, 2, 4, CAST(N'2019-06-12' AS Date)),
       (5, 2, 1, CAST(N'2019-06-15' AS Date)),
       (6, 2, 2, CAST(N'2019-06-19' AS Date)),
       (7, 3, 3, CAST(N'2019-06-13' AS Date)),
       (8, 3, 2, CAST(N'2019-06-17' AS Date)),
       (9, 4, 5, CAST(N'2019-06-25' AS Date)),
       (10, 4, 1, CAST(N'2019-06-28' AS Date)),
       (11, 3, 4, CAST(N'2019-06-14' AS Date)),
       (12, 4, 3, CAST(N'2019-06-27' AS Date))

INSERT [dbo].[CreditResult] ([ID], [StudentID], [CreditID], [Result]) 
VALUES (1, 1, 1, 1),
	   (2, 1, 2, 0),
	   (3, 2, 1, 1),
       (4, 2, 2, 1),
       (5, 3, 1, 0),
       (6, 3, 2, 1),
       (7, 1, 3, 1),
       (8, 1, 4, 1),
       (9, 2, 3, 1),
       (10, 2, 4, 0),
       (11, 3, 3, 0),
       (12, 3, 4, 0),
       (13, 4, 5, 0),
       (14, 4, 6, 1),
       (15, 5, 5, 1),
       (16, 5, 6, 1),
       (17, 6, 5, 1),
       (18, 6, 6, 1),
       (19, 4, 7, 1),
       (20, 4, 8, 0),
       (21, 5, 7, 0),
       (22, 5, 8, 1),
       (23, 6, 7, 1),
       (24, 6, 8, 1)

INSERT [dbo].[ExamResult] ([ID], [StudentID], [ExamID], [Result]) 
VALUES (1, 1, 1, 2),
       (2, 1, 2, 2),
       (3, 1, 3, 2),
       (4, 2, 1, 8),
       (5, 2, 2, 6),
       (6, 2, 3, 4),
       (7, 3, 1, 7),
       (8, 3, 2, 8),
       (9, 3, 3, 5),
       (10, 1, 4, 5),
       (11, 1, 5, 6),
       (12, 1, 6, 9),
       (13, 2, 4, 7),
       (14, 2, 5, 6),
       (15, 2, 6, 8),
       (16, 3, 4, 5),
       (17, 3, 5, 4),
       (18, 3, 6, 7),
       (19, 4, 7, 5),
       (20, 4, 8, 9),
       (21, 4, 11, 9),
       (22, 5, 7, 2),
       (23, 5, 8, 2),
       (24, 5, 11, 2),
       (25, 6, 7, 2),
       (26, 6, 8, 2),
       (27, 6, 11, 2),
       (28, 4, 9, 7),
       (29, 4, 10, 6),
       (30, 4, 12, 9),
       (31, 5, 9, 4),
       (32, 5, 10, 6),
       (33, 5, 12, 5),
       (34, 6, 9, 7),
       (35, 6, 10, 8),
       (36, 6, 12, 8)


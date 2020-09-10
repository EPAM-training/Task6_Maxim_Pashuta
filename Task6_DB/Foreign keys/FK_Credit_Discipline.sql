ALTER TABLE [dbo].[Credit]  
ADD  CONSTRAINT [FK_Credit_Discipline] FOREIGN KEY([DisciplineID])
	REFERENCES [dbo].[Discipline] ([ID])
ON DELETE SET NULL
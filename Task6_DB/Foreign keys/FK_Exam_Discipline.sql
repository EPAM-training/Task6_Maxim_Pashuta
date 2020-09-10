ALTER TABLE [dbo].[Exam]  
WITH CHECK ADD  CONSTRAINT [FK_Exam_Discipline] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[Discipline] ([ID])
ON DELETE SET NULL
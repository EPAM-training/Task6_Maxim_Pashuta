ALTER TABLE [dbo].[ExamResult]  
WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
ON DELETE SET NULL
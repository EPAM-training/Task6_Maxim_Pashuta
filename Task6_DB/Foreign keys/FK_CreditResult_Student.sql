ALTER TABLE [dbo].[CreditResult]  
WITH CHECK ADD  CONSTRAINT [FK_CreditResult_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
ON DELETE SET NULL
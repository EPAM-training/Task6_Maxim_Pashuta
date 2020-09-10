ALTER TABLE [dbo].[CreditResult]
WITH CHECK ADD  CONSTRAINT [FK_CreditResult_Credit] FOREIGN KEY([CreditID])
REFERENCES [dbo].[Credit] ([ID])
ON DELETE SET NULL
﻿ALTER TABLE [dbo].[Credit]  
WITH CHECK ADD  CONSTRAINT [FK_Credit_Session] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Session] ([ID])
ON DELETE SET NULL
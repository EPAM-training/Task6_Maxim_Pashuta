﻿ALTER TABLE [dbo].[Session]  
WITH CHECK ADD  CONSTRAINT [FK_Session_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([ID])
ON DELETE SET NULL
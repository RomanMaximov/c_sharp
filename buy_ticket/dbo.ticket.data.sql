﻿--INSERT INTO [dbo].[ticket] ([ticket_id], [ticket_number], [comfort_class], [seat], [pass_name], [date_at]) VALUES (N'58c88c16-8e9b-45a3-a017-42080ec23f9c', 1, N'FIRST', 1, N'Bob Dow', N'2023-02-24 13:11:26')
--ALTER TABLE dbo.ticket ADD seat_status VARCHAR(10) NULL;
--ALTER TABLE dbo.ticket ALTER COLUMN pass_name NVARCHAR(30) NULL;
--ALTER TABLE dbo.ticket ALTER COLUMN date_at DATETIME NULL;
--UPDATE ticket SET pass_name = NULL, date_at = NULL, seat_status = 'vacant' WHERE ticket_id = '58c88c16-8e9b-45a3-a017-42080ec23f9c';
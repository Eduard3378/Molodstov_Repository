/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT dbo.Students ON;
--- Students
insert into dbo.Students (Id, Name, Surname, Patronymic, GenderId, DateOfBirth, PassingSessionByStudentId)
values (9, N'Елена4', N'Воробьева4', N'Васильевна4', 3, GETDATE(), 9),
(10, N'Елена5', N'Воробьева5', N'Васильевна5', 3, GETDATE(), 10),
(11, N'Елена6', N'Воробьева6', N'Васильевна6', 3,GETDATE(), 11)
SET IDENTITY_INSERT dbo.Students OFF;

SET IDENTITY_INSERT dbo.PassingSessionByStudents ON;
--- PassingSessionByStudents
insert into dbo.PassingSessionByStudents (Id, StudentId, SessionId, CreditScore1, CreditScore2, CreditScore3, ExamMark1, ExamMark2, ExamMark3)
values (17, 9, 1, 5, 4, 5, 4, 5, 4),
(18, 9, 2, 4, 5, 4, 5, 4, 5),
(19, 10, 1, 4, 6, 4, 6, 5, 4),
(20, 10, 2, 6, 4, 6, 4, 5, 6),
(21, 11, 1, 7, 5, 6, 5, 6, 7),
(22, 11, 2, 6, 6, 5, 5, 7, 8)
SET IDENTITY_INSERT dbo.PassingSessionByStudents OFF;



--- StudentGroups
insert into dbo.StudentGroups (GroupId, StudentId)
values (1, 9),
(3, 10),
(3, 11)

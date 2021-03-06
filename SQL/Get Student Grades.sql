USE
Assignments;
GO

CREATE
OR ALTER FUNCTION
[dbo].[GetStudentsGrades](@moduleId NVARCHAR(30))
RETURNS TABLE
RETURN (SELECT
               m.ModuleName,
               a.AssignmentName,
               g.Grade
        FROM Assignments a
        JOIN StudentAssignments sa
            ON (a.AssignmentID = sa.AssignmentID)
        JOIN Grades g
            ON (
                (CAST(sa.Points AS FLOAT) / CAST(a.MaxMark AS FLOAT) * 100)
                    BETWEEN g.MinimumMark AND g.MaximumMark)
        JOIN Modules m
            ON (m.ModuleID = a.ModuleID)
        JOIN Students s
            ON (sa.StudentID = s.StudentID)
        WHERE m.ModuleID = @moduleId
);
GO

-- Test Data --
-- INSERT INTO Courses (CourseID, CourseName, EnrollmentYear, FinalYear)
-- VALUES (NEWID(), 'BSc in Software Development', 2020, 2023);
-- 
-- INSERT INTO Modules (ModuleID, ModuleName, SemesterNumber, CourseID)
-- VALUES ('ENG1', 'English I', 1, (SELECT c.CourseID FROM Course c WHERE c.CourseName = 'BSc in Software Development'));
-- 
-- INSERT INTO Modules (ModuleID, ModuleName, SemesterNumber, CourseID)
-- VALUES ('ENG2', 'English II', 2, (SELECT c.CourseID FROM Course c WHERE c.CourseName = 'BSc in Software Development'));
-- 
-- INSERT INTO Students (StudentID, FirstName, LastName, SchoolEmail, CourseID)
-- VALUES ('446102L', 'Fabian', 'Muscat', 'fabian.muscat.d102385@mcast.edu.mt', (SELECT c.CourseID FROM Course c WHERE c.CourseName = 'BSc in Software Development'));
-- 
-- INSERT INTO Assignments (AssignmentID, AssignmentName, ModuleID, MaxMark, DateIssued, DeadlineDate, TypeID)
-- VALUES (NEWID(), 'TCA1', 'ENG1', 45, '20210118', '20210118', (SELECT t.TypeID FROM Type t WHERE t.AssignmentType = 'TCA'));
-- 
-- INSERT INTO Assignments (AssignmentID, AssignmentName, ModuleID, MaxMark, DateIssued, DeadlineDate, TypeID)
-- VALUES (NEWID(), 'TCA2', 'ENG1', 55, '20210120', '20210120', (SELECT t.TypeID FROM Type t WHERE t.AssignmentType = 'TCA'));
-- 
-- INSERT INTO Assignments (AssignmentName, ModuleID, MaxMark, DateIssued, DeadlineDate, TypeID)
-- VALUES ('Literature Review', 'ENG2', 50, '20210315', '20210401', (SELECT t.TypeID FROM Type t WHERE t.AssignmentType = 'Home'));
-- 
-- INSERT INTO StudentAssignments (AssignmentID, StudentID, Points)
-- VALUES ((SELECT a.AssignmentID FROM Assignments a WHERE a.AssignmentName = 'TCA1'), '446102L', 38);
-- 
-- INSERT INTO StudentAssignments (AssignmentID, StudentID, Points)
-- VALUES ((SELECT a.AssignmentID FROM Assignments a WHERE a.AssignmentName = 'TCA2'), '446102L', 46);
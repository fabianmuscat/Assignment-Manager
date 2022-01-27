USE AssignmentsManager;
GO

CREATE OR ALTER FUNCTION [dbo].[GetCourseId](@course NVARCHAR(100))
RETURNS INT
BEGIN
    RETURN (SELECT c.CourseID
            FROM Courses c
            WHERE c.CourseName = @course);
END
GO

CREATE OR ALTER PROC [dbo].[AddCourseAndModule]
    (@enrollmentYear NUMERIC(4,0), @finalYear NUMERIC(4,0),
    @module NVARCHAR(50), @semesterNumber TINYINT, @course NVARCHAR(100)) AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        BEGIN TRY
            IF EXISTS(SELECT c.CourseID
                      FROM Courses c
                      WHERE c.CourseName = @course)
                THROW 60001, 'Course already exists', 1;

            IF EXISTS(SELECT m.ModuleID
                      FROM Modules m
                      WHERE m.ModuleName = @module)
                THROW 60002, 'Module already exists', 1;

            IF @finalYear < @enrollmentYear
                THROW 60002, 'Final year cannot be before the enrollment year', 1;

            IF @semesterNumber < 0 OR @semesterNumber > 2
                THROW 60003, 'Semester number must be either 1 or 2', 1;

            INSERT INTO Courses (CourseName, EnrollmentYear, FinalYear)
            VALUES (@course, @enrollmentYear, @finalYear);

            INSERT INTO Modules (ModuleName, SemesterNumber, CourseID)
            VALUES (@module, @semesterNumber, (SELECT dbo.GetCourseId(@course)))

            COMMIT TRANSACTION;
        END TRY

        BEGIN CATCH
            ROLLBACK TRANSACTION;
            DECLARE @number INT = ERROR_NUMBER();
            DECLARE @msg NVARCHAR(MAX) = ERROR_MESSAGE();
            DECLARE @state INT = ERROR_STATE();

            THROW @number, @msg, @state;
        END CATCH
END

SELECT dbo.GetCourseId('BSc in Software Development') 'CourseID'
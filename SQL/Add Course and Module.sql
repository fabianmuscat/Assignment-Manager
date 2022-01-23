USE AssignmentsManager;
GO

CREATE OR ALTER FUNCTION dbo.fn_getCourseId(@course NVARCHAR(100))
RETURNS UNIQUEIDENTIFIER
BEGIN
    RETURN (SELECT c.CourseID
            FROM Course c
            WHERE c.CourseName = @course);
END
GO

CREATE OR ALTER PROC dbo.sp_addCourseAndModule
    (@moduleID NVARCHAR(30), @enrollmentYear NUMERIC(4,0), @finalYear NUMERIC(4,0),
    @module NVARCHAR(50), @semesterNumber TINYINT, @course NVARCHAR(100)) AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        BEGIN TRY
            IF EXISTS(SELECT c.CourseID
                      FROM Course c
                      WHERE c.CourseName = @course)
                THROW 60001, 'Course already exists', 1;

            IF EXISTS(SELECT m.ModuleID
                      FROM Module m
                      WHERE m.ModuleName = @module)
                THROW 60002, 'Module already exists', 1;

            IF @finalYear < @enrollmentYear
                THROW 60002, 'Final year cannot be before the enrollment year', 1;

            IF @semesterNumber < 0 OR @semesterNumber > 2
                THROW 60003, 'Semester number must be either 1 or 2', 1;

            INSERT INTO Course (CourseID, CourseName, EnrollmentYear, FinalYear)
            VALUES (NEWID(), @course, @enrollmentYear, @finalYear);

            INSERT INTO Module (ModuleID, ModuleName, SemesterNumber, CourseID)
            VALUES (@moduleID, @module, @semesterNumber, (SELECT dbo.fn_getCourseId(@course)))

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

SELECT dbo.fn_getCourseId('BSc in Software Development') 'CourseID'
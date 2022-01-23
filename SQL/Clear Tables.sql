USE AssignmentsManager;
GO

CREATE OR ALTER PROC dbo.sp_clearData AS
BEGIN
   SET NOCOUNT ON;

    BEGIN TRANSACTION
        BEGIN TRY
            DELETE FROM dbo.StudentAssignment
            DELETE FROM dbo.Assignment;
            DELETE FROM dbo.Module;
            DELETE FROM dbo.Student;
            DELETE FROM dbo.Course;
            
            COMMIT TRANSACTION;
        END TRY

        BEGIN CATCH
            ROLLBACK TRANSACTION;
            THROW 60001, 'There was an error while clearing the tables', 1;
        END CATCH
END
GO

EXEC dbo.sp_clearData;
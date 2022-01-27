USE AssignmentsManager;
GO

CREATE OR ALTER PROC [dbo].[PopulateGrades] AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        BEGIN TRY
            IF EXISTS (SELECT Grade FROM Grades g)
                THROW 60001, 'Table is not empty', 1;

            INSERT INTO dbo.Grades (Grade, MinimumMark, MaximumMark)
            VALUES
                   ('A*', 90, 100),
                   ('A', 80, 89),
                   ('B', 70, 79),
                   ('C', 60, 69),
                   ('D', 50, 59),
                   ('CP', 40, 49),
                   ('U', 0, 39);

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
GO

EXEC sp_populateGrades;
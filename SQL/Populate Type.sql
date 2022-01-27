USE AssignmentsManager;
GO

CREATE OR ALTER PROC dbo.sp_populateType AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION
        BEGIN TRY
            IF EXISTS (SELECT TypeID FROM Type t)
                THROW 60001, 'Table is not empty', 1;

            INSERT INTO dbo.Type (AssignmentType)
            VALUES ('TCA'), ('Home'), ('Practical');

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

EXEC sp_populateType;
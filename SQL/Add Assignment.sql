USE
AssignmentsManager;
GO

CREATE
OR ALTER FUNCTION
[dbo].[GetModuleId](@module NVARCHAR(50))
RETURNS NVARCHAR(30)
BEGIN
RETURN (SELECT m.ModuleID
        FROM Module m
        WHERE m.ModuleName = @module);
END
GO


CREATE
OR ALTER FUNCTION
[dbo].[GetTypeId](@type NVARCHAR(20))
RETURNS INTEGER
BEGIN
RETURN (SELECT t.TypeID
        FROM Type t
        WHERE t.AssignmentType = @type);
END
GO

CREATE
OR ALTER
PROC [dbo].[AddAssignment](@name NVARCHAR(100), @module NVARCHAR(50), @type NVARCHAR(20), @maxMark TINYINT, @startDate DATE, @endDate DATE) AS
BEGIN
    SET
NOCOUNT ON;

BEGIN
TRANSACTION
BEGIN TRY
            DECLARE
@moduleId NVARCHAR(30) = (SELECT dbo.GetModuleId(@module));
            IF
@moduleId IS NULL
                THROW 51000, 'Invalid module name', 1;

            DECLARE
@typeID INT = (SELECT dbo.GetTypeId(@type));
            IF
@typeID IS NULL
                THROW 52000, 'Invalid assignment type', 1;

            IF
@maxMark < 0 OR @maxMark > 100
                THROW 53000, 'Max mark must be between 0 and 100', 1;

            IF
@endDate < @startDate
                THROW 54000, 'End date cannot be before start date', 1;

INSERT INTO Assignment (AssignmentName, ModuleID, MaxMark, DateIssued, DeadlineDate, TypeID)
VALUES (@name, @moduleId, @maxMark, @startDate, @endDate, @typeID);

COMMIT TRANSACTION;
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
            THROW;
END CATCH
END
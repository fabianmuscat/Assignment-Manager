USE Assignments;
GO

CREATE OR ALTER FUNCTION dbo.fn_getModuleTotal(@moduleId NVARCHAR(30))
RETURNS TINYINT
BEGIN
    DECLARE @total TINYINT;

    SELECT @total = SUM(sa.Points)
    FROM Assignment a
    JOIN StudentAssignment sa
        ON (a.AssignmentID = SA.AssignmentID)
    WHERE a.ModuleID = @moduleId
    GROUP BY a.ModuleID;

    RETURN @total;
END

SELECT dbo.fn_getModuleTotal('ENG1');
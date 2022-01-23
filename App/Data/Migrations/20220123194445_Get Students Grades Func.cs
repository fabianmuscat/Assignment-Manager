using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class GetStudentsGradesFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var func = @"CREATE OR ALTER FUNCTION [dbo].[GetStudentsGrades](@moduleId NVARCHAR(30))
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
                        GO";

            migrationBuilder.Sql(func);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[GetStudentsGrades]");
        }
    }
}

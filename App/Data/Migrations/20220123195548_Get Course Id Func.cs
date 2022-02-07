using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class GetCourseIdFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc = @"CREATE OR ALTER FUNCTION [dbo].[GetCourseId](@course NVARCHAR(100))
                        RETURNS INT
                        BEGIN
                            RETURN (SELECT c.CourseID
                                    FROM Courses c
                                    WHERE c.CourseName = @course);
                        END
                        GO";

            migrationBuilder.Sql(proc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[GetCourseId]");
        }
    }
}

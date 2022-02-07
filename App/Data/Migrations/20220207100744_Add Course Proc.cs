using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddCourseProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc = @"CREATE PROC [dbo].[AddCourse](@course NVARCHAR(100), @enrollmentDate DATETIME2, @finalDate DATETIME2) AS
                        BEGIN
                            SET NOCOUNT ON;

                            BEGIN TRANSACTION
                            BEGIN TRY
                            IF EXISTS(SELECT c.CourseID
                                FROM Courses c
                            WHERE c.CourseName = @course)
                            THROW 60001, 'Course already exists', 1;

                            IF @finalDate < @enrollmentDate
                            THROW 60002, 'End Date cannot be before the enrollment date', 1;

                            INSERT INTO Courses (CourseName, EnrollmentDate, EndDate)
                            VALUES (@course, @enrollmentDate, @finalDate);

                            COMMIT TRANSACTION;
                            END TRY

                            BEGIN CATCH
                                ROLLBACK TRANSACTION;
                                DECLARE @number INT = ERROR_NUMBER();
                                DECLARE @msg NVARCHAR(MAX) = ERROR_MESSAGE();
                                DECLARE @state INT = ERROR_STATE();

                                THROW @number, @msg, @state;
                            END CATCH
                    END";

            migrationBuilder.Sql(proc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[AddCourse]");
        }
    }
}

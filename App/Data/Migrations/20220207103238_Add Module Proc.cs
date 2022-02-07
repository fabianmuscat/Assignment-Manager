using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddModuleProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc =
                @"
                ALTER PROC [dbo].[AddModule](@module NVARCHAR(100), @course NVARCHAR(100), @semesterNumber INTEGER, @year TINYINT) AS
                BEGIN
                    SET NOCOUNT ON;

                    BEGIN TRANSACTION
                        BEGIN TRY
                            DECLARE @courseId INT = (SELECT dbo.GetCourseId(@course));
                            IF EXISTS(SELECT m.ModuleId
                                FROM Modules m
                                WHERE m.ModuleName = @module)
                                THROW 60001, 'Module already exists', 1;
                                
                            IF NOT EXISTS(SELECT c.CourseID
                                FROM Courses c
                                WHERE c.CourseName = @course)
                                THROW 60002, 'Course does not exist', 1;

                            INSERT INTO Modules (ModuleName, SemesterNumber, CourseID, Year)
                            VALUES (@module, @semesterNumber, @courseId, @year);

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
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[AddModule]");
            migrationBuilder.Sql("DROP FUNCTION [dbo].[GetModuleId]");
        }
    }
}

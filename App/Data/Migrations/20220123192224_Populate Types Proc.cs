using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class PopulateTypesProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var proc = @"CREATE OR ALTER PROC [dbo].[PopulateTypes] AS
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
                        GO";

            migrationBuilder.Sql(proc);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[PopulateTyoes]");
        }
    }
}

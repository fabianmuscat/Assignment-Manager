using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class GetModuleTotalFunc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var func = @"CREATE OR ALTER FUNCTION [dbo].[GetModuleTotal](@moduleId NVARCHAR(30))
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
                        END";

            migrationBuilder.Sql(func);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [dbo].[GetModuleTotal]");

        }
    }
}

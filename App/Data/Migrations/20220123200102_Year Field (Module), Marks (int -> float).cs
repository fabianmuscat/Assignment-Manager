using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class YearFieldModuleMarksintfloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Points",
                table: "StudentAssignments",
                type: "real",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<decimal>(
                name: "Year",
                table: "Modules",
                type: "numeric(4,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Modules");

            migrationBuilder.AlterColumn<byte>(
                name: "Points",
                table: "StudentAssignments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class DroppedStudentIdColumnsAddedStudentModuleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_StudentId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_StudentId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_AspNetUsers_StudentId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Modules",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentName",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.CreateTable(
                name: "StudentModule",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModule", x => new { x.StudentId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_StudentModule_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentModule_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ModuleName",
                table: "Modules",
                column: "ModuleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentName",
                table: "Assignments",
                column: "AssignmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentModule_ModuleId",
                table: "StudentModule",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_StudentId",
                table: "Assignments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetUsers_StudentId",
                table: "Modules",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_StudentId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_StudentId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentModule");

            migrationBuilder.DropIndex(
                name: "IX_Modules_ModuleName",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseName",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentName",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourse");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Modules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssignmentName",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_StudentId",
                table: "Assignments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetUsers_StudentId",
                table: "Modules",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_AspNetUsers_StudentId",
                table: "StudentCourse",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseID");
        }
    }
}

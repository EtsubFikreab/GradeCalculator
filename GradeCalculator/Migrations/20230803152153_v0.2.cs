using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeCalculator.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Semester_profiles_ProfileID",
                table: "Semester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profiles",
                table: "profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.RenameTable(
                name: "profiles",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Semesters",
                newName: "Year");

            migrationBuilder.RenameIndex(
                name: "IX_Semester_ProfileID",
                table: "Semesters",
                newName: "IX_Semesters_ProfileID");

            migrationBuilder.AddColumn<int>(
                name: "SemesterNumber",
                table: "Semesters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semesters_SemesterId",
                table: "Course",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_Profiles_ProfileID",
                table: "Semesters",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semesters_SemesterId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_Profiles_ProfileID",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "SemesterNumber",
                table: "Semesters");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "profiles");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Semester",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Semesters_ProfileID",
                table: "Semester",
                newName: "IX_Semester_ProfileID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profiles",
                table: "profiles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Semester_profiles_ProfileID",
                table: "Semester",
                column: "ProfileID",
                principalTable: "profiles",
                principalColumn: "ID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeCalculator.Migrations
{
    /// <inheritdoc />
    public partial class v021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterNumber",
                table: "Semesters",
                newName: "SemesterOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterOrder",
                table: "Semesters",
                newName: "SemesterNumber");
        }
    }
}

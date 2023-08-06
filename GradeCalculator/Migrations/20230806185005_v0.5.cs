using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeCalculator.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalCreditHour",
                table: "Semesters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalGradePoint",
                table: "Semesters",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCreditHour",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "TotalGradePoint",
                table: "Semesters");
        }
    }
}

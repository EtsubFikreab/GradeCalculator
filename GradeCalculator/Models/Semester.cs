namespace GradeCalculator.Models
{
	public class Semester
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SemesterOrder { get; set; }
		public int Year { get; set; }
		public double? Average { get; set; }
		public double? CGPA { get; set; }

		public List<Course>? Courses { get; set; }
	}
}

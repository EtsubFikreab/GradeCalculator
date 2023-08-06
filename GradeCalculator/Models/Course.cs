namespace GradeCalculator.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string CourseCode { get; set; }
		public string CourseTitle { get; set; }
		public double CreditHour { get; set; }
		public string Grade { get; set; }
		public double? GradePoint { get; set; }
	}
}

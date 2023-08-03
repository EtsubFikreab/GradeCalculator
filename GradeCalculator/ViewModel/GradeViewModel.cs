using GradeCalculator.Models;

namespace GradeCalculator.ViewModel
{
	public class GradeViewModel
	{
		public Profile profile { get; set; }
		public List<Semester>? semesters { get; set; }
		public Semester? newSemester { get; set; }
		public Course? newCourse { get; set; }

	}
}

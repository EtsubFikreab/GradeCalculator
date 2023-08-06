using GradeCalculator.Models;

namespace GradeCalculator.Repository
{
	public interface IGradeCalculatorRepository
	{
		public List<Profile> GetProfiles();
		public void AddProfile(string ProfileName);
		public Profile GetProfile(Profile profile);
		public Profile GetProfileById(int id);
		public void AddSemester(Profile profile, Semester semester);
		public void AddCourse(Profile profile, Semester semester, Course course);
		public Course CalculateGradePoint(Course course);
		public Semester GetSemester(int SemesterID);
		public void DeleteSemester(Semester semester);
		public void EditSemester(Semester semester);

	}
}

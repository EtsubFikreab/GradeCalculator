using GradeCalculator.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GradeCalculator.Repository
{
	public class GradeCalculatorRepository : IGradeCalculatorRepository
	{
		private readonly GradeCalculatorContext _GradeCalculatorContext;
		public GradeCalculatorRepository(GradeCalculatorContext context)
		{
			_GradeCalculatorContext = context;
		}
		public void AddProfile(string ProfileName)
		{
			_GradeCalculatorContext.Profiles.Add(new Profile { Name = ProfileName });
			_GradeCalculatorContext.SaveChanges();
		}
		public List<Profile> GetProfiles()
		{
			return _GradeCalculatorContext.Profiles.ToList();
		}
		public Profile GetProfile(Profile profile)
		{
			profile = _GradeCalculatorContext.Profiles.Where(p => p.ID == profile.ID).Include(p => p.Semesters).FirstOrDefault();
			for (int i = 0; i < profile.Semesters.Count; i++)
			{
				profile.Semesters[i] = _GradeCalculatorContext.Semesters.Where(s => s.Id == profile.Semesters[i].Id).Include(s => s.Courses).FirstOrDefault();
			}
			return profile;
		}
		public Profile GetProfileById(int id)
		{
			Profile profile = _GradeCalculatorContext.Profiles.Where(p => p.ID == id).Include(p => p.Semesters).ThenInclude(s => s.Courses).FirstOrDefault();
			return profile;
		}
		public void AddSemester(Profile profile, Semester semester)
		{
			_GradeCalculatorContext.Profiles.Where(p => p.ID == profile.ID).Include(p => p.Semesters).FirstOrDefault().Semesters.Add(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public void AddCourse(Semester semester, Course course)
		{
			//_GradeCalculatorContext.Profiles.Where(p => p.ID == profile.ID).Include(p => p.Semesters).FirstOrDefault().Semesters.Where(;
			_GradeCalculatorContext.Semesters.Where(w => w.Id == semester.Id).Include(w => w.Courses).FirstOrDefault().Courses.Add(course);
			_GradeCalculatorContext.SaveChanges();
		}
		public Course CalculateGradePoint(Course course)
		{
			course.Grade = course.Grade.ToUpper();
			if (course.Grade.Equals("A+") || course.Grade.Equals("A"))
				course.GradePoint = course.CreditHour * 4;
			else if (course.Grade.Equals("A-"))
				course.GradePoint = course.CreditHour * 3.7;
			else if (course.Grade.Equals("B+"))
				course.GradePoint = course.CreditHour * 3.5;
			else if (course.Grade.Equals("B"))
				course.GradePoint = course.CreditHour * 3;
			else if (course.Grade.Equals("B-"))
				course.GradePoint = course.CreditHour * 2.7;
			else if (course.Grade.Equals("C+"))
				course.GradePoint = course.CreditHour * 2.5;
			else if (course.Grade.Equals("C"))
				course.GradePoint = course.CreditHour * 2;
			else if (course.Grade.Equals("C-"))
				course.GradePoint = course.CreditHour * 1.7;
			else if (course.Grade.Equals("D+"))
				course.GradePoint = course.CreditHour * 1.5;
			else if (course.Grade.Equals("D"))
				course.GradePoint = course.CreditHour * 1;
			else if (course.Grade.Equals("D-"))
				course.GradePoint = course.CreditHour * 0.7;
			else if (course.Grade.Equals("F"))
				course.GradePoint = course.CreditHour * 0;
			else
				course.GradePoint = 0;
			return course;
		}
		public Semester GetSemester(int SemesterID)
		{
			return _GradeCalculatorContext.Semesters.Where(s=>s.Id==SemesterID).Include(s=>s.Courses).FirstOrDefault();
		}
		public void DeleteSemester(Semester semester)
		{
			_GradeCalculatorContext.Semesters.Remove(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public void EditSemester(Semester semester)
		{
			var modifiedSemeseter = _GradeCalculatorContext.Attach(semester);
			modifiedSemeseter.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_GradeCalculatorContext.SaveChanges();
		}
	}
}

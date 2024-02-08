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
			profile.Semesters = profile.Semesters.OrderBy(s => s.SemesterOrder).ToList();
			return profile;
		}
		public Profile GetProfileById(int id)
		{
			Profile profile = _GradeCalculatorContext.Profiles.Where(p => p.ID == id).Include(p => p.Semesters).ThenInclude(s => s.Courses).FirstOrDefault();
			profile.Semesters = profile.Semesters.OrderBy(s => s.SemesterOrder).ToList();
			return profile;
		}
		public void AddSemester(Profile profile, Semester semester)
		{
			semester.CGPA = 0;
			semester.Average = 0;
			semester.TotalCreditHour = 0;
			semester.TotalGradePoint = 0;
			_GradeCalculatorContext.Profiles.Where(p => p.ID == profile.ID).Include(p => p.Semesters).FirstOrDefault().Semesters.Add(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public void AddCourse(Profile profile, Semester semester, Course course)
		{
			_GradeCalculatorContext.Semesters.Where(w => w.Id == semester.Id).Include(w => w.Courses).FirstOrDefault().Courses.Add(course);
			profile = GetProfileById(profile.ID);
			semester = _GradeCalculatorContext.Semesters.Where(w => w.Id == semester.Id).Include(w => w.Courses).FirstOrDefault();
			semester = CalculateGrade(profile.Semesters, semester);
			_GradeCalculatorContext.Update(semester);
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
			return _GradeCalculatorContext.Semesters.Where(s => s.Id == SemesterID).Include(s => s.Courses).FirstOrDefault();
		}
		public void DeleteSemester(Semester semester)
		{
			_GradeCalculatorContext.Semesters.Remove(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public Course GetCourse(int CourseId)
		{
			return _GradeCalculatorContext.Courses.Find(CourseId);
		}
		public void DeleteCourse(Profile profile, Semester semester, Course course)
		{
			_GradeCalculatorContext.Courses.Remove(course);
			profile = GetProfileById(profile.ID);
			semester = _GradeCalculatorContext.Semesters.Where(w => w.Id == semester.Id).Include(w => w.Courses).FirstOrDefault();
			semester = CalculateGrade(profile.Semesters, semester);
			_GradeCalculatorContext.Update(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public void EditSemester(Semester semester)
		{
			_GradeCalculatorContext.Update(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		public void EditCourse(Profile profile, Semester semester, Course course)
		{
			_GradeCalculatorContext.Courses.Update(course);
			profile = GetProfileById(profile.ID);
			semester = _GradeCalculatorContext.Semesters.Where(w => w.Id == semester.Id).Include(w => w.Courses).FirstOrDefault();
			semester = CalculateGrade(profile.Semesters, semester);
			_GradeCalculatorContext.Update(semester);
			_GradeCalculatorContext.SaveChanges();
		}
		Semester CalculateGrade(List<Semester> semesters, Semester semester)
		{
			if (semester.Courses.Count > 0 && semester.SemesterOrder.Equals(semesters[0].SemesterOrder))
			{
				semester.TotalGradePoint = 0;
				semester.TotalCreditHour = 0;
				foreach (var c in semester.Courses)
				{
					semester.TotalCreditHour += c.CreditHour;
					semester.TotalGradePoint += c.GradePoint;
				}
				semester.Average = (semester.TotalGradePoint / (semester.TotalCreditHour * 4)) * 4;
				semester.CGPA = semester.Average;
			}
			else
			{
				semester.TotalGradePoint = 0;
				semester.TotalCreditHour = 0;
				if (semester.Courses.Count > 0)
				{
					foreach (var c in semester.Courses)
					{
						semester.TotalCreditHour += c.CreditHour;
						semester.TotalGradePoint += c.GradePoint;
					}
					semester.Average = (semester.TotalGradePoint / (semester.TotalCreditHour * 4)) * 4;
				}
				else
					semester.Average = 0;
				double? TotalGP = 0;
				double? TotalCredit = 0;
				int i = 0;
				do
				{
					TotalGP += semesters[i].TotalGradePoint;
					TotalCredit += semesters[i].TotalCreditHour;
					i++;
				} while (i < semesters.Count && semesters[i].SemesterOrder <= semester.SemesterOrder);

				semester.CGPA = (TotalGP / (TotalCredit * 4)) * 4;
			}
			return semester;
		}
	}
}

using GradeCalculator.Models;
using Microsoft.EntityFrameworkCore;

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
		public void AddSemester(Profile profile)
		{

		}
	}
}

using GradeCalculator.Models;

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
	}
}

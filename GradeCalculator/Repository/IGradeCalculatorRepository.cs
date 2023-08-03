using GradeCalculator.Models;

namespace GradeCalculator.Repository
{
	public interface IGradeCalculatorRepository
	{
		public List<Profile> GetProfiles();
		public void AddProfile(string ProfileName);
		public Profile GetProfile(Profile profile);
    }
}

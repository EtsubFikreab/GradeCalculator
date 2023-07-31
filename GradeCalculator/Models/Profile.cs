namespace GradeCalculator.Models
{
	public class Profile
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<Semester>? Semesters { get; set; }
	}
}

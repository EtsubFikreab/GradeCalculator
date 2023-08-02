using GradeCalculator.Models;
using GradeCalculator.Repository;
using GradeCalculator.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GradeCalculator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IGradeCalculatorRepository _GradeCalculatorRepository;

		public HomeController(ILogger<HomeController> logger, IGradeCalculatorRepository gradeCalculatorRepository)
		{
			_logger = logger;
			_GradeCalculatorRepository = gradeCalculatorRepository;
		}

		public IActionResult Index()
		{
			List<Profile> profiles = _GradeCalculatorRepository.GetProfiles();
			ProfileViewModel profileViewModel = new ProfileViewModel { Profiles = profiles };
			return View(profileViewModel);
		}
		public ActionResult AddProfile(ProfileViewModel profileViewModel)
		{
			_GradeCalculatorRepository.AddProfile(profileViewModel.Profile.Name);
			return Redirect("Index");
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
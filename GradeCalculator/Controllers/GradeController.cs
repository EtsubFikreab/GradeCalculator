using GradeCalculator.Repository;
using GradeCalculator.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GradeCalculator.Controllers
{
    public class GradeController : Controller
    {
		private readonly IGradeCalculatorRepository _GradeCalculatorRepository;
		public IActionResult Index(ProfileViewModel profileViewModel)
        {
            return View(profileViewModel.Profile);
        }
        public ActionResult ViewGrades()
        {
            return View();
        }
    }
}

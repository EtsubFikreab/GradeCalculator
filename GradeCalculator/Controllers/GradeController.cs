using GradeCalculator.Repository;
using GradeCalculator.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GradeCalculator.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeCalculatorRepository _GradeCalculatorRepository;
        public GradeController(IGradeCalculatorRepository gradeCalculatorRepository)
        {
            _GradeCalculatorRepository = gradeCalculatorRepository;
        }
        public IActionResult Index(ProfileViewModel profileViewModel)
        {
            GradeViewModel gradeViewModel = new GradeViewModel { profile = profileViewModel.Profile };
            //gradeViewModel.semesters = _GradeCalculatorRepository.ge
            return View(gradeViewModel);
        }
        public ActionResult ViewGrades()
        {
            return View();
        }
        public IActionResult AddSemester(GradeViewModel gradeViewModel)
        {
            gradeViewModel.profile = _GradeCalculatorRepository.GetProfile(gradeViewModel.profile);

            return Index(new ProfileViewModel { Profile=gradeViewModel.profile});
            //return View(gradeViewModel);
        }
    }
}

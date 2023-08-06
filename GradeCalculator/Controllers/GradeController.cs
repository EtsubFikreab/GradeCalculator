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
		public IActionResult Index(int id)
		{
			GradeViewModel gradeViewModel = new GradeViewModel { profile = _GradeCalculatorRepository.GetProfileById(id) };
			//gradeViewModel.semesters = _GradeCalculatorRepository.ge
			return View(gradeViewModel);
		}
		public ActionResult ViewGrades()
		{
			return View();
		}
		public IActionResult AddSemester(GradeViewModel gradeViewModel)
		{
			//gradeViewModel.profile = _GradeCalculatorRepository.GetProfile(gradeViewModel.profile);
			_GradeCalculatorRepository.AddSemester(gradeViewModel.profile, gradeViewModel.newSemester);
			return View(gradeViewModel);
		}
		public IActionResult AddCourse(GradeViewModel gradeViewModel)
		{
			gradeViewModel.newCourse = _GradeCalculatorRepository.CalculateGradePoint(gradeViewModel.newCourse);
			_GradeCalculatorRepository.AddCourse(gradeViewModel.profile, gradeViewModel.newSemester, gradeViewModel.newCourse);
			return View(gradeViewModel);
		}
		public IActionResult DeleteSemester(GradeViewModel gradeViewModel)
		{
			gradeViewModel.newSemester = _GradeCalculatorRepository.GetSemester(gradeViewModel.newSemester.Id);
			_GradeCalculatorRepository.DeleteSemester(gradeViewModel.newSemester);
			return View(gradeViewModel);
		}
		public IActionResult EditSemester(GradeViewModel gradeViewModel)
		{
			if(gradeViewModel.newSemester.Name == null)
			gradeViewModel.newSemester = _GradeCalculatorRepository.GetSemester(gradeViewModel.newSemester.Id);
			_GradeCalculatorRepository.EditSemester(gradeViewModel.newSemester);
			return View(gradeViewModel);
		}
		public IActionResult DeleteCourse(GradeViewModel gradeViewModel)
		{
			gradeViewModel.newCourse = _GradeCalculatorRepository.GetCourse(gradeViewModel.newCourse.Id);
			_GradeCalculatorRepository.DeleteCourse(gradeViewModel.newCourse);
			return View(gradeViewModel);
		}
	}
}

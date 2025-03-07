using Microsoft.AspNetCore.Mvc;
using SalaryPackaging.Models;
using SalaryPackaging.Services;

namespace SalaryPackaging.Controllers
{
    public class SalaryPackagingController : Controller
    {
        private readonly ISalaryPackagingService _salaryPackagingService;

        public SalaryPackagingController(ISalaryPackagingService salaryPackagingService)
        {
            _salaryPackagingService = salaryPackagingService;
        }
        [HttpPost]
        public IActionResult Calculate(Employee employee)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", new { error = "Invalid input" });

            try
            {
                employee.SalaryPackagingLimit = _salaryPackagingService.CalculatePackageLimit(employee);
                return View("Index", employee);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

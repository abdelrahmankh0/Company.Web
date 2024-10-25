using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
		{
			_employeeService = employeeService;
           _departmentService = departmentService;
        }
		
		public IActionResult Index(string searchInp)
		{
			//viewBag - ViewData - TempData
			// ViewBag.Message = "Hello From Employee index (ViewBag)";

			// ViewData["TextMessage"] = "Hello From Employee index (ViewData)";



			IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
			if (string.IsNullOrEmpty(searchInp))		
				 employees = _employeeService.GetAll();
			else
				 employees = _employeeService.GetEmployeeByName(searchInp);
				return View(employees);
			
			

        }
	    [HttpGet]
		public IActionResult Create()
		{
			var departments = _departmentService.GetAll();
			ViewBag.Departments = departments;	
			return View();
		}
		[HttpPost]
		public IActionResult Create(EmployeeDto employee)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);

                    return RedirectToAction(nameof(Index));
                }
                var departments = _departmentService.GetAll();
                ViewBag.Departments = departments;
                return View(employee);
            }
            catch (Exception ex)
            {
                var departments = _departmentService.GetAll();
                ViewBag.Departments = departments;
                return View(employee);

            }
        }
		/*
	   public IActionResult Details(int? id, string viewName = "Details")
		{



		}
		[HttpGet]
		public IActionResult Update(int? id)
		{

		}

		[HttpPost]
		public IActionResult Update(int? id, Employee employee)
		{


		}

		[HttpGet]
		public IActionResult Delete(int id)
		{


		}
		*/


	}
}
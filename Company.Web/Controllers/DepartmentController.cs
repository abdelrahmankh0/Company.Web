using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
	public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
           //  TempData.Keep("TextTempMessage");
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(DepartmentDto department)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);

					//TempData["TextTempMessage"] = "Hello From Employee index (TempData)";


					return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentErrors", "ValidationErrors");

                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);

            }

        }

        public IActionResult Details(int? id,string viewName="Details")
        {
			var department = _departmentService.GetById(id);

            if (department is null)
                return RedirectToAction("Not Found Page",null,"Home");

            return View(viewName,department);


		}
        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id,"Update");

		}

        [HttpPost]
        public IActionResult Update(int? id,DepartmentDto department)
        {
            if(department.Id != id.Value)
				return RedirectToAction("Not Found Page", null, "Home");

            _departmentService.Update(department);

            return RedirectToAction(nameof(Index));

		}

        [HttpGet]
        public IActionResult Delete(int id)
        {
			var department = _departmentService.GetById(id);

			if (department is null)
				return RedirectToAction("Not Found Page", null, "Home");

            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));


		}


	}
}

using Company.Data.Models;
using Company.Repository.Repositories;
using Company.Service.Interfaces;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var department = departmentService.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Department department)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    departmentService.Add(department);

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
			var department = departmentService.GetById(id);

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
        public IActionResult Update(int? id,Department department)
        {
            if(department.Id != id.Value)
				return RedirectToAction("Not Found Page", null, "Home");

            departmentService.Update(department);

            return RedirectToAction(nameof(Index));

		}

        [HttpPost]
        public IActionResult Delete(int id)
        {
			var department = departmentService.GetById(id);

			if (department is null)
				return RedirectToAction("Not Found Page", null, "Home");

            departmentService.Delete(department);
            return RedirectToAction(nameof(Index));


		}


	}
}

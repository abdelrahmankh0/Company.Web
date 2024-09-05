using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;

        public DepartmentController(DepartmentService departmentService )
        {
            departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var department = departmentService.GetAll();
            return View(department);
        }
    }
}

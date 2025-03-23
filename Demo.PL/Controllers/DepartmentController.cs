using Microsoft.AspNetCore.Mvc;
using Demo.PesnL.Services;

namespace Demo.PL.Controllers
{
    public class DepartmentController(DepartmentServices DeptServices) : Controller
    {
        public IActionResult Index()
        {
            var depts = DeptServices.GetDepartmentById(10);
            return View(depts);
        }
    }
}

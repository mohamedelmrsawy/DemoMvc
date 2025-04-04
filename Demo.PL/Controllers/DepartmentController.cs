using Microsoft.AspNetCore.Mvc;
using Demo.PesnL.Services;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices _DeptServices) : Controller
    {
        public IActionResult Index()
        {
            var depts = _DeptServices.GetAllDepartments();
            return View(depts);
        }
    }
}

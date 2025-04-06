using Demo.PesnL.DataTransferObject;
using Demo.PesnL.DataTransferObject.Employeess;
using Demo.PesnL.Services.EmployeeServicess;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeService _service , ILogger<EmployeeController> logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var emp = _service.GetAllEmployee();
            return View(emp);
        }

        #region Create
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]

        public IActionResult Create(CreateEmployeeDto dept)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _service.CreateEmployee(dept);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Employee can not creating");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        logger.LogError(ex.Message);
                    }
                }
            }

            return View(dept);

        }

        #endregion

        #region Details 
        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _service.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();
            return View(emp);
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Demo.PesnL.Services;
using Demo.PesnL.DataTransferObject;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices _DeptServices,
        ILogger<DepartmentController> logger, IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index()
        {
            var depts = _DeptServices.GetAllDepartments();
            return View(depts);
        }

        #region Creating Depart
        
        public IActionResult Create() => View();

        [HttpPost]

        public IActionResult Create(CreatedDepartmentDto dept)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _DeptServices.AddDepartment(dept);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department can not creating");
                }
                catch(Exception ex)
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
    }
}

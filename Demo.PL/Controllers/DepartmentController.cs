using Microsoft.AspNetCore.Mvc;
using Demo.PesnL.Services;
using Demo.PesnL.DataTransferObject;
using Demo.PL.ViewModels.DepartmentViewModel;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentServices _DeptServices,
        ILogger<DepartmentController> logger, IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = new DepartmentDbo() { Name = "View Data" };
            ViewBag.Message = new DepartmentDbo() { Name = "View Bag" };

            var depts = _DeptServices.GetAllDepartments();
            return View(depts);
        }

        #region Creating Depart
        
        public IActionResult Create() => View();

        [HttpPost]

        public IActionResult Create(DepartmentViewModel dept)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var dept2 = new CreatedDepartmentDto()
                    {
                        Name = dept.Name,
                        Code = dept.Code,
                        DateOfCreation = dept.DateOfCreation,
                        Description = dept.Description
                    };
                    int Result = _DeptServices.AddDepartment(dept2);
                    string Message;
                    //if (Result > 0)
                    //    return RedirectToAction(nameof(Index));
                    //else
                    //    ModelState.AddModelError(string.Empty, "Department can not creating");

                    if (Result > 0)
                    {
                        Message = $"Department {dept.Name} is Created ";                      
                    }
                    else
                    {
                        Message = $"Department {dept.Name} is Created ";
                    }
                    TempData["Message"] = Message ;
                    return RedirectToAction(nameof(Index));

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

        #region Details Of Department
        [HttpGet]

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var dept = _DeptServices.GetDepartmentById(id.Value);
            if (dept is null) return NotFound();
            return View(dept);
        }

        #endregion

        #region Edit
        [HttpGet]

        public IActionResult Edit([FromRoute]int id , DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var deptView = new UpdatedDepartmentDto()
                    {
                        Id = id ,
                        code = model.Code,
                        Name = model.Name,
                        Description = model.Description,
                        DateOfCreation = (DateOnly)model.DateOfCreation
                    };

                    int Result = _DeptServices.UpdateDepartment(deptView);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "!!!!");
                    }


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
            return View(model);
            
        }

        #endregion

        #region Delete

        [HttpGet]
        
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var dept = _DeptServices.GetDepartmentById(id.Value);
            if (dept is null) return NotFound();
            return View(dept);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool delete = _DeptServices.DeletedDepartment(id);
                if (delete)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "!!!!!!!");
                    return RedirectToAction(nameof(Delete));
                }
            }catch(Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }

        }


        #endregion

    }
}

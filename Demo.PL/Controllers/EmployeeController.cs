using Demo.PesnL.DataTransferObject;
using Demo.PesnL.DataTransferObject.Employeess;
using Demo.PesnL.Services.EmployeeServicess;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeService _service , ILogger<EmployeeController> logger, IWebHostEnvironment _environment) : Controller
    {
        #region Index
        public IActionResult Index()
        {
            var emp = _service.GetAllEmployee();
            return View(emp);
        } 
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(EmployeeViewModel dept)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var empdto = new CreateEmployeeDto()
                    {
                        Name = dept.Name,
                        Age = dept.Age,
                        Address = dept.Address,
                        Email = dept.Email,
                        EmployeeType = dept.EmployeeType,
                        Gender = dept.Gender,
                        HiringDate = dept.HiringDate,
                        IsActive = dept.IsActive,
                        PhoneNumber = dept.PhoneNumber,
                        Salary = dept.Salary,
                        DepartmentId = dept.DepartmentId
                    };

                    int Result = _service.CreateEmployee(empdto);
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

        #region Edit

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _service.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();

            var empDto = new EmployeeViewModel()
            {
                Name = emp.Name,
                Address = emp.Address,
                Age = emp.Age,
                Email = emp.Email,
                HiringDate = emp.HiringDate,
                IsActive = emp.IsActive,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary,
                

            };
            return View(empDto);
        }

        [HttpPost]

        public IActionResult Edit([FromRoute]int? id , EmployeeViewModel dto)
        {
            if (!id.HasValue ) return BadRequest();
            if (!ModelState.IsValid) return View(dto);
            try
            {
                var empdto = new UpdateEmployeeDto()
                {
                    Id = id.Value,
                    Name = dto.Name,
                    Address = dto.Address,
                    Age = dto.Age,
                    Email = dto.Email,
                    HiringDate = dto.HiringDate,
                    IsActive = dto.IsActive,
                    PhoneNumber = dto.PhoneNumber,
                    Salary = dto.Salary,
                    DepartmentId = dto.DepartmentId
                    
                };
                var Result = _service.UpdateEmployee(empdto);
                if (Result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "!!!!!!");
                    return View(dto);
                }




            }catch(Exception ex)
            {


                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(dto);
                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }


            }

        }

        #endregion

        #region Delete

        [HttpPost]

        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool delete = _service.DeleteEmployee(id);
                if (delete)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "!!!!!!!");
                    return RedirectToAction(nameof(Delete));
                }
            }
            catch (Exception ex)
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

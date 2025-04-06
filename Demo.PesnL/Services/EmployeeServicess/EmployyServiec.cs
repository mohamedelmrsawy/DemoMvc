using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Employees;
using Demo.PesnL.DataTransferObject.Employeess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Services.EmployeeServicess
{
    class EmployyServiec(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public IEnumerable<Employee> GetAllEmployee(bool WithTracking)
        {
            var Employee = _employeeRepository.GetAll(WithTracking);
            var empDto = Employee.Select(e => new Employee()
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Email = e.Email,
                IsActive = e.IsActive,
                Salary = e.Salary,
                EmployeeType = e.EmployeeType,
                Gender = e.Gender
            });
            return empDto;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetById(id);
            return emp is null ? null : new EmployeeDetailsDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                Address = emp.Address,
                Age = emp.Age,
                Email = emp.Email,
                HiringDate = DateOnly.FromDateTime(emp.HiringDate),
                IsActive = emp.IsActive,
                PhoneNumber = emp.PhonNumber,
                EmployeeType = emp.EmployeeType.ToString(),
                Gender = emp.Gender.ToString(),
                CreatedBy = 1,
                CreatedOn = emp.CreatedOn,
                LastModifiedBy = 1,
                LastModifiedOn = (DateTime)emp.LastModifiedOn
            };
        }

        public int CreateEmployee(CreateEmployeeDto dto)
        {
            throw new NotImplementedException();          
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

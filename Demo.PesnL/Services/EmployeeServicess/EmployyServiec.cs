using AutoMapper;
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
    public class EmployyServiec(IEmployeeRepository _employeeRepository , IMapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployee(bool WithTracking)
        {
            var Employee = _employeeRepository.GetAll(WithTracking);
            var empDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employee);
            //var empDto = Employee.Select(e => new Employee()
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Email = e.Email,
            //    IsActive = e.IsActive,
            //    Salary = e.Salary,
            //    EmployeeType = e.EmployeeType,
            //    Gender = e.Gender
            //});
            return empDto;
        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetById(id);
            return emp is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(emp);
        }

        public int CreateEmployee(CreateEmployeeDto dto)
        {
            var emp = _mapper.Map<CreateEmployeeDto, Employee>(dto);
            return _employeeRepository.Add(emp);
        }

        public bool DeleteEmployee(int id)
        {
            var emp = _employeeRepository.GetById(id);
            if (emp is null) return false;
            else
            {
                emp.InDeleted = true;
                return _employeeRepository.Update(emp) > 0 ? true : false;
            }
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(dto));
        }
    }
}

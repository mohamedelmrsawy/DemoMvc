using AutoMapper;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Employees;
using Demo.DataAccess.Repositories.UnitOfWorks;
using Demo.PesnL.DataTransferObject.Employeess;
using Demo.PesnL.Services.AttachementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Services.EmployeeServicess
{

    {
        public IEnumerable<EmployeeDto> GetAllEmployee(string? empSearsh)
        {

            IEnumerable<Employee> employees;

            if (string.IsNullOrWhiteSpace(empSearsh))
            {
                // employees = _employeeRepository.GetAll();
                employees = _unitOfWork.employeeRepository.GetAll();
            }else
            {
                employees = _unitOfWork.employeeRepository.GetAll(e => e.Name.ToLower().Contains(empSearsh.ToLower()));
            }


            //var Result = _employeeRepository.GetEnumerable().Where(e => e.InDeleted != true).Select(e => new EmployeeDto
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Age = e.Age,
            //    Salary = e.Salary
            //}).Where(e => e.Age > 25);

            //return Result.ToList();


            var Employee = _employeeRepository.GetAll(WithTracking);

            var empDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employee);


            //var Employee = _employeeRepository.GetAll(e => e.Name.ToLower().Contains(empSearsh.ToLower()));
            var empDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return empDto;




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

        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var emp = _unitOfWork.employeeRepository.GetById(id);
            return emp is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(emp);
        }

        public int CreateEmployee(CreateEmployeeDto dto)
        {
            var emp = _mapper.Map<CreateEmployeeDto, Employee>(dto);
            _unitOfWork.employeeRepository.Add(emp);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var emp = _unitOfWork.employeeRepository.GetById(id);
            if (emp is null) return false;
            else
            {
                emp.InDeleted = true;
                _unitOfWork.employeeRepository.Update(emp) ;
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }

        public int UpdateEmployee(UpdateEmployeeDto dto)
        {
            _unitOfWork.employeeRepository.Update(_mapper.Map<UpdateEmployeeDto, Employee>(dto));
            return _unitOfWork.SaveChanges();
        }
    }
}

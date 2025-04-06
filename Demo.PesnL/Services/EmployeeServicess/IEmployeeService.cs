using Demo.DataAccess.Models;
using Demo.PesnL.DataTransferObject.Employeess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Services.EmployeeServicess
{
    interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee(bool WithTracking);
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto dto);
        int UpdateEmployee(UpdateEmployeeDto dto);
        int DeleteEmployee(int id);

    }
}

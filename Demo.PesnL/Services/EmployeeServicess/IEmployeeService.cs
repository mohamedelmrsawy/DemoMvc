using Demo.DataAccess.Models;
using Demo.PesnL.DataTransferObject.Employeess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Services.EmployeeServicess
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployee(bool WithTracking = false);
        EmployeeDetailsDto GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto dto);
        int UpdateEmployee(UpdateEmployeeDto dto);
        bool DeleteEmployee(int id);

    }
}

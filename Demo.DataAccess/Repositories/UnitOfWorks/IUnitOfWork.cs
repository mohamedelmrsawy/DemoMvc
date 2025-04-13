using Demo.DataAccess.Repositories.Departments;
using Demo.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository employeeRepository { get;  }
        public IDepartmentRepositories  departmentRepositories { get;  }

        int SaveChanges();
    }
}

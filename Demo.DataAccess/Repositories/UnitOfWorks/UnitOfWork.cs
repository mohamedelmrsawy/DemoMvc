using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Departments;
using Demo.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepositories _departmentRepositories;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(IEmployeeRepository employeeRepository , IDepartmentRepositories departmentRepositories , ApplicationDbContext dbContext)
        {
            _employeeRepository = employeeRepository;
            _departmentRepositories = departmentRepositories;
            _dbContext = dbContext;
        }

        public IEmployeeRepository employeeRepository  => _employeeRepository; 
        public IDepartmentRepositories departmentRepositories  => _departmentRepositories; 

        public int SaveChanges() => _dbContext.SaveChanges();
        
    }
}

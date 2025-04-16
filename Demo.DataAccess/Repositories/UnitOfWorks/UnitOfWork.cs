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

        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepositories> _departmentRepositories;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(/*IEmployeeRepository employeeRepository , IDepartmentRepositories departmentRepositories ,*/ ApplicationDbContext dbContext)
        {
            //_employeeRepository = employeeRepository;
            //_departmentRepositories = departmentRepositories;
            _dbContext = dbContext;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _departmentRepositories = new Lazy<IDepartmentRepositories>(() => new DepartmentRepositories(dbContext));
        }

        public IEmployeeRepository employeeRepository  => _employeeRepository.Value; 
        public IDepartmentRepositories departmentRepositories  => _departmentRepositories.Value; 

        public int SaveChanges() => _dbContext.SaveChanges();
        
    }
}

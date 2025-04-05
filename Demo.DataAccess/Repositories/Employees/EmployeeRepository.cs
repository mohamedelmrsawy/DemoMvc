using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Generic;


namespace Demo.DataAccess.Repositories.Employees
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {

    }
}

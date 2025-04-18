using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Departments
{
    public class DepartmentRepositories(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepositories
    {
        
    }
}

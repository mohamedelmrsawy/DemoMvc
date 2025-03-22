using Demo.DataAccess.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    class DepartmentRepositories
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepositories(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

    }
}

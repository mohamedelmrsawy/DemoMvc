using Demo.DataAccess.Repositories;

namespace Demo.PesnL.Services
{
    class DepartmentServices
    {
        private readonly IDepartmentRepositories departmentRepositories;

        public DepartmentServices(IDepartmentRepositories departmentRepositories)
        {
            this.departmentRepositories = departmentRepositories;
        }

    }
}

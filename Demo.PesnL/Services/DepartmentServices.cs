using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Departments;
using Demo.PesnL.DataTransferObject;
using Demo.PesnL.Factories;

namespace Demo.PesnL.Services
{
    public class DepartmentServices(IDepartmentRepositories _departmentRepositories) : IDepartmentServices
    {
        //private readonly IDepartmentRepositories departmentRepositories = _departmentRepositories;


        public IEnumerable<DepartmentDbo> GetAllDepartments()
        {
            var department = _departmentRepositories.GetAll();


            return department.Select(d => d.ToDepartmentDbo());
        }

        public DepartmentDetilsDbo GetDepartmentById(int id)
        {
            var department = _departmentRepositories.GetById(id);

            if (department is null)
            {
                return null;
            }
            else
            {
                var deptDetils = new DepartmentDetilsDbo()
                {
                    Id = department.Id,
                    Name = department.Name,
                };

                return deptDetils;
            }

        }

        public int AddDepartment(CreatedDepartmentDto d)
        {
            var dept = d.ToEntity();
            return _departmentRepositories.Add(dept);
        }

        public int UpdateDepartment(UpdatedDepartmentDto d)
        {
            return _departmentRepositories.Update(d.ToEntity());
        }

        public bool DeletedDepartment(int id)
        {
            var Dept = _departmentRepositories.GetById(id);

            if (Dept is null)
            {
                return false;
            }
            else
            {
                int R = _departmentRepositories.Remove(Dept);
                return R > 0 ? true : false;
            }

        }

    }
}

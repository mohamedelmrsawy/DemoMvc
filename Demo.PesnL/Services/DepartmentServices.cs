using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Departments;
using Demo.DataAccess.Repositories.UnitOfWorks;
using Demo.PesnL.DataTransferObject;
using Demo.PesnL.Factories;

namespace Demo.PesnL.Services
{
    public class DepartmentServices(IUnitOfWork _unitOfWork) : IDepartmentServices
    {
        //private readonly IDepartmentRepositories departmentRepositories = _departmentRepositories;


        public IEnumerable<DepartmentDbo> GetAllDepartments()
        {
            var department = _unitOfWork.departmentRepositories.GetAll();


            return department.Select(d => d.ToDepartmentDbo());
        }

        public DepartmentDetilsDbo GetDepartmentById(int id)
        {
            var department = _unitOfWork.departmentRepositories.GetById(id);

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
            _unitOfWork.departmentRepositories.Add(dept);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateDepartment(UpdatedDepartmentDto d)
        {
            _unitOfWork.departmentRepositories.Update(d.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        public bool DeletedDepartment(int id)
        {
            var Dept = _unitOfWork.departmentRepositories.GetById(id);

            if (Dept is null)
            {
                return false;
            }
            else
            {
                _unitOfWork.departmentRepositories.Remove(Dept);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }

        }

    }
}

using Demo.PesnL.DataTransferObject;

namespace Demo.PesnL.Services
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDepartmentDto d);
        bool DeletedDepartment(int id);
        IEnumerable<DepartmentDbo> GetAllDepartments();
        DepartmentDetilsDbo GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto d);
    }
}
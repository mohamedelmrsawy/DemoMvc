using Demo.DataAccess.Models;
using Demo.PesnL.DataTransferObject;


namespace Demo.PesnL.Factories
{
    static class DepartmentFactories
    {

        public static DepartmentDbo ToDepartmentDbo(this Department d)
        {
            return new DepartmentDbo()
            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = DateOnly.FromDateTime(d.CreatedOn)
            };
        }

        public static DepartmentDetilsDbo ToDepartmentDetilsDbo(this Department d)
        {
            return new DepartmentDetilsDbo()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                CreatedOn = DateOnly.FromDateTime(d.CreatedOn).ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto d)
        {
            return new Department()
            {
                Name = d.Name,
                Code = d.code,
                Description = d.Description
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto d)
        {
            return new Department()
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.code,
                Description = d.Description
            };
        }
    }
}

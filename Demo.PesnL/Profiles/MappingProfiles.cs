using AutoMapper;
using Demo.DataAccess.Models;
using Demo.PesnL.DataTransferObject.Employeess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Gender, option => option.MapFrom(src => src.Gender))
                                               .ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeType))
                                               .ForMember(dest => dest.Department , option => option.MapFrom(src => src.department != null ? src.department.Name : null ));

            CreateMap<Employee, EmployeeDetailsDto>().ForMember(dest => dest.Gender, option => option.MapFrom(src => src.Gender))
                                               .ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeType))
                                               .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                                               .ForMember(dest => dest.Department, option => option.MapFrom(src => src.department != null ? src.department.Name : null)); ;

            CreateMap<CreateEmployeeDto, Employee>().ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdateEmployeeDto, Employee>().ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
    }
}

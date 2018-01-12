using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.API.Models;
using RESTFulExample.DAL.Entities;

namespace RESTFulExample.API.Util
{
    public class MappingProfile: Profile
    {
         public MappingProfile()
         {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<EmployeeVM, EmployeeDTO>();
            CreateMap<EmployeeDTO, EmployeeVM>();
        }
    }
}

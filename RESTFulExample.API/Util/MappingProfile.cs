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

            CreateMap<Air, AirDTO>();
            CreateMap<AirDTO, Air>();
            CreateMap<AirVM, AirDTO>();
            CreateMap<AirDTO, AirVM>();

            CreateMap<Train, TrainDTO>();
            CreateMap<TrainDTO, Train>();
            CreateMap<TrainVM, TrainDTO>();
            CreateMap<TrainDTO, TrainVM>();

            CreateMap<Hotel, HotelDTO>();
            CreateMap<HotelDTO, Hotel>();
            CreateMap<HotelVM, HotelDTO>();
            CreateMap<HotelDTO, HotelVM>();
        }
    }
}

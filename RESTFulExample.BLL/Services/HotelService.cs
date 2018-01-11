using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Services
{
    public class HotelService : IHotelService
    {
        IUnitOfWork unitOfWork { get; set; }

        public HotelService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var employees = await Mapper.Map<Task<IEnumerable<Employee>>, Task<IEnumerable<EmployeeDTO>>>(unitOfWork.Employees.GetAllAsync());
            return employees;
        }

        public async Task CreateAsync(HotelDTO hotelDTO)
        {
            if (hotelDTO == null)
            {
                throw new BusinessLogicException("Требуется отель", "");
            }

            Hotel hotel = Mapper.Map<HotelDTO, Hotel>(hotelDTO);

            await unitOfWork.Hotels.CreateAsync(hotel);
        }

        public async Task UpdateAsync(HotelDTO hotelDTO)
        {
            if (hotelDTO == null)
            {
                throw new BusinessLogicException("Требуется клиент", "");
            }

            Hotel hotel = Mapper.Map<HotelDTO, Hotel>(hotelDTO);

            await unitOfWork.Hotels.UpdateAsync(hotel);
        }

        public async Task DeleteAsync(int? id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            var hotel = await unitOfWork.Hotels.GetByIdAsynс(id);

            if (hotel == null)
            {
                throw new BusinessLogicException("Поезд не найден", "");
            }

            await unitOfWork.Hotels.DeleteAsync(hotel);
        }

        public async Task<HotelDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            var hotel = await Mapper.Map<Task<Hotel>, Task<HotelDTO>>(unitOfWork.Hotels.GetByIdAsynс(id));
            return hotel;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}

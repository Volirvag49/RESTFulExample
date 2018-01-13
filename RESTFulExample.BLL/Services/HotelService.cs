using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<HotelDTO>> GetAllAsync()
        {
            var hotels = await Mapper.Map<Task<IEnumerable<Hotel>>, Task<IEnumerable<HotelDTO>>>(unitOfWork.Hotels.GetAllAsync());
            return hotels;
        }

        public async Task<IEnumerable<HotelDTO>> GetAvailableAsync()
        {
            Expression<Func<Hotel, bool>> searchQuery = q => q.TravellerId == null;
            var hotels = await Mapper.Map<Task<IEnumerable<Hotel>>, Task<IEnumerable<HotelDTO>>>(unitOfWork.Hotels.GetAsync(filter: searchQuery));
            return hotels;
        }

        public async Task CreateAsync(HotelDTO hotelDTO)
        {
            if (hotelDTO == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            Hotel hotel = new Hotel() {
                Checkin = hotelDTO.Checkin,
                Checkout = hotelDTO.Checkout,
                Name = hotelDTO.Name,
                Provider = hotelDTO.Provider,
                TravellerId = hotelDTO.TravellerId
            };

            unitOfWork.Hotels.Create(hotel);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(HotelDTO hotelDTO)
        {
            if (hotelDTO == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            Hotel hotel = Mapper.Map<HotelDTO, Hotel>(hotelDTO);

            unitOfWork.Hotels.Update(hotel);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            Hotel hotel = await unitOfWork.Hotels.GetByIdAsynс(id);

            if (hotel == null)
            {
                throw new BusinessLogicException("Услуга не найдена", "");
            }

            unitOfWork.Hotels.Delete(hotel);
            await unitOfWork.CommitAsync();
        }

        public async Task<HotelDTO> GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            HotelDTO hotelDTO = await Mapper.Map<Task<Hotel>, Task<HotelDTO>>(unitOfWork.Hotels.GetByIdAsynс(id));
            return hotelDTO;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}

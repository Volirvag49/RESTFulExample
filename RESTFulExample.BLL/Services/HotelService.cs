using AutoMapper;
using RESTFulExample.BLL.DTO;
using RESTFulExample.BLL.Infrastructure;
using RESTFulExample.BLL.Interfaces;
using RESTFulExample.DAL.Entities;
using RESTFulExample.DAL.Interfaces;
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

        public async Task<IEnumerable<HotelDTO>> GetAllAsync()
        {
            var hotels = await Mapper.Map<Task<IEnumerable<Hotel>>, Task<IEnumerable<HotelDTO>>>(unitOfWork.Hotels.GetAllAsync());
            return hotels;
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
                throw new BusinessLogicException("Требуется отель", "");
            }

            Hotel hotel = Mapper.Map<HotelDTO, Hotel>(hotelDTO);

            await unitOfWork.Hotels.UpdateAsync(hotel);
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
                throw new BusinessLogicException("Отель не найден", "");
            }

            await unitOfWork.Hotels.DeleteAsync(hotel);
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

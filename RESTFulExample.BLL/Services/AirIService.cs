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
    public class AirIService : IAirService
    {

        IUnitOfWork unitOfWork { get; set; }

        public AirIService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable<AirDTO>> GetAllAsync()
        {
            var airs = await Mapper.Map<Task<IEnumerable<Air>>, Task<IEnumerable<AirDTO>>>(unitOfWork.Airs.GetAllAsync());
            return airs;
        }

        public async Task<IEnumerable<AirDTO>> GetAvailableAsync()
        {
            Expression<Func<Air, bool>> searchQuery = q => q.TravellerId == null;
            var airs = await Mapper.Map<Task<IEnumerable<Air>>, Task<IEnumerable<AirDTO>>>(unitOfWork.Airs.GetAsync(filter: searchQuery));
            return airs;
        }

        public async Task CreateAsync(AirDTO airDTO)
        {
            if (airDTO == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            Air air = new Air() {
                ArrivalAirport = airDTO.ArrivalAirport,
                ArrivalDate = airDTO.ArrivalDate,
                DepartureAirport = airDTO.DepartureAirport,
                DepartureDate = airDTO.DepartureDate,
                Provider = airDTO.Provider,
                TravellerId = airDTO.TravellerId

            };
            unitOfWork.Airs.Create(air);
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(AirDTO airDTO)
        {
            if (airDTO == null)
            {
                throw new BusinessLogicException("Требуется услуга", "");
            }

            Air air = Mapper.Map<AirDTO, Air>(airDTO);

            unitOfWork.Airs.Update(air);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            Air air = await unitOfWork.Airs.GetByIdAsynс(id);

            if (air == null)
            {
                throw new BusinessLogicException("Услуга не найдена", "");
            }

            unitOfWork.Airs.Delete(air);
            await unitOfWork.CommitAsync();
        }

        public async Task<AirDTO> GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            AirDTO airDTO = await Mapper.Map<Task<Air>, Task<AirDTO>>(unitOfWork.Airs.GetByIdAsynс(id));
            return airDTO;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}

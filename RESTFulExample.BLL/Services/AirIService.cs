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

        public async Task CreateAsync(AirDTO airDTO)
        {
            if (airDTO == null)
            {
                throw new BusinessLogicException("Требуется перелёт", "");
            }

            Air air = Mapper.Map<AirDTO, Air>(airDTO);

            await unitOfWork.Airs.CreateAsync(air);
        }

        public async Task UpdateAsync(AirDTO airDTO)
        {
            if (airDTO == null)
            {
                throw new BusinessLogicException("Требуется перелёт", "");
            }

            Air air = Mapper.Map<AirDTO, Air>(airDTO);

            await unitOfWork.Airs.UpdateAsync(air);
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
                throw new BusinessLogicException("Перелёт не найден", "");
            }

            await unitOfWork.Airs.DeleteAsync(air);
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

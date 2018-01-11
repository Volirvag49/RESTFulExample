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
    public class AirIService : IAirService
    {

        IUnitOfWork unitOfWork { get; set; }

        public AirIService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
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

        public async Task DeleteAsync(int? id)
        {
            if(id == null)
            {
                throw new BusinessLogicException("Требуется перелёт", "");
            }

            var air = await unitOfWork.Airs.GetByIdAsynс(id);

            if (air == null)
            {
                throw new BusinessLogicException("Перелёт не найден", "");
            }

            await unitOfWork.Airs.DeleteAsync(air);
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var airs = await Mapper.Map<Task<IEnumerable<Air>>, Task<IEnumerable<AirDTO>>>(unitOfWork.Airs.GetAllAsync());
            return airs;
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

        public async Task<AirDTO> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            var air = await Mapper.Map<Task<Air>, Task<AirDTO>>(unitOfWork.Airs.GetByIdAsynс(id));
            return air;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}

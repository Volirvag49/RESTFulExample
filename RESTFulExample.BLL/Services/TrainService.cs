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
    public class TrainService : ITrainService
    {
        IUnitOfWork unitOfWork { get; set; }

        public TrainService(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public async Task<IEnumerable<TrainDTO>> GetAllAsync()
        {
            var trains = await Mapper.Map<Task<IEnumerable<Train>>, Task<IEnumerable<TrainDTO>>>(unitOfWork.Trains.GetAllAsync());
            return trains;
        }

        public async Task CreateAsync(TrainDTO trainDTO)
        {
            if (trainDTO == null)
            {
                throw new BusinessLogicException("Требуется поезд", "");
            }

            Train train = Mapper.Map<TrainDTO, Train>(trainDTO);

            await unitOfWork.Trains.CreateAsync(train);
        }

        public async Task UpdateAsync(TrainDTO trainDTO)
        {
            if (trainDTO == null)
            {
                throw new BusinessLogicException("Требуется поезд", "");
            }

            Train train = Mapper.Map<TrainDTO, Train>(trainDTO);

            await unitOfWork.Trains.UpdateAsync(train);
        }

        public async Task DeleteAsync(string id)
        {

            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            Train train = await unitOfWork.Trains.GetByIdAsynс(id);

            if (train == null)
            {
                throw new BusinessLogicException("поезд не найден", "");
            }

            await unitOfWork.Trains.DeleteAsync(train);
        }

        public async Task<TrainDTO> GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new BusinessLogicException("Требуется идентификатор", "");
            }

            TrainDTO trainDTO = await Mapper.Map<Task<Train>, Task<TrainDTO>>(unitOfWork.Trains.GetByIdAsynс(id));
            return trainDTO;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}

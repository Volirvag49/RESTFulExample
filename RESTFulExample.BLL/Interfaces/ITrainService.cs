using RESTFulExample.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface ITrainService : IDisposable
    {
        Task<IEnumerable<TrainDTO>> GetAllAsync();
        Task<IEnumerable<TrainDTO>> GetAvailableAsync();
        Task CreateAsync(TrainDTO trainDTO);
        Task UpdateAsync(TrainDTO trainDTO);
        Task DeleteAsync(string id);
        Task<TrainDTO> GetByIdAsync(string id);
    }
}

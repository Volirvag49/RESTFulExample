using RESTFulExample.BLL.DTO;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace RESTFulExample.BLL.Interfaces
{
    public interface ITrainService : IDisposable
    {
        Task<IEnumerable> GetAllAsync();
        Task CreateAsync(TrainDTO trainDTO);
        Task UpdateAsync(TrainDTO trainDTO);
        Task DeleteAsync(int? id);
        Task<TrainDTO> GetByIdAsync(int? id);
    }
}
